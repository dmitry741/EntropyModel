namespace EntropyModel
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLeftRed = new System.Windows.Forms.Label();
            this.lblLeftBlue = new System.Windows.Forms.Label();
            this.lblRightBlue = new System.Windows.Forms.Label();
            this.lblRightRed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLeftAverageSpeed = new System.Windows.Forms.Label();
            this.lblRightAverageSpeed = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAverageSpeedRed = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAverageSpeedBlue = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(848, 424);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 508);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(81, 26);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(186, 508);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(81, 26);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Стоп";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(779, 508);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 26);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Выход";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Количество красных шаров:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 458);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Количество синих шаров:";
            // 
            // lblLeftRed
            // 
            this.lblLeftRed.AutoSize = true;
            this.lblLeftRed.Location = new System.Drawing.Point(170, 439);
            this.lblLeftRed.Name = "lblLeftRed";
            this.lblLeftRed.Size = new System.Drawing.Size(13, 13);
            this.lblLeftRed.TabIndex = 6;
            this.lblLeftRed.Text = "0";
            // 
            // lblLeftBlue
            // 
            this.lblLeftBlue.AutoSize = true;
            this.lblLeftBlue.Location = new System.Drawing.Point(170, 458);
            this.lblLeftBlue.Name = "lblLeftBlue";
            this.lblLeftBlue.Size = new System.Drawing.Size(13, 13);
            this.lblLeftBlue.TabIndex = 7;
            this.lblLeftBlue.Text = "0";
            // 
            // lblRightBlue
            // 
            this.lblRightBlue.AutoSize = true;
            this.lblRightBlue.Location = new System.Drawing.Point(835, 458);
            this.lblRightBlue.Name = "lblRightBlue";
            this.lblRightBlue.Size = new System.Drawing.Size(13, 13);
            this.lblRightBlue.TabIndex = 11;
            this.lblRightBlue.Text = "0";
            // 
            // lblRightRed
            // 
            this.lblRightRed.AutoSize = true;
            this.lblRightRed.Location = new System.Drawing.Point(835, 439);
            this.lblRightRed.Name = "lblRightRed";
            this.lblRightRed.Size = new System.Drawing.Size(13, 13);
            this.lblRightRed.TabIndex = 10;
            this.lblRightRed.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(685, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Количество синих шаров:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(685, 439);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Количество красных шаров:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 477);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Средняя скорость шаров:";
            // 
            // lblLeftAverageSpeed
            // 
            this.lblLeftAverageSpeed.AutoSize = true;
            this.lblLeftAverageSpeed.Location = new System.Drawing.Point(170, 477);
            this.lblLeftAverageSpeed.Name = "lblLeftAverageSpeed";
            this.lblLeftAverageSpeed.Size = new System.Drawing.Size(13, 13);
            this.lblLeftAverageSpeed.TabIndex = 13;
            this.lblLeftAverageSpeed.Text = "0";
            // 
            // lblRightAverageSpeed
            // 
            this.lblRightAverageSpeed.AutoSize = true;
            this.lblRightAverageSpeed.Location = new System.Drawing.Point(835, 477);
            this.lblRightAverageSpeed.Name = "lblRightAverageSpeed";
            this.lblRightAverageSpeed.Size = new System.Drawing.Size(13, 13);
            this.lblRightAverageSpeed.TabIndex = 15;
            this.lblRightAverageSpeed.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(685, 477);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Средняя скорость шаров:";
            // 
            // lblAverageSpeedRed
            // 
            this.lblAverageSpeedRed.AutoSize = true;
            this.lblAverageSpeedRed.Location = new System.Drawing.Point(524, 439);
            this.lblAverageSpeedRed.Name = "lblAverageSpeedRed";
            this.lblAverageSpeedRed.Size = new System.Drawing.Size(13, 13);
            this.lblAverageSpeedRed.TabIndex = 17;
            this.lblAverageSpeedRed.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(334, 439);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Средняя скорость красных шаров:";
            // 
            // lblAverageSpeedBlue
            // 
            this.lblAverageSpeedBlue.AutoSize = true;
            this.lblAverageSpeedBlue.Location = new System.Drawing.Point(524, 457);
            this.lblAverageSpeedBlue.Name = "lblAverageSpeedBlue";
            this.lblAverageSpeedBlue.Size = new System.Drawing.Size(13, 13);
            this.lblAverageSpeedBlue.TabIndex = 19;
            this.lblAverageSpeedBlue.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(334, 457);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Средняя скорость синих шаров:";
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(99, 508);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(81, 26);
            this.btnPause.TabIndex = 20;
            this.btnPause.Text = "Пауза";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.Location = new System.Drawing.Point(407, 508);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(56, 16);
            this.lblTime.TabIndex = 21;
            this.lblTime.Text = "0.00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 542);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.lblAverageSpeedBlue);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblAverageSpeedRed);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblRightAverageSpeed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblLeftAverageSpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRightBlue);
            this.Controls.Add(this.lblRightRed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblLeftBlue);
            this.Controls.Add(this.lblLeftRed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Энтропия";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLeftRed;
        private System.Windows.Forms.Label lblLeftBlue;
        private System.Windows.Forms.Label lblRightBlue;
        private System.Windows.Forms.Label lblRightRed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLeftAverageSpeed;
        private System.Windows.Forms.Label lblRightAverageSpeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAverageSpeedRed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAverageSpeedBlue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblTime;
    }
}

