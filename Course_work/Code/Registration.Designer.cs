namespace CW_windows_forms
{
    partial class Registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            this.login_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.repeat_password_label = new System.Windows.Forms.Label();
            this.born_data_label = new System.Windows.Forms.Label();
            this.login_textbox = new System.Windows.Forms.TextBox();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.repeat_password_textbox = new System.Windows.Forms.TextBox();
            this.registration_button = new System.Windows.Forms.Button();
            this.date_choose = new System.Windows.Forms.DateTimePicker();
            this.second_name_label = new System.Windows.Forms.Label();
            this.first_name_label = new System.Windows.Forms.Label();
            this.second_name_textbox = new System.Windows.Forms.TextBox();
            this.first_name_textbox = new System.Windows.Forms.TextBox();
            this.mail_label = new System.Windows.Forms.Label();
            this.mail_textbox = new System.Windows.Forms.TextBox();
            this.information_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Location = new System.Drawing.Point(248, 106);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(38, 13);
            this.login_label.TabIndex = 0;
            this.login_label.Text = "Логин";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(248, 148);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(45, 13);
            this.password_label.TabIndex = 1;
            this.password_label.Text = "Пароль";
            // 
            // repeat_password_label
            // 
            this.repeat_password_label.AutoSize = true;
            this.repeat_password_label.Location = new System.Drawing.Point(248, 189);
            this.repeat_password_label.Name = "repeat_password_label";
            this.repeat_password_label.Size = new System.Drawing.Size(100, 13);
            this.repeat_password_label.TabIndex = 2;
            this.repeat_password_label.Text = "Повторите пароль";
            // 
            // born_data_label
            // 
            this.born_data_label.AutoSize = true;
            this.born_data_label.Location = new System.Drawing.Point(248, 226);
            this.born_data_label.Name = "born_data_label";
            this.born_data_label.Size = new System.Drawing.Size(86, 13);
            this.born_data_label.TabIndex = 3;
            this.born_data_label.Text = "Дата рождения";
            // 
            // login_textbox
            // 
            this.login_textbox.Location = new System.Drawing.Point(398, 106);
            this.login_textbox.Name = "login_textbox";
            this.login_textbox.Size = new System.Drawing.Size(100, 20);
            this.login_textbox.TabIndex = 4;
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(398, 148);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.Size = new System.Drawing.Size(100, 20);
            this.password_textbox.TabIndex = 4;
            this.password_textbox.UseSystemPasswordChar = true;
            // 
            // repeat_password_textbox
            // 
            this.repeat_password_textbox.Location = new System.Drawing.Point(398, 189);
            this.repeat_password_textbox.Name = "repeat_password_textbox";
            this.repeat_password_textbox.Size = new System.Drawing.Size(100, 20);
            this.repeat_password_textbox.TabIndex = 4;
            this.repeat_password_textbox.UseSystemPasswordChar = true;
            // 
            // registration_button
            // 
            this.registration_button.Location = new System.Drawing.Point(327, 377);
            this.registration_button.Name = "registration_button";
            this.registration_button.Size = new System.Drawing.Size(133, 23);
            this.registration_button.TabIndex = 5;
            this.registration_button.Text = "Зарегистрироваться";
            this.registration_button.UseVisualStyleBackColor = true;
            this.registration_button.Click += new System.EventHandler(this.registration_button_Click);
            // 
            // date_choose
            // 
            this.date_choose.Location = new System.Drawing.Point(398, 226);
            this.date_choose.Name = "date_choose";
            this.date_choose.Size = new System.Drawing.Size(200, 20);
            this.date_choose.TabIndex = 6;
            // 
            // second_name_label
            // 
            this.second_name_label.AutoSize = true;
            this.second_name_label.Location = new System.Drawing.Point(248, 274);
            this.second_name_label.Name = "second_name_label";
            this.second_name_label.Size = new System.Drawing.Size(56, 13);
            this.second_name_label.TabIndex = 7;
            this.second_name_label.Text = "Фамилия";
            // 
            // first_name_label
            // 
            this.first_name_label.AutoSize = true;
            this.first_name_label.Location = new System.Drawing.Point(248, 317);
            this.first_name_label.Name = "first_name_label";
            this.first_name_label.Size = new System.Drawing.Size(29, 13);
            this.first_name_label.TabIndex = 8;
            this.first_name_label.Text = "Имя";
            // 
            // second_name_textbox
            // 
            this.second_name_textbox.Location = new System.Drawing.Point(398, 274);
            this.second_name_textbox.Name = "second_name_textbox";
            this.second_name_textbox.Size = new System.Drawing.Size(100, 20);
            this.second_name_textbox.TabIndex = 9;
            // 
            // first_name_textbox
            // 
            this.first_name_textbox.Location = new System.Drawing.Point(398, 310);
            this.first_name_textbox.Name = "first_name_textbox";
            this.first_name_textbox.Size = new System.Drawing.Size(100, 20);
            this.first_name_textbox.TabIndex = 10;
            // 
            // mail_label
            // 
            this.mail_label.AutoSize = true;
            this.mail_label.Location = new System.Drawing.Point(248, 65);
            this.mail_label.Name = "mail_label";
            this.mail_label.Size = new System.Drawing.Size(37, 13);
            this.mail_label.TabIndex = 11;
            this.mail_label.Text = "Почта";
            // 
            // mail_textbox
            // 
            this.mail_textbox.Location = new System.Drawing.Point(398, 65);
            this.mail_textbox.Name = "mail_textbox";
            this.mail_textbox.Size = new System.Drawing.Size(100, 20);
            this.mail_textbox.TabIndex = 12;
            // 
            // information_label
            // 
            this.information_label.AutoSize = true;
            this.information_label.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.information_label.Location = new System.Drawing.Point(190, 19);
            this.information_label.Name = "information_label";
            this.information_label.Size = new System.Drawing.Size(424, 19);
            this.information_label.TabIndex = 13;
            this.information_label.Text = "Для регистрации в системе введите ваши личные данные";
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.information_label);
            this.Controls.Add(this.mail_textbox);
            this.Controls.Add(this.mail_label);
            this.Controls.Add(this.first_name_textbox);
            this.Controls.Add(this.second_name_textbox);
            this.Controls.Add(this.first_name_label);
            this.Controls.Add(this.second_name_label);
            this.Controls.Add(this.date_choose);
            this.Controls.Add(this.registration_button);
            this.Controls.Add(this.repeat_password_textbox);
            this.Controls.Add(this.password_textbox);
            this.Controls.Add(this.login_textbox);
            this.Controls.Add(this.born_data_label);
            this.Controls.Add(this.repeat_password_label);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.login_label);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Registration_FormClosing);
            this.Load += new System.EventHandler(this.Registration_Load);
            this.SizeChanged += new System.EventHandler(this.Registration_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label repeat_password_label;
        private System.Windows.Forms.Label born_data_label;
        private System.Windows.Forms.TextBox login_textbox;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.TextBox repeat_password_textbox;
        private System.Windows.Forms.Button registration_button;
        private System.Windows.Forms.DateTimePicker date_choose;
        private System.Windows.Forms.Label second_name_label;
        private System.Windows.Forms.Label first_name_label;
        private System.Windows.Forms.TextBox second_name_textbox;
        private System.Windows.Forms.TextBox first_name_textbox;
        private System.Windows.Forms.Label mail_label;
        private System.Windows.Forms.TextBox mail_textbox;
        private System.Windows.Forms.Label information_label;
    }
}