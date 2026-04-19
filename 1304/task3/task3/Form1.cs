using System;
using System.IO; 
using System.Windows.Forms;

namespace task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Текстові файли|*.txt|Всі файли|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        textBox1.Text = File.ReadAllText(ofd.FileName);

                        this.Tag = ofd.FileName;
                        this.Text = "Редагується: " + Path.GetFileName(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка при читанні файлу: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (this.Tag != null)
            {
                string filePath = this.Tag.ToString();
                try
                {
                    File.WriteAllText(filePath, textBox1.Text);
                    MessageBox.Show("Файл успішно оновлено!", "Збережено");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при збереженні: " + ex.Message);
                }
            }
            else
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Текстові файли|*.txt";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, textBox1.Text);
                        this.Tag = sfd.FileName; 
                        MessageBox.Show("Файл створено та збережено!", "Успіх");
                    }
                }
            }
        }
    }
}