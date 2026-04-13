namespace task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            button1.Location = new Point(random.Next(0, this.ClientSize.Width - button1.Width), random.Next(0, this.ClientSize.Height - button1.Height));
            
        }
    }
}
