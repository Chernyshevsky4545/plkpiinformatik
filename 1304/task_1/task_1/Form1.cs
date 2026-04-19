using System;
using System.Drawing;
using System.Windows.Forms;

namespace task_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.MouseEnter += Button1_MouseEnter;
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            Random random = new Random();

            int newX = random.Next(0, this.ClientSize.Width - button1.Width);
            int newY = random.Next(0, this.ClientSize.Height - button1.Height);


            button1.Location = new Point(newX, newY);
        }
    }
}