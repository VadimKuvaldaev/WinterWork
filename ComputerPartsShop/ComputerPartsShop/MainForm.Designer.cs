namespace ComputerPartsShop
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.inventoryPage = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.AddProductButton = new System.Windows.Forms.Button();
            this.FilterCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.SearchNameTextBox = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblSearchName = new System.Windows.Forms.Label();
            this.ProductsDataGridView = new System.Windows.Forms.DataGridView();
            this.salesPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CatalogGroupBox = new System.Windows.Forms.GroupBox();
            this.AddToCartButton = new System.Windows.Forms.Button();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.QuantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CatalogDataGridView = new System.Windows.Forms.DataGridView();
            this.CartGroupBox = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.TotalSumLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblTotalSum = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.reportsPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GenerateReportButton = new System.Windows.Forms.Button();
            this.EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label = new System.Windows.Forms.Label();
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DateTimePickerLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ReportByDayLanel = new System.Windows.Forms.Label();
            this.ReportByDayCartesian = new LiveCharts.WinForms.CartesianChart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ReportByEmpLabel = new System.Windows.Forms.Label();
            this.ReportByEmpPic = new LiveCharts.WinForms.PieChart();
            this.MainTabControl.SuspendLayout();
            this.inventoryPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).BeginInit();
            this.salesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.CatalogGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CatalogDataGridView)).BeginInit();
            this.CartGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.reportsPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.inventoryPage);
            this.MainTabControl.Controls.Add(this.salesPage);
            this.MainTabControl.Controls.Add(this.reportsPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1223, 612);
            this.MainTabControl.TabIndex = 0;
            // 
            // inventoryPage
            // 
            this.inventoryPage.Controls.Add(this.button1);
            this.inventoryPage.Controls.Add(this.AddProductButton);
            this.inventoryPage.Controls.Add(this.FilterCategoryComboBox);
            this.inventoryPage.Controls.Add(this.SearchNameTextBox);
            this.inventoryPage.Controls.Add(this.lblFilter);
            this.inventoryPage.Controls.Add(this.lblSearchName);
            this.inventoryPage.Controls.Add(this.ProductsDataGridView);
            this.inventoryPage.Location = new System.Drawing.Point(4, 24);
            this.inventoryPage.Name = "inventoryPage";
            this.inventoryPage.Padding = new System.Windows.Forms.Padding(3);
            this.inventoryPage.Size = new System.Drawing.Size(1215, 584);
            this.inventoryPage.TabIndex = 0;
            this.inventoryPage.Text = "Склад";
            this.inventoryPage.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(195, 546);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "- Удалить товар";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // AddProductButton
            // 
            this.AddProductButton.BackColor = System.Drawing.Color.LightGreen;
            this.AddProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProductButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddProductButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AddProductButton.Location = new System.Drawing.Point(22, 546);
            this.AddProductButton.Name = "AddProductButton";
            this.AddProductButton.Size = new System.Drawing.Size(167, 32);
            this.AddProductButton.TabIndex = 5;
            this.AddProductButton.Text = "+ Добавить товар";
            this.AddProductButton.UseVisualStyleBackColor = false;
            // 
            // FilterCategoryComboBox
            // 
            this.FilterCategoryComboBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilterCategoryComboBox.FormattingEnabled = true;
            this.FilterCategoryComboBox.Location = new System.Drawing.Point(611, 6);
            this.FilterCategoryComboBox.Name = "FilterCategoryComboBox";
            this.FilterCategoryComboBox.Size = new System.Drawing.Size(302, 29);
            this.FilterCategoryComboBox.TabIndex = 4;
            // 
            // SearchNameTextBox
            // 
            this.SearchNameTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchNameTextBox.Location = new System.Drawing.Point(83, 6);
            this.SearchNameTextBox.Name = "SearchNameTextBox";
            this.SearchNameTextBox.Size = new System.Drawing.Size(302, 29);
            this.SearchNameTextBox.TabIndex = 3;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFilter.Location = new System.Drawing.Point(516, 9);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(99, 21);
            this.lblFilter.TabIndex = 2;
            this.lblFilter.Text = "Категории:";
            // 
            // lblSearchName
            // 
            this.lblSearchName.AutoSize = true;
            this.lblSearchName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSearchName.Location = new System.Drawing.Point(22, 9);
            this.lblSearchName.Name = "lblSearchName";
            this.lblSearchName.Size = new System.Drawing.Size(65, 21);
            this.lblSearchName.TabIndex = 1;
            this.lblSearchName.Text = "Поиск:";
            // 
            // ProductsDataGridView
            // 
            this.ProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductsDataGridView.Location = new System.Drawing.Point(23, 41);
            this.ProductsDataGridView.Name = "ProductsDataGridView";
            this.ProductsDataGridView.Size = new System.Drawing.Size(1173, 499);
            this.ProductsDataGridView.TabIndex = 0;
            this.ProductsDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ProductsDataGridView_CellFormatting);
            // 
            // salesPage
            // 
            this.salesPage.Controls.Add(this.splitContainer1);
            this.salesPage.Location = new System.Drawing.Point(4, 24);
            this.salesPage.Name = "salesPage";
            this.salesPage.Padding = new System.Windows.Forms.Padding(3);
            this.salesPage.Size = new System.Drawing.Size(1215, 584);
            this.salesPage.TabIndex = 1;
            this.salesPage.Text = "Продажи";
            this.salesPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.CatalogGroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CartGroupBox);
            this.splitContainer1.Size = new System.Drawing.Size(1209, 578);
            this.splitContainer1.SplitterDistance = 612;
            this.splitContainer1.TabIndex = 0;
            // 
            // CatalogGroupBox
            // 
            this.CatalogGroupBox.Controls.Add(this.AddToCartButton);
            this.CatalogGroupBox.Controls.Add(this.lblQuantity);
            this.CatalogGroupBox.Controls.Add(this.QuantityNumericUpDown);
            this.CatalogGroupBox.Controls.Add(this.CatalogDataGridView);
            this.CatalogGroupBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CatalogGroupBox.Location = new System.Drawing.Point(5, 3);
            this.CatalogGroupBox.Name = "CatalogGroupBox";
            this.CatalogGroupBox.Size = new System.Drawing.Size(604, 575);
            this.CatalogGroupBox.TabIndex = 0;
            this.CatalogGroupBox.TabStop = false;
            this.CatalogGroupBox.Text = "Доступные товары";
            // 
            // AddToCartButton
            // 
            this.AddToCartButton.BackColor = System.Drawing.Color.LightGreen;
            this.AddToCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddToCartButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddToCartButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AddToCartButton.Location = new System.Drawing.Point(399, 529);
            this.AddToCartButton.Name = "AddToCartButton";
            this.AddToCartButton.Size = new System.Drawing.Size(199, 32);
            this.AddToCartButton.TabIndex = 6;
            this.AddToCartButton.Text = "+ Добавить в корзину";
            this.AddToCartButton.UseVisualStyleBackColor = false;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(6, 531);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(109, 21);
            this.lblQuantity.TabIndex = 3;
            this.lblQuantity.Text = "Количество:";
            // 
            // QuantityNumericUpDown
            // 
            this.QuantityNumericUpDown.Location = new System.Drawing.Point(121, 529);
            this.QuantityNumericUpDown.Name = "QuantityNumericUpDown";
            this.QuantityNumericUpDown.Size = new System.Drawing.Size(120, 29);
            this.QuantityNumericUpDown.TabIndex = 1;
            // 
            // CatalogDataGridView
            // 
            this.CatalogDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CatalogDataGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.CatalogDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CatalogDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CatalogDataGridView.Location = new System.Drawing.Point(6, 28);
            this.CatalogDataGridView.Name = "CatalogDataGridView";
            this.CatalogDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CatalogDataGridView.Size = new System.Drawing.Size(592, 495);
            this.CatalogDataGridView.TabIndex = 0;
            // 
            // CartGroupBox
            // 
            this.CartGroupBox.Controls.Add(this.button3);
            this.CartGroupBox.Controls.Add(this.TotalSumLabel);
            this.CartGroupBox.Controls.Add(this.button2);
            this.CartGroupBox.Controls.Add(this.lblTotalSum);
            this.CartGroupBox.Controls.Add(this.dataGridView1);
            this.CartGroupBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CartGroupBox.Location = new System.Drawing.Point(-1, 3);
            this.CartGroupBox.Name = "CartGroupBox";
            this.CartGroupBox.Size = new System.Drawing.Size(599, 574);
            this.CartGroupBox.TabIndex = 1;
            this.CartGroupBox.TabStop = false;
            this.CartGroupBox.Text = "Корзина покупателя";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SkyBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(217, 530);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 32);
            this.button3.TabIndex = 12;
            this.button3.Text = "Сформировать чек";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // TotalSumLabel
            // 
            this.TotalSumLabel.AutoSize = true;
            this.TotalSumLabel.BackColor = System.Drawing.Color.Transparent;
            this.TotalSumLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.TotalSumLabel.Location = new System.Drawing.Point(66, 533);
            this.TotalSumLabel.Name = "TotalSumLabel";
            this.TotalSumLabel.Size = new System.Drawing.Size(58, 21);
            this.TotalSumLabel.TabIndex = 11;
            this.TotalSumLabel.Text = "0 руб.";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightCoral;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(408, 530);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 32);
            this.button2.TabIndex = 10;
            this.button2.Text = "- Убрать из корзины";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // lblTotalSum
            // 
            this.lblTotalSum.AutoSize = true;
            this.lblTotalSum.Location = new System.Drawing.Point(6, 532);
            this.lblTotalSum.Name = "lblTotalSum";
            this.lblTotalSum.Size = new System.Drawing.Size(63, 21);
            this.lblTotalSum.TabIndex = 9;
            this.lblTotalSum.Text = "Итого:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(592, 496);
            this.dataGridView1.TabIndex = 7;
            // 
            // reportsPage
            // 
            this.reportsPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.reportsPage.Controls.Add(this.tableLayoutPanel1);
            this.reportsPage.Controls.Add(this.panel1);
            this.reportsPage.Location = new System.Drawing.Point(4, 24);
            this.reportsPage.Name = "reportsPage";
            this.reportsPage.Padding = new System.Windows.Forms.Padding(3);
            this.reportsPage.Size = new System.Drawing.Size(1215, 584);
            this.reportsPage.TabIndex = 2;
            this.reportsPage.Text = "Отчетность";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1209, 518);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GenerateReportButton);
            this.panel1.Controls.Add(this.EndDateTimePicker);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.StartDateTimePicker);
            this.panel1.Controls.Add(this.DateTimePickerLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1209, 60);
            this.panel1.TabIndex = 0;
            // 
            // GenerateReportButton
            // 
            this.GenerateReportButton.BackColor = System.Drawing.Color.SkyBlue;
            this.GenerateReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateReportButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenerateReportButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GenerateReportButton.Location = new System.Drawing.Point(1007, 15);
            this.GenerateReportButton.Name = "GenerateReportButton";
            this.GenerateReportButton.Size = new System.Drawing.Size(197, 32);
            this.GenerateReportButton.TabIndex = 13;
            this.GenerateReportButton.Text = "Сформировать отчет";
            this.GenerateReportButton.UseVisualStyleBackColor = false;
            // 
            // EndDateTimePicker
            // 
            this.EndDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EndDateTimePicker.Location = new System.Drawing.Point(76, 16);
            this.EndDateTimePicker.Name = "EndDateTimePicker";
            this.EndDateTimePicker.Size = new System.Drawing.Size(173, 29);
            this.EndDateTimePicker.TabIndex = 3;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(252, 21);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(16, 21);
            this.label.TabIndex = 2;
            this.label.Text = "-";
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartDateTimePicker.Location = new System.Drawing.Point(271, 16);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(173, 29);
            this.StartDateTimePicker.TabIndex = 1;
            // 
            // DateTimePickerLabel
            // 
            this.DateTimePickerLabel.AutoSize = true;
            this.DateTimePickerLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateTimePickerLabel.Location = new System.Drawing.Point(5, 19);
            this.DateTimePickerLabel.Name = "DateTimePickerLabel";
            this.DateTimePickerLabel.Size = new System.Drawing.Size(74, 21);
            this.DateTimePickerLabel.TabIndex = 0;
            this.DateTimePickerLabel.Text = "Преиод:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ReportByDayCartesian);
            this.panel2.Controls.Add(this.ReportByDayLanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(598, 512);
            this.panel2.TabIndex = 2;
            // 
            // ReportByDayLanel
            // 
            this.ReportByDayLanel.AutoSize = true;
            this.ReportByDayLanel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReportByDayLanel.Location = new System.Drawing.Point(3, 3);
            this.ReportByDayLanel.Name = "ReportByDayLanel";
            this.ReportByDayLanel.Size = new System.Drawing.Size(220, 21);
            this.ReportByDayLanel.TabIndex = 3;
            this.ReportByDayLanel.Text = "Динамика выручки (руб.):";
            // 
            // ReportByDayCartesian
            // 
            this.ReportByDayCartesian.Location = new System.Drawing.Point(3, 27);
            this.ReportByDayCartesian.Name = "ReportByDayCartesian";
            this.ReportByDayCartesian.Size = new System.Drawing.Size(592, 482);
            this.ReportByDayCartesian.TabIndex = 4;
            this.ReportByDayCartesian.Text = "cartesianChart1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ReportByEmpPic);
            this.panel3.Controls.Add(this.ReportByEmpLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(607, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(599, 512);
            this.panel3.TabIndex = 3;
            // 
            // ReportByEmpLabel
            // 
            this.ReportByEmpLabel.AutoSize = true;
            this.ReportByEmpLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReportByEmpLabel.Location = new System.Drawing.Point(3, 3);
            this.ReportByEmpLabel.Name = "ReportByEmpLabel";
            this.ReportByEmpLabel.Size = new System.Drawing.Size(198, 21);
            this.ReportByEmpLabel.TabIndex = 4;
            this.ReportByEmpLabel.Text = "Популярность товаров:";
            // 
            // ReportByEmpPic
            // 
            this.ReportByEmpPic.Location = new System.Drawing.Point(3, 27);
            this.ReportByEmpPic.Name = "ReportByEmpPic";
            this.ReportByEmpPic.Size = new System.Drawing.Size(593, 485);
            this.ReportByEmpPic.TabIndex = 5;
            this.ReportByEmpPic.Text = "pieChart1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 612);
            this.Controls.Add(this.MainTabControl);
            this.Name = "MainForm";
            this.Text = "Магазин компьютерных комплектующих";
            this.MainTabControl.ResumeLayout(false);
            this.inventoryPage.ResumeLayout(false);
            this.inventoryPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).EndInit();
            this.salesPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.CatalogGroupBox.ResumeLayout(false);
            this.CatalogGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CatalogDataGridView)).EndInit();
            this.CartGroupBox.ResumeLayout(false);
            this.CartGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.reportsPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage inventoryPage;
        private System.Windows.Forms.TabPage salesPage;
        private System.Windows.Forms.TabPage reportsPage;
        private System.Windows.Forms.DataGridView ProductsDataGridView;
        private System.Windows.Forms.TextBox SearchNameTextBox;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblSearchName;
        private System.Windows.Forms.ComboBox FilterCategoryComboBox;
        private System.Windows.Forms.Button AddProductButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox CatalogGroupBox;
        private System.Windows.Forms.DataGridView CatalogDataGridView;
        private System.Windows.Forms.GroupBox CartGroupBox;
        private System.Windows.Forms.NumericUpDown QuantityNumericUpDown;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button AddToCartButton;
        private System.Windows.Forms.Label TotalSumLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblTotalSum;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker EndDateTimePicker;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.Label DateTimePickerLabel;
        private System.Windows.Forms.Button GenerateReportButton;
        private System.Windows.Forms.Panel panel2;
        private LiveCharts.WinForms.CartesianChart ReportByDayCartesian;
        private System.Windows.Forms.Label ReportByDayLanel;
        private System.Windows.Forms.Panel panel3;
        private LiveCharts.WinForms.PieChart ReportByEmpPic;
        private System.Windows.Forms.Label ReportByEmpLabel;
    }
}

