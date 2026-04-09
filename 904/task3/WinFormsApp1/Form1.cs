namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            int atIndex = email.IndexOf('@');
            int dotIndex = email.LastIndexOf('.');

            if (atIndex > 0 && dotIndex > atIndex)
            {
                label2.Text = "Адреса підходить";
            }
            else
            {
                label2.Text = "Адреса не підходить, переконайтесь що є @ та крапка в кінці";
            }
        }
    }
}
