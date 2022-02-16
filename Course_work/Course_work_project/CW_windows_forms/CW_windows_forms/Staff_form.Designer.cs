namespace CW_windows_forms
{
    partial class Staff_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Staff_form));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходИзАккаунтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходИзПриложенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.персональныеДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.авиакомпанияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.активностьАвиакомпанииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вППToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.классификацияВППToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маршрутToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.местаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.метеопрогнозToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правилапоперевозкебагажаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рейсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.самолётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистическиеДанныеОПассажирахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статусБилетаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статусБрониToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статусСамолётаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.start_page_tabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.personal_data_tabPage = new System.Windows.Forms.TabPage();
            this.patronymic_textbox = new System.Windows.Forms.TextBox();
            this.patronymic_label = new System.Windows.Forms.Label();
            this.first_name_textbox = new System.Windows.Forms.TextBox();
            this.second_name_textbox = new System.Windows.Forms.TextBox();
            this.first_name_label = new System.Windows.Forms.Label();
            this.second_name_label = new System.Windows.Forms.Label();
            this.selphone_number_textbox = new System.Windows.Forms.TextBox();
            this.login_textbox = new System.Windows.Forms.TextBox();
            this.selphone_number = new System.Windows.Forms.Label();
            this.login_label = new System.Windows.Forms.Label();
            this.tables_tabPage = new System.Windows.Forms.TabPage();
            this.full_name_label = new System.Windows.Forms.Label();
            this.tables_dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.start_page_tabPage.SuspendLayout();
            this.personal_data_tabPage.SuspendLayout();
            this.tables_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tables_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.сотрудникToolStripMenuItem,
            this.таблицыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1234, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходИзАккаунтаToolStripMenuItem,
            this.выходИзПриложенияToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходИзАккаунтаToolStripMenuItem
            // 
            this.выходИзАккаунтаToolStripMenuItem.Name = "выходИзАккаунтаToolStripMenuItem";
            this.выходИзАккаунтаToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.выходИзАккаунтаToolStripMenuItem.Text = "Выход из аккаунта";
            this.выходИзАккаунтаToolStripMenuItem.Click += new System.EventHandler(this.выходИзАккаунтаToolStripMenuItem_Click);
            // 
            // выходИзПриложенияToolStripMenuItem
            // 
            this.выходИзПриложенияToolStripMenuItem.Name = "выходИзПриложенияToolStripMenuItem";
            this.выходИзПриложенияToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.выходИзПриложенияToolStripMenuItem.Text = "Выход из приложения";
            this.выходИзПриложенияToolStripMenuItem.Click += new System.EventHandler(this.выходИзПриложенияToolStripMenuItem_Click);
            // 
            // сотрудникToolStripMenuItem
            // 
            this.сотрудникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.персональныеДанныеToolStripMenuItem});
            this.сотрудникToolStripMenuItem.Name = "сотрудникToolStripMenuItem";
            this.сотрудникToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.сотрудникToolStripMenuItem.Text = "Сотрудник";
            // 
            // персональныеДанныеToolStripMenuItem
            // 
            this.персональныеДанныеToolStripMenuItem.Name = "персональныеДанныеToolStripMenuItem";
            this.персональныеДанныеToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.персональныеДанныеToolStripMenuItem.Text = "Персональные данные";
            this.персональныеДанныеToolStripMenuItem.Click += new System.EventHandler(this.персональныеДанныеToolStripMenuItem_Click);
            // 
            // таблицыToolStripMenuItem
            // 
            this.таблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.авиакомпанияToolStripMenuItem,
            this.активностьАвиакомпанииToolStripMenuItem,
            this.вППToolStripMenuItem,
            this.классификацияВППToolStripMenuItem,
            this.маршрутToolStripMenuItem,
            this.местаToolStripMenuItem,
            this.метеопрогнозToolStripMenuItem,
            this.правилапоперевозкебагажаToolStripMenuItem,
            this.рейсToolStripMenuItem,
            this.самолётToolStripMenuItem,
            this.статистическиеДанныеОПассажирахToolStripMenuItem,
            this.статусБилетаToolStripMenuItem,
            this.статусБрониToolStripMenuItem,
            this.статусСамолётаToolStripMenuItem});
            this.таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            this.таблицыToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.таблицыToolStripMenuItem.Text = "Таблицы";
            // 
            // авиакомпанияToolStripMenuItem
            // 
            this.авиакомпанияToolStripMenuItem.Name = "авиакомпанияToolStripMenuItem";
            this.авиакомпанияToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.авиакомпанияToolStripMenuItem.Text = "Авиакомпания";
            this.авиакомпанияToolStripMenuItem.Click += new System.EventHandler(this.авиакомпанияToolStripMenuItem_Click);
            // 
            // активностьАвиакомпанииToolStripMenuItem
            // 
            this.активностьАвиакомпанииToolStripMenuItem.Name = "активностьАвиакомпанииToolStripMenuItem";
            this.активностьАвиакомпанииToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.активностьАвиакомпанииToolStripMenuItem.Text = "Активность авиакомпании";
            this.активностьАвиакомпанииToolStripMenuItem.Click += new System.EventHandler(this.активностьАвиакомпанииToolStripMenuItem_Click);
            // 
            // вППToolStripMenuItem
            // 
            this.вППToolStripMenuItem.Name = "вППToolStripMenuItem";
            this.вППToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.вППToolStripMenuItem.Text = "ВПП";
            this.вППToolStripMenuItem.Click += new System.EventHandler(this.вППToolStripMenuItem_Click);
            // 
            // классификацияВППToolStripMenuItem
            // 
            this.классификацияВППToolStripMenuItem.Name = "классификацияВППToolStripMenuItem";
            this.классификацияВППToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.классификацияВППToolStripMenuItem.Text = "Классификация ВПП";
            this.классификацияВППToolStripMenuItem.Click += new System.EventHandler(this.классификацияВППToolStripMenuItem_Click);
            // 
            // маршрутToolStripMenuItem
            // 
            this.маршрутToolStripMenuItem.Name = "маршрутToolStripMenuItem";
            this.маршрутToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.маршрутToolStripMenuItem.Text = "Маршрут";
            this.маршрутToolStripMenuItem.Click += new System.EventHandler(this.маршрутToolStripMenuItem_Click);
            // 
            // местаToolStripMenuItem
            // 
            this.местаToolStripMenuItem.Name = "местаToolStripMenuItem";
            this.местаToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.местаToolStripMenuItem.Text = "Места";
            this.местаToolStripMenuItem.Click += new System.EventHandler(this.местаToolStripMenuItem_Click);
            // 
            // метеопрогнозToolStripMenuItem
            // 
            this.метеопрогнозToolStripMenuItem.Name = "метеопрогнозToolStripMenuItem";
            this.метеопрогнозToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.метеопрогнозToolStripMenuItem.Text = "Метеопрогноз";
            this.метеопрогнозToolStripMenuItem.Click += new System.EventHandler(this.метеопрогнозToolStripMenuItem_Click);
            // 
            // правилапоперевозкебагажаToolStripMenuItem
            // 
            this.правилапоперевозкебагажаToolStripMenuItem.Name = "правилапоперевозкебагажаToolStripMenuItem";
            this.правилапоперевозкебагажаToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.правилапоперевозкебагажаToolStripMenuItem.Text = "Правила_по_перевозке_багажа";
            this.правилапоперевозкебагажаToolStripMenuItem.Click += new System.EventHandler(this.правилапоперевозкебагажаToolStripMenuItem_Click);
            // 
            // рейсToolStripMenuItem
            // 
            this.рейсToolStripMenuItem.Name = "рейсToolStripMenuItem";
            this.рейсToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.рейсToolStripMenuItem.Text = "Рейс";
            this.рейсToolStripMenuItem.Click += new System.EventHandler(this.рейсToolStripMenuItem_Click);
            // 
            // самолётToolStripMenuItem
            // 
            this.самолётToolStripMenuItem.Name = "самолётToolStripMenuItem";
            this.самолётToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.самолётToolStripMenuItem.Text = "Самолёт";
            this.самолётToolStripMenuItem.Click += new System.EventHandler(this.самолётToolStripMenuItem_Click);
            // 
            // статистическиеДанныеОПассажирахToolStripMenuItem
            // 
            this.статистическиеДанныеОПассажирахToolStripMenuItem.Name = "статистическиеДанныеОПассажирахToolStripMenuItem";
            this.статистическиеДанныеОПассажирахToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.статистическиеДанныеОПассажирахToolStripMenuItem.Text = "Статистические данные о пассажирах";
            this.статистическиеДанныеОПассажирахToolStripMenuItem.Click += new System.EventHandler(this.статистическиеДанныеОПассажирахToolStripMenuItem_Click);
            // 
            // статусБилетаToolStripMenuItem
            // 
            this.статусБилетаToolStripMenuItem.Name = "статусБилетаToolStripMenuItem";
            this.статусБилетаToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.статусБилетаToolStripMenuItem.Text = "Статус билета";
            this.статусБилетаToolStripMenuItem.Click += new System.EventHandler(this.статусБилетаToolStripMenuItem_Click);
            // 
            // статусБрониToolStripMenuItem
            // 
            this.статусБрониToolStripMenuItem.Name = "статусБрониToolStripMenuItem";
            this.статусБрониToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.статусБрониToolStripMenuItem.Text = "Статус брони";
            this.статусБрониToolStripMenuItem.Click += new System.EventHandler(this.статусБрониToolStripMenuItem_Click);
            // 
            // статусСамолётаToolStripMenuItem
            // 
            this.статусСамолётаToolStripMenuItem.Name = "статусСамолётаToolStripMenuItem";
            this.статусСамолётаToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.статусСамолётаToolStripMenuItem.Text = "Статус самолёта";
            this.статусСамолётаToolStripMenuItem.Click += new System.EventHandler(this.статусСамолётаToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.start_page_tabPage);
            this.tabControl1.Controls.Add(this.personal_data_tabPage);
            this.tabControl1.Controls.Add(this.tables_tabPage);
            this.tabControl1.Location = new System.Drawing.Point(13, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1060, 620);
            this.tabControl1.TabIndex = 1;
            // 
            // start_page_tabPage
            // 
            this.start_page_tabPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.start_page_tabPage.Controls.Add(this.label1);
            this.start_page_tabPage.Location = new System.Drawing.Point(4, 22);
            this.start_page_tabPage.Name = "start_page_tabPage";
            this.start_page_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.start_page_tabPage.Size = new System.Drawing.Size(1052, 594);
            this.start_page_tabPage.TabIndex = 2;
            this.start_page_tabPage.Text = "Начальная страница";
            this.start_page_tabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(270, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(528, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Добро пожаловать на сайт аэропорта!";
            // 
            // personal_data_tabPage
            // 
            this.personal_data_tabPage.Controls.Add(this.patronymic_textbox);
            this.personal_data_tabPage.Controls.Add(this.patronymic_label);
            this.personal_data_tabPage.Controls.Add(this.first_name_textbox);
            this.personal_data_tabPage.Controls.Add(this.second_name_textbox);
            this.personal_data_tabPage.Controls.Add(this.first_name_label);
            this.personal_data_tabPage.Controls.Add(this.second_name_label);
            this.personal_data_tabPage.Controls.Add(this.selphone_number_textbox);
            this.personal_data_tabPage.Controls.Add(this.login_textbox);
            this.personal_data_tabPage.Controls.Add(this.selphone_number);
            this.personal_data_tabPage.Controls.Add(this.login_label);
            this.personal_data_tabPage.Location = new System.Drawing.Point(4, 22);
            this.personal_data_tabPage.Name = "personal_data_tabPage";
            this.personal_data_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.personal_data_tabPage.Size = new System.Drawing.Size(1052, 594);
            this.personal_data_tabPage.TabIndex = 0;
            this.personal_data_tabPage.Text = "Персональные данные";
            this.personal_data_tabPage.UseVisualStyleBackColor = true;
            // 
            // patronymic_textbox
            // 
            this.patronymic_textbox.Location = new System.Drawing.Point(563, 368);
            this.patronymic_textbox.Name = "patronymic_textbox";
            this.patronymic_textbox.Size = new System.Drawing.Size(100, 20);
            this.patronymic_textbox.TabIndex = 39;
            // 
            // patronymic_label
            // 
            this.patronymic_label.AutoSize = true;
            this.patronymic_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.patronymic_label.Location = new System.Drawing.Point(413, 368);
            this.patronymic_label.Name = "patronymic_label";
            this.patronymic_label.Size = new System.Drawing.Size(54, 13);
            this.patronymic_label.TabIndex = 38;
            this.patronymic_label.Text = "Отчество";
            // 
            // first_name_textbox
            // 
            this.first_name_textbox.Location = new System.Drawing.Point(563, 325);
            this.first_name_textbox.Name = "first_name_textbox";
            this.first_name_textbox.Size = new System.Drawing.Size(100, 20);
            this.first_name_textbox.TabIndex = 37;
            // 
            // second_name_textbox
            // 
            this.second_name_textbox.Location = new System.Drawing.Point(563, 285);
            this.second_name_textbox.Name = "second_name_textbox";
            this.second_name_textbox.Size = new System.Drawing.Size(100, 20);
            this.second_name_textbox.TabIndex = 36;
            // 
            // first_name_label
            // 
            this.first_name_label.AutoSize = true;
            this.first_name_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.first_name_label.Location = new System.Drawing.Point(413, 328);
            this.first_name_label.Name = "first_name_label";
            this.first_name_label.Size = new System.Drawing.Size(29, 13);
            this.first_name_label.TabIndex = 35;
            this.first_name_label.Text = "Имя";
            // 
            // second_name_label
            // 
            this.second_name_label.AutoSize = true;
            this.second_name_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.second_name_label.Location = new System.Drawing.Point(413, 285);
            this.second_name_label.Name = "second_name_label";
            this.second_name_label.Size = new System.Drawing.Size(56, 13);
            this.second_name_label.TabIndex = 34;
            this.second_name_label.Text = "Фамилия";
            // 
            // selphone_number_textbox
            // 
            this.selphone_number_textbox.Location = new System.Drawing.Point(563, 241);
            this.selphone_number_textbox.Name = "selphone_number_textbox";
            this.selphone_number_textbox.Size = new System.Drawing.Size(100, 20);
            this.selphone_number_textbox.TabIndex = 31;
            // 
            // login_textbox
            // 
            this.login_textbox.Location = new System.Drawing.Point(563, 198);
            this.login_textbox.Name = "login_textbox";
            this.login_textbox.Size = new System.Drawing.Size(100, 20);
            this.login_textbox.TabIndex = 33;
            // 
            // selphone_number
            // 
            this.selphone_number.AutoSize = true;
            this.selphone_number.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.selphone_number.Location = new System.Drawing.Point(413, 241);
            this.selphone_number.Name = "selphone_number";
            this.selphone_number.Size = new System.Drawing.Size(93, 13);
            this.selphone_number.TabIndex = 30;
            this.selphone_number.Text = "Номер телефона";
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.login_label.Location = new System.Drawing.Point(413, 198);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(38, 13);
            this.login_label.TabIndex = 28;
            this.login_label.Text = "Логин";
            // 
            // tables_tabPage
            // 
            this.tables_tabPage.Controls.Add(this.tables_dataGridView);
            this.tables_tabPage.Location = new System.Drawing.Point(4, 22);
            this.tables_tabPage.Name = "tables_tabPage";
            this.tables_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tables_tabPage.Size = new System.Drawing.Size(1052, 594);
            this.tables_tabPage.TabIndex = 1;
            this.tables_tabPage.Text = "Таблицы";
            this.tables_tabPage.UseVisualStyleBackColor = true;
            // 
            // full_name_label
            // 
            this.full_name_label.AutoSize = true;
            this.full_name_label.Location = new System.Drawing.Point(1132, 50);
            this.full_name_label.Name = "full_name_label";
            this.full_name_label.Size = new System.Drawing.Size(34, 13);
            this.full_name_label.TabIndex = 2;
            this.full_name_label.Text = "ФИО";
            // 
            // tables_dataGridView
            // 
            this.tables_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.tables_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tables_dataGridView.Location = new System.Drawing.Point(7, 7);
            this.tables_dataGridView.Name = "tables_dataGridView";
            this.tables_dataGridView.Size = new System.Drawing.Size(805, 580);
            this.tables_dataGridView.TabIndex = 0;
            // 
            // Staff_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 661);
            this.Controls.Add(this.full_name_label);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Staff_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База данных аэропорта - Сотрудник";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Staff_form_FormClosing);
            this.Load += new System.EventHandler(this.Staff_form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.start_page_tabPage.ResumeLayout(false);
            this.start_page_tabPage.PerformLayout();
            this.personal_data_tabPage.ResumeLayout(false);
            this.personal_data_tabPage.PerformLayout();
            this.tables_tabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tables_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходИзАккаунтаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходИзПриложенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem персональныеДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem авиакомпанияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem активностьАвиакомпанииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вППToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem классификацияВППToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem маршрутToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem местаToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage personal_data_tabPage;
        private System.Windows.Forms.TabPage tables_tabPage;
        private System.Windows.Forms.ToolStripMenuItem метеопрогнозToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правилапоперевозкебагажаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рейсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem самолётToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистическиеДанныеОПассажирахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статусБилетаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статусБрониToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статусСамолётаToolStripMenuItem;
        private System.Windows.Forms.TextBox patronymic_textbox;
        private System.Windows.Forms.Label patronymic_label;
        private System.Windows.Forms.TextBox first_name_textbox;
        private System.Windows.Forms.TextBox second_name_textbox;
        private System.Windows.Forms.Label first_name_label;
        private System.Windows.Forms.Label second_name_label;
        private System.Windows.Forms.TextBox selphone_number_textbox;
        private System.Windows.Forms.TextBox login_textbox;
        private System.Windows.Forms.Label selphone_number;
        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.Label full_name_label;
        private System.Windows.Forms.TabPage start_page_tabPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tables_dataGridView;
    }
}