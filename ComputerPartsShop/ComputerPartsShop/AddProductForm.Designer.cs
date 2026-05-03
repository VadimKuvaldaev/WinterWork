namespace ComputerPartsShop
{
    partial class AddProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addNameTextBox = new System.Windows.Forms.TextBox();
            this.addCategoryTextBox = new System.Windows.Forms.TextBox();
            this.addPriceTextBox = new System.Windows.Forms.TextBox();
            this.addQuantityTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.ApplayButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addNameTextBox
            // 
            this.addNameTextBox.Location = new System.Drawing.Point(148, 39);
            this.addNameTextBox.Name = "addNameTextBox";
            this.addNameTextBox.Size = new System.Drawing.Size(245, 29);
            this.addNameTextBox.TabIndex = 0;
            // 
            // addCategoryTextBox
            // 
            this.addCategoryTextBox.Location = new System.Drawing.Point(148, 84);
            this.addCategoryTextBox.Name = "addCategoryTextBox";
            this.addCategoryTextBox.Size = new System.Drawing.Size(245, 29);
            this.addCategoryTextBox.TabIndex = 1;
            // 
            // addPriceTextBox
            // 
            this.addPriceTextBox.Location = new System.Drawing.Point(148, 130);
            this.addPriceTextBox.Name = "addPriceTextBox";
            this.addPriceTextBox.Size = new System.Drawing.Size(245, 29);
            this.addPriceTextBox.TabIndex = 2;
            // 
            // addQuantityTextBox
            // 
            this.addQuantityTextBox.Location = new System.Drawing.Point(148, 175);
            this.addQuantityTextBox.Name = "addQuantityTextBox";
            this.addQuantityTextBox.Size = new System.Drawing.Size(245, 29);
            this.addQuantityTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Наименование:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Категория:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Цена:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Количество:";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(45, 258);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(112, 31);
            this.OKButton.TabIndex = 8;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // ApplayButton
            // 
            this.ApplayButton.Location = new System.Drawing.Point(163, 257);
            this.ApplayButton.Name = "ApplayButton";
            this.ApplayButton.Size = new System.Drawing.Size(112, 34);
            this.ApplayButton.TabIndex = 9;
            this.ApplayButton.Text = "Применить";
            this.ApplayButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(281, 258);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(112, 33);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 306);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ApplayButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addQuantityTextBox);
            this.Controls.Add(this.addPriceTextBox);
            this.Controls.Add(this.addCategoryTextBox);
            this.Controls.Add(this.addNameTextBox);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление товара";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox addNameTextBox;
        private System.Windows.Forms.TextBox addCategoryTextBox;
        private System.Windows.Forms.TextBox addPriceTextBox;
        private System.Windows.Forms.TextBox addQuantityTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button ApplayButton;
        private System.Windows.Forms.Button CancelButton;
    }
}