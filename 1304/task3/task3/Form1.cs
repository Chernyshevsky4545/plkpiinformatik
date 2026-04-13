using System;
using System.IO; // Важливо для роботи з файлами (File) та шляхами (Path)
using System.Windows.Forms;

namespace task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // КНОПКА ВІДКРИТИ (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Налаштовуємо фільтр, щоб бачити лише текстові файли
                ofd.Filter = "Текстові файли|*.txt|Всі файли|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Зчитуємо весь текст із вибраного файлу і вставляємо в textBox1
                        textBox1.Text = File.ReadAllText(ofd.FileName);

                        // Запам'ятовуємо шлях до файлу в Tag, щоб потім зберегти саме в нього
                        this.Tag = ofd.FileName;

                        // Міняємо заголовок вікна, щоб бачити назву файлу
                        this.Text = "Редагується: " + Path.GetFileName(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка при читанні файлу: " + ex.Message);
                    }
                }
            }
        }

        // КНОПКА ЗБЕРЕГТИ/ОНОВИТИ (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи ми вже відкривали файл (чи є шлях у Tag)
            if (this.Tag != null)
            {
                string filePath = this.Tag.ToString();
                try
                {
                    // Оновлюємо (перезаписуємо) існуючий файл
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
                // Якщо ми нічого не відкривали, а просто написали текст — пропонуємо створити новий файл
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Текстові файли|*.txt";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, textBox1.Text);
                        this.Tag = sfd.FileName; // Тепер програма знає цей шлях
                        MessageBox.Show("Файл створено та збережено!", "Успіх");
                    }
                }
            }
        }
    }
}