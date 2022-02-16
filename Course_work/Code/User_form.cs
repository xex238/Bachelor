using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW_windows_forms
{
    public partial class User_form : Form
    {
        //type_of_places_context_menu_strip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(type_of_places_context_menu_strip_ItemClicked);
        //choose_class_context_menu_strip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(choose_class_context_menu_strip_ItemClicked);
        ContextMenuStrip type_of_places_context_menu_strip = new ContextMenuStrip();
        ContextMenuStrip choose_class_context_menu_strip = new ContextMenuStrip();
        bool type_of_places_button_visible = false;
        int number_of_flight = -1; // Номер рейса, выбранный пользователем
        string[] ticket_values_from_flight; // Запись для вставки в таблицу "Билет"
        string value_table = "";
        DataGridView flight_dataGridView;

        SqlDataAdapter sql_data_adapter = null;
        DataTable data_table = null;

        public User_form()
        {
            InitializeComponent();
        }
        private async void Select_function(string command)
        {
            SqlDataReader sql_data_reader = null;

            try
            {
                SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                sql_data_reader = await sql_command.ExecuteReaderAsync();

                // Начало вставленного кода
                var columns_name = new List<string>();

                int count_of_columns = sql_data_reader.FieldCount;

                for (int i = 0; i < count_of_columns; i++)
                {
                    columns_name.Add(sql_data_reader.GetName(i));
                }
                // Конец вставленного кода

                List<string[]> data = new List<string[]>();

                DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[count_of_columns];

                while (await (sql_data_reader.ReadAsync()))
                {
                    data.Add(new string[count_of_columns]);

                    for (int i = 0; i < count_of_columns; i++)
                    {
                        data[data.Count - 1][i] = sql_data_reader[i].ToString();
                    }
                }
                sql_data_reader.Close();

                // Код для тестирования
                user_dataGridView.Columns.Clear();

                for (int i = 0; i < count_of_columns; i++)
                {
                    columns[i] = new DataGridViewTextBoxColumn();
                    columns[i].ReadOnly = true;
                    columns[i].HeaderText = columns_name[i];
                }

                for (int i = 0; i < count_of_columns; i++)
                {
                    user_dataGridView.Columns.Add(columns[i]);
                }

                user_dataGridView.Rows.Clear();
                tabControl1.SelectTab(my_tickets_page);
                foreach (string[] s in data)
                {
                    user_dataGridView.Rows.Add(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sql_data_reader != null)
                {
                    sql_data_reader.Close();
                }
            }
        }
        private void User_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (My_values.sql_connection != null && My_values.sql_connection.State != ConnectionState.Closed)
            {
                My_values.sql_connection.Close();
                Application.Exit();
            }
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (My_values.sql_connection != null && My_values.sql_connection.State != ConnectionState.Closed)
            {
                My_values.sql_connection.Close();
                Application.Exit();
            }
        }
        private void моиБилетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string command = "SELECT Билет.Номер_билета, Билет.Номер_рейса, Билет.Класс_обслуживания, Билет.Цена, Билет.Дата_время_отправления, Билет.Дата_время_прибытия, Билет.Аэропорт_отправления, Билет.Аэропорт_прибытия, Билет.Номер_места, Билет.Статус_билета\n";
            command += "FROM Билет, Билет_Пользователь\n";
            command += "WHERE Билет_Пользователь.ID_пользователя = " + My_values.value_user_ID + " and Билет.Номер_билета = Билет_Пользователь.Номер_билета";

            Select_function(command);
        }
        private async void User_form_Load(object sender, EventArgs e)
        {
            registration_label.Text += My_values.value_user_login;

            SqlDataReader sql_data_reader = null;
            try
            {
                string command = "SELECT * FROM Пользователь WHERE Пользователь.Почта = '" + My_values.value_user_mail + "'and Пользователь.Пароль = '" + My_values.value_user_password + "'";
                SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                sql_data_reader = await sql_command.ExecuteReaderAsync();

                while (await sql_data_reader.ReadAsync())
                {
                    login_textbox.Text = sql_data_reader["Логин"].ToString();
                    selphone_number_textbox.Text = sql_data_reader["Номер_телефона"].ToString();
                    second_name_textbox.Text = sql_data_reader["Фамилия"].ToString();
                    first_name_textbox.Text = sql_data_reader["Имя"].ToString();
                    patronymic_textbox.Text = sql_data_reader["Отчество"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(sql_data_reader != null)
                {
                    sql_data_reader.Close();
                }
            }

            // Загрузка картинок
            try
            {
                Image start_page_image = new Bitmap(@"user\pictures\start_page_background.jpg");
                this.start_page.BackgroundImage = start_page_image;
                this.start_page.BackgroundImageLayout = ImageLayout.Stretch;

                Image personal_data_image = new Bitmap(@"user\pictures\star_sky_plain.jpg");
                this.personal_data_tabPage.BackgroundImage = personal_data_image;
                this.personal_data_tabPage.BackgroundImageLayout = ImageLayout.Stretch;

                Image reference_image = new Bitmap(@"user\pictures\NUST_MISIS.jpg");
                this.reference_page.BackgroundImage = reference_image;
                this.reference_page.BackgroundImageLayout = ImageLayout.Stretch;

                Image my_image = new Bitmap(@"user\themes\night_theme.jpg");
                this.BackgroundImage = my_image;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void выходИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My_values.user.Hide();
            My_values.st_form.Show();
        }
        private void моиБрониToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string command = "SELECT Бронь.Номер_брони, Бронь.Номер_рейса, Бронь.Класс_обслуживания, Бронь.Цена, Бронь.Дата_время_отправления, Бронь.Дата_время_прибытия, Бронь.Аэропорт_отправления, Бронь.Аэропорт_прибытия, Бронь.Номер_места, Бронь.Статус_брони\n";
            command += "FROM Бронь, Бронь_Пользователь\n";
            command += "WHERE Бронь_Пользователь.ID_пользователя = " + My_values.value_user_ID + " and Бронь.Номер_брони = Бронь_Пользователь.Номер_брони";

            Select_function(command);
        }
        private async void рейсыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlDataReader sql_data_reader = null;

            try
            {
                string command = "SELECT Номер_рейса, Дата_время_отправления, Дата_время_прибытия, Аэропорт_отправления, Аэропорт_прибытия, Общее_количество_мест, Количество_свободных_мест\n";
                command = command + "FROM Рейс";

                SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                sql_data_reader = await sql_command.ExecuteReaderAsync();

                List<string[]> data = new List<string[]>();

                int count_of_columns = 7;
                while (await(sql_data_reader.ReadAsync()))
                {
                    data.Add(new string[count_of_columns]);

                    for (int i = 0; i < count_of_columns; i++)
                    {
                        data[data.Count - 1][i] = sql_data_reader[i].ToString();
                    }
                }
                sql_data_reader.Close();

                airport_dataGridView.Columns.Clear();
                //user_dataGridView.Columns.Clear();

                DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[count_of_columns];

                for (int i = 0; i < count_of_columns; i++)
                {
                    columns[i] = new DataGridViewTextBoxColumn();
                    columns[i].ReadOnly = true;
                }

                columns[0].HeaderText = "Номер рейса";
                columns[1].HeaderText = "Дата и время отправления";
                columns[2].HeaderText = "Дата и время прибытия";
                columns[3].HeaderText = "Аэропорт отправления";
                columns[4].HeaderText = "Аэропорт прибытия";
                columns[5].HeaderText = "Общее количество мест";
                columns[6].HeaderText = "Количество свободных мест";

                for (int i = 0; i < count_of_columns; i++)
                {
                    airport_dataGridView.Columns.Add(columns[i]);
                }

                airport_dataGridView.Rows.Clear();
                tabControl1.SelectTab(buy_ticket_tabPage);
                foreach (string[] s in data)
                {
                    airport_dataGridView.Rows.Add(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sql_data_reader != null)
                {
                    sql_data_reader.Close();
                }
            }
        }
        private void type_of_places_context_menu_strip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem.Text == "Любые")
            {
                type_of_places_button.Text = "Любые";
            }
            if(e.ClickedItem.Text == "Только свободные")
            {
                type_of_places_button.Text = "Только свободные";
            }
        }
        private void type_of_places_button_Click(object sender, EventArgs e)
        {
            if(!type_of_places_button_visible)
            {
                type_of_places_context_menu_strip.Items.Clear();
                type_of_places_context_menu_strip.Items.Add("Любые");
                type_of_places_context_menu_strip.Items.Add("Только свободные");

                type_of_places_context_menu_strip.Show(type_of_places_button, new Point(0, type_of_places_button.Height));
            }
            else
            {
                type_of_places_context_menu_strip.Hide();
            }
        }
        private async void select_data_button_Click(object sender, EventArgs e)
        {
            if(type_of_places_button.Text == "Выберите места")
            {
                MessageBox.Show("Места не выбраны", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                SqlDataReader sql_data_reader = null;

                if ((airport_depart_textBox.Text == "") || (airport_arrive_textBox.Text == ""))
                {
                    MessageBox.Show("Не все поля заполнены", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        string command = "SELECT Номер_рейса, Дата_время_отправления, Дата_время_прибытия, Аэропорт_отправления, Аэропорт_прибытия, Общее_количество_мест, Количество_свободных_мест\n";
                        command = command + "FROM Рейс\n";

                        if (type_of_places_button.Text == "Только свободные")
                        {
                            command = command + "WHERE (Рейс.Аэропорт_отправления = '" + airport_depart_textBox.Text + "') and (Рейс.Аэропорт_прибытия = '" + airport_arrive_textBox.Text + "') and (Рейс.Количество_свободных_мест > 0) and\n";
                        }
                        else
                        {
                            command = command + "WHERE (Рейс.Аэропорт_отправления = '" + airport_depart_textBox.Text + "') and (Рейс.Аэропорт_прибытия = '" + airport_arrive_textBox.Text + "') and\n";
                        }
                        command = command + "(DAY(Рейс.Дата_время_отправления) = " + dateTimePicker1.Value.Day + ") and (MONTH(Рейс.Дата_время_отправления) = " + dateTimePicker1.Value.Month + ") and (YEAR(Рейс.Дата_время_отправления) = " + dateTimePicker1.Value.Year + ")";

                        SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                        sql_data_reader = await sql_command.ExecuteReaderAsync();

                        List<string[]> data = new List<string[]>();

                        int count_of_columns = 7;
                        while (await (sql_data_reader.ReadAsync()))
                        {
                            data.Add(new string[count_of_columns]);

                            for (int i = 0; i < count_of_columns; i++)
                            {
                                data[data.Count - 1][i] = sql_data_reader[i].ToString();
                            }
                        }
                        sql_data_reader.Close();

                        airport_dataGridView.Columns.Clear();

                        DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[count_of_columns];

                        for (int i = 0; i < count_of_columns; i++)
                        {
                            columns[i] = new DataGridViewTextBoxColumn();
                            columns[i].ReadOnly = true;
                            //columns[i].Visible = false; // Тут было произведено изменение
                        }

                        columns[0].HeaderText = "Номер рейса";
                        columns[1].HeaderText = "Дата и время отправления";
                        columns[2].HeaderText = "Дата и время прибытия";
                        columns[3].HeaderText = "Аэропорт отправления";
                        columns[4].HeaderText = "Аэропорт прибытия";
                        columns[5].HeaderText = "Общее количество мест";
                        columns[6].HeaderText = "Количество свободных мест";

                        for (int i = 0; i < count_of_columns; i++)
                        {
                            airport_dataGridView.Columns.Add(columns[i]);
                        }

                        airport_dataGridView.Rows.Clear();
                        tabControl1.SelectTab(buy_ticket_tabPage);
                        foreach (string[] s in data)
                        {
                            airport_dataGridView.Rows.Add(s);
                        }

                        value_table = "Рейс";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sql_data_reader != null)
                        {
                            sql_data_reader.Close();
                        }
                    }
                }
            }
        }
        private async void расценкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlDataReader sql_data_reader = null;

            try
            {
                string command = "SELECT Номер_рейса, Стоимость_первого_класса, Стоимость_бизнес_класса, Стоимость_эконом_класса\n";
                command = command + "FROM Расценки";

                SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                sql_data_reader = await sql_command.ExecuteReaderAsync();

                List<string[]> data = new List<string[]>();

                int count_of_columns = 7;
                while (await(sql_data_reader.ReadAsync()))
                {
                    data.Add(new string[count_of_columns]);

                    for (int i = 0; i < count_of_columns; i++)
                    {
                        data[data.Count - 1][i] = sql_data_reader[i].ToString();
                    }
                }
                sql_data_reader.Close();

                airport_dataGridView.Columns.Clear();

                DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[count_of_columns];

                for (int i = 0; i < count_of_columns; i++)
                {
                    columns[i] = new DataGridViewTextBoxColumn();
                    columns[i].ReadOnly = true;
                }

                columns[0].HeaderText = "Номер рейса";
                columns[1].HeaderText = "Дата и время отправления";
                columns[2].HeaderText = "Дата и время прибытия";
                columns[3].HeaderText = "Аэропорт отправления";
                columns[4].HeaderText = "Аэропорт прибытия";
                columns[5].HeaderText = "Общее количество мест";
                columns[6].HeaderText = "Количество свободных мест";

                for (int i = 0; i < count_of_columns; i++)
                {
                    airport_dataGridView.Columns.Add(columns[i]);
                }

                airport_dataGridView.Rows.Clear();
                tabControl1.SelectTab(buy_ticket_tabPage);
                foreach (string[] s in data)
                {
                    airport_dataGridView.Rows.Add(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sql_data_reader != null)
                {
                    sql_data_reader.Close();
                }
            }
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(reference_page);
        }
        private void персональныеДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(personal_data_tabPage);
        }
        private async void update_button_Click(object sender, EventArgs e)
        {
            try
            {
                if((login_textbox.Text != "") && (second_name_textbox.Text != "") && (first_name_textbox.Text != ""))
                {
                    string command = "UPDATE Пользователь\n";
                    if (password_textbox.Text == "")
                    {
                        command += "SET Логин = '" + login_textbox.Text + "', Номер_телефона = '" + selphone_number_textbox.Text + "', Фамилия = '" + second_name_textbox.Text + "', Имя = '" + first_name_textbox.Text + "', Отчество = '" + patronymic_textbox.Text + "'\n";
                        command += "WHERE Пользователь.Почта = '" + My_values.value_user_mail + "' and Пользователь.Пароль = '" + My_values.value_user_password + "'";

                        SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);
                        await sql_command.ExecuteNonQueryAsync();

                        MessageBox.Show("Данные пользователя обновлены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if((password_textbox.Text != "") && (old_password_textBox.Text == My_values.value_user_password))
                    {
                        command += "SET Логин = '" + login_textbox.Text + "', Пароль = '" + password_textbox.Text + "', Номер_телефона = '" + selphone_number_textbox.Text + "', Фамилия = '" + second_name_textbox.Text + "', Имя = '" + first_name_textbox.Text + "', Отчество = '" + patronymic_textbox.Text + "'\n";
                        command += "WHERE Пользователь.Почта = '" + My_values.value_user_mail + "' and Пользователь.Пароль = '" + My_values.value_user_password + "'";

                        SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);
                        await sql_command.ExecuteNonQueryAsync();

                        string file_path = "TextFile.txt";
                        string text = My_values.value_user_mail + "\n" + password_textbox.Text;
                        File.WriteAllText(file_path, text);

                        MessageBox.Show("Данные пользователя обновлены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void choose_floght_button_Click(object sender, EventArgs e)
        {
            if(value_table != "Рейс")
            {
                MessageBox.Show("Выведите список рейсов для выбора", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(type_of_places_button.Text == "Выберите места")
            {
                MessageBox.Show("Места не выбраны", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlDataReader sql_data_reader = null;

                try
                {
                    // Часть, не входящая в try
                    int selected_row_index = airport_dataGridView.CurrentCell.RowIndex;
                    int count_of_columns = airport_dataGridView.ColumnCount;

                    //MessageBox.Show(count_of_columns.ToString(), "Количество столбцов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    number_of_flight = Convert.ToInt32(airport_dataGridView.Rows[selected_row_index].Cells[0].Value);
                    string command = "SELECT * FROM Места WHERE Места.ID = \n";
                    command += "(SELECT ID_таблицы_мест FROM Рейс WHERE Номер_рейса = '" + airport_dataGridView.Rows[selected_row_index].Cells[0].Value.ToString() + "')";

                    ticket_values_from_flight = new string[6];
                    ticket_values_from_flight[0] = airport_dataGridView[0, selected_row_index].Value.ToString();
                    ticket_values_from_flight[2] = "'" + airport_dataGridView[1, selected_row_index].Value.ToString() + "'"; // Дата_время_отправления
                    ticket_values_from_flight[3] = "'" + airport_dataGridView[2, selected_row_index].Value.ToString() + "'"; // Дата_время_прибытия
                    ticket_values_from_flight[4] = "'" + airport_dataGridView[3, selected_row_index].Value.ToString() + "'"; // Аэропорт_отправления
                    ticket_values_from_flight[5] = "'" + airport_dataGridView[4, selected_row_index].Value.ToString() + "'"; // Аэропорт_прибытия

                    // Вторая часть работы метода
                    sql_data_adapter = new SqlDataAdapter(command, My_values.sql_connection);
                    SqlCommandBuilder sql_command_builder = new SqlCommandBuilder(sql_data_adapter);
                    data_table = new DataTable();
                    sql_data_adapter.Fill(data_table);

                    SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                    sql_data_reader = await sql_command.ExecuteReaderAsync();

                    var columns_name = new List<string>();

                    //MessageBox.Show(sql_data_reader.FieldCount.ToString(), "Количество столбцов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //int count_of_columns = sql_data_reader.FieldCount;
                    count_of_columns = sql_data_reader.FieldCount;

                    for (int i = 0; i < count_of_columns; i++)
                    {
                        columns_name.Add(sql_data_reader.GetName(i));
                    }

                    List<string[]> data = new List<string[]>();

                    DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[count_of_columns];

                    while (await (sql_data_reader.ReadAsync()))
                    {
                        data.Add(new string[count_of_columns]);

                        for (int i = 0; i < count_of_columns; i++)
                        {
                            data[data.Count - 1][i] = sql_data_reader[i].ToString();
                        }
                    }
                    sql_data_reader.Close();

                    airport_dataGridView.Columns.Clear();

                    for (int i = 0; i < count_of_columns; i++)
                    {
                        columns[i] = new DataGridViewTextBoxColumn();
                        columns[i].ReadOnly = false;
                        columns[i].HeaderText = columns_name[i];
                    }
                    columns[0].ReadOnly = true;

                    for (int i = 0; i < count_of_columns; i++)
                    {
                        airport_dataGridView.Columns.Add(columns[i]);
                    }

                    airport_dataGridView.Rows.Clear();
                    foreach (string[] s in data)
                    {
                        airport_dataGridView.Rows.Add(s);
                    }

                    value_table = "Места";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sql_data_reader != null)
                    {
                        sql_data_reader.Close();
                    }
                }
            }
        }
        private void choose_class_context_menu_strip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem.Text == "Первый класс")
            {
                choose_class_button.Text = "Первый класс";
            }
            if(e.ClickedItem.Text == "Бизнесс класс")
            {
                choose_class_button.Text = "Бизнесс класс";
            }
            if(e.ClickedItem.Text == "Эконом класс")
            {
                choose_class_button.Text = "Эконом класс";
            }
        }
        private void choose_class_button_Click(object sender, EventArgs e)
        {
            try
            {
                int selected_row_index = airport_dataGridView.CurrentCell.RowIndex;
                //int count_of_columns = airport_dataGridView.ColumnCount;

                choose_class_context_menu_strip.Items.Clear();
                choose_class_context_menu_strip.Items.Add("Первый класс");
                choose_class_context_menu_strip.Items.Add("Бизнесс класс");
                choose_class_context_menu_strip.Items.Add("Эконом класс");

                //// Видимость кнопок в зависимости от наличия мест в определённом классе
                //int count_of_places_first_class = Convert.ToInt32(airport_dataGridView.Rows[selected_row_index].Cells[2].Value);
                //int count_of_places_busines_class = Convert.ToInt32(airport_dataGridView.Rows[selected_row_index].Cells[5].Value);
                //int count_of_places_economy_class = Convert.ToInt32(airport_dataGridView.Rows[selected_row_index].Cells[8].Value);
                //if(count_of_places_first_class != 0)
                //{
                //    choose_class_context_menu_strip.Items[0].Visible = true;
                //}
                //else
                //{
                //    choose_class_context_menu_strip.Items[0].Visible = false;
                //}
                //if(count_of_places_busines_class != 0)
                //{
                //    choose_class_context_menu_strip.Items[1].Visible = true;
                //}
                //else
                //{
                //    choose_class_context_menu_strip.Items[1].Visible = false;
                //}
                //if(count_of_places_economy_class != 0)
                //{
                //    choose_class_context_menu_strip.Items[2].Visible = true;
                //}
                //else
                //{
                //    choose_class_context_menu_strip.Items[2].Visible = false;
                //}

                //type_of_places_context_menu_strip.Show(type_of_places_button, new Point(0, type_of_places_button.Height));
                choose_class_context_menu_strip.Show(choose_class_button, new Point(0, choose_class_button.Height));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buy_ticket_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (value_table != "Места")
                {
                    MessageBox.Show("Сначала выберите рейс", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (choose_class_button.Text == "Выберите класс")
                {
                    MessageBox.Show("Сначала выберите класс", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int selected_row_index = airport_dataGridView.CurrentCell.RowIndex;
                    if (((choose_class_button.Text == "Первый класс") && (Convert.ToInt32(airport_dataGridView[2, selected_row_index].Value) == 0)) ||
                    ((choose_class_button.Text == "Бизнесс класс") && (Convert.ToInt32(airport_dataGridView[5, selected_row_index].Value) == 0)) ||
                    ((choose_class_button.Text == "Эконом класс") && (Convert.ToInt32(airport_dataGridView[8, selected_row_index].Value) == 0)))
                    {
                        MessageBox.Show("Свободных мест нет", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        My_values.passport_form = new Passport_data_form();
                        My_values.passport_form.Show();
                        My_values.passport_form.Activate();
                        // Поставить дальнейшее выполнение программы на ожидание
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async void buy_ticket_button_Click_continue()
        {
            try
            {
                int selected_row_index = airport_dataGridView.CurrentCell.RowIndex;

                string type_of_class = "";

                string command = "BEGIN TRANSACTION\n";

                // Вставляем данные в таблицу "Билет"
                command += "INSERT INTO Билет (Номер_рейса, Класс_обслуживания, Цена, Дата_время_отправления, Дата_время_прибытия, Аэропорт_отправления, Аэропорт_прибытия, Серия_паспорта, Номер_паспорта, Номер_места, Статус_билета)\n";
                command += "VALUES (" + ticket_values_from_flight[0] + ", ";

                int place_number = -1;
                if (choose_class_button.Text == "Первый класс") // Класс обслуживания и цена
                {
                    type_of_class = "'FIRST'";
                    command += "'FIRST', ";
                    command += "'" + airport_dataGridView[3, selected_row_index].Value.ToString() + "', ";
                    place_number = Convert.ToInt32(airport_dataGridView[1, selected_row_index].Value) - Convert.ToInt32(airport_dataGridView[2, selected_row_index].Value) + 1;
                }
                if (choose_class_button.Text == "Бизнесс класс") // Класс обслуживания и цена
                {
                    type_of_class = "'BUSINESS'";
                    command += "'BUSINESS', ";
                    command += "'" + airport_dataGridView[6, selected_row_index].Value.ToString() + "', ";
                    place_number = Convert.ToInt32(airport_dataGridView[4, selected_row_index].Value) - Convert.ToInt32(airport_dataGridView[5, selected_row_index].Value) + 1;
                }
                if (choose_class_button.Text == "Эконом класс") // Класс обслуживания и цена
                {
                    type_of_class = "'ECONOMY'";
                    command += "'ECONOMY', ";
                    command += "'" + airport_dataGridView[9, selected_row_index].Value.ToString() + "', ";
                    place_number = Convert.ToInt32(airport_dataGridView[7, selected_row_index].Value) - Convert.ToInt32(airport_dataGridView[8, selected_row_index].Value) + 1;
                }
                command += ticket_values_from_flight[2] + ", "; // Дата_время_отправления
                command += ticket_values_from_flight[3] + ", "; // Дата_время_прибытия
                command += ticket_values_from_flight[4] + ", "; // Аэропорт отправления
                command += ticket_values_from_flight[5] + ", "; // Аэропорт прибытия
                command += My_values.user_passport_series + ", "; // Серия паспорта
                command += My_values.user_passport_number + ", "; // Номер паспорта
                command += place_number + ", 1)\n \n"; // Номер места, статус билета

                // Обновляем таблицу "Рейс"
                command += "UPDATE Рейс\n";
                command += "SET Количество_свободных_мест = Количество_свободных_мест - 1\n";
                command += "WHERE Номер_рейса = " + ticket_values_from_flight[0] + "\n";
                command += "\n";

                // Обновляем таблицу "Места"
                command += "UPDATE Места\n";
                if (choose_class_button.Text == "Первый класс")
                {
                    command += "SET Количество_свободных_мест_первого_класса = Количество_свободных_мест_первого_класса - 1\n";
                }
                if (choose_class_button.Text == "Бизнесс класс")
                {
                    command += "SET Количество_свободных_мест_бизнес_класса = Количество_свободных_мест_бизнес_класса - 1\n";
                }
                if (choose_class_button.Text == "Эконом класс")
                {
                    command += "SET Количество_свободных_мест_эконом_класса = Количество_свободных_мест_эконом_класса - 1\n";
                }
                command += "WHERE ID = (SELECT ID_таблицы_мест FROM Рейс WHERE Номер_рейса = " + ticket_values_from_flight[0] + ")\n \n";

                //MessageBox.Show("Здесь всё в порядке", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Номер рейса, класс обслуживания и номер места однозначно определяют номер билета
                command += "DECLARE @my_ticket INT\n";
                command += "SET @my_ticket = (SELECT Билет.Номер_билета FROM Билет WHERE (Номер_рейса = " + ticket_values_from_flight[0] + " and Класс_обслуживания = " + type_of_class + " and Номер_места = " + place_number + "))\n \n";

                command += "INSERT INTO Билет_Пользователь (Номер_билета, ID_пользователя)\n";
                command += "VALUES (@my_ticket, " + My_values.value_user_ID + ")\n";

                command += "COMMIT\n \n";

                //MessageBox.Show(command, "Сформированная команда", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                await sql_command.ExecuteNonQueryAsync();

                MessageBox.Show("Покупка прошла удачно", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void reservation_ticket_button_Click(object sender, EventArgs e)
        {
            if (value_table != "Места")
            {
                MessageBox.Show("Сначала выберите рейс", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (choose_class_button.Text == "Выберите класс")
            {
                MessageBox.Show("Сначала выберите класс", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int selected_row_index = airport_dataGridView.CurrentCell.RowIndex;
                if (((choose_class_button.Text == "Первый класс") && (Convert.ToInt32(airport_dataGridView[2, selected_row_index].Value) == 0)) ||
                ((choose_class_button.Text == "Бизнесс класс") && (Convert.ToInt32(airport_dataGridView[5, selected_row_index].Value) == 0)) ||
                ((choose_class_button.Text == "Эконом класс") && (Convert.ToInt32(airport_dataGridView[8, selected_row_index].Value) == 0)))
                {
                    MessageBox.Show("Свободных мест нет", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        //int selected_row_index = airport_dataGridView.CurrentCell.RowIndex;
                        string type_of_class = "";

                        string command = "BEGIN TRANSACTION\n";

                        // Вставляем данные в таблицу "Билет"
                        //command += "INSERT INTO Билет (Номер_рейса, Класс_обслуживания, Цена, Дата_время_отправления, Дата_время_прибытия, Аэропорт_отправления, Аэропорт_прибытия, Серия_паспорта, Номер_паспорта, Номер_места, Статус_билета)\n";
                        command += "INSERT INTO Бронь (Номер_рейса, Класс_обслуживания, Цена, Дата_время_отправления, Дата_время_прибытия, Аэропорт_отправления, Аэропорт_прибытия, Номер_места, Статус_брони)\n";
                        command += "VALUES (" + ticket_values_from_flight[0] + ", ";

                        int place_number = -1;
                        if (choose_class_button.Text == "Первый класс")
                        {
                            type_of_class = "'FIRST'";
                            command += "'FIRST', ";
                            command += "'" + airport_dataGridView[3, selected_row_index].Value.ToString() + "', ";
                            place_number = Convert.ToInt32(airport_dataGridView[1, selected_row_index].Value) - Convert.ToInt32(airport_dataGridView[2, selected_row_index].Value) + 1;
                        }
                        if (choose_class_button.Text == "Бизнесс класс")
                        {
                            type_of_class = "'BUSINESS'";
                            command += "'BUSINESS', ";
                            command += "'" + airport_dataGridView[6, selected_row_index].Value.ToString() + "', ";
                            place_number = Convert.ToInt32(airport_dataGridView[4, selected_row_index].Value) - Convert.ToInt32(airport_dataGridView[5, selected_row_index].Value) + 1;
                        }
                        if (choose_class_button.Text == "Эконом класс")
                        {
                            type_of_class = "'ECONOMY'";
                            command += "'ECONOMY', ";
                            command += "'" + airport_dataGridView[9, selected_row_index].Value.ToString() + "', ";
                            place_number = Convert.ToInt32(airport_dataGridView[7, selected_row_index].Value) - Convert.ToInt32(airport_dataGridView[8, selected_row_index].Value) + 1;
                        }
                        command += ticket_values_from_flight[2] + ", ";
                        command += ticket_values_from_flight[3] + ", ";
                        command += ticket_values_from_flight[4] + ", ";
                        command += ticket_values_from_flight[5] + ", " + place_number + ", 1)\n \n";

                        // Обновляем таблицу "Рейс"
                        command += "UPDATE Рейс\n";
                        command += "SET Количество_свободных_мест = Количество_свободных_мест - 1\n";
                        command += "WHERE Номер_рейса = " + ticket_values_from_flight[0] + "\n";
                        command += "\n";

                        // Обновляем таблицу "Места"
                        command += "UPDATE Места\n";
                        if (choose_class_button.Text == "Первый класс")
                        {
                            command += "SET Количество_свободных_мест_первого_класса = Количество_свободных_мест_первого_класса - 1\n";
                        }
                        if (choose_class_button.Text == "Бизнесс класс")
                        {
                            command += "SET Количество_свободных_мест_бизнесс_класса = Количество_свободных_мест_бизнесс_класса - 1\n";
                        }
                        if (choose_class_button.Text == "Эконом класс")
                        {
                            command += "SET Количество_свободных_мест_эконом_класса = Количество_свободных_мест_эконом_класса - 1\n";
                        }
                        command += "WHERE ID = (SELECT ID_таблицы_мест FROM Рейс WHERE Номер_рейса = " + ticket_values_from_flight[0] + ")\n \n";

                        MessageBox.Show("Здесь всё в порядке", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Номер рейса, класс обслуживания и номер места однозначно определяют номер билета
                        command += "DECLARE @my_reservation INT\n";
                        command += "SET @my_reservation = (SELECT Бронь.Номер_брони FROM Бронь WHERE (Номер_рейса = " + ticket_values_from_flight[0] + " and Класс_обслуживания = " + type_of_class + "and Номер_места = " + place_number + "))\n \n";

                        command += "INSERT INTO Бронь_Пользователь (Номер_брони, ID_пользователя)\n";
                        command += "VALUES (@my_reservation, " + My_values.value_user_ID + ")\n";

                        command += "COMMIT\n \n";

                        MessageBox.Show(command, "Сформированная команда", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                        await sql_command.ExecuteNonQueryAsync();

                        MessageBox.Show("Бронирование прошло удачно", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void show_my_tickets_button_Click(object sender, EventArgs e)
        {
            string command = "SELECT Билет.Номер_билета, Билет.Номер_рейса, Билет.Класс_обслуживания, Билет.Цена, Билет.Дата_время_отправления, Билет.Дата_время_прибытия, Билет.Аэропорт_отправления, Билет.Аэропорт_прибытия, Билет.Номер_места, Билет.Статус_билета\n";
            command += "FROM Билет, Билет_Пользователь\n";
            command += "WHERE Билет_Пользователь.ID_пользователя = " + My_values.value_user_ID + " and Билет.Номер_билета = Билет_Пользователь.Номер_билета";

            Select_function(command);
        }
        private void show_my_reservations_button_Click(object sender, EventArgs e)
        {
            string command = "SELECT Бронь.Номер_брони, Бронь.Номер_рейса, Бронь.Класс_обслуживания, Бронь.Цена, Бронь.Дата_время_отправления, Бронь.Дата_время_прибытия, Бронь.Аэропорт_отправления, Бронь.Аэропорт_прибытия, Бронь.Номер_места, Бронь.Статус_брони\n";
            command += "FROM Бронь, Бронь_Пользователь\n";
            command += "WHERE Бронь_Пользователь.ID_пользователя = " + My_values.value_user_ID + " and Бронь.Номер_брони = Бронь_Пользователь.Номер_брони";

            Select_function(command);
        }
        private void светлаяТемаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image my_image = new Bitmap(@"user\themes\light_theme.jpg");
                this.BackgroundImage = my_image;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void установитьСвоюТемуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string file_path = "";
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    file_path = ofd.FileName;
                }

                Image my_image = new Bitmap(file_path);
                this.BackgroundImage = my_image;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void тёмнаяТемаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image my_image = new Bitmap(@"user\themes\night_theme.jpg");
                this.BackgroundImage = my_image;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void show_active_tickets_button_Click(object sender, EventArgs e)
        {
            DateTime my_datetime = DateTime.Now;

            string command = "SELECT Билет.Номер_билета, Билет.Номер_рейса, Билет.Класс_обслуживания, Билет.Цена, Билет.Дата_время_отправления, Билет.Дата_время_прибытия, Билет.Аэропорт_отправления, Билет.Аэропорт_прибытия, Билет.Номер_места, Билет.Статус_билета\n";
            command += "FROM Билет, Билет_Пользователь\n";
            command += "WHERE Билет_Пользователь.ID_пользователя = " + My_values.value_user_ID + " and Билет.Номер_билета = Билет_Пользователь.Номер_билета and Билет.Дата_время_отправления > '" + my_datetime.Year + "." + my_datetime.Month + "." + my_datetime.Day + "'";

            Select_function(command);
        }
        private void show_active_reservations_button_Click(object sender, EventArgs e)
        {
            DateTime my_datetime = DateTime.Now;

            string command = "SELECT Бронь.Номер_брони, Бронь.Номер_рейса, Бронь.Класс_обслуживания, Бронь.Цена, Бронь.Дата_время_отправления, Бронь.Дата_время_прибытия, Бронь.Аэропорт_отправления, Бронь.Аэропорт_прибытия, Бронь.Номер_места, Бронь.Статус_брони\n";
            command += "FROM Бронь, Бронь_Пользователь\n";
            command += "WHERE Бронь_Пользователь.ID_пользователя = " + My_values.value_user_ID + " and Бронь.Номер_брони = Бронь_Пользователь.Номер_брони and Бронь.Дата_время_отправления > '" + my_datetime.Year + "." + my_datetime.Month + "." + my_datetime.Day + "'";

            Select_function(command);
        }
    }
}