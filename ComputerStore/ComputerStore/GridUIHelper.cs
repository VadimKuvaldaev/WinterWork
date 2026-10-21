using ComputerStoreLib.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerStore
{
    public static class GridUIHelper
    {
        public static void ConfigureProductsForSaleGrid(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();
            grid.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id", Width = 40 },
                new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Наименование", DataPropertyName = "Name", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "Категория", DataPropertyName = "Category", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Цена (₽)", DataPropertyName = "Price", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } },
                new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "В наличии", DataPropertyName = "Quantity", Width = 80 }
            });
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
        }

        public static void ConfigureCartGrid(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();
            grid.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "ProductName", HeaderText = "Наименование", DataPropertyName = "ProductName", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Цена (₽)", DataPropertyName = "Price", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } },
                new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Количество", DataPropertyName = "Quantity", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "TotalPrice", HeaderText = "Итого (₽)", DataPropertyName = "TotalPrice", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } }
            });
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
        }

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
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
        }

        public static void ConfigureSalesGrid(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();
            grid.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "№", DataPropertyName = "Id", Width = 40 },
                new DataGridViewTextBoxColumn { Name = "SaleDate", HeaderText = "Дата", DataPropertyName = "SaleDate", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "UserId", HeaderText = "ID продавца", DataPropertyName = "UserId", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "TotalAmount", HeaderText = "Сумма (₽)", DataPropertyName = "TotalAmount", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } }
            });
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
        }

        public static void HighlightRows(DataGridView grid, List<ProductItem> products)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                var product = row.DataBoundItem as ProductItem;
                if (product == null) continue;

                if (product.Quantity == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.Red;
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                }
                else if (product.Quantity <= 5)
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
}
