using System;
using System.Drawing;
using System.Windows.Forms;

namespace task2
{
    public partial class Form1 : Form
    {
        bool isXTurn = true;
        int stepCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // Цей метод ми підключимо до всіх кнопок вручну
        private void GameButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (isXTurn)
                btn.Text = "X";
            else
                btn.Text = "O";

            btn.Enabled = false;
            stepCount++;

            if (CheckWinner())
            {
                string finalWinner = isXTurn ? "X" : "O";
                MessageBox.Show("Переміг гравець: " + finalWinner);
                ResetGame();
            }
            else if (stepCount == 9)
            {
                MessageBox.Show("Нічия!");
                ResetGame();
            }
            else
            {
                isXTurn = !isXTurn;
            }
        }

        private bool CheckWinner()
        {
            // Перевірка ліній (горизонталі, вертикалі, діагоналі)
            if (CheckLine(button1, button2, button3)) return true;
            if (CheckLine(button4, button5, button6)) return true;
            if (CheckLine(button7, button8, button9)) return true;
            if (CheckLine(button1, button4, button7)) return true;
            if (CheckLine(button2, button5, button8)) return true;
            if (CheckLine(button3, button6, button9)) return true;
            if (CheckLine(button1, button5, button9)) return true;
            if (CheckLine(button3, button5, button7)) return true;
            return false;
        }

        private bool CheckLine(Button b1, Button b2, Button b3)
        {
            return b1.Text != "" && b1.Text == b2.Text && b2.Text == b3.Text;
        }

        private void ResetGame()
        {
            isXTurn = true;
            stepCount = 0;
            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    c.Text = "";
                    c.Enabled = true;
                }
            }
        }
    }
}