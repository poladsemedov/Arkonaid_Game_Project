using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arkonaid_Game_Project
{
    public partial class Form1 : Form
    {
        int ballX;
        int ballY;
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            ResetBall();
            timer1.Interval = 20;
            timer1.Start();
        }
        private void ResetBall()
        {
            pictureBox1.Left = 150;
            pictureBox1.Top = 100;

            ballX = r.Next(6, 11);
            ballY = r.Next(6, 11);

            if (r.Next(0, 2) == 0) ballX = -ballX;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Left += ballX;
            pictureBox1.Top += ballY;

            if (pictureBox1.Left < 0)
            {
                ballX = -ballX;
            }

            if (pictureBox1.Left + pictureBox1.Width > this.ClientSize.Width - 20)
            {
                ballX = -ballX;
            }

            if (pictureBox1.Top < 0)
            {
                ballY = -ballY;
            }

            if (pictureBox1.Bounds.IntersectsWith(panel1.Bounds))
            {
                ballY = -ballY;
                pictureBox1.Top = panel1.Top - pictureBox1.Height;
            }

            if (pictureBox1.Top + pictureBox1.Height > this.ClientSize.Height)
            {
                timer1.Stop();
                MessageBox.Show("Oyun bitdi! Top yerə düşdü.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetBall();
                timer1.Start();
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                panel1.Left -= 20;
                if (panel1.Left < 0) panel1.Left = 0;
            }
            if (e.KeyCode == Keys.Right)
            {
                panel1.Left += 20;
                if (panel1.Right > ClientSize.Width) panel1.Left = ClientSize.Width - panel1.Width;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Left -= 130;
            if (panel1.Left < 0)
            {
                panel1.Left = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Left += 130;
            if (panel1.Right > ClientSize.Width)
            {
                panel1.Left = ClientSize.Width - panel1.Width;
            }
        }
    }

}
