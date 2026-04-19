using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace task
{
    public partial class Form1 : Form
    {
        bool xTurn = true;
        Button[] ticTacButtons;
        string currentFilePath = "";

        public Form1()
        {
            InitializeComponent();

            button1.MouseEnter += Button1_MouseEnter;

            ticTacButtons = new Button[] {
                button2, button3, button4,
                button7, button6, button5,
                button10, button9, button8
            };

            foreach (var btn in ticTacButtons)
            {
                btn.Click += TicTac_Click;
                btn.Text = "";
                btn.Font = new Font("Arial", 14, FontStyle.Regular);
            }

            button11.Click += BtnOpen_Click;
            button12.Click += BtnSave_Click;
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            Random r = new Random();
            int maxX = this.ClientSize.Width - button1.Width;
            int maxY = this.ClientSize.Height - button1.Height;
            button1.Location = new Point(r.Next(0, maxX), r.Next(0, maxY));
        }

        private void TicTac_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text != "") return;


            btn.Text = xTurn ? "X" : "O";
            btn.ForeColor = SystemColors.ControlText; 
            xTurn = !xTurn;
            CheckWinner();
        }

        private void CheckWinner()
        {
            int[][] winConditions = new int[][]
            {
                new int[] {0, 1, 2}, new int[] {3, 4, 5}, new int[] {6, 7, 8},
                new int[] {0, 3, 6}, new int[] {1, 4, 7}, new int[] {2, 5, 8},
                new int[] {0, 4, 8}, new int[] {2, 4, 6}
            };

            foreach (var condition in winConditions)
            {
                if (ticTacButtons[condition[0]].Text != "" &&
                    ticTacButtons[condition[0]].Text == ticTacButtons[condition[1]].Text &&
                    ticTacButtons[condition[1]].Text == ticTacButtons[condition[2]].Text)
                {
                    MessageBox.Show("Переміг " + ticTacButtons[condition[0]].Text + "!");
                    ResetGame();
                    return;
                }
            }

            bool isDraw = true;
            foreach (var btn in ticTacButtons) if (btn.Text == "") isDraw = false;
            if (isDraw) { MessageBox.Show("Нічия!"); ResetGame(); }
        }

        private void ResetGame()
        {
            foreach (var btn in ticTacButtons) btn.Text = "";
            xTurn = true;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Text Files|*.txt" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = ofd.FileName;
                richTextBox1.Text = File.ReadAllText(currentFilePath);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveFileDialog sfd = new SaveFileDialog { Filter = "Text Files|*.txt" };
                if (sfd.ShowDialog() == DialogResult.OK) currentFilePath = sfd.FileName;
                else return;
            }
            File.WriteAllText(currentFilePath, richTextBox1.Text);
            MessageBox.Show("Збережено!");
        }
    }
}