using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace ExpenseManager
{
    public partial class Form1 : Form
    {
        private List<Expense> expenses = new List<Expense>();
        private string filePath = "expenses.json";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            expenses = LoadData();
            RefreshGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var expense = new Expense
            {
                Date = dateTimePicker1.Value,
                Category = comboBoxCategory.Text,
                Description = textBoxDescription.Text,
                Amount = numericUpDownAmount.Value
            };

            expenses.Add(expense);
            SaveData(expenses);
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = expenses;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var filtered = expenses.Where(x =>
                (string.IsNullOrEmpty(comboBoxFilter.Text) || x.Category == comboBoxFilter.Text) &&
                x.Date >= dateFrom.Value &&
                x.Date <= dateTo.Value
            ).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtered;
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            if (expenses.Count == 0) return;

            decimal total = expenses.Sum(x => x.Amount);
            decimal max = expenses.Max(x => x.Amount);

            labelTotal.Text = $"Сума: {total}";
            labelMax.Text = $"Макс: {max}";
        }

        private void SaveData(List<Expense> list)
        {
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(filePath, json);
        }

        private List<Expense> LoadData()
        {
            if (!File.Exists(filePath))
                return new List<Expense>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Expense>>(json) ?? new List<Expense>();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var lines = new List<string> { "Date,Category,Description,Amount" };

            lines.AddRange(expenses.Select(x =>
                $"{x.Date},{x.Category},{x.Description},{x.Amount}"));

            File.WriteAllLines("expenses.csv", lines);

            MessageBox.Show("Експорт завершено!");
        }
    }

    public class Expense
    {
        public DateTime Date { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}