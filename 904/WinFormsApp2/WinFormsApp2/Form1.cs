namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello" + textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
  int b = Convert.ToInt32(textBox3.Text);
            int a = Convert.ToInt32(textBox2.Text);


            MessageBox.Show((a + b).ToString());
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
