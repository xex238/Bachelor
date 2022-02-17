using System.Windows.Forms;

namespace CW_windows_forms
{
    partial class Admin_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        ContextMenuStrip context_menu_strip = new ContextMenuStrip();

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
            context_menu_strip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(context_menu_strip_ItemClicked);

            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_form));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходИзАккаунтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходИзПриложенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеАккаунтамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.авиакомпанияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.активностьавиакомпанииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.билетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.билетпользовательToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.броньToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.броньпользовательToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вППToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.классификацияВППToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маршрутToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.метеопрогнозToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пользовательToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правилапоперевозкебагажаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расценкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рейсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.самолётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистическиеданныеопассажирахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статусбилетаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статусброниToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статуссамолётаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.airportDB_2DataSet1 = new CW_windows_forms.AirportDB_2DataSet1();
            this.airportDB2DataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.sql_request_tabPage = new System.Windows.Forms.TabPage();
            this.execute_button = new System.Windows.Forms.Button();
            this.sql_request_label = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.sql_dataGridView = new System.Windows.Forms.DataGridView();
            this.account_management_tabPage = new System.Windows.Forms.TabPage();
            this.add_button = new System.Windows.Forms.Button();
            this.choose_role_button = new System.Windows.Forms.Button();
            this.selphone_textBox = new System.Windows.Forms.TextBox();
            this.selphone_label = new System.Windows.Forms.Label();
            this.patronymic_textBox = new System.Windows.Forms.TextBox();
            this.patronymic_label = new System.Windows.Forms.Label();
            this.mail_textbox = new System.Windows.Forms.TextBox();
            this.mail_label = new System.Windows.Forms.Label();
            this.first_name_textbox = new System.Windows.Forms.TextBox();
            this.second_name_textbox = new System.Windows.Forms.TextBox();
            this.first_name_label = new System.Windows.Forms.Label();
            this.second_name_label = new System.Windows.Forms.Label();
            this.date_choose = new System.Windows.Forms.DateTimePicker();
            this.repeat_password_textbox = new System.Windows.Forms.TextBox();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.login_textbox = new System.Windows.Forms.TextBox();
            this.born_data_label = new System.Windows.Forms.Label();
            this.repeat_password_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.login_label = new System.Windows.Forms.Label();
            this.tables_tabPage = new System.Windows.Forms.TabPage();
            this.update_button = new System.Windows.Forms.Button();
            this.delete_string_button = new System.Windows.Forms.Button();
            this.update_string_button = new System.Windows.Forms.Button();
            this.add_string_button = new System.Windows.Forms.Button();
            this.tables_dataGridView = new System.Windows.Forms.DataGridView();
            this.местаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.start_page_tabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.airportDB_2DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.airportDB2DataSet1BindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.sql_request_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sql_dataGridView)).BeginInit();
            this.account_management_tabPage.SuspendLayout();
            this.tables_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tables_dataGridView)).BeginInit();
            this.start_page_tabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.управлениеАккаунтамиToolStripMenuItem,
            this.таблицыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1291, 24);
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
            // управлениеАккаунтамиToolStripMenuItem
            // 
            this.управлениеАккаунтамиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьПользователяToolStripMenuItem});
            this.управлениеАккаунтамиToolStripMenuItem.Name = "управлениеАккаунтамиToolStripMenuItem";
            this.управлениеАккаунтамиToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.управлениеАккаунтамиToolStripMenuItem.Text = "Управление аккаунтами";
            // 
            // добавитьПользователяToolStripMenuItem
            // 
            this.добавитьПользователяToolStripMenuItem.Name = "добавитьПользователяToolStripMenuItem";
            this.добавитьПользователяToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.добавитьПользователяToolStripMenuItem.Text = "Добавить пользователя";
            this.добавитьПользователяToolStripMenuItem.Click += new System.EventHandler(this.добавитьПользователяToolStripMenuItem_Click);
            // 
            // таблицыToolStripMenuItem
            // 
            this.таблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.авиакомпанияToolStripMenuItem,
            this.активностьавиакомпанииToolStripMenuItem,
            this.билетToolStripMenuItem,
            this.билетпользовательToolStripMenuItem,
            this.броньToolStripMenuItem,
            this.броньпользовательToolStripMenuItem,
            this.вППToolStripMenuItem,
            this.классификацияВППToolStripMenuItem,
            this.маршрутToolStripMenuItem,
            this.местаToolStripMenuItem,
            this.метеопрогнозToolStripMenuItem,
            this.пользовательToolStripMenuItem,
            this.правилапоперевозкебагажаToolStripMenuItem,
            this.расценкиToolStripMenuItem,
            this.рейсToolStripMenuItem,
            this.самолётToolStripMenuItem,
            this.статистическиеданныеопассажирахToolStripMenuItem,
            this.статусбилетаToolStripMenuItem,
            this.статусброниToolStripMenuItem,
            this.статуссамолётаToolStripMenuItem});
            this.таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            this.таблицыToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.таблицыToolStripMenuItem.Text = "Таблицы";
            // 
            // авиакомпанияToolStripMenuItem
            // 
            this.авиакомпанияToolStripMenuItem.Name = "авиакомпанияToolStripMenuItem";
            this.авиакомпанияToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.авиакомпанияToolStripMenuItem.Text = "Авиакомпания";
            this.авиакомпанияToolStripMenuItem.Click += new System.EventHandler(this.авиакомпанияToolStripMenuItem_Click);
            // 
            // активностьавиакомпанииToolStripMenuItem
            // 
            this.активностьавиакомпанииToolStripMenuItem.Name = "активностьавиакомпанииToolStripMenuItem";
            this.активностьавиакомпанииToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.активностьавиакомпанииToolStripMenuItem.Text = "Активность_авиакомпании";
            this.активностьавиакомпанииToolStripMenuItem.Click += new System.EventHandler(this.активностьавиакомпанииToolStripMenuItem_Click);
            // 
            // билетToolStripMenuItem
            // 
            this.билетToolStripMenuItem.Name = "билетToolStripMenuItem";
            this.билетToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.билетToolStripMenuItem.Text = "Билет";
            this.билетToolStripMenuItem.Click += new System.EventHandler(this.билетToolStripMenuItem_Click);
            // 
            // билетпользовательToolStripMenuItem
            // 
            this.билетпользовательToolStripMenuItem.Name = "билетпользовательToolStripMenuItem";
            this.билетпользовательToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.билетпользовательToolStripMenuItem.Text = "Билет_Пользователь";
            this.билетпользовательToolStripMenuItem.Click += new System.EventHandler(this.билетпользовательToolStripMenuItem_Click);
            // 
            // броньToolStripMenuItem
            // 
            this.броньToolStripMenuItem.Name = "броньToolStripMenuItem";
            this.броньToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.броньToolStripMenuItem.Text = "Бронь";
            this.броньToolStripMenuItem.Click += new System.EventHandler(this.броньToolStripMenuItem_Click);
            // 
            // броньпользовательToolStripMenuItem
            // 
            this.броньпользовательToolStripMenuItem.Name = "броньпользовательToolStripMenuItem";
            this.броньпользовательToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.броньпользовательToolStripMenuItem.Text = "Бронь_Пользователь";
            this.броньпользовательToolStripMenuItem.Click += new System.EventHandler(this.броньпользовательToolStripMenuItem_Click);
            // 
            // вППToolStripMenuItem
            // 
            this.вППToolStripMenuItem.Name = "вППToolStripMenuItem";
            this.вППToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.вППToolStripMenuItem.Text = "ВПП";
            this.вППToolStripMenuItem.Click += new System.EventHandler(this.вППToolStripMenuItem_Click);
            // 
            // классификацияВППToolStripMenuItem
            // 
            this.классификацияВППToolStripMenuItem.Name = "классификацияВППToolStripMenuItem";
            this.классификацияВППToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.классификацияВППToolStripMenuItem.Text = "Классификация_ВПП";
            this.классификацияВППToolStripMenuItem.Click += new System.EventHandler(this.классификацияВППToolStripMenuItem_Click);
            // 
            // маршрутToolStripMenuItem
            // 
            this.маршрутToolStripMenuItem.Name = "маршрутToolStripMenuItem";
            this.маршрутToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.маршрутToolStripMenuItem.Text = "Маршрут";
            this.маршрутToolStripMenuItem.Click += new System.EventHandler(this.маршрутToolStripMenuItem_Click);
            // 
            // метеопрогнозToolStripMenuItem
            // 
            this.метеопрогнозToolStripMenuItem.Name = "метеопрогнозToolStripMenuItem";
            this.метеопрогнозToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.метеопрогнозToolStripMenuItem.Text = "Метеопрогноз";
            this.метеопрогнозToolStripMenuItem.Click += new System.EventHandler(this.метеопрогнозToolStripMenuItem_Click);
            // 
            // пользовательToolStripMenuItem
            // 
            this.пользовательToolStripMenuItem.Name = "пользовательToolStripMenuItem";
            this.пользовательToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.пользовательToolStripMenuItem.Text = "Пользователь";
            this.пользовательToolStripMenuItem.Click += new System.EventHandler(this.пользовательToolStripMenuItem_Click);
            // 
            // правилапоперевозкебагажаToolStripMenuItem
            // 
            this.правилапоперевозкебагажаToolStripMenuItem.Name = "правилапоперевозкебагажаToolStripMenuItem";
            this.правилапоперевозкебагажаToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.правилапоперевозкебагажаToolStripMenuItem.Text = "Правила_по_перевозке_багажа";
            this.правилапоперевозкебагажаToolStripMenuItem.Click += new System.EventHandler(this.правилапоперевозкебагажаToolStripMenuItem_Click);
            // 
            // расценкиToolStripMenuItem
            // 
            this.расценкиToolStripMenuItem.Name = "расценкиToolStripMenuItem";
            this.расценкиToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.расценкиToolStripMenuItem.Text = "Расценки";
            this.расценкиToolStripMenuItem.Click += new System.EventHandler(this.расценкиToolStripMenuItem_Click);
            // 
            // рейсToolStripMenuItem
            // 
            this.рейсToolStripMenuItem.Name = "рейсToolStripMenuItem";
            this.рейсToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.рейсToolStripMenuItem.Text = "Рейс";
            this.рейсToolStripMenuItem.Click += new System.EventHandler(this.рейсToolStripMenuItem_Click);
            // 
            // самолётToolStripMenuItem
            // 
            this.самолётToolStripMenuItem.Name = "самолётToolStripMenuItem";
            this.самолётToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.самолётToolStripMenuItem.Text = "Самолёт";
            this.самолётToolStripMenuItem.Click += new System.EventHandler(this.самолётToolStripMenuItem_Click);
            // 
            // статистическиеданныеопассажирахToolStripMenuItem
            // 
            this.статистическиеданныеопассажирахToolStripMenuItem.Name = "статистическиеданныеопассажирахToolStripMenuItem";
            this.статистическиеданныеопассажирахToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.статистическиеданныеопассажирахToolStripMenuItem.Text = "Статистические_данные_о_пассажирах";
            this.статистическиеданныеопассажирахToolStripMenuItem.Click += new System.EventHandler(this.статистическиеданныеопассажирахToolStripMenuItem_Click);
            // 
            // статусбилетаToolStripMenuItem
            // 
            this.статусбилетаToolStripMenuItem.Name = "статусбилетаToolStripMenuItem";
            this.статусбилетаToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.статусбилетаToolStripMenuItem.Text = "Статус_билета";
            this.статусбилетаToolStripMenuItem.Click += new System.EventHandler(this.статусбилетаToolStripMenuItem_Click);
            // 
            // статусброниToolStripMenuItem
            // 
            this.статусброниToolStripMenuItem.Name = "статусброниToolStripMenuItem";
            this.статусброниToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.статусброниToolStripMenuItem.Text = "Статус_брони";
            this.статусброниToolStripMenuItem.Click += new System.EventHandler(this.статусброниToolStripMenuItem_Click);
            // 
            // статуссамолётаToolStripMenuItem
            // 
            this.статуссамолётаToolStripMenuItem.Name = "статуссамолётаToolStripMenuItem";
            this.статуссамолётаToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.статуссамолётаToolStripMenuItem.Text = "Статус_самолёта";
            this.статуссамолётаToolStripMenuItem.Click += new System.EventHandler(this.статуссамолётаToolStripMenuItem_Click);
            // 
            // airportDB_2DataSet1
            // 
            this.airportDB_2DataSet1.DataSetName = "AirportDB_2DataSet1";
            this.airportDB_2DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // airportDB2DataSet1BindingSource
            // 
            this.airportDB2DataSet1BindingSource.DataSource = this.airportDB_2DataSet1;
            this.airportDB2DataSet1BindingSource.Position = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.start_page_tabPage);
            this.tabControl1.Controls.Add(this.sql_request_tabPage);
            this.tabControl1.Controls.Add(this.account_management_tabPage);
            this.tabControl1.Controls.Add(this.tables_tabPage);
            this.tabControl1.Location = new System.Drawing.Point(13, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1266, 557);
            this.tabControl1.TabIndex = 1;
            // 
            // sql_request_tabPage
            // 
            this.sql_request_tabPage.Controls.Add(this.execute_button);
            this.sql_request_tabPage.Controls.Add(this.sql_request_label);
            this.sql_request_tabPage.Controls.Add(this.richTextBox);
            this.sql_request_tabPage.Controls.Add(this.sql_dataGridView);
            this.sql_request_tabPage.Location = new System.Drawing.Point(4, 22);
            this.sql_request_tabPage.Name = "sql_request_tabPage";
            this.sql_request_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.sql_request_tabPage.Size = new System.Drawing.Size(1258, 531);
            this.sql_request_tabPage.TabIndex = 0;
            this.sql_request_tabPage.Text = "Sql запросы";
            this.sql_request_tabPage.UseVisualStyleBackColor = true;
            // 
            // execute_button
            // 
            this.execute_button.Location = new System.Drawing.Point(563, 496);
            this.execute_button.Name = "execute_button";
            this.execute_button.Size = new System.Drawing.Size(75, 23);
            this.execute_button.TabIndex = 11;
            this.execute_button.Text = "Выполнить";
            this.execute_button.UseVisualStyleBackColor = true;
            this.execute_button.Click += new System.EventHandler(this.execute_button_Click_1);
            // 
            // sql_request_label
            // 
            this.sql_request_label.AutoSize = true;
            this.sql_request_label.Location = new System.Drawing.Point(387, 347);
            this.sql_request_label.Name = "sql_request_label";
            this.sql_request_label.Size = new System.Drawing.Size(425, 13);
            this.sql_request_label.TabIndex = 10;
            this.sql_request_label.Text = "Введите sql запрос (поддерживает операции SELECT, INSERT, UPDATE, DELETE)";
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(387, 376);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(444, 96);
            this.richTextBox.TabIndex = 9;
            this.richTextBox.Text = "";
            // 
            // sql_dataGridView
            // 
            this.sql_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sql_dataGridView.Location = new System.Drawing.Point(6, 6);
            this.sql_dataGridView.Name = "sql_dataGridView";
            this.sql_dataGridView.Size = new System.Drawing.Size(1246, 323);
            this.sql_dataGridView.TabIndex = 8;
            // 
            // account_management_tabPage
            // 
            this.account_management_tabPage.Controls.Add(this.add_button);
            this.account_management_tabPage.Controls.Add(this.choose_role_button);
            this.account_management_tabPage.Controls.Add(this.selphone_textBox);
            this.account_management_tabPage.Controls.Add(this.selphone_label);
            this.account_management_tabPage.Controls.Add(this.patronymic_textBox);
            this.account_management_tabPage.Controls.Add(this.patronymic_label);
            this.account_management_tabPage.Controls.Add(this.mail_textbox);
            this.account_management_tabPage.Controls.Add(this.mail_label);
            this.account_management_tabPage.Controls.Add(this.first_name_textbox);
            this.account_management_tabPage.Controls.Add(this.second_name_textbox);
            this.account_management_tabPage.Controls.Add(this.first_name_label);
            this.account_management_tabPage.Controls.Add(this.second_name_label);
            this.account_management_tabPage.Controls.Add(this.date_choose);
            this.account_management_tabPage.Controls.Add(this.repeat_password_textbox);
            this.account_management_tabPage.Controls.Add(this.password_textbox);
            this.account_management_tabPage.Controls.Add(this.login_textbox);
            this.account_management_tabPage.Controls.Add(this.born_data_label);
            this.account_management_tabPage.Controls.Add(this.repeat_password_label);
            this.account_management_tabPage.Controls.Add(this.password_label);
            this.account_management_tabPage.Controls.Add(this.login_label);
            this.account_management_tabPage.Location = new System.Drawing.Point(4, 22);
            this.account_management_tabPage.Name = "account_management_tabPage";
            this.account_management_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.account_management_tabPage.Size = new System.Drawing.Size(1258, 531);
            this.account_management_tabPage.TabIndex = 1;
            this.account_management_tabPage.Text = "Управление аккаунтами";
            this.account_management_tabPage.UseVisualStyleBackColor = true;
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(454, 486);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(102, 23);
            this.add_button.TabIndex = 32;
            this.add_button.Text = "Добавить";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // choose_role_button
            // 
            this.choose_role_button.Location = new System.Drawing.Point(454, 444);
            this.choose_role_button.Name = "choose_role_button";
            this.choose_role_button.Size = new System.Drawing.Size(102, 23);
            this.choose_role_button.TabIndex = 31;
            this.choose_role_button.Text = "Выбрать роль";
            this.choose_role_button.UseVisualStyleBackColor = true;
            this.choose_role_button.Click += new System.EventHandler(this.choose_role_button_Click);
            // 
            // selphone_textBox
            // 
            this.selphone_textBox.Location = new System.Drawing.Point(532, 388);
            this.selphone_textBox.Name = "selphone_textBox";
            this.selphone_textBox.Size = new System.Drawing.Size(100, 20);
            this.selphone_textBox.TabIndex = 30;
            // 
            // selphone_label
            // 
            this.selphone_label.AutoSize = true;
            this.selphone_label.Location = new System.Drawing.Point(382, 395);
            this.selphone_label.Name = "selphone_label";
            this.selphone_label.Size = new System.Drawing.Size(93, 13);
            this.selphone_label.TabIndex = 29;
            this.selphone_label.Text = "Номер телефона";
            // 
            // patronymic_textBox
            // 
            this.patronymic_textBox.Location = new System.Drawing.Point(532, 346);
            this.patronymic_textBox.Name = "patronymic_textBox";
            this.patronymic_textBox.Size = new System.Drawing.Size(100, 20);
            this.patronymic_textBox.TabIndex = 28;
            // 
            // patronymic_label
            // 
            this.patronymic_label.AutoSize = true;
            this.patronymic_label.Location = new System.Drawing.Point(382, 353);
            this.patronymic_label.Name = "patronymic_label";
            this.patronymic_label.Size = new System.Drawing.Size(54, 13);
            this.patronymic_label.TabIndex = 27;
            this.patronymic_label.Text = "Отчество";
            // 
            // mail_textbox
            // 
            this.mail_textbox.Location = new System.Drawing.Point(532, 59);
            this.mail_textbox.Name = "mail_textbox";
            this.mail_textbox.Size = new System.Drawing.Size(100, 20);
            this.mail_textbox.TabIndex = 26;
            // 
            // mail_label
            // 
            this.mail_label.AutoSize = true;
            this.mail_label.Location = new System.Drawing.Point(382, 59);
            this.mail_label.Name = "mail_label";
            this.mail_label.Size = new System.Drawing.Size(37, 13);
            this.mail_label.TabIndex = 25;
            this.mail_label.Text = "Почта";
            // 
            // first_name_textbox
            // 
            this.first_name_textbox.Location = new System.Drawing.Point(532, 304);
            this.first_name_textbox.Name = "first_name_textbox";
            this.first_name_textbox.Size = new System.Drawing.Size(100, 20);
            this.first_name_textbox.TabIndex = 24;
            // 
            // second_name_textbox
            // 
            this.second_name_textbox.Location = new System.Drawing.Point(532, 268);
            this.second_name_textbox.Name = "second_name_textbox";
            this.second_name_textbox.Size = new System.Drawing.Size(100, 20);
            this.second_name_textbox.TabIndex = 23;
            // 
            // first_name_label
            // 
            this.first_name_label.AutoSize = true;
            this.first_name_label.Location = new System.Drawing.Point(382, 311);
            this.first_name_label.Name = "first_name_label";
            this.first_name_label.Size = new System.Drawing.Size(29, 13);
            this.first_name_label.TabIndex = 22;
            this.first_name_label.Text = "Имя";
            // 
            // second_name_label
            // 
            this.second_name_label.AutoSize = true;
            this.second_name_label.Location = new System.Drawing.Point(382, 268);
            this.second_name_label.Name = "second_name_label";
            this.second_name_label.Size = new System.Drawing.Size(56, 13);
            this.second_name_label.TabIndex = 21;
            this.second_name_label.Text = "Фамилия";
            // 
            // date_choose
            // 
            this.date_choose.Location = new System.Drawing.Point(532, 220);
            this.date_choose.Name = "date_choose";
            this.date_choose.Size = new System.Drawing.Size(200, 20);
            this.date_choose.TabIndex = 20;
            // 
            // repeat_password_textbox
            // 
            this.repeat_password_textbox.Location = new System.Drawing.Point(532, 183);
            this.repeat_password_textbox.Name = "repeat_password_textbox";
            this.repeat_password_textbox.Size = new System.Drawing.Size(100, 20);
            this.repeat_password_textbox.TabIndex = 17;
            this.repeat_password_textbox.UseSystemPasswordChar = true;
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(532, 142);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.Size = new System.Drawing.Size(100, 20);
            this.password_textbox.TabIndex = 18;
            this.password_textbox.UseSystemPasswordChar = true;
            // 
            // login_textbox
            // 
            this.login_textbox.Location = new System.Drawing.Point(532, 100);
            this.login_textbox.Name = "login_textbox";
            this.login_textbox.Size = new System.Drawing.Size(100, 20);
            this.login_textbox.TabIndex = 19;
            // 
            // born_data_label
            // 
            this.born_data_label.AutoSize = true;
            this.born_data_label.Location = new System.Drawing.Point(382, 220);
            this.born_data_label.Name = "born_data_label";
            this.born_data_label.Size = new System.Drawing.Size(86, 13);
            this.born_data_label.TabIndex = 16;
            this.born_data_label.Text = "Дата рождения";
            // 
            // repeat_password_label
            // 
            this.repeat_password_label.AutoSize = true;
            this.repeat_password_label.Location = new System.Drawing.Point(382, 183);
            this.repeat_password_label.Name = "repeat_password_label";
            this.repeat_password_label.Size = new System.Drawing.Size(100, 13);
            this.repeat_password_label.TabIndex = 15;
            this.repeat_password_label.Text = "Повторите пароль";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(382, 142);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(45, 13);
            this.password_label.TabIndex = 14;
            this.password_label.Text = "Пароль";
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Location = new System.Drawing.Point(382, 100);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(38, 13);
            this.login_label.TabIndex = 13;
            this.login_label.Text = "Логин";
            // 
            // tables_tabPage
            // 
            this.tables_tabPage.Controls.Add(this.update_button);
            this.tables_tabPage.Controls.Add(this.delete_string_button);
            this.tables_tabPage.Controls.Add(this.update_string_button);
            this.tables_tabPage.Controls.Add(this.add_string_button);
            this.tables_tabPage.Controls.Add(this.tables_dataGridView);
            this.tables_tabPage.Location = new System.Drawing.Point(4, 22);
            this.tables_tabPage.Name = "tables_tabPage";
            this.tables_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tables_tabPage.Size = new System.Drawing.Size(1258, 531);
            this.tables_tabPage.TabIndex = 2;
            this.tables_tabPage.Text = "Таблицы";
            this.tables_tabPage.UseVisualStyleBackColor = true;
            // 
            // update_button
            // 
            this.update_button.Location = new System.Drawing.Point(326, 456);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(123, 23);
            this.update_button.TabIndex = 18;
            this.update_button.Text = "Обновить таблицу";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // delete_string_button
            // 
            this.delete_string_button.Location = new System.Drawing.Point(727, 456);
            this.delete_string_button.Name = "delete_string_button";
            this.delete_string_button.Size = new System.Drawing.Size(106, 23);
            this.delete_string_button.TabIndex = 17;
            this.delete_string_button.Text = "Удалить запись";
            this.delete_string_button.UseVisualStyleBackColor = true;
            this.delete_string_button.Click += new System.EventHandler(this.delete_string_button_Click_1);
            // 
            // update_string_button
            // 
            this.update_string_button.Location = new System.Drawing.Point(602, 456);
            this.update_string_button.Name = "update_string_button";
            this.update_string_button.Size = new System.Drawing.Size(106, 23);
            this.update_string_button.TabIndex = 16;
            this.update_string_button.Text = "Обновить запись";
            this.update_string_button.UseVisualStyleBackColor = true;
            this.update_string_button.Click += new System.EventHandler(this.update_string_button_Click);
            // 
            // add_string_button
            // 
            this.add_string_button.Location = new System.Drawing.Point(473, 456);
            this.add_string_button.Name = "add_string_button";
            this.add_string_button.Size = new System.Drawing.Size(106, 23);
            this.add_string_button.TabIndex = 15;
            this.add_string_button.Text = "Добавить запись";
            this.add_string_button.UseVisualStyleBackColor = true;
            this.add_string_button.Click += new System.EventHandler(this.add_string_button_Click);
            // 
            // tables_dataGridView
            // 
            this.tables_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tables_dataGridView.Location = new System.Drawing.Point(6, 6);
            this.tables_dataGridView.MultiSelect = false;
            this.tables_dataGridView.Name = "tables_dataGridView";
            this.tables_dataGridView.Size = new System.Drawing.Size(1246, 391);
            this.tables_dataGridView.TabIndex = 9;
            // 
            // местаToolStripMenuItem
            // 
            this.местаToolStripMenuItem.Name = "местаToolStripMenuItem";
            this.местаToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.местаToolStripMenuItem.Text = "Места";
            this.местаToolStripMenuItem.Click += new System.EventHandler(this.местаToolStripMenuItem_Click);
            // 
            // start_page_tabPage
            // 
            this.start_page_tabPage.Controls.Add(this.label1);
            this.start_page_tabPage.Location = new System.Drawing.Point(4, 22);
            this.start_page_tabPage.Name = "start_page_tabPage";
            this.start_page_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.start_page_tabPage.Size = new System.Drawing.Size(1258, 531);
            this.start_page_tabPage.TabIndex = 3;
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
            this.label1.TabIndex = 4;
            this.label1.Text = "Добро пожаловать на сайт аэропорта!";
            // 
            // Admin_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 597);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Admin_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База данных аэропорта - Администратор";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_form_FormClosing);
            this.Load += new System.EventHandler(this.Admin_form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.airportDB_2DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.airportDB2DataSet1BindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.sql_request_tabPage.ResumeLayout(false);
            this.sql_request_tabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sql_dataGridView)).EndInit();
            this.account_management_tabPage.ResumeLayout(false);
            this.account_management_tabPage.PerformLayout();
            this.tables_tabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tables_dataGridView)).EndInit();
            this.start_page_tabPage.ResumeLayout(false);
            this.start_page_tabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem авиакомпанияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem активностьавиакомпанииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem билетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem билетпользовательToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem броньToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem броньпользовательToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вППToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem классификацияВППToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem маршрутToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem метеопрогнозToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правилапоперевозкебагажаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расценкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рейсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem самолётToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистическиеданныеопассажирахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статусбилетаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статусброниToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статуссамолётаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходИзАккаунтаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходИзПриложенияToolStripMenuItem;
        private System.Windows.Forms.BindingSource airportDB2DataSet1BindingSource;
        private AirportDB_2DataSet1 airportDB_2DataSet1;
        private System.Windows.Forms.ToolStripMenuItem пользовательToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem управлениеАккаунтамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьПользователяToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage sql_request_tabPage;
        private System.Windows.Forms.Button execute_button;
        private System.Windows.Forms.Label sql_request_label;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.DataGridView sql_dataGridView;
        private System.Windows.Forms.TabPage account_management_tabPage;
        private System.Windows.Forms.TextBox mail_textbox;
        private System.Windows.Forms.Label mail_label;
        private System.Windows.Forms.TextBox first_name_textbox;
        private System.Windows.Forms.TextBox second_name_textbox;
        private System.Windows.Forms.Label first_name_label;
        private System.Windows.Forms.Label second_name_label;
        private System.Windows.Forms.DateTimePicker date_choose;
        private System.Windows.Forms.TextBox repeat_password_textbox;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.TextBox login_textbox;
        private System.Windows.Forms.Label born_data_label;
        private System.Windows.Forms.Label repeat_password_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.Button choose_role_button;
        private System.Windows.Forms.TextBox selphone_textBox;
        private System.Windows.Forms.Label selphone_label;
        private System.Windows.Forms.TextBox patronymic_textBox;
        private System.Windows.Forms.Label patronymic_label;
        private System.Windows.Forms.Button add_button;
        private TabPage tables_tabPage;
        private DataGridView tables_dataGridView;
        private Button delete_string_button;
        private Button update_string_button;
        private Button add_string_button;
        private Button update_button;
        private ToolStripMenuItem местаToolStripMenuItem;
        private TabPage start_page_tabPage;
        private Label label1;
    }
}