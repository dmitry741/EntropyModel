using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/* Урок "Механика столкновений. Игры и хаос."
 * Все уроки на http://digitalmodels.ru
 * 
 */

namespace EntropyModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region members

        readonly Random _rnd = new Random(16);
        Bitmap _bitmap = null;
        readonly Timer _timer = new Timer { Enabled = false };
        ulong _tickCount = 0;
        DateTime _startTime;
        TimeSpan _timeSpan = new TimeSpan(0);

        // коллекция стенок
        readonly List<Wall> _walls = new List<Wall>();

        // коллекция шаров
        readonly List<Ball> _balls = new List<Ball>();

        // константы
        const int cMargin = 16;
        const int cTimeInterval = 25;

        #endregion

        #region private methods

        void SetInfo()
        {
            int letfRedCount = _balls.Count(b => 0 < b.X && b.X < pictureBox1.Width / 2 && b.Label == "Red");
            int leftBlueCount = _balls.Count(b => 0 < b.X && b.X < pictureBox1.Width / 2 && b.Label == "Blue");
            int rightRedCount = _balls.Count(b => pictureBox1.Width / 2 < b.X && b.X < pictureBox1.Width && b.Label == "Red");
            int rightBlueCount = _balls.Count(b => pictureBox1.Width / 2 < b.X && b.X < pictureBox1.Width && b.Label == "Blue");

            double leftAverageSpeed = _balls.Where(b => 0 < b.X && b.X < pictureBox1.Width / 2).Average(b => b.Velocity.Length);
            double rightAverageSpeed = _balls.Where(b => pictureBox1.Width / 2 < b.X && b.X < pictureBox1.Width).Average(b => b.Velocity.Length);

            double redAverageSpeed = _balls.Where(b => b.Label == "Red").Average(b => b.Velocity.Length);
            double blueAverageSpeed = _balls.Where(b => b.Label == "Blue").Average(b => b.Velocity.Length);

            lblLeftRed.Text = letfRedCount.ToString();
            lblLeftBlue.Text = leftBlueCount.ToString();
            lblRightRed.Text = rightRedCount.ToString();
            lblRightBlue.Text = rightBlueCount.ToString();

            lblLeftAverageSpeed.Text = Math.Round(leftAverageSpeed, 2).ToString();
            lblRightAverageSpeed.Text = Math.Round(rightAverageSpeed, 2).ToString();
            lblAverageSpeedRed.Text = Math.Round(redAverageSpeed, 2).ToString();
            lblAverageSpeedBlue.Text = Math.Round(blueAverageSpeed, 2).ToString();
        }

        void CreateModel()
        {
            _walls.Clear();
            _balls.Clear();

            AddWalls();

            const int cBallCount = 16;

            RectangleF left = new RectangleF(2 * cMargin, 2 * cMargin, pictureBox1.Width / 2 - 4 * cMargin, pictureBox1.Height - 4 * cMargin);
            AddBalls(cBallCount, 9, 1, Color.Red, "Red", 1.6, left);

            RectangleF right = new RectangleF(pictureBox1.Width / 2 + 2 * cMargin, 2 * cMargin, pictureBox1.Width / 2 - 4 * cMargin, pictureBox1.Height - 4 * cMargin);
            AddBalls(cBallCount, 9, 1, Color.DarkBlue, "Blue", 3.2, right);
        }

        void AddWalls()
        {
            _walls.Add(new Wall(cMargin, cMargin, cMargin, pictureBox1.Height - cMargin));
            _walls.Add(new Wall(cMargin, pictureBox1.Height - cMargin, pictureBox1.Width - cMargin, pictureBox1.Height - cMargin));
            _walls.Add(new Wall(pictureBox1.Width - cMargin, pictureBox1.Height - cMargin, pictureBox1.Width - cMargin, cMargin));
            _walls.Add(new Wall(pictureBox1.Width - cMargin, cMargin, cMargin, cMargin));

            double R = 40;

            _walls.Add(new Wall(pictureBox1.Width / 2, cMargin, pictureBox1.Width / 2, (pictureBox1.Height - R) / 2));
            _walls.Add(new Wall(pictureBox1.Width / 2, pictureBox1.Height - cMargin, pictureBox1.Width / 2, (pictureBox1.Height + R) / 2));
        }

        void AddBalls(int count, double raduis, double weight, Color color, string label, double maxspeed, RectangleF r)
        {
            int n = 0;

            while (n < count)
            {
                double x = _rnd.NextDouble() * r.Width + r.X;
                double y = _rnd.NextDouble() * r.Height + r.Y;

                if (CheckForPlace(Convert.ToInt32(x), Convert.ToInt32(y), raduis))
                {
                    Vector velocity = new Vector
                    {
                        X = _rnd.NextDouble(),
                        Y = _rnd.NextDouble()
                    };

                    if (_rnd.NextDouble() < 0.5)
                        velocity.X = -velocity.X;

                    if (_rnd.NextDouble() < 0.5)
                        velocity.Y = -velocity.Y;

                    Ball ball = new Ball
                    {
                        Radius = raduis,
                        Weight = weight,
                        Color = color,
                        Label = label,
                        Velocity = maxspeed * velocity,
                        X = x,
                        Y = y
                    };

                    _balls.Add(ball);
                    n++;
                }
            }
        }

        void Render()
        {
            if (_bitmap == null)
                return;

            Graphics g = Graphics.FromImage(_bitmap);
            g.Clear(Color.White);

            Pen penWall = new Pen(Color.DarkGray, 2.0f);

            // отрисовка стен
            foreach (Wall wall in _walls)
            {
                g.DrawLine(penWall, (float)wall.X1, (float)wall.Y1, (float)wall.X2, (float)wall.Y2);
            }

            // отрисова шаров
            foreach (Ball ball in _balls)
            {
                double R = ball.Radius;
                SolidBrush bubleBrush = new SolidBrush(ball.Color);
                Pen pen = new Pen(ball.Color);
                Rectangle rectangle = new Rectangle((int)(ball.X - R), (int)(ball.Y - R), (int)(2 * R), (int)(2 * R));
                g.FillEllipse(bubleBrush, rectangle);
                g.DrawEllipse(pen, rectangle);
            }

            pictureBox1.Image = _bitmap;
        }

        bool CheckForPlace(int X, int Y, double R)
        {
            bool result = true;

            foreach (Ball ball in _balls)
            {
                double D = Math.Sqrt((X - ball.X) * (X - ball.X) + (Y - ball.Y) * (Y - ball.Y));

                if (D < R + ball.Radius + 1)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        void Tick()
        {
            foreach (Ball ball in _balls)
            {
                // сдвигаемся согласно траектории
                ball.Go();

                foreach (Wall wall in _walls)
                {
                    // взаимодействие со стенками
                    MechanicsSystemSolver.Solve(ball, wall);
                }
            }

            foreach (Ball ball in _balls)
            {
                foreach (Wall wall1 in _walls)
                {
                    // взаимодействие с  углами
                    MechanicsSystemSolver.Solve(ball, wall1.X1, wall1.Y1);
                    MechanicsSystemSolver.Solve(ball, wall1.X2, wall1.Y2);
                }
            }

            for (int i = 0; i < _balls.Count; i++)
            {
                for (int j = i + 1; j < _balls.Count; j++)
                {
                    // взаимодействие шаров между собой
                    MechanicsSystemSolver.Solve(_balls[i], _balls[j]);
                }
            }

            if (_tickCount % (1000 / cTimeInterval) == 0) // раз в секунду
            {
                SetInfo();
            }

            if (_tickCount % (200 / cTimeInterval) == 0) // 5 раз в секунду
            {
                DateTime curDateTime = DateTime.Now;
                _timeSpan = curDateTime - _startTime;
                lblTime.Text = string.Format("{0}.{1}:{2}", _timeSpan.Hours, _timeSpan.Minutes.ToString("00"), _timeSpan.Seconds.ToString("00"));
            }

            _tickCount++;
        }

        #endregion

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!_timer.Enabled)
            {
                _startTime = DateTime.Now - _timeSpan;
                _timer.Interval = cTimeInterval;
                _timer.Start();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
            }

            CreateModel();
            SetInfo();
            _timeSpan = new TimeSpan(0);
            lblTime.Text = "0.00:00";
            Render();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            _timer.Tick += Timer_Tick;

            CreateModel();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Tick();
            Render();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }
    }
}
