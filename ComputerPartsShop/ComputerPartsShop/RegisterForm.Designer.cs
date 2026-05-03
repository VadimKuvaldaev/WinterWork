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
            this.CreateBotton = new System.Windows.Forms.Button();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.tbNewLogin = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblNewLogin = new System.Windows.Forms.Label();
            this.cbNewRole = new System.Windows.Forms.ComboBox();
            this.lblNewRole = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateBotton
            // 
            this.CreateBotton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CreateBotton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateBotton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateBotton.Location = new System.Drawing.Point(91, 261);
            this.CreateBotton.Margin = new System.Windows.Forms.Padding(4);
            this.CreateBotton.Name = "CreateBotton";
            this.CreateBotton.Size = new System.Drawing.Size(280, 47);
            this.CreateBotton.TabIndex = 9;
            this.CreateBotton.Text = "Зарегистрироваться";
            this.CreateBotton.UseVisualStyleBackColor = false;
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNewPassword.Location = new System.Drawing.Point(31, 100);
            this.tbNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.Size = new System.Drawing.Size(385, 29);
            this.tbNewPassword.TabIndex = 8;
            this.tbNewPassword.UseSystemPasswordChar = true;
            // 
            // tbNewLogin
            // 
            this.tbNewLogin.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNewLogin.Location = new System.Drawing.Point(31, 38);
            this.tbNewLogin.Margin = new System.Windows.Forms.Padding(4);
            this.tbNewLogin.Name = "tbNewLogin";
            this.tbNewLogin.Size = new System.Drawing.Size(385, 29);
            this.tbNewLogin.TabIndex = 7;
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
            // cbNewRole
            // 
            this.cbNewRole.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbNewRole.FormattingEnabled = true;
            this.cbNewRole.Items.AddRange(new object[] {
            "Admin",
            "Seller"});
            this.cbNewRole.Location = new System.Drawing.Point(31, 166);
            this.cbNewRole.Name = "cbNewRole";
            this.cbNewRole.Size = new System.Drawing.Size(385, 29);
            this.cbNewRole.TabIndex = 10;
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
            this.Controls.Add(this.cbNewRole);
            this.Controls.Add(this.CreateBotton);
            this.Controls.Add(this.tbNewPassword);
            this.Controls.Add(this.tbNewLogin);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblNewLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateBotton;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.TextBox tbNewLogin;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblNewLogin;
        private System.Windows.Forms.ComboBox cbNewRole;
        private System.Windows.Forms.Label lblNewRole;
    }
}