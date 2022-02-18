namespace CW_windows_forms
{
    partial class Start_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start_form));
            this.registration_button = new System.Windows.Forms.Button();
            this.login_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // registration_button
            // 
            this.registration_button.Location = new System.Drawing.Point(97, 36);
            this.registration_button.Name = "registration_button";
            this.registration_button.Size = new System.Drawing.Size(129, 23);
            this.registration_button.TabIndex = 0;
            this.registration_button.Text = "Зарегистрироваться";
            this.registration_button.UseVisualStyleBackColor = true;
            this.registration_button.Click += new System.EventHandler(this.registration_button_Click);
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(97, 79);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(129, 23);
            this.login_button.TabIndex = 1;
            this.login_button.Text = "Войти";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // Start_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.registration_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Start_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Начальная форма";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Start_form_FormClosing);
            this.Load += new System.EventHandler(this.Start_form_Load);
            this.SizeChanged += new System.EventHandler(this.Start_form_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button registration_button;
        private System.Windows.Forms.Button login_button;
    }
}