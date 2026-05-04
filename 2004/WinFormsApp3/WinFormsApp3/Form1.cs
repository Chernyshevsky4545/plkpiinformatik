using Microsoft.VisualBasic.Devices;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        bool X = true;
        int steps = 0;
        public Form1()
        {
            InitializeComponent();
            KrestikiNoliki();
        }
        private void KrestikiNoliki()
        {
            button1.Click += click;
            button2.Click += click;
            button3.Click += click;
            button4.Click += click;
            button5.Click += click;
            button6.Click += click;
            button7.Click += click;
            button8.Click += click;
            button9.Click += click;

        }
        private void click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (X)
            {
                button.Text = "X";
                X = false;
            }
            else
            {
                button.Text = "0";
                X = true;
            }
            steps++;
            if (steps == 9)
            {
                MessageBox.Show("Ничья!");
                Application.Restart();
            }
            checkwinner();
        }
        private void checkwinner()
        {
            bool winner = false;


            if (button1.Text == button2.Text && button2.Text == button3.Text && button1.Text != "")
                {
                    MessageBox.Show($"Победитель: {button1.Text}");
                    Application.Restart();
                }
                if (button4.Text == button5.Text && button5.Text == button6.Text && button4.Text != "")
                {
                    MessageBox.Show($"Победитель: {button4.Text}");
                    Application.Restart();
                }
                if (button7.Text == button8.Text && button8.Text == button9.Text && button7.Text != "")
                {
                    MessageBox.Show($"Победитель: {button7.Text}");
                    Application.Restart();
                }
                if (button1.Text == button4.Text && button4.Text == button7.Text && button1.Text != "")
                {
                    MessageBox.Show($"Победитель: {button1.Text}");
                    Application.Restart();
                }
                if (button2.Text == button5.Text && button5.Text == button8.Text && button2.Text != "")
                {
                    MessageBox.Show($"Победитель: {button2.Text}");
                    Application.Restart();
                }
                if (button3.Text == button6.Text && button6.Text == button9.Text && button3.Text != "")
                {
                    MessageBox.Show($"Победитель: {button3.Text}");
                    Application.Restart();
                }
                if (button1.Text == button5.Text && button5.Text == button9.Text && button1.Text != "")
                {
                    MessageBox.Show($"Победитель: {button1.Text}");
                    Application.Restart();
                }
                if (button3.Text == button5.Text && button5.Text == button7.Text && button3.Text != "")
                {
                    MessageBox.Show($"Победитель: {button3.Text}");
                    Application.Restart();
                }
                if (winner)
                {
                    MessageBox.Show($"Победитель: {(X ? "0" : "X")}");
                    Application.Restart();
                }

                else if (steps == 9)
                {
                    MessageBox.Show("Ничья!");
                    Application.Restart();
                }
            {
                winner = true;
            }
        }



    }
}
