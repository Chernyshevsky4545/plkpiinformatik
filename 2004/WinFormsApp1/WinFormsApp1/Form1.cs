using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<string> memes = new List<string>();
        private int currentMeme = 0;

        public Form1()
        {
            InitializeComponent();

            button1.Click += (s, e) => PrevMeme();
            button2.Click += (s, e) => NextMeme();

            button1.TabStop = false;
            button2.TabStop = false;

            LoadMemes();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Right)
            {
                NextMeme();
                return true; 
            }
            if (keyData == Keys.Left)
            {
                PrevMeme();
                return true; 
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void LoadMemes()
        {
            string path = Path.Combine(Application.StartupPath, "memes");

            if (Directory.Exists(path))
            {
                memes.AddRange(Directory.GetFiles(path, "*.jpg"));
                memes.AddRange(Directory.GetFiles(path, "*.png"));
                memes.AddRange(Directory.GetFiles(path, "*.jpeg"));

                if (memes.Count > 0) ShowMeme(0);
            }
            else
            {
                Directory.CreateDirectory(path);
                MessageBox.Show("Створено папку 'memes'. Закинь туди фото!");
            }
        }

        private void ShowMeme(int index)
        {
            if (pictureBox1 != null && memes.Count > 0)
            {
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();

                pictureBox1.Image = Image.FromFile(memes[index]);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                currentMeme = index;
            }
        }

        private void NextMeme()
        {
            if (memes.Count == 0) return;
            currentMeme = (currentMeme + 1) % memes.Count;
            ShowMeme(currentMeme);
        }

        private void PrevMeme()
        {
            if (memes.Count == 0) return;
            currentMeme--;
            if (currentMeme < 0) currentMeme = memes.Count - 1;
            ShowMeme(currentMeme);
        }
    }
}