using System.Drawing;
using System.Windows.Forms;

namespace ComputerStoreLib
{
    /// <summary>
    /// Настройка таблиц для отображения товаров
    /// </summary>
    public class ProductGridConfigurator
    {
        /// <summary>
        /// Настройка таблицы каталога для продаж
        /// </summary>
        public static void ConfigureProductsForSaleGrid(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();
            grid.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "Id",
                    HeaderText = "ID",
                    DataPropertyName = "Id",
                    Width = 40
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Name",
                    HeaderText = "Наименование",
                    DataPropertyName = "Name",
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Category",
                    HeaderText = "Категория",
                    DataPropertyName = "Category",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Price",
                    HeaderText = "Цена (₽)",
                    DataPropertyName = "Price",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Quantity",
                    HeaderText = "В наличии",
                    DataPropertyName = "Quantity",
                    Width = 80
                }
            });
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// Настройка таблицы корзины
        /// </summary>
        public static void ConfigureCartGrid(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();
            grid.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductName",
                    HeaderText = "Наименование",
                    DataPropertyName = "ProductName",
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Price",
                    HeaderText = "Цена (₽)",
                    DataPropertyName = "Price",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Quantity",
                    HeaderText = "Количество",
                    DataPropertyName = "Quantity",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "TotalPrice",
                    HeaderText = "Итого (₽)",
                    DataPropertyName = "TotalPrice",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
                }
            });
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// Настройка таблицы склада
        /// </summary>
        public static void ConfigureInventoryGrid(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();
            grid.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id", Width = 40 },
                new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Наименование", DataPropertyName = "Name", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "Категория", DataPropertyName = "Category", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Цена (₽)", DataPropertyName = "Price", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } },
                new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Остаток", DataPropertyName = "Quantity", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "TotalValue", HeaderText = "Общая стоимость (₽)", DataPropertyName = "TotalValue", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } }
            });
        }

        /// <summary>
        /// Настройка таблицы продаж
        /// </summary>
        public static void ConfigureSalesGrid(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();
            grid.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "№", DataPropertyName = "Id", Width = 40 },
                new DataGridViewTextBoxColumn { Name = "SaleDate", HeaderText = "Дата", DataPropertyName = "SaleDate", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "UserName", HeaderText = "Продавец", DataPropertyName = "UserName", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "TotalAmount", HeaderText = "Сумма (₽)", DataPropertyName = "TotalAmount", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } }
            });
        }

        /// <summary>
        /// Подсветка строки в зависимости от количества товара
        /// </summary>
        public static void HighlightProductRow(DataGridViewRow row, int quantity)
        {
            if (quantity == 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightCoral;
                row.DefaultCellStyle.ForeColor = Color.White;
                row.DefaultCellStyle.SelectionBackColor = Color.Red;
                row.DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else if (quantity <= 5)
            {
                row.DefaultCellStyle.BackColor = Color.LightYellow;
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.SelectionBackColor = Color.Gold;
                row.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                row.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }
    }
}

