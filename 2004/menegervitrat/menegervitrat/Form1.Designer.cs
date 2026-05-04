namespace ExpenseManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Button btnExport;

        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.ComboBox comboBoxFilter;

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateTo;

        private System.Windows.Forms.NumericUpDown numericUpDownAmount;

        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelMax;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnStats = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();

            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();

            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();

            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();

            this.labelTotal = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();

            this.SuspendLayout();

            // DataGridView
            this.dataGridView1.Location = new System.Drawing.Point(12, 150);
            this.dataGridView1.Size = new System.Drawing.Size(760, 250);
            this.dataGridView1.Name = "dataGridView1";

            // Button Add
            this.btnAdd.Text = "Додати";
            this.btnAdd.Location = new System.Drawing.Point(12, 110);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // Button Filter
            this.btnFilter.Text = "Фільтр";
            this.btnFilter.Location = new System.Drawing.Point(100, 110);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            // Button Stats
            this.btnStats.Text = "Статистика";
            this.btnStats.Location = new System.Drawing.Point(180, 110);
            this.btnStats.Name = "btnStats";
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);

            // Button Export
            this.btnExport.Text = "CSV";
            this.btnExport.Location = new System.Drawing.Point(280, 110);
            this.btnExport.Name = "btnExport";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            // Inputs
            this.textBoxDescription.Location = new System.Drawing.Point(12, 12);
            this.textBoxDescription.Width = 200;
            this.textBoxDescription.Name = "textBoxDescription";

            this.comboBoxCategory.Location = new System.Drawing.Point(220, 12);
            this.comboBoxCategory.Items.AddRange(new string[] { "Їжа", "Транспорт", "Розваги" });
            this.comboBoxCategory.Name = "comboBoxCategory";

            this.dateTimePicker1.Location = new System.Drawing.Point(400, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";

            this.numericUpDownAmount.Location = new System.Drawing.Point(600, 12);
            this.numericUpDownAmount.Name = "numericUpDownAmount";

            // Filter controls
            this.comboBoxFilter.Location = new System.Drawing.Point(12, 60);
            this.comboBoxFilter.Items.AddRange(new string[] { "Їжа", "Транспорт", "Розваги" });
            this.comboBoxFilter.Name = "comboBoxFilter";

            this.dateFrom.Location = new System.Drawing.Point(200, 60);
            this.dateFrom.Name = "dateFrom";
            this.dateTo.Location = new System.Drawing.Point(400, 60);
            this.dateTo.Name = "dateTo";

            // Labels
            this.labelTotal.Location = new System.Drawing.Point(12, 420);
            this.labelTotal.Name = "labelTotal";
            this.labelMax.Location = new System.Drawing.Point(200, 420);
            this.labelMax.Name = "labelMax";

            // Form
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnStats);
            this.Controls.Add(this.btnExport);

            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.comboBoxFilter);

            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.dateTo);

            this.Controls.Add(this.numericUpDownAmount);

            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelMax);

            this.Load += new System.EventHandler(this.Form1_Load);

            this.Text = "Менеджер витрат";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// Dispose used resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}