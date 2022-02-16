namespace CW_windows_forms
{
    partial class Autorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Autorization));
            this.mail_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.autorization_button = new System.Windows.Forms.Button();
            this.mail_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.hello_label = new System.Windows.Forms.Label();
            this.stay_in_system_checkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mail_textBox
            // 
            this.mail_textBox.Location = new System.Drawing.Point(175, 130);
            this.mail_textBox.Name = "mail_textBox";
            this.mail_textBox.Size = new System.Drawing.Size(100, 20);
            this.mail_textBox.TabIndex = 0;
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(175, 169);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(100, 20);
            this.password_textBox.TabIndex = 1;
            this.password_textBox.UseSystemPasswordChar = true;
            // 
            // autorization_button
            // 
            this.autorization_button.Location = new System.Drawing.Point(185, 249);
            this.autorization_button.Name = "autorization_button";
            this.autorization_button.Size = new System.Drawing.Size(75, 23);
            this.autorization_button.TabIndex = 2;
            this.autorization_button.Text = "Войти";
            this.autorization_button.UseVisualStyleBackColor = true;
            this.autorization_button.Click += new System.EventHandler(this.autorization_button_Click);
            // 
            // mail_label
            // 
            this.mail_label.AutoSize = true;
            this.mail_label.Location = new System.Drawing.Point(81, 137);
            this.mail_label.Name = "mail_label";
            this.mail_label.Size = new System.Drawing.Size(37, 13);
            this.mail_label.TabIndex = 3;
            this.mail_label.Text = "Почта";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(81, 176);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(45, 13);
            this.password_label.TabIndex = 4;
            this.password_label.Text = "Пароль";
            // 
            // hello_label
            // 
            this.hello_label.AutoSize = true;
            this.hello_label.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hello_label.Location = new System.Drawing.Point(21, 37);
            this.hello_label.Name = "hello_label";
            this.hello_label.Size = new System.Drawing.Size(347, 38);
            this.hello_label.TabIndex = 5;
            this.hello_label.Text = "Добро пожаловать на сайт аэропорта!\r\nДля авторизации введите вашу почту и пароль";
            // 
            // stay_in_system_checkBox
            // 
            this.stay_in_system_checkBox.AutoSize = true;
            this.stay_in_system_checkBox.Location = new System.Drawing.Point(145, 212);
            this.stay_in_system_checkBox.Name = "stay_in_system_checkBox";
            this.stay_in_system_checkBox.Size = new System.Drawing.Size(160, 17);
            this.stay_in_system_checkBox.TabIndex = 6;
            this.stay_in_system_checkBox.Text = "Запомнить почту и пароль";
            this.stay_in_system_checkBox.UseVisualStyleBackColor = true;
            // 
            // Autorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(380, 322);
            this.Controls.Add(this.stay_in_system_checkBox);
            this.Controls.Add(this.hello_label);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.mail_label);
            this.Controls.Add(this.autorization_button);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.mail_textBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Autorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Autorization_FormClosing);
            this.Load += new System.EventHandler(this.Autorization_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mail_textBox;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Button autorization_button;
        private System.Windows.Forms.Label mail_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label hello_label;
        private System.Windows.Forms.CheckBox stay_in_system_checkBox;
    }
}