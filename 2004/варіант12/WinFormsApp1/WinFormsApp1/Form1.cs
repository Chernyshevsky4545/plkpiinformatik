using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string targetText = "Натисніть 'Старт', щоб почати.";
        private int elapsedTime = 0;

        // Список речень для тренування
        private List<string> sentences = new List<string>
        {
            "Програмування це цікавий процес створення нових інструментів.",
            "Швидка коричнева лисиця перестрибує через ледачого собаку.",
            "Створення інтерфейсів користувача вимагає уваги до деталей.",
            "Git допомагає розробникам відстежувати зміни у коді.",
            "C# є чудовою мовою для розробки desktop застосунків.",
            "фізика, геометрія, школа",
            "яблуко на голові довго падає",
            "футбол, Роналду, чемпіонат, Англія",
            "Інформатика дуже класний предмет для вивчення",
            "ХО-ХО-ХО СІКС СЕВЕН ПОСХАЛКО00000"
        };

        public Form1()
        {
            InitializeComponent();

            // Початкові налаштування
            textBox1.Enabled = false;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            targetText = sentences[rand.Next(sentences.Count)];

            label1.Text = targetText;
            textBox1.Clear();
            textBox1.Enabled = true;
            button2.Enabled = true;

            elapsedTime = 0;
            label2.Text = "Час: 0 с | Помилок: 0 | Швидкість: 0 симв/хв";
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            string typedText = textBox1.Text;

            // Очищаємо текст від пробілів, ком та крапок для точного порівняння літер
            string cleanTarget = targetText.Replace(" ", "").Replace(",", "").Replace(".", "");
            string cleanTyped = typedText.Replace(" ", "").Replace(",", "").Replace(".", "");

            // Використовуємо відстань Левенштейна для точного визначення кількості помилок/пропусків
            int errors = ComputeLevenshteinDistance(cleanTyped, cleanTarget);

            double minutes = (double)elapsedTime / 60;
            int speed = minutes > 0 ? (int)(typedText.Length / minutes) : 0;

            label2.Text = $"Час: {elapsedTime} с | Помилок: {errors} | Швидкість: {speed} симв/хв";

            // Додаємо результат у список (ListBox)
            listBox1.Items.Add($"{DateTime.Now.ToShortTimeString()} | Швидкість: {speed} симв/хв | Помилок: {errors}");

            // Вимикаємо поле та кнопку після перевірки
            textBox1.Enabled = false;
            button2.Enabled = false;
        }

        // Метод для обчислення відстані Левенштейна між двома рядками
        private int ComputeLevenshteinDistance(string source, string target)
        {
            if (string.IsNullOrEmpty(source)) return target?.Length ?? 0;
            if (string.IsNullOrEmpty(target)) return source?.Length ?? 0;

            source = source.ToLower();
            target = target.ToLower();

            int[,] dp = new int[source.Length + 1, target.Length + 1];

            for (int i = 0; i <= source.Length; i++) dp[i, 0] = i;
            for (int j = 0; j <= target.Length; j++) dp[0, j] = j;

            for (int i = 1; i <= source.Length; i++)
            {
                for (int j = 1; j <= target.Length; j++)
                {
                    int cost = (source[i - 1] == target[j - 1]) ? 0 : 1;

                    dp[i, j] = Math.Min(
                        Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
                        dp[i - 1, j - 1] + cost
                    );
                }
            }

            return dp[source.Length, target.Length];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedTime++;
            label2.Text = $"Час: {elapsedTime} с";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Створюємо діалогове вікно вибору файлу
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Зберегти результати";
            saveFileDialog.FileName = "leaderboard.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, true))
                    {
                        foreach (var item in listBox1.Items)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }
                    MessageBox.Show("Результати успішно збережено у файл " + saveFileDialog.FileName + "!", "Збережено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка під час збереження: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}