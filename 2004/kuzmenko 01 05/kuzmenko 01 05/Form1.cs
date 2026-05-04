namespace kuzmenko_01_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        

class TicTacToe : Form
        {
            Button[,] cells = new Button[3, 3];
            bool xTurn = true;
            int moves = 0;

            TicTacToe()
            {
                Text = "Tic-Tac-Toe";
                Size = new Size(320, 380);
                StartPosition = FormStartPosition.CenterScreen;
                FormBorderStyle = FormBorderStyle.FixedSingle;

                for (int r = 0; r < 3; r++)
                    for (int c = 0; c < 3; c++)
                    {
                        var btn = new Button();
                        btn.Size = new Size(90, 90);
                        btn.Location = new Point(10 + c * 95, 10 + r * 95);
                        btn.Font = new Font("Arial", 32, FontStyle.Bold);
                        btn.Tag = new int[] { r, c };
                        btn.Click += CellClick;
                        cells[r, c] = btn;
                        Controls.Add(btn);
                    }

                var reset = new Button();
                reset.Text = "Restart";
                reset.Size = new Size(280, 40);
                reset.Location = new Point(10, 300);
                reset.Click += (s, e) => Reset();
                Controls.Add(reset);
            }

            void CellClick(object sender, EventArgs e)
            {
                var btn = (Button)sender;
                if (btn.Text != "") return;

                btn.Text = xTurn ? "X" : "O";
                btn.ForeColor = xTurn ? Color.Blue : Color.Red;
                moves++;

                if (CheckWin())
                {
                    MessageBox.Show($"{(xTurn ? "X" : "O")} wins!");
                    Reset();
                    return;
                }
                if (moves == 9)
                {
                    MessageBox.Show("Draw!");
                    Reset();
                    return;
                }
                xTurn = !xTurn;
            }

            bool CheckWin()
            {
                string p = xTurn ? "X" : "O";
                for (int i = 0; i < 3; i++)
                {
                    if (cells[i, 0].Text == p && cells[i, 1].Text == p && cells[i, 2].Text == p) return true;
                    if (cells[0, i].Text == p && cells[1, i].Text == p && cells[2, i].Text == p) return true;
                }
                if (cells[0, 0].Text == p && cells[1, 1].Text == p && cells[2, 2].Text == p) return true;
                if (cells[0, 2].Text == p && cells[1, 1].Text == p && cells[2, 0].Text == p) return true;
                return false;
            }

            void Reset()
            {
                foreach (var btn in cells) { btn.Text = ""; btn.ForeColor = SystemColors.ControlText; }
                xTurn = true;
                moves = 0;
            }

            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.Run(new TicTacToe());
            }
        }

        }
    }
}
