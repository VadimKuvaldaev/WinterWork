namespace ComputerPartsShop
{
    partial class RegisterForm
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
            this.CreateButton = new System.Windows.Forms.Button();
            this.NewPasswordTextBox = new System.Windows.Forms.TextBox();
            this.NewLoginTextBox = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblNewLogin = new System.Windows.Forms.Label();
            this.NewRoleComboBox = new System.Windows.Forms.ComboBox();
            this.lblNewRole = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateButton.Location = new System.Drawing.Point(91, 261);
            this.CreateButton.Margin = new System.Windows.Forms.Padding(4);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(280, 47);
            this.CreateButton.TabIndex = 9;
            this.CreateButton.Text = "Зарегистрироваться";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click_1);
            // 
            // NewPasswordTextBox
            // 
            this.NewPasswordTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewPasswordTextBox.Location = new System.Drawing.Point(31, 100);
            this.NewPasswordTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.NewPasswordTextBox.Name = "NewPasswordTextBox";
            this.NewPasswordTextBox.Size = new System.Drawing.Size(385, 29);
            this.NewPasswordTextBox.TabIndex = 8;
            this.NewPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // NewLoginTextBox
            // 
            this.NewLoginTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewLoginTextBox.Location = new System.Drawing.Point(31, 38);
            this.NewLoginTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.NewLoginTextBox.Name = "NewLoginTextBox";
            this.NewLoginTextBox.Size = new System.Drawing.Size(385, 29);
            this.NewLoginTextBox.TabIndex = 7;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNewPassword.Location = new System.Drawing.Point(25, 75);
            this.lblNewPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(73, 21);
            this.lblNewPassword.TabIndex = 6;
            this.lblNewPassword.Text = "Пароль:";
            // 
            // lblNewLogin
            // 
            this.lblNewLogin.AutoSize = true;
            this.lblNewLogin.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNewLogin.Location = new System.Drawing.Point(25, 13);
            this.lblNewLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewLogin.Name = "lblNewLogin";
            this.lblNewLogin.Size = new System.Drawing.Size(65, 21);
            this.lblNewLogin.TabIndex = 5;
            this.lblNewLogin.Text = "Логин:";
            // 
            // NewRoleComboBox
            // 
            this.NewRoleComboBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewRoleComboBox.FormattingEnabled = true;
            this.NewRoleComboBox.Location = new System.Drawing.Point(31, 166);
            this.NewRoleComboBox.Name = "NewRoleComboBox";
            this.NewRoleComboBox.Size = new System.Drawing.Size(385, 29);
            this.NewRoleComboBox.TabIndex = 10;
            // 
            // lblNewRole
            // 
            this.lblNewRole.AutoSize = true;
            this.lblNewRole.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNewRole.Location = new System.Drawing.Point(27, 142);
            this.lblNewRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewRole.Name = "lblNewRole";
            this.lblNewRole.Size = new System.Drawing.Size(109, 21);
            this.lblNewRole.TabIndex = 11;
            this.lblNewRole.Text = "Выбор роли";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 321);
            this.Controls.Add(this.lblNewRole);
            this.Controls.Add(this.NewRoleComboBox);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.NewPasswordTextBox);
            this.Controls.Add(this.NewLoginTextBox);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblNewLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.TextBox NewPasswordTextBox;
        private System.Windows.Forms.TextBox NewLoginTextBox;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblNewLogin;
        private System.Windows.Forms.ComboBox NewRoleComboBox;
        private System.Windows.Forms.Label lblNewRole;
    }
}