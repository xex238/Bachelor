namespace CW_windows_forms
{
    partial class User_form
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
            type_of_places_context_menu_strip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(type_of_places_context_menu_strip_ItemClicked);
            choose_class_context_menu_strip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(choose_class_context_menu_strip_ItemClicked);

            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_form));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходИзАккаунтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хреньToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моиБилетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моиБрониToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.персональныеДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.аэропортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рейсыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расценкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.опцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тёмнаяТемаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.светлаяТемаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.установитьСвоюТемуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.билетBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.airportDB_2DataSet1 = new CW_windows_forms.AirportDB_2DataSet1();
            this.билетTableAdapter = new CW_windows_forms.AirportDB_2DataSet1TableAdapters.БилетTableAdapter();
            this.start_page = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.personal_data_tabPage = new System.Windows.Forms.TabPage();
            this.old_password_textBox = new System.Windows.Forms.TextBox();
            this.change_label = new System.Windows.Forms.Label();
            this.patronymic_textbox = new System.Windows.Forms.TextBox();
            this.patronymic_label = new System.Windows.Forms.Label();
            this.first_name_textbox = new System.Windows.Forms.TextBox();
            this.second_name_textbox = new System.Windows.Forms.TextBox();
            this.first_name_label = new System.Windows.Forms.Label();
            this.second_name_label = new System.Windows.Forms.Label();
            this.update_button = new System.Windows.Forms.Button();
            this.selphone_number_textbox = new System.Windows.Forms.TextBox();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.login_textbox = new System.Windows.Forms.TextBox();
            this.selphone_number = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.login_label = new System.Windows.Forms.Label();
            this.my_tickets_page = new System.Windows.Forms.TabPage();
            this.show_active_tickets_button = new System.Windows.Forms.Button();
            this.show_my_reservations_button = new System.Windows.Forms.Button();
            this.show_my_tickets_button = new System.Windows.Forms.Button();
            this.user_dataGridView = new System.Windows.Forms.DataGridView();
            this.buy_ticket_tabPage = new System.Windows.Forms.TabPage();
            this.reservation_ticket_button = new System.Windows.Forms.Button();
            this.buy_ticket_button = new System.Windows.Forms.Button();
            this.choose_class_button = new System.Windows.Forms.Button();
            this.information_label2 = new System.Windows.Forms.Label();
            this.information_label1 = new System.Windows.Forms.Label();
            this.choose_floght_button = new System.Windows.Forms.Button();
            this.type_of_places_button = new System.Windows.Forms.Button();
            this.airport_arrive_textBox = new System.Windows.Forms.TextBox();
            this.airport_depart_textBox = new System.Windows.Forms.TextBox();
            this.airport_arrive_label = new System.Windows.Forms.Label();
            this.airport_depart_label = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.select_data_label = new System.Windows.Forms.Label();
            this.select_data_button = new System.Windows.Forms.Button();
            this.airport_dataGridView = new System.Windows.Forms.DataGridView();
            this.reference_page = new System.Windows.Forms.TabPage();
            this.reference_label = new System.Windows.Forms.Label();
            this.registration_label = new System.Windows.Forms.Label();
            this.show_active_reservations_button = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.билетBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.airportDB_2DataSet1)).BeginInit();
            this.start_page.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.personal_data_tabPage.SuspendLayout();
            this.my_tickets_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_dataGridView)).BeginInit();
            this.buy_ticket_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.airport_dataGridView)).BeginInit();
            this.reference_page.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem,
            this.хреньToolStripMenuItem,
            this.аэропортToolStripMenuItem,
            this.опцииToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1234, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходИзАккаунтаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ToolStripMenuItem.Text = "Файл";
            // 
            // выходИзАккаунтаToolStripMenuItem
            // 
            this.выходИзАккаунтаToolStripMenuItem.Name = "выходИзАккаунтаToolStripMenuItem";
            this.выходИзАккаунтаToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.выходИзАккаунтаToolStripMenuItem.Text = "Выход из аккаунта";
            this.выходИзАккаунтаToolStripMenuItem.Click += new System.EventHandler(this.выходИзАккаунтаToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.выходToolStripMenuItem.Text = "Выход из приложения";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // хреньToolStripMenuItem
            // 
            this.хреньToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.моиБилетыToolStripMenuItem,
            this.моиБрониToolStripMenuItem,
            this.toolStripMenuItem1,
            this.персональныеДанныеToolStripMenuItem});
            this.хреньToolStripMenuItem.Name = "хреньToolStripMenuItem";
            this.хреньToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.хреньToolStripMenuItem.Text = "Пользователь";
            // 
            // моиБилетыToolStripMenuItem
            // 
            this.моиБилетыToolStripMenuItem.Name = "моиБилетыToolStripMenuItem";
            this.моиБилетыToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.моиБилетыToolStripMenuItem.Text = "Мои билеты";
            this.моиБилетыToolStripMenuItem.Click += new System.EventHandler(this.моиБилетыToolStripMenuItem_Click);
            // 
            // моиБрониToolStripMenuItem
            // 
            this.моиБрониToolStripMenuItem.Name = "моиБрониToolStripMenuItem";
            this.моиБрониToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.моиБрониToolStripMenuItem.Text = "Мои брони";
            this.моиБрониToolStripMenuItem.Click += new System.EventHandler(this.моиБрониToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(198, 6);
            // 
            // персональныеДанныеToolStripMenuItem
            // 
            this.персональныеДанныеToolStripMenuItem.Name = "персональныеДанныеToolStripMenuItem";
            this.персональныеДанныеToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.персональныеДанныеToolStripMenuItem.Text = "Персональные данные";
            this.персональныеДанныеToolStripMenuItem.Click += new System.EventHandler(this.персональныеДанныеToolStripMenuItem_Click);
            // 
            // аэропортToolStripMenuItem
            // 
            this.аэропортToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.рейсыToolStripMenuItem,
            this.расценкиToolStripMenuItem});
            this.аэропортToolStripMenuItem.Name = "аэропортToolStripMenuItem";
            this.аэропортToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.аэропортToolStripMenuItem.Text = "Аэропорт";
            // 
            // рейсыToolStripMenuItem
            // 
            this.рейсыToolStripMenuItem.Name = "рейсыToolStripMenuItem";
            this.рейсыToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.рейсыToolStripMenuItem.Text = "Рейсы";
            this.рейсыToolStripMenuItem.Click += new System.EventHandler(this.рейсыToolStripMenuItem_Click);
            // 
            // расценкиToolStripMenuItem
            // 
            this.расценкиToolStripMenuItem.Name = "расценкиToolStripMenuItem";
            this.расценкиToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.расценкиToolStripMenuItem.Text = "Расценки";
            this.расценкиToolStripMenuItem.Click += new System.EventHandler(this.расценкиToolStripMenuItem_Click);
            // 
            // опцииToolStripMenuItem
            // 
            this.опцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem});
            this.опцииToolStripMenuItem.Name = "опцииToolStripMenuItem";
            this.опцииToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.опцииToolStripMenuItem.Text = "Опции";
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тёмнаяТемаToolStripMenuItem,
            this.светлаяТемаToolStripMenuItem,
            this.установитьСвоюТемуToolStripMenuItem});
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.изменитьToolStripMenuItem.Text = "Тема";
            // 
            // тёмнаяТемаToolStripMenuItem
            // 
            this.тёмнаяТемаToolStripMenuItem.Name = "тёмнаяТемаToolStripMenuItem";
            this.тёмнаяТемаToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.тёмнаяТемаToolStripMenuItem.Text = "Тёмная тема";
            this.тёмнаяТемаToolStripMenuItem.Click += new System.EventHandler(this.тёмнаяТемаToolStripMenuItem_Click);
            // 
            // светлаяТемаToolStripMenuItem
            // 
            this.светлаяТемаToolStripMenuItem.Name = "светлаяТемаToolStripMenuItem";
            this.светлаяТемаToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.светлаяТемаToolStripMenuItem.Text = "Светлая тема";
            this.светлаяТемаToolStripMenuItem.Click += new System.EventHandler(this.светлаяТемаToolStripMenuItem_Click);
            // 
            // установитьСвоюТемуToolStripMenuItem
            // 
            this.установитьСвоюТемуToolStripMenuItem.Name = "установитьСвоюТемуToolStripMenuItem";
            this.установитьСвоюТемуToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.установитьСвоюТемуToolStripMenuItem.Text = "Установить свою тему";
            this.установитьСвоюТемуToolStripMenuItem.Click += new System.EventHandler(this.установитьСвоюТемуToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // билетBindingSource
            // 
            this.билетBindingSource.DataMember = "Билет";
            this.билетBindingSource.DataSource = this.airportDB_2DataSet1;
            // 
            // airportDB_2DataSet1
            // 
            this.airportDB_2DataSet1.DataSetName = "AirportDB_2DataSet1";
            this.airportDB_2DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // билетTableAdapter
            // 
            this.билетTableAdapter.ClearBeforeFill = true;
            // 
            // start_page
            // 
            this.start_page.AutoScroll = true;
            this.start_page.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.start_page.Controls.Add(this.label1);
            this.start_page.Location = new System.Drawing.Point(4, 22);
            this.start_page.Name = "start_page";
            this.start_page.Padding = new System.Windows.Forms.Padding(3);
            this.start_page.Size = new System.Drawing.Size(1052, 594);
            this.start_page.TabIndex = 0;
            this.start_page.Text = "Начальная страница";
            this.start_page.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(270, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(528, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Добро пожаловать на сайт аэропорта!";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.start_page);
            this.tabControl1.Controls.Add(this.personal_data_tabPage);
            this.tabControl1.Controls.Add(this.my_tickets_page);
            this.tabControl1.Controls.Add(this.buy_ticket_tabPage);
            this.tabControl1.Controls.Add(this.reference_page);
            this.tabControl1.Location = new System.Drawing.Point(13, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1060, 620);
            this.tabControl1.TabIndex = 3;
            // 
            // personal_data_tabPage
            // 
            this.personal_data_tabPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.personal_data_tabPage.Controls.Add(this.old_password_textBox);
            this.personal_data_tabPage.Controls.Add(this.change_label);
            this.personal_data_tabPage.Controls.Add(this.patronymic_textbox);
            this.personal_data_tabPage.Controls.Add(this.patronymic_label);
            this.personal_data_tabPage.Controls.Add(this.first_name_textbox);
            this.personal_data_tabPage.Controls.Add(this.second_name_textbox);
            this.personal_data_tabPage.Controls.Add(this.first_name_label);
            this.personal_data_tabPage.Controls.Add(this.second_name_label);
            this.personal_data_tabPage.Controls.Add(this.update_button);
            this.personal_data_tabPage.Controls.Add(this.selphone_number_textbox);
            this.personal_data_tabPage.Controls.Add(this.password_textbox);
            this.personal_data_tabPage.Controls.Add(this.login_textbox);
            this.personal_data_tabPage.Controls.Add(this.selphone_number);
            this.personal_data_tabPage.Controls.Add(this.password_label);
            this.personal_data_tabPage.Controls.Add(this.login_label);
            this.personal_data_tabPage.Location = new System.Drawing.Point(4, 22);
            this.personal_data_tabPage.Name = "personal_data_tabPage";
            this.personal_data_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.personal_data_tabPage.Size = new System.Drawing.Size(1052, 594);
            this.personal_data_tabPage.TabIndex = 4;
            this.personal_data_tabPage.Text = "Персональные данные";
            this.personal_data_tabPage.UseVisualStyleBackColor = true;
            // 
            // old_password_textBox
            // 
            this.old_password_textBox.Location = new System.Drawing.Point(501, 400);
            this.old_password_textBox.Name = "old_password_textBox";
            this.old_password_textBox.Size = new System.Drawing.Size(100, 20);
            this.old_password_textBox.TabIndex = 29;
            this.old_password_textBox.UseSystemPasswordChar = true;
            // 
            // change_label
            // 
            this.change_label.AutoSize = true;
            this.change_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.change_label.Location = new System.Drawing.Point(408, 364);
            this.change_label.Name = "change_label";
            this.change_label.Size = new System.Drawing.Size(331, 13);
            this.change_label.TabIndex = 28;
            this.change_label.Text = "Для изменений пароля необходимо ввести Ваш старый пароль";
            // 
            // patronymic_textbox
            // 
            this.patronymic_textbox.Location = new System.Drawing.Point(578, 318);
            this.patronymic_textbox.Name = "patronymic_textbox";
            this.patronymic_textbox.Size = new System.Drawing.Size(100, 20);
            this.patronymic_textbox.TabIndex = 27;
            // 
            // patronymic_label
            // 
            this.patronymic_label.AutoSize = true;
            this.patronymic_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.patronymic_label.Location = new System.Drawing.Point(428, 318);
            this.patronymic_label.Name = "patronymic_label";
            this.patronymic_label.Size = new System.Drawing.Size(54, 13);
            this.patronymic_label.TabIndex = 26;
            this.patronymic_label.Text = "Отчество";
            // 
            // first_name_textbox
            // 
            this.first_name_textbox.Location = new System.Drawing.Point(578, 281);
            this.first_name_textbox.Name = "first_name_textbox";
            this.first_name_textbox.Size = new System.Drawing.Size(100, 20);
            this.first_name_textbox.TabIndex = 25;
            // 
            // second_name_textbox
            // 
            this.second_name_textbox.Location = new System.Drawing.Point(578, 241);
            this.second_name_textbox.Name = "second_name_textbox";
            this.second_name_textbox.Size = new System.Drawing.Size(100, 20);
            this.second_name_textbox.TabIndex = 24;
            // 
            // first_name_label
            // 
            this.first_name_label.AutoSize = true;
            this.first_name_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.first_name_label.Location = new System.Drawing.Point(428, 284);
            this.first_name_label.Name = "first_name_label";
            this.first_name_label.Size = new System.Drawing.Size(29, 13);
            this.first_name_label.TabIndex = 23;
            this.first_name_label.Text = "Имя";
            // 
            // second_name_label
            // 
            this.second_name_label.AutoSize = true;
            this.second_name_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.second_name_label.Location = new System.Drawing.Point(428, 241);
            this.second_name_label.Name = "second_name_label";
            this.second_name_label.Size = new System.Drawing.Size(56, 13);
            this.second_name_label.TabIndex = 22;
            this.second_name_label.Text = "Фамилия";
            // 
            // update_button
            // 
            this.update_button.Location = new System.Drawing.Point(484, 455);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(133, 23);
            this.update_button.TabIndex = 20;
            this.update_button.Text = "Сохранить изменения";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // selphone_number_textbox
            // 
            this.selphone_number_textbox.Location = new System.Drawing.Point(578, 197);
            this.selphone_number_textbox.Name = "selphone_number_textbox";
            this.selphone_number_textbox.Size = new System.Drawing.Size(100, 20);
            this.selphone_number_textbox.TabIndex = 17;
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(578, 156);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.Size = new System.Drawing.Size(100, 20);
            this.password_textbox.TabIndex = 18;
            this.password_textbox.UseSystemPasswordChar = true;
            // 
            // login_textbox
            // 
            this.login_textbox.Location = new System.Drawing.Point(578, 114);
            this.login_textbox.Name = "login_textbox";
            this.login_textbox.Size = new System.Drawing.Size(100, 20);
            this.login_textbox.TabIndex = 19;
            // 
            // selphone_number
            // 
            this.selphone_number.AutoSize = true;
            this.selphone_number.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.selphone_number.Location = new System.Drawing.Point(428, 197);
            this.selphone_number.Name = "selphone_number";
            this.selphone_number.Size = new System.Drawing.Size(93, 13);
            this.selphone_number.TabIndex = 15;
            this.selphone_number.Text = "Номер телефона";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.password_label.Location = new System.Drawing.Point(428, 156);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(45, 13);
            this.password_label.TabIndex = 14;
            this.password_label.Text = "Пароль";
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.login_label.Location = new System.Drawing.Point(428, 114);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(38, 13);
            this.login_label.TabIndex = 13;
            this.login_label.Text = "Логин";
            // 
            // my_tickets_page
            // 
            this.my_tickets_page.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.my_tickets_page.Controls.Add(this.show_active_reservations_button);
            this.my_tickets_page.Controls.Add(this.show_active_tickets_button);
            this.my_tickets_page.Controls.Add(this.show_my_reservations_button);
            this.my_tickets_page.Controls.Add(this.show_my_tickets_button);
            this.my_tickets_page.Controls.Add(this.user_dataGridView);
            this.my_tickets_page.Location = new System.Drawing.Point(4, 22);
            this.my_tickets_page.Name = "my_tickets_page";
            this.my_tickets_page.Padding = new System.Windows.Forms.Padding(3);
            this.my_tickets_page.Size = new System.Drawing.Size(1052, 594);
            this.my_tickets_page.TabIndex = 1;
            this.my_tickets_page.Text = "Мои билеты";
            this.my_tickets_page.UseVisualStyleBackColor = true;
            // 
            // show_active_tickets_button
            // 
            this.show_active_tickets_button.Location = new System.Drawing.Point(839, 124);
            this.show_active_tickets_button.Name = "show_active_tickets_button";
            this.show_active_tickets_button.Size = new System.Drawing.Size(189, 23);
            this.show_active_tickets_button.TabIndex = 3;
            this.show_active_tickets_button.Text = "Показать действующие билеты";
            this.show_active_tickets_button.UseVisualStyleBackColor = true;
            this.show_active_tickets_button.Click += new System.EventHandler(this.show_active_tickets_button_Click);
            // 
            // show_my_reservations_button
            // 
            this.show_my_reservations_button.Location = new System.Drawing.Point(867, 66);
            this.show_my_reservations_button.Name = "show_my_reservations_button";
            this.show_my_reservations_button.Size = new System.Drawing.Size(137, 23);
            this.show_my_reservations_button.TabIndex = 2;
            this.show_my_reservations_button.Text = "Показать мои брони";
            this.show_my_reservations_button.UseVisualStyleBackColor = true;
            this.show_my_reservations_button.Click += new System.EventHandler(this.show_my_reservations_button_Click);
            // 
            // show_my_tickets_button
            // 
            this.show_my_tickets_button.Location = new System.Drawing.Point(867, 25);
            this.show_my_tickets_button.Name = "show_my_tickets_button";
            this.show_my_tickets_button.Size = new System.Drawing.Size(137, 23);
            this.show_my_tickets_button.TabIndex = 1;
            this.show_my_tickets_button.Text = "Показать мои билеты";
            this.show_my_tickets_button.UseVisualStyleBackColor = true;
            this.show_my_tickets_button.Click += new System.EventHandler(this.show_my_tickets_button_Click);
            // 
            // user_dataGridView
            // 
            this.user_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.user_dataGridView.Location = new System.Drawing.Point(0, 0);
            this.user_dataGridView.Name = "user_dataGridView";
            this.user_dataGridView.Size = new System.Drawing.Size(807, 582);
            this.user_dataGridView.TabIndex = 0;
            // 
            // buy_ticket_tabPage
            // 
            this.buy_ticket_tabPage.BackColor = System.Drawing.Color.Transparent;
            this.buy_ticket_tabPage.Controls.Add(this.reservation_ticket_button);
            this.buy_ticket_tabPage.Controls.Add(this.buy_ticket_button);
            this.buy_ticket_tabPage.Controls.Add(this.choose_class_button);
            this.buy_ticket_tabPage.Controls.Add(this.information_label2);
            this.buy_ticket_tabPage.Controls.Add(this.information_label1);
            this.buy_ticket_tabPage.Controls.Add(this.choose_floght_button);
            this.buy_ticket_tabPage.Controls.Add(this.type_of_places_button);
            this.buy_ticket_tabPage.Controls.Add(this.airport_arrive_textBox);
            this.buy_ticket_tabPage.Controls.Add(this.airport_depart_textBox);
            this.buy_ticket_tabPage.Controls.Add(this.airport_arrive_label);
            this.buy_ticket_tabPage.Controls.Add(this.airport_depart_label);
            this.buy_ticket_tabPage.Controls.Add(this.dateTimePicker1);
            this.buy_ticket_tabPage.Controls.Add(this.select_data_label);
            this.buy_ticket_tabPage.Controls.Add(this.select_data_button);
            this.buy_ticket_tabPage.Controls.Add(this.airport_dataGridView);
            this.buy_ticket_tabPage.Location = new System.Drawing.Point(4, 22);
            this.buy_ticket_tabPage.Name = "buy_ticket_tabPage";
            this.buy_ticket_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.buy_ticket_tabPage.Size = new System.Drawing.Size(1052, 594);
            this.buy_ticket_tabPage.TabIndex = 3;
            this.buy_ticket_tabPage.Text = "Купить/забронировать билет";
            // 
            // reservation_ticket_button
            // 
            this.reservation_ticket_button.Location = new System.Drawing.Point(868, 522);
            this.reservation_ticket_button.Name = "reservation_ticket_button";
            this.reservation_ticket_button.Size = new System.Drawing.Size(120, 23);
            this.reservation_ticket_button.TabIndex = 29;
            this.reservation_ticket_button.Text = "Забронировать билет";
            this.reservation_ticket_button.UseVisualStyleBackColor = true;
            this.reservation_ticket_button.Click += new System.EventHandler(this.reservation_ticket_button_Click);
            // 
            // buy_ticket_button
            // 
            this.buy_ticket_button.Location = new System.Drawing.Point(868, 473);
            this.buy_ticket_button.Name = "buy_ticket_button";
            this.buy_ticket_button.Size = new System.Drawing.Size(120, 23);
            this.buy_ticket_button.TabIndex = 28;
            this.buy_ticket_button.Text = "Купить билет";
            this.buy_ticket_button.UseVisualStyleBackColor = true;
            this.buy_ticket_button.Click += new System.EventHandler(this.buy_ticket_button_Click);
            // 
            // choose_class_button
            // 
            this.choose_class_button.Location = new System.Drawing.Point(868, 427);
            this.choose_class_button.Name = "choose_class_button";
            this.choose_class_button.Size = new System.Drawing.Size(120, 23);
            this.choose_class_button.TabIndex = 27;
            this.choose_class_button.Text = "Выберите класс";
            this.choose_class_button.UseVisualStyleBackColor = true;
            this.choose_class_button.Click += new System.EventHandler(this.choose_class_button_Click);
            // 
            // information_label2
            // 
            this.information_label2.AutoSize = true;
            this.information_label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.information_label2.Location = new System.Drawing.Point(849, 383);
            this.information_label2.Name = "information_label2";
            this.information_label2.Size = new System.Drawing.Size(173, 19);
            this.information_label2.TabIndex = 26;
            this.information_label2.Text = "Шаг 2. Выберите класс";
            // 
            // information_label1
            // 
            this.information_label1.AutoSize = true;
            this.information_label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.information_label1.Location = new System.Drawing.Point(849, 15);
            this.information_label1.Name = "information_label1";
            this.information_label1.Size = new System.Drawing.Size(167, 19);
            this.information_label1.TabIndex = 26;
            this.information_label1.Text = "Шаг 1. Выберите рейс";
            // 
            // choose_floght_button
            // 
            this.choose_floght_button.Location = new System.Drawing.Point(874, 335);
            this.choose_floght_button.Name = "choose_floght_button";
            this.choose_floght_button.Size = new System.Drawing.Size(106, 23);
            this.choose_floght_button.TabIndex = 25;
            this.choose_floght_button.Text = "Выбрать рейс";
            this.choose_floght_button.UseVisualStyleBackColor = true;
            this.choose_floght_button.Click += new System.EventHandler(this.choose_floght_button_Click);
            // 
            // type_of_places_button
            // 
            this.type_of_places_button.Location = new System.Drawing.Point(868, 245);
            this.type_of_places_button.Name = "type_of_places_button";
            this.type_of_places_button.Size = new System.Drawing.Size(120, 23);
            this.type_of_places_button.TabIndex = 24;
            this.type_of_places_button.Text = "Выберите места";
            this.type_of_places_button.UseVisualStyleBackColor = true;
            this.type_of_places_button.Click += new System.EventHandler(this.type_of_places_button_Click);
            // 
            // airport_arrive_textBox
            // 
            this.airport_arrive_textBox.Location = new System.Drawing.Point(874, 204);
            this.airport_arrive_textBox.Name = "airport_arrive_textBox";
            this.airport_arrive_textBox.Size = new System.Drawing.Size(100, 20);
            this.airport_arrive_textBox.TabIndex = 23;
            // 
            // airport_depart_textBox
            // 
            this.airport_depart_textBox.Location = new System.Drawing.Point(874, 142);
            this.airport_depart_textBox.Name = "airport_depart_textBox";
            this.airport_depart_textBox.Size = new System.Drawing.Size(100, 20);
            this.airport_depart_textBox.TabIndex = 22;
            // 
            // airport_arrive_label
            // 
            this.airport_arrive_label.AutoSize = true;
            this.airport_arrive_label.Location = new System.Drawing.Point(871, 174);
            this.airport_arrive_label.Name = "airport_arrive_label";
            this.airport_arrive_label.Size = new System.Drawing.Size(117, 13);
            this.airport_arrive_label.TabIndex = 21;
            this.airport_arrive_label.Text = "Аэропорт назначения";
            // 
            // airport_depart_label
            // 
            this.airport_depart_label.AutoSize = true;
            this.airport_depart_label.Location = new System.Drawing.Point(871, 113);
            this.airport_depart_label.Name = "airport_depart_label";
            this.airport_depart_label.Size = new System.Drawing.Size(123, 13);
            this.airport_depart_label.TabIndex = 20;
            this.airport_depart_label.Text = "Аэропорт отправления";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(835, 77);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 19;
            // 
            // select_data_label
            // 
            this.select_data_label.AutoSize = true;
            this.select_data_label.Location = new System.Drawing.Point(873, 52);
            this.select_data_label.Name = "select_data_label";
            this.select_data_label.Size = new System.Drawing.Size(101, 13);
            this.select_data_label.TabIndex = 18;
            this.select_data_label.Text = "Дата отправления";
            // 
            // select_data_button
            // 
            this.select_data_button.Location = new System.Drawing.Point(855, 290);
            this.select_data_button.Name = "select_data_button";
            this.select_data_button.Size = new System.Drawing.Size(139, 23);
            this.select_data_button.TabIndex = 17;
            this.select_data_button.Text = "Показать результаты";
            this.select_data_button.UseVisualStyleBackColor = true;
            this.select_data_button.Click += new System.EventHandler(this.select_data_button_Click);
            // 
            // airport_dataGridView
            // 
            this.airport_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.airport_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.airport_dataGridView.Location = new System.Drawing.Point(7, 7);
            this.airport_dataGridView.Name = "airport_dataGridView";
            this.airport_dataGridView.Size = new System.Drawing.Size(805, 580);
            this.airport_dataGridView.TabIndex = 0;
            // 
            // reference_page
            // 
            this.reference_page.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reference_page.Controls.Add(this.reference_label);
            this.reference_page.Location = new System.Drawing.Point(4, 22);
            this.reference_page.Name = "reference_page";
            this.reference_page.Padding = new System.Windows.Forms.Padding(3);
            this.reference_page.Size = new System.Drawing.Size(1053, 595);
            this.reference_page.TabIndex = 2;
            this.reference_page.Text = "О программе";
            this.reference_page.UseVisualStyleBackColor = true;
            // 
            // reference_label
            // 
            this.reference_label.AutoSize = true;
            this.reference_label.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reference_label.Location = new System.Drawing.Point(544, 43);
            this.reference_label.Name = "reference_label";
            this.reference_label.Size = new System.Drawing.Size(209, 266);
            this.reference_label.TabIndex = 0;
            this.reference_label.Text = resources.GetString("reference_label.Text");
            // 
            // registration_label
            // 
            this.registration_label.AutoSize = true;
            this.registration_label.Location = new System.Drawing.Point(1080, 50);
            this.registration_label.Name = "registration_label";
            this.registration_label.Size = new System.Drawing.Size(142, 13);
            this.registration_label.TabIndex = 4;
            this.registration_label.Text = "Вы зарегистрированы как\r\n";
            // 
            // show_active_reservations_button
            // 
            this.show_active_reservations_button.Location = new System.Drawing.Point(839, 168);
            this.show_active_reservations_button.Name = "show_active_reservations_button";
            this.show_active_reservations_button.Size = new System.Drawing.Size(189, 23);
            this.show_active_reservations_button.TabIndex = 4;
            this.show_active_reservations_button.Text = "Показать действующие брони";
            this.show_active_reservations_button.UseVisualStyleBackColor = true;
            this.show_active_reservations_button.Click += new System.EventHandler(this.show_active_reservations_button_Click);
            // 
            // User_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1234, 661);
            this.Controls.Add(this.registration_label);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "User_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База данных аэропорта - Пользователь";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.User_form_FormClosing);
            this.Load += new System.EventHandler(this.User_form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.билетBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.airportDB_2DataSet1)).EndInit();
            this.start_page.ResumeLayout(false);
            this.start_page.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.personal_data_tabPage.ResumeLayout(false);
            this.personal_data_tabPage.PerformLayout();
            this.my_tickets_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.user_dataGridView)).EndInit();
            this.buy_ticket_tabPage.ResumeLayout(false);
            this.buy_ticket_tabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.airport_dataGridView)).EndInit();
            this.reference_page.ResumeLayout(false);
            this.reference_page.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem хреньToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem моиБилетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem моиБрониToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem персональныеДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem аэропортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рейсыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расценкиToolStripMenuItem;
        private AirportDB_2DataSet1 airportDB_2DataSet1;
        private System.Windows.Forms.BindingSource билетBindingSource;
        private AirportDB_2DataSet1TableAdapters.БилетTableAdapter билетTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.TabPage start_page;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage my_tickets_page;
        private System.Windows.Forms.DataGridView user_dataGridView;
        private System.Windows.Forms.TabPage reference_page;
        private System.Windows.Forms.Label reference_label;
        private System.Windows.Forms.ToolStripMenuItem выходИзАккаунтаToolStripMenuItem;
        private System.Windows.Forms.TabPage buy_ticket_tabPage;
        private System.Windows.Forms.DataGridView airport_dataGridView;
        private System.Windows.Forms.Button type_of_places_button;
        private System.Windows.Forms.TextBox airport_arrive_textBox;
        private System.Windows.Forms.TextBox airport_depart_textBox;
        private System.Windows.Forms.Label airport_arrive_label;
        private System.Windows.Forms.Label airport_depart_label;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label select_data_label;
        private System.Windows.Forms.Button select_data_button;
        private System.Windows.Forms.Label registration_label;
        private System.Windows.Forms.ToolStripMenuItem опцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.TabPage personal_data_tabPage;
        private System.Windows.Forms.TextBox patronymic_textbox;
        private System.Windows.Forms.Label patronymic_label;
        private System.Windows.Forms.TextBox first_name_textbox;
        private System.Windows.Forms.TextBox second_name_textbox;
        private System.Windows.Forms.Label first_name_label;
        private System.Windows.Forms.Label second_name_label;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.TextBox selphone_number_textbox;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.TextBox login_textbox;
        private System.Windows.Forms.Label selphone_number;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.TextBox old_password_textBox;
        private System.Windows.Forms.Label change_label;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Button choose_floght_button;
        private System.Windows.Forms.Button reservation_ticket_button;
        private System.Windows.Forms.Button buy_ticket_button;
        private System.Windows.Forms.Button choose_class_button;
        private System.Windows.Forms.Label information_label2;
        private System.Windows.Forms.Label information_label1;
        private System.Windows.Forms.Button show_my_reservations_button;
        private System.Windows.Forms.Button show_my_tickets_button;
        private System.Windows.Forms.Button show_active_tickets_button;
        private System.Windows.Forms.ToolStripMenuItem тёмнаяТемаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem светлаяТемаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem установитьСвоюТемуToolStripMenuItem;
        private System.Windows.Forms.Button show_active_reservations_button;
    }
}