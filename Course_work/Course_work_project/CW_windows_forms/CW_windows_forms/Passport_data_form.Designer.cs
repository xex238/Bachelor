namespace CW_windows_forms
{
    partial class Passport_data_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Passport_data_form));
            this.series_passport_label = new System.Windows.Forms.Label();
            this.number_passport_label = new System.Windows.Forms.Label();
            this.series_passport_textBox = new System.Windows.Forms.TextBox();
            this.number_passport_textBox = new System.Windows.Forms.TextBox();
            this.information_label = new System.Windows.Forms.Label();
            this.accept_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // series_passport_label
            // 
            this.series_passport_label.AutoSize = true;
            this.series_passport_label.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.series_passport_label.Location = new System.Drawing.Point(178, 85);
            this.series_passport_label.Name = "series_passport_label";
            this.series_passport_label.Size = new System.Drawing.Size(92, 14);
            this.series_passport_label.TabIndex = 0;
            this.series_passport_label.Text = "Серия паспорта";
            // 
            // number_passport_label
            // 
            this.number_passport_label.AutoSize = true;
            this.number_passport_label.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number_passport_label.Location = new System.Drawing.Point(178, 145);
            this.number_passport_label.Name = "number_passport_label";
            this.number_passport_label.Size = new System.Drawing.Size(97, 14);
            this.number_passport_label.TabIndex = 1;
            this.number_passport_label.Text = "Номер паспорта";
            // 
            // series_passport_textBox
            // 
            this.series_passport_textBox.Location = new System.Drawing.Point(303, 85);
            this.series_passport_textBox.Name = "series_passport_textBox";
            this.series_passport_textBox.Size = new System.Drawing.Size(100, 20);
            this.series_passport_textBox.TabIndex = 2;
            // 
            // number_passport_textBox
            // 
            this.number_passport_textBox.Location = new System.Drawing.Point(303, 140);
            this.number_passport_textBox.Name = "number_passport_textBox";
            this.number_passport_textBox.Size = new System.Drawing.Size(100, 20);
            this.number_passport_textBox.TabIndex = 3;
            // 
            // information_label
            // 
            this.information_label.AutoSize = true;
            this.information_label.Font = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.information_label.Location = new System.Drawing.Point(140, 29);
            this.information_label.Name = "information_label";
            this.information_label.Size = new System.Drawing.Size(304, 23);
            this.information_label.TabIndex = 4;
            this.information_label.Text = "Введите Ваши паспортные данные";
            // 
            // accept_button
            // 
            this.accept_button.Location = new System.Drawing.Point(241, 194);
            this.accept_button.Name = "accept_button";
            this.accept_button.Size = new System.Drawing.Size(90, 23);
            this.accept_button.TabIndex = 5;
            this.accept_button.Text = "Принять";
            this.accept_button.UseVisualStyleBackColor = true;
            this.accept_button.Click += new System.EventHandler(this.accept_button_Click);
            // 
            // Passport_data_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.accept_button);
            this.Controls.Add(this.information_label);
            this.Controls.Add(this.number_passport_textBox);
            this.Controls.Add(this.series_passport_textBox);
            this.Controls.Add(this.number_passport_label);
            this.Controls.Add(this.series_passport_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Passport_data_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввод паспортных данных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label series_passport_label;
        private System.Windows.Forms.Label number_passport_label;
        private System.Windows.Forms.TextBox series_passport_textBox;
        private System.Windows.Forms.TextBox number_passport_textBox;
        private System.Windows.Forms.Label information_label;
        private System.Windows.Forms.Button accept_button;
    }
}