using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntropyModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region members

        Random _rnd = new Random(16);
        Bitmap _bitmap = null;
        readonly Timer _timer = new Timer { Enabled = false };

        // коллекция стенок
        readonly List<Wall> _walls = new List<Wall>();

        // коллекция шаров
        readonly List<Ball> _balls = new List<Ball>();

        // константы
        const int cDs = 16;
        const double cMaxSpeed = 2.5;
        const int cMinRadius = 9;
        const int cMinWeight = 1;
        const int cTimeInterval = 25;

        #endregion

        #region private methods

        void CreateModel()
        {
            AddWalls();

            RectangleF left = new RectangleF(2 * cDs, 2 * cDs, pictureBox1.Width / 2 - 4 * cDs, pictureBox1.Height - 4 * cDs);
            AddBalls(16, 9, 1, Color.Red, "Red", 1, left);

            RectangleF right = new RectangleF(pictureBox1.Width / 2 + 2 * cDs, 2 * cDs, pictureBox1.Width / 2 - 4 * cDs, pictureBox1.Height - 4 * cDs);
            AddBalls(16, 9, 1, Color.DarkBlue, "Blue", 2.5, right);
        }

        void AddWalls()
        {
            _walls.Add(new Wall(cDs, cDs, cDs, pictureBox1.Height - cDs));
            _walls.Add(new Wall(cDs, pictureBox1.Height - cDs, pictureBox1.Width - cDs, pictureBox1.Height - cDs));
            _walls.Add(new Wall(pictureBox1.Width - cDs, pictureBox1.Height - cDs, pictureBox1.Width - cDs, cDs));
            _walls.Add(new Wall(pictureBox1.Width - cDs, cDs, cDs, cDs));

            double R = 32;

            _walls.Add(new Wall(pictureBox1.Width / 2, cDs, pictureBox1.Width / 2, (pictureBox1.Height - R) / 2));
            _walls.Add(new Wall(pictureBox1.Width / 2, pictureBox1.Height - cDs, pictureBox1.Width / 2, (pictureBox1.Height + R) / 2));
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

                    Ball ball = new Ball
                    {
                        Radius = raduis,
                        Weight = weight,
                        Color = color,
                        Label = label,
                        Velocity = maxspeed * velocity.Ort,
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

                if (D < R + ball.Radius)
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
        }

        #endregion

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!_timer.Enabled)
            {
                _timer.Interval = cTimeInterval;
                _timer.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
            }
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
