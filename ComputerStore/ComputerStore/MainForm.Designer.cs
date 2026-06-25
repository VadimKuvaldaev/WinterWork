namespace ComputerStore
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label UserInfoLabel;
        private System.Windows.Forms.Label UserRoleLabel;
        private System.Windows.Forms.Button LogoutButton;

        // TabControl
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage InventoryTabPage;
        private System.Windows.Forms.TabPage SalesTabPage;
        private System.Windows.Forms.TabPage ReportsTabPage;

        // Inventory (Склад)
        private System.Windows.Forms.Panel InventoryTopPanel;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label CategoryFilterLabel;
        private System.Windows.Forms.ComboBox CategoryFilterComboBox;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button AddProductButton;
        private System.Windows.Forms.Button EditProductButton;
        private System.Windows.Forms.Button DeleteProductButton;
        private System.Windows.Forms.Label ProductCountLabel;
        private System.Windows.Forms.DataGridView ProductsDataGridView;

        // Sales (Продажи)
        private System.Windows.Forms.SplitContainer SalesSplitContainer;
        private System.Windows.Forms.Panel CatalogPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CatalogLabel;
        private System.Windows.Forms.DataGridView ProductsForSaleDataGridView;
        private System.Windows.Forms.Panel CatalogBottomPanel;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.NumericUpDown QuantityNumericUpDown;
        private System.Windows.Forms.Button AddToCartButton;
        private System.Windows.Forms.Panel CartPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label CartLabel;
        private System.Windows.Forms.DataGridView CartDataGridView;
        private System.Windows.Forms.Panel CartBottomPanel;
        private System.Windows.Forms.Label CartTotalLabel;
        private System.Windows.Forms.Label CartCountLabel;
        private System.Windows.Forms.Button RemoveFromCartButton;
        private System.Windows.Forms.Button ClearCartButton;
        private System.Windows.Forms.Button CheckoutButton;

        // Reports (Отчеты)
        private System.Windows.Forms.Panel ReportsTopPanel;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.Button GenerateReportButton;
        private System.Windows.Forms.Label SalesCountLabel;
        private System.Windows.Forms.Label TotalRevenueLabel;
        private System.Windows.Forms.DataGridView SalesDataGridView;

        // Графики
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.SplitContainer ReportsSplitContainer;
        private System.Windows.Forms.Panel ChartLeftPanel;
        private System.Windows.Forms.Panel ChartRightPanel;
        private System.Windows.Forms.Label ChartTitleLabel;
        private System.Windows.Forms.Label PieTitleLabel;
        private System.Windows.Forms.SplitContainer chartSplit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.UserInfoLabel = new System.Windows.Forms.Label();
            this.UserRoleLabel = new System.Windows.Forms.Label();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.InventoryTabPage = new System.Windows.Forms.TabPage();
            this.ProductsDataGridView = new System.Windows.Forms.DataGridView();
            this.InventoryTopPanel = new System.Windows.Forms.Panel();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.CategoryFilterLabel = new System.Windows.Forms.Label();
            this.CategoryFilterComboBox = new System.Windows.Forms.ComboBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.AddProductButton = new System.Windows.Forms.Button();
            this.EditProductButton = new System.Windows.Forms.Button();
            this.DeleteProductButton = new System.Windows.Forms.Button();
            this.ProductCountLabel = new System.Windows.Forms.Label();
            this.SalesTabPage = new System.Windows.Forms.TabPage();
            this.SalesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CatalogPanel = new System.Windows.Forms.Panel();
            this.ProductsForSaleDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CatalogLabel = new System.Windows.Forms.Label();
            this.CatalogBottomPanel = new System.Windows.Forms.Panel();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.QuantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AddToCartButton = new System.Windows.Forms.Button();
            this.CartPanel = new System.Windows.Forms.Panel();
            this.CartDataGridView = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CartLabel = new System.Windows.Forms.Label();
            this.CartBottomPanel = new System.Windows.Forms.Panel();
            this.CartTotalLabel = new System.Windows.Forms.Label();
            this.CartCountLabel = new System.Windows.Forms.Label();
            this.RemoveFromCartButton = new System.Windows.Forms.Button();
            this.ClearCartButton = new System.Windows.Forms.Button();
            this.CheckoutButton = new System.Windows.Forms.Button();
            this.ReportsTabPage = new System.Windows.Forms.TabPage();
            this.ReportsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.chartSplit = new System.Windows.Forms.SplitContainer();
            this.ChartLeftPanel = new System.Windows.Forms.Panel();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ChartTitleLabel = new System.Windows.Forms.Label();
            this.ChartRightPanel = new System.Windows.Forms.Panel();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PieTitleLabel = new System.Windows.Forms.Label();
            this.SalesDataGridView = new System.Windows.Forms.DataGridView();
            this.ReportsTopPanel = new System.Windows.Forms.Panel();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.GenerateReportButton = new System.Windows.Forms.Button();
            this.SalesCountLabel = new System.Windows.Forms.Label();
            this.TotalRevenueLabel = new System.Windows.Forms.Label();
            this.HeaderPanel.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.InventoryTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).BeginInit();
            this.InventoryTopPanel.SuspendLayout();
            this.SalesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSplitContainer)).BeginInit();
            this.SalesSplitContainer.Panel1.SuspendLayout();
            this.SalesSplitContainer.Panel2.SuspendLayout();
            this.SalesSplitContainer.SuspendLayout();
            this.CatalogPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsForSaleDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.CatalogBottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumericUpDown)).BeginInit();
            this.CartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CartDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.CartBottomPanel.SuspendLayout();
            this.ReportsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReportsSplitContainer)).BeginInit();
            this.ReportsSplitContainer.Panel1.SuspendLayout();
            this.ReportsSplitContainer.Panel2.SuspendLayout();
            this.ReportsSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSplit)).BeginInit();
            this.chartSplit.Panel1.SuspendLayout();
            this.chartSplit.Panel2.SuspendLayout();
            this.chartSplit.SuspendLayout();
            this.ChartLeftPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.ChartRightPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDataGridView)).BeginInit();
            this.ReportsTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.HeaderPanel.Controls.Add(this.TitleLabel);
            this.HeaderPanel.Controls.Add(this.UserInfoLabel);
            this.HeaderPanel.Controls.Add(this.UserRoleLabel);
            this.HeaderPanel.Controls.Add(this.LogoutButton);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(1200, 70);
            this.HeaderPanel.TabIndex = 0;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(20, 22);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(391, 25);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Учет и продажа компьютерных деталей";
            // 
            // UserInfoLabel
            // 
            this.UserInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserInfoLabel.AutoSize = true;
            this.UserInfoLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.UserInfoLabel.ForeColor = System.Drawing.Color.White;
            this.UserInfoLabel.Location = new System.Drawing.Point(750, 10);
            this.UserInfoLabel.Name = "UserInfoLabel";
            this.UserInfoLabel.Size = new System.Drawing.Size(99, 19);
            this.UserInfoLabel.TabIndex = 1;
            this.UserInfoLabel.Text = "Пользователь:";
            // 
            // UserRoleLabel
            // 
            this.UserRoleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserRoleLabel.AutoSize = true;
            this.UserRoleLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.UserRoleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.UserRoleLabel.Location = new System.Drawing.Point(750, 35);
            this.UserRoleLabel.Name = "UserRoleLabel";
            this.UserRoleLabel.Size = new System.Drawing.Size(42, 19);
            this.UserRoleLabel.TabIndex = 2;
            this.UserRoleLabel.Text = "Роль:";
            // 
            // LogoutButton
            // 
            this.LogoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.LogoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoutButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LogoutButton.ForeColor = System.Drawing.Color.White;
            this.LogoutButton.Location = new System.Drawing.Point(1050, 17);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(120, 35);
            this.LogoutButton.TabIndex = 3;
            this.LogoutButton.Text = "Выход";
            this.LogoutButton.UseVisualStyleBackColor = false;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.InventoryTabPage);
            this.MainTabControl.Controls.Add(this.SalesTabPage);
            this.MainTabControl.Controls.Add(this.ReportsTabPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MainTabControl.Location = new System.Drawing.Point(0, 70);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1200, 630);
            this.MainTabControl.TabIndex = 1;
            // 
            // InventoryTabPage
            // 
            this.InventoryTabPage.BackColor = System.Drawing.Color.White;
            this.InventoryTabPage.Controls.Add(this.ProductsDataGridView);
            this.InventoryTabPage.Controls.Add(this.InventoryTopPanel);
            this.InventoryTabPage.Location = new System.Drawing.Point(4, 26);
            this.InventoryTabPage.Name = "InventoryTabPage";
            this.InventoryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.InventoryTabPage.Size = new System.Drawing.Size(1192, 600);
            this.InventoryTabPage.TabIndex = 0;
            this.InventoryTabPage.Text = "📦 Склад";
            // 
            // ProductsDataGridView
            // 
            this.ProductsDataGridView.AllowUserToAddRows = false;
            this.ProductsDataGridView.AllowUserToDeleteRows = false;
            this.ProductsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProductsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.ProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductsDataGridView.Location = new System.Drawing.Point(3, 82);
            this.ProductsDataGridView.Name = "ProductsDataGridView";
            this.ProductsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductsDataGridView.Size = new System.Drawing.Size(1186, 515);
            this.ProductsDataGridView.TabIndex = 1;
            // 
            // InventoryTopPanel
            // 
            this.InventoryTopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.InventoryTopPanel.Controls.Add(this.SearchLabel);
            this.InventoryTopPanel.Controls.Add(this.SearchTextBox);
            this.InventoryTopPanel.Controls.Add(this.CategoryFilterLabel);
            this.InventoryTopPanel.Controls.Add(this.CategoryFilterComboBox);
            this.InventoryTopPanel.Controls.Add(this.RefreshButton);
            this.InventoryTopPanel.Controls.Add(this.AddProductButton);
            this.InventoryTopPanel.Controls.Add(this.EditProductButton);
            this.InventoryTopPanel.Controls.Add(this.DeleteProductButton);
            this.InventoryTopPanel.Controls.Add(this.ProductCountLabel);
            this.InventoryTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InventoryTopPanel.Location = new System.Drawing.Point(3, 3);
            this.InventoryTopPanel.Name = "InventoryTopPanel";
            this.InventoryTopPanel.Size = new System.Drawing.Size(1186, 79);
            this.InventoryTopPanel.TabIndex = 0;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(15, 15);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(51, 19);
            this.SearchLabel.TabIndex = 0;
            this.SearchLabel.Text = "Поиск:";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(70, 12);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(180, 25);
            this.SearchTextBox.TabIndex = 1;
            // 
            // CategoryFilterLabel
            // 
            this.CategoryFilterLabel.AutoSize = true;
            this.CategoryFilterLabel.Location = new System.Drawing.Point(270, 15);
            this.CategoryFilterLabel.Name = "CategoryFilterLabel";
            this.CategoryFilterLabel.Size = new System.Drawing.Size(76, 19);
            this.CategoryFilterLabel.TabIndex = 2;
            this.CategoryFilterLabel.Text = "Категория:";
            // 
            // CategoryFilterComboBox
            // 
            this.CategoryFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryFilterComboBox.Location = new System.Drawing.Point(350, 12);
            this.CategoryFilterComboBox.Name = "CategoryFilterComboBox";
            this.CategoryFilterComboBox.Size = new System.Drawing.Size(150, 25);
            this.CategoryFilterComboBox.TabIndex = 3;
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.ForeColor = System.Drawing.Color.White;
            this.RefreshButton.Location = new System.Drawing.Point(520, 10);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(100, 30);
            this.RefreshButton.TabIndex = 4;
            this.RefreshButton.Text = "Обновить";
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // AddProductButton
            // 
            this.AddProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.AddProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProductButton.ForeColor = System.Drawing.Color.White;
            this.AddProductButton.Location = new System.Drawing.Point(650, 10);
            this.AddProductButton.Name = "AddProductButton";
            this.AddProductButton.Size = new System.Drawing.Size(120, 30);
            this.AddProductButton.TabIndex = 5;
            this.AddProductButton.Text = "Добавить";
            this.AddProductButton.UseVisualStyleBackColor = false;
            this.AddProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // EditProductButton
            // 
            this.EditProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.EditProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditProductButton.ForeColor = System.Drawing.Color.Black;
            this.EditProductButton.Location = new System.Drawing.Point(790, 10);
            this.EditProductButton.Name = "EditProductButton";
            this.EditProductButton.Size = new System.Drawing.Size(120, 30);
            this.EditProductButton.TabIndex = 6;
            this.EditProductButton.Text = "Редактировать";
            this.EditProductButton.UseVisualStyleBackColor = false;
            this.EditProductButton.Click += new System.EventHandler(this.EditProductButton_Click);
            // 
            // DeleteProductButton
            // 
            this.DeleteProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.DeleteProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteProductButton.ForeColor = System.Drawing.Color.White;
            this.DeleteProductButton.Location = new System.Drawing.Point(930, 10);
            this.DeleteProductButton.Name = "DeleteProductButton";
            this.DeleteProductButton.Size = new System.Drawing.Size(120, 30);
            this.DeleteProductButton.TabIndex = 7;
            this.DeleteProductButton.Text = "Удалить";
            this.DeleteProductButton.UseVisualStyleBackColor = false;
            this.DeleteProductButton.Click += new System.EventHandler(this.DeleteProductButton_Click);
            // 
            // ProductCountLabel
            // 
            this.ProductCountLabel.AutoSize = true;
            this.ProductCountLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.ProductCountLabel.Location = new System.Drawing.Point(15, 52);
            this.ProductCountLabel.Name = "ProductCountLabel";
            this.ProductCountLabel.Size = new System.Drawing.Size(125, 19);
            this.ProductCountLabel.TabIndex = 8;
            this.ProductCountLabel.Text = "Всего товаров: 0";
            // 
            // SalesTabPage
            // 
            this.SalesTabPage.BackColor = System.Drawing.Color.White;
            this.SalesTabPage.Controls.Add(this.SalesSplitContainer);
            this.SalesTabPage.Location = new System.Drawing.Point(4, 26);
            this.SalesTabPage.Name = "SalesTabPage";
            this.SalesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SalesTabPage.Size = new System.Drawing.Size(1192, 600);
            this.SalesTabPage.TabIndex = 1;
            this.SalesTabPage.Text = "🛒 Продажи";
            // 
            // SalesSplitContainer
            // 
            this.SalesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SalesSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.SalesSplitContainer.Name = "SalesSplitContainer";
            // 
            // SalesSplitContainer.Panel1
            // 
            this.SalesSplitContainer.Panel1.Controls.Add(this.CatalogPanel);
            // 
            // SalesSplitContainer.Panel2
            // 
            this.SalesSplitContainer.Panel2.Controls.Add(this.CartPanel);
            this.SalesSplitContainer.Size = new System.Drawing.Size(1186, 594);
            this.SalesSplitContainer.SplitterDistance = 593;
            this.SalesSplitContainer.TabIndex = 0;
            // 
            // CatalogPanel
            // 
            this.CatalogPanel.Controls.Add(this.ProductsForSaleDataGridView);
            this.CatalogPanel.Controls.Add(this.panel1);
            this.CatalogPanel.Controls.Add(this.CatalogBottomPanel);
            this.CatalogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CatalogPanel.Location = new System.Drawing.Point(0, 0);
            this.CatalogPanel.Name = "CatalogPanel";
            this.CatalogPanel.Size = new System.Drawing.Size(593, 594);
            this.CatalogPanel.TabIndex = 0;
            // 
            // ProductsForSaleDataGridView
            // 
            this.ProductsForSaleDataGridView.AllowUserToAddRows = false;
            this.ProductsForSaleDataGridView.AllowUserToDeleteRows = false;
            this.ProductsForSaleDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProductsForSaleDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.ProductsForSaleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductsForSaleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductsForSaleDataGridView.Location = new System.Drawing.Point(0, 35);
            this.ProductsForSaleDataGridView.Name = "ProductsForSaleDataGridView";
            this.ProductsForSaleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductsForSaleDataGridView.Size = new System.Drawing.Size(593, 499);
            this.ProductsForSaleDataGridView.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CatalogLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 35);
            this.panel1.TabIndex = 3;
            // 
            // CatalogLabel
            // 
            this.CatalogLabel.AutoSize = true;
            this.CatalogLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.CatalogLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.CatalogLabel.Location = new System.Drawing.Point(5, 8);
            this.CatalogLabel.Name = "CatalogLabel";
            this.CatalogLabel.Size = new System.Drawing.Size(140, 21);
            this.CatalogLabel.TabIndex = 0;
            this.CatalogLabel.Text = "Каталог товаров";
            // 
            // CatalogBottomPanel
            // 
            this.CatalogBottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.CatalogBottomPanel.Controls.Add(this.QuantityLabel);
            this.CatalogBottomPanel.Controls.Add(this.QuantityNumericUpDown);
            this.CatalogBottomPanel.Controls.Add(this.AddToCartButton);
            this.CatalogBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CatalogBottomPanel.Location = new System.Drawing.Point(0, 534);
            this.CatalogBottomPanel.Name = "CatalogBottomPanel";
            this.CatalogBottomPanel.Size = new System.Drawing.Size(593, 60);
            this.CatalogBottomPanel.TabIndex = 2;
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Location = new System.Drawing.Point(10, 22);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(85, 19);
            this.QuantityLabel.TabIndex = 0;
            this.QuantityLabel.Text = "Количество:";
            // 
            // QuantityNumericUpDown
            // 
            this.QuantityNumericUpDown.Location = new System.Drawing.Point(100, 18);
            this.QuantityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QuantityNumericUpDown.Name = "QuantityNumericUpDown";
            this.QuantityNumericUpDown.Size = new System.Drawing.Size(80, 25);
            this.QuantityNumericUpDown.TabIndex = 1;
            this.QuantityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AddToCartButton
            // 
            this.AddToCartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.AddToCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddToCartButton.ForeColor = System.Drawing.Color.White;
            this.AddToCartButton.Location = new System.Drawing.Point(200, 13);
            this.AddToCartButton.Name = "AddToCartButton";
            this.AddToCartButton.Size = new System.Drawing.Size(150, 35);
            this.AddToCartButton.TabIndex = 2;
            this.AddToCartButton.Text = "Добавить в корзину";
            this.AddToCartButton.UseVisualStyleBackColor = false;
            this.AddToCartButton.Click += new System.EventHandler(this.AddToCartButton_Click);
            // 
            // CartPanel
            // 
            this.CartPanel.Controls.Add(this.CartDataGridView);
            this.CartPanel.Controls.Add(this.panel2);
            this.CartPanel.Controls.Add(this.CartBottomPanel);
            this.CartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CartPanel.Location = new System.Drawing.Point(0, 0);
            this.CartPanel.Name = "CartPanel";
            this.CartPanel.Size = new System.Drawing.Size(589, 594);
            this.CartPanel.TabIndex = 0;
            // 
            // CartDataGridView
            // 
            this.CartDataGridView.AllowUserToAddRows = false;
            this.CartDataGridView.AllowUserToDeleteRows = false;
            this.CartDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CartDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.CartDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CartDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CartDataGridView.Location = new System.Drawing.Point(0, 35);
            this.CartDataGridView.Name = "CartDataGridView";
            this.CartDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CartDataGridView.Size = new System.Drawing.Size(589, 439);
            this.CartDataGridView.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CartLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(589, 35);
            this.panel2.TabIndex = 4;
            // 
            // CartLabel
            // 
            this.CartLabel.AutoSize = true;
            this.CartLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.CartLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.CartLabel.Location = new System.Drawing.Point(3, 7);
            this.CartLabel.Name = "CartLabel";
            this.CartLabel.Size = new System.Drawing.Size(77, 21);
            this.CartLabel.TabIndex = 0;
            this.CartLabel.Text = "Корзина";
            // 
            // CartBottomPanel
            // 
            this.CartBottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.CartBottomPanel.Controls.Add(this.CartTotalLabel);
            this.CartBottomPanel.Controls.Add(this.CartCountLabel);
            this.CartBottomPanel.Controls.Add(this.RemoveFromCartButton);
            this.CartBottomPanel.Controls.Add(this.ClearCartButton);
            this.CartBottomPanel.Controls.Add(this.CheckoutButton);
            this.CartBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CartBottomPanel.Location = new System.Drawing.Point(0, 474);
            this.CartBottomPanel.Name = "CartBottomPanel";
            this.CartBottomPanel.Size = new System.Drawing.Size(589, 120);
            this.CartBottomPanel.TabIndex = 2;
            // 
            // CartTotalLabel
            // 
            this.CartTotalLabel.AutoSize = true;
            this.CartTotalLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.CartTotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.CartTotalLabel.Location = new System.Drawing.Point(10, 15);
            this.CartTotalLabel.Name = "CartTotalLabel";
            this.CartTotalLabel.Size = new System.Drawing.Size(105, 25);
            this.CartTotalLabel.TabIndex = 0;
            this.CartTotalLabel.Text = "Итого: 0 ₽";
            // 
            // CartCountLabel
            // 
            this.CartCountLabel.AutoSize = true;
            this.CartCountLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CartCountLabel.Location = new System.Drawing.Point(10, 45);
            this.CartCountLabel.Name = "CartCountLabel";
            this.CartCountLabel.Size = new System.Drawing.Size(80, 19);
            this.CartCountLabel.TabIndex = 1;
            this.CartCountLabel.Text = "Позиций: 0";
            // 
            // RemoveFromCartButton
            // 
            this.RemoveFromCartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.RemoveFromCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveFromCartButton.ForeColor = System.Drawing.Color.White;
            this.RemoveFromCartButton.Location = new System.Drawing.Point(200, 10);
            this.RemoveFromCartButton.Name = "RemoveFromCartButton";
            this.RemoveFromCartButton.Size = new System.Drawing.Size(170, 35);
            this.RemoveFromCartButton.TabIndex = 2;
            this.RemoveFromCartButton.Text = "Удалить из корзины";
            this.RemoveFromCartButton.UseVisualStyleBackColor = false;
            this.RemoveFromCartButton.Click += new System.EventHandler(this.RemoveFromCartButton_Click);
            // 
            // ClearCartButton
            // 
            this.ClearCartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.ClearCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearCartButton.ForeColor = System.Drawing.Color.White;
            this.ClearCartButton.Location = new System.Drawing.Point(200, 55);
            this.ClearCartButton.Name = "ClearCartButton";
            this.ClearCartButton.Size = new System.Drawing.Size(170, 35);
            this.ClearCartButton.TabIndex = 3;
            this.ClearCartButton.Text = "Очистить корзину";
            this.ClearCartButton.UseVisualStyleBackColor = false;
            // 
            // CheckoutButton
            // 
            this.CheckoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.CheckoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckoutButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.CheckoutButton.ForeColor = System.Drawing.Color.White;
            this.CheckoutButton.Location = new System.Drawing.Point(400, 25);
            this.CheckoutButton.Name = "CheckoutButton";
            this.CheckoutButton.Size = new System.Drawing.Size(160, 50);
            this.CheckoutButton.TabIndex = 4;
            this.CheckoutButton.Text = "Оформить продажу";
            this.CheckoutButton.UseVisualStyleBackColor = false;
            // 
            // ReportsTabPage
            // 
            this.ReportsTabPage.BackColor = System.Drawing.Color.White;
            this.ReportsTabPage.Controls.Add(this.ReportsSplitContainer);
            this.ReportsTabPage.Controls.Add(this.ReportsTopPanel);
            this.ReportsTabPage.Controls.Add(this.SalesCountLabel);
            this.ReportsTabPage.Controls.Add(this.TotalRevenueLabel);
            this.ReportsTabPage.Location = new System.Drawing.Point(4, 26);
            this.ReportsTabPage.Name = "ReportsTabPage";
            this.ReportsTabPage.Size = new System.Drawing.Size(1192, 600);
            this.ReportsTabPage.TabIndex = 2;
            this.ReportsTabPage.Text = "📊 Отчеты";
            // 
            // ReportsSplitContainer
            // 
            this.ReportsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportsSplitContainer.Location = new System.Drawing.Point(0, 60);
            this.ReportsSplitContainer.Name = "ReportsSplitContainer";
            this.ReportsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ReportsSplitContainer.Panel1
            // 
            this.ReportsSplitContainer.Panel1.Controls.Add(this.chartSplit);
            // 
            // ReportsSplitContainer.Panel2
            // 
            this.ReportsSplitContainer.Panel2.Controls.Add(this.SalesDataGridView);
            this.ReportsSplitContainer.Size = new System.Drawing.Size(1192, 540);
            this.ReportsSplitContainer.SplitterDistance = 324;
            this.ReportsSplitContainer.TabIndex = 4;
            // 
            // chartSplit
            // 
            this.chartSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartSplit.Location = new System.Drawing.Point(0, 0);
            this.chartSplit.Name = "chartSplit";
            // 
            // chartSplit.Panel1
            // 
            this.chartSplit.Panel1.Controls.Add(this.ChartLeftPanel);
            // 
            // chartSplit.Panel2
            // 
            this.chartSplit.Panel2.Controls.Add(this.ChartRightPanel);
            this.chartSplit.Size = new System.Drawing.Size(1192, 324);
            this.chartSplit.SplitterDistance = 596;
            this.chartSplit.TabIndex = 0;
            // 
            // ChartLeftPanel
            // 
            this.ChartLeftPanel.Controls.Add(this.cartesianChart1);
            this.ChartLeftPanel.Controls.Add(this.panel3);
            this.ChartLeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.ChartLeftPanel.Name = "ChartLeftPanel";
            this.ChartLeftPanel.Size = new System.Drawing.Size(596, 324);
            this.ChartLeftPanel.TabIndex = 0;
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Location = new System.Drawing.Point(0, 25);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(596, 299);
            this.cartesianChart1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ChartTitleLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(596, 25);
            this.panel3.TabIndex = 1;
            // 
            // ChartTitleLabel
            // 
            this.ChartTitleLabel.AutoSize = true;
            this.ChartTitleLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ChartTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.ChartTitleLabel.Location = new System.Drawing.Point(3, 3);
            this.ChartTitleLabel.Name = "ChartTitleLabel";
            this.ChartTitleLabel.Size = new System.Drawing.Size(170, 20);
            this.ChartTitleLabel.TabIndex = 0;
            this.ChartTitleLabel.Text = "📈 Динамика продаж";
            // 
            // ChartRightPanel
            // 
            this.ChartRightPanel.Controls.Add(this.pieChart1);
            this.ChartRightPanel.Controls.Add(this.panel4);
            this.ChartRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartRightPanel.Location = new System.Drawing.Point(0, 0);
            this.ChartRightPanel.Name = "ChartRightPanel";
            this.ChartRightPanel.Size = new System.Drawing.Size(592, 324);
            this.ChartRightPanel.TabIndex = 0;
            // 
            // pieChart1
            // 
            this.pieChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieChart1.Location = new System.Drawing.Point(0, 25);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(592, 299);
            this.pieChart1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.PieTitleLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(592, 25);
            this.panel4.TabIndex = 2;
            // 
            // PieTitleLabel
            // 
            this.PieTitleLabel.AutoSize = true;
            this.PieTitleLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.PieTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.PieTitleLabel.Location = new System.Drawing.Point(3, 3);
            this.PieTitleLabel.Name = "PieTitleLabel";
            this.PieTitleLabel.Size = new System.Drawing.Size(317, 20);
            this.PieTitleLabel.TabIndex = 0;
            this.PieTitleLabel.Text = "🍩 Распределение продаж по категориям";
            // 
            // SalesDataGridView
            // 
            this.SalesDataGridView.AllowUserToAddRows = false;
            this.SalesDataGridView.AllowUserToDeleteRows = false;
            this.SalesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SalesDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.SalesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SalesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SalesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.SalesDataGridView.Name = "SalesDataGridView";
            this.SalesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SalesDataGridView.Size = new System.Drawing.Size(1192, 212);
            this.SalesDataGridView.TabIndex = 1;
            // 
            // ReportsTopPanel
            // 
            this.ReportsTopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ReportsTopPanel.Controls.Add(this.StartDateLabel);
            this.ReportsTopPanel.Controls.Add(this.StartDatePicker);
            this.ReportsTopPanel.Controls.Add(this.EndDateLabel);
            this.ReportsTopPanel.Controls.Add(this.EndDatePicker);
            this.ReportsTopPanel.Controls.Add(this.GenerateReportButton);
            this.ReportsTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ReportsTopPanel.Location = new System.Drawing.Point(0, 0);
            this.ReportsTopPanel.Name = "ReportsTopPanel";
            this.ReportsTopPanel.Size = new System.Drawing.Size(1192, 60);
            this.ReportsTopPanel.TabIndex = 0;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(20, 22);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(56, 19);
            this.StartDateLabel.TabIndex = 0;
            this.StartDateLabel.Text = "С даты:";
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDatePicker.Location = new System.Drawing.Point(75, 18);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(120, 25);
            this.StartDatePicker.TabIndex = 1;
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(210, 22);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(62, 19);
            this.EndDateLabel.TabIndex = 2;
            this.EndDateLabel.Text = "По дату:";
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDatePicker.Location = new System.Drawing.Point(271, 18);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(120, 25);
            this.EndDatePicker.TabIndex = 3;
            // 
            // GenerateReportButton
            // 
            this.GenerateReportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.GenerateReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateReportButton.ForeColor = System.Drawing.Color.White;
            this.GenerateReportButton.Location = new System.Drawing.Point(420, 16);
            this.GenerateReportButton.Name = "GenerateReportButton";
            this.GenerateReportButton.Size = new System.Drawing.Size(150, 30);
            this.GenerateReportButton.TabIndex = 4;
            this.GenerateReportButton.Text = "Сформировать отчет";
            this.GenerateReportButton.UseVisualStyleBackColor = false;
            this.GenerateReportButton.Click += new System.EventHandler(this.GenerateReportButton_Click);
            // 
            // SalesCountLabel
            // 
            this.SalesCountLabel.AutoSize = true;
            this.SalesCountLabel.Location = new System.Drawing.Point(20, 565);
            this.SalesCountLabel.Name = "SalesCountLabel";
            this.SalesCountLabel.Size = new System.Drawing.Size(111, 19);
            this.SalesCountLabel.TabIndex = 2;
            this.SalesCountLabel.Text = "Всего продаж: 0";
            // 
            // TotalRevenueLabel
            // 
            this.TotalRevenueLabel.AutoSize = true;
            this.TotalRevenueLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.TotalRevenueLabel.Location = new System.Drawing.Point(20, 590);
            this.TotalRevenueLabel.Name = "TotalRevenueLabel";
            this.TotalRevenueLabel.Size = new System.Drawing.Size(150, 19);
            this.TotalRevenueLabel.TabIndex = 3;
            this.TotalRevenueLabel.Text = "Общая выручка: 0 ₽";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.HeaderPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учет и продажа компьютерных деталей";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.InventoryTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).EndInit();
            this.InventoryTopPanel.ResumeLayout(false);
            this.InventoryTopPanel.PerformLayout();
            this.SalesTabPage.ResumeLayout(false);
            this.SalesSplitContainer.Panel1.ResumeLayout(false);
            this.SalesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SalesSplitContainer)).EndInit();
            this.SalesSplitContainer.ResumeLayout(false);
            this.CatalogPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductsForSaleDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.CatalogBottomPanel.ResumeLayout(false);
            this.CatalogBottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumericUpDown)).EndInit();
            this.CartPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CartDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.CartBottomPanel.ResumeLayout(false);
            this.CartBottomPanel.PerformLayout();
            this.ReportsTabPage.ResumeLayout(false);
            this.ReportsTabPage.PerformLayout();
            this.ReportsSplitContainer.Panel1.ResumeLayout(false);
            this.ReportsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReportsSplitContainer)).EndInit();
            this.ReportsSplitContainer.ResumeLayout(false);
            this.chartSplit.Panel1.ResumeLayout(false);
            this.chartSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSplit)).EndInit();
            this.chartSplit.ResumeLayout(false);
            this.ChartLeftPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ChartRightPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDataGridView)).EndInit();
            this.ReportsTopPanel.ResumeLayout(false);
            this.ReportsTopPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}