using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        // 1. Створюємо генератор випадкових чисел
        // Він потрібен, щоб обирати нові координати для кнопки
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            // 2. Підписуємо кнопку на подію "MouseEnter"
            // MouseEnter спрацьовує, як тільки курсор миші торкається межі кнопки
            button1.MouseEnter += Button1_MouseEnter;
        }

        // 3. Цей метод спрацьовує кожного разу, коли мишка наближається до кнопки
        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            // Обчислюємо максимально можливу позицію по горизонталі (X)
            // Ширина вікна мінус ширина кнопки, щоб вона не вилізла за край
            int maxX = this.ClientSize.Width - button1.Width;

            // Обчислюємо максимально можливу позицію по вертикалі (Y)
            // Висота вікна мінус висота кнопки
            int maxY = this.ClientSize.Height - button1.Height;

            // 4. Генеруємо нові випадкові координати в межах вікна
            int newX = random.Next(0, maxX);
            int newY = random.Next(0, maxY);

            // 5. Переміщуємо кнопку на нове місце
            button1.Location = new System.Drawing.Point(newX, newY);
        }

        // Цей метод можна залишити порожнім, бо натиснути кнопку буде майже неможливо
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ого! Ти все ж таки спіймав її!");
        }
    }
}