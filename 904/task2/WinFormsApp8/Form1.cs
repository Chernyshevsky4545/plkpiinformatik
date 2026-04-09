namespace WinFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int currentYear = DateTime.Now.Year;

            if (int.TryParse(textBox1.Text, out int birthYear))
            {
                if (birthYear > currentYear || birthYear < 1900)
                {
                    MessageBox.Show("Будь ласка, введіть коректний рік (від 1900 до " + currentYear + ")",
                                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int age = currentYear - birthYear;
                    label1.Text = "Ваш вік: " + age.ToString();
                }
            }
            else
            {
                MessageBox.Show("Введіть рік народження цифрами!", "Помилка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
