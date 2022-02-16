using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW_windows_forms
{
    public partial class Admin_form : Form
    {
        //context_menu_strip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(context_menu_strip_ItemClicked);
        SqlDataAdapter sql_data_adapter = null;
        DataTable data_table = null;

        string value_table = "";

        //ContextMenuStrip context_menu_strip = new ContextMenuStrip();

        private void Update_sql_data_adapter()
        {
            sql_data_adapter.Update(data_table);
        }
        public Admin_form()
        {
            InitializeComponent();
        }
        private async void Select_function(string command)
        {
            SqlDataReader sql_data_reader = null;

            try
            {
                sql_data_adapter = new SqlDataAdapter(command, My_values.sql_connection);
                SqlCommandBuilder sql_command_builder = new SqlCommandBuilder(sql_data_adapter);
                data_table = new DataTable();
                sql_data_adapter.Fill(data_table);

                SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                sql_data_reader = await sql_command.ExecuteReaderAsync();

                var columns_name = new List<string>();

                int count_of_columns = sql_data_reader.FieldCount;

                for (int i = 0; i < count_of_columns; i++)
                {
                    columns_name.Add(sql_data_reader.GetName(i));
                }

                List<string[]> data = new List<string[]>();

                DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[count_of_columns];

                while (await(sql_data_reader.ReadAsync()))
                {
                    data.Add(new string[count_of_columns]);

                    for (int i = 0; i < count_of_columns; i++)
                    {
                        data[data.Count - 1][i] = sql_data_reader[i].ToString();
                    }
                }
                sql_data_reader.Close();

                // Код для тестирования
                //sql_dataGridView.Columns.Clear();
                tables_dataGridView.Columns.Clear();

                for (int i = 0; i < count_of_columns; i++)
                {
                    columns[i] = new DataGridViewTextBoxColumn();
                    columns[i].ReadOnly = false;
                    columns[i].HeaderText = columns_name[i];
                }
                columns[0].ReadOnly = true;

                for (int i = 0; i < count_of_columns; i++)
                {
                    tables_dataGridView.Columns.Add(columns[i]);
                }

                tables_dataGridView.Rows.Clear();
                foreach (string[] s in data)
                {
                    tables_dataGridView.Rows.Add(s);
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
        private void execute_button_Click(object sender, EventArgs e)
        {
            string command = richTextBox.Text;
            Select_function(command);
        }
        private void Admin_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (My_values.sql_connection != null && My_values.sql_connection.State != ConnectionState.Closed)
            {
                My_values.sql_connection.Close();
                Application.Exit();
            }
        }
        private void выходИзПриложенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (My_values.sql_connection != null && My_values.sql_connection.State != ConnectionState.Closed)
            {
                My_values.sql_connection.Close();
            }
            Application.Exit();
        }
        private void выходИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My_values.admin.Hide();
            My_values.st_form.Show();
        }
        private void авиакомпанияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Авиакомпания";
            string command = "SELECT * FROM Авиакомпания";
            Select_function(command);
        }
        private void активностьавиакомпанииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Активность_авиакомпании";
            string command = "SELECT * FROM Активность_авиакомпании";
            Select_function(command);
        }
        private void билетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Билет";
            string command = "SELECT * FROM Билет";
            Select_function(command);
        }
        private void билетпользовательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Билет_пользователь";
            string command = "SELECT * FROM Билет_Пользователь";
            Select_function(command);
        }
        private void броньToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Бронь";
            string command = "SELECT * FROM Бронь";
            Select_function(command);
        }
        private void броньпользовательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Бронь_Пользователь";
            string command = "SELECT * FROM Бронь_Пользователь";
            Select_function(command);
        }
        private void вППToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "ВПП";
            string command = "SELECT * FROM ВПП";
            Select_function(command);
        }
        private void классификацияВППToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Классификация_ВПП";
            string command = "SELECT * FROM Классификация_ВПП";
            Select_function(command);
        }
        private void маршрутToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Маршрут";
            string command = "SELECT * FROM Маршрут";
            Select_function(command);
        }
        private void метеопрогнозToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Метеопрогноз";
            string command = "SELECT * FROM Метеопрогноз";
            Select_function(command);
        }
        private void персоналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Персонал";
            string command = "SELECT * FROM Персонал";
            Select_function(command);
        }
        private void пользовательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Пользователь";
            string command = "SELECT * FROM Пользователь";
            Select_function(command);
        }
        private void правилапоперевозкебагажаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Правила_по_перевозке_багажа";
            string command = "SELECT * FROM Правила_по_перевозке_багажа";
            Select_function(command);
        }
        private void расценкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Расценки";
            string command = "SELECT * FROM Расценки";
            Select_function(command);
        }
        private void рейсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Рейс";
            string command = "SELECT * FROM Рейс";
            Select_function(command);
        }
        private void самолётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Самолёт";
            string command = "SELECT * FROM Самолёт";
            Select_function(command);
        }
        private void статистическиеданныеопассажирахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Статистические_данные_о_пассажирах";
            string command = "SELECT * FROM Статистические_данные_о_пассажирах";
            Select_function(command);
        }
        private void статусбилетаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Статус_билета";
            string command = "SELECT * FROM Статус_билета";
            Select_function(command);
        }
        private void статусброниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Статус_брони";
            string command = "SELECT * FROM Статус_брони";
            Select_function(command);
        }
        private void статуссамолётаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string command = "SELECT * FROM Статус_самолёта";
            //Select_function(command);

            SqlDataAdapter sql_data_adapter = new SqlDataAdapter(command, My_values.sql_connection);
            SqlCommandBuilder sql_command_builder = new SqlCommandBuilder(sql_data_adapter);

            DataTable data_table = new DataTable();
            sql_data_adapter.Fill(data_table);
            BindingSource binding_source = new BindingSource();
            binding_source.DataSource = data_table;

            sql_dataGridView.DataSource = binding_source;
            sql_dataGridView.Columns[0].Visible = false;
        }
        private void delete_string_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить выбранную запись?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    //admin_dataGridView.Rows.RemoveAt(admin_dataGridView.CurrentRow.Index);
                    //sql_data_adapter.Fill(data_table);
                    //Update_sql_data_adapter();

                    //string s = admin_dataGridView.CurrentCell.Value.ToString();
                    //MessageBox.Show(s, "Выбранная строка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BindingSource bs = new BindingSource();
                    bs = (BindingSource)(this.sql_dataGridView.DataSource);
                    string table_name = bs.DataMember;
                    //string table_name = admin_dataGridView.DataSource.ToString();
                    MessageBox.Show(table_name, "Название таблицы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void choose_role_button_Click(object sender, EventArgs e)
        {
            context_menu_strip.Items.Clear();
            context_menu_strip.Items.Add("Пользователь");
            context_menu_strip.Items.Add("Персонал");
            context_menu_strip.Items.Add("Администратор");

            context_menu_strip.Show(choose_role_button, new Point(0, choose_role_button.Height));
        }
        private void context_menu_strip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Пользователь")
            {
                choose_role_button.Text = "Пользователь";
            }
            if (e.ClickedItem.Text == "Персонал")
            {
                choose_role_button.Text = "Персонал";
            }
            if(e.ClickedItem.Text == "Администратор")
            {
                choose_role_button.Text = "Администратор";
            }
        }
        private void добавитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(account_management_tabPage);

            mail_textbox.Text = "";
            login_textbox.Text = "";
            password_textbox.Text = "";
            repeat_password_textbox.Text = "";
            second_name_textbox.Text = "";
            first_name_textbox.Text = "";
            patronymic_textBox.Text = "";
            selphone_textBox.Text = "";
            choose_role_button.Text = "Выбрать роль";
        }
        private async void add_button_Click(object sender, EventArgs e)
        {
            if((mail_textbox.Text != "") && (login_textbox.Text != "") && (password_textbox.Text != "") && (repeat_password_textbox.Text != "") && (second_name_textbox.Text != "") && (first_name_textbox.Text != "") && (selphone_textBox.Text != ""))
            {
                SqlDataReader sql_data_reader = null;

                string check_command = "SELECT * FROM Пользователь WHERE Пользователь.Почта = '" + mail_textbox.Text + "'";

                SqlCommand check_sql_command = new SqlCommand(check_command, My_values.sql_connection);

                List<object> l = new List<object>();

                sql_data_reader = await check_sql_command.ExecuteReaderAsync();

                while (await sql_data_reader.ReadAsync())
                {
                    l.Add(sql_data_reader["ID"]);
                }

                if(l.Count == 0)
                {
                    if (password_textbox.Text == repeat_password_textbox.Text)
                    {
                        try
                        {
                            string command = "INSERT INTO Пользователь (Почта, Логин, Пароль, Имя, Фамилия, Отчество, Номер_телефона, Дата_рождения, Роль) VALUES ('" + mail_textbox.Text + "', '" + login_textbox.Text + "', '" + password_textbox.Text + "', '" + first_name_textbox.Text + "', '" + second_name_textbox.Text + "', '" + patronymic_textBox.Text + "', '" + selphone_textBox.Text + "', '" + date_choose.Value.ToString("yyyy-MM-dd") + "', '" + choose_role_button.Text + "')";

                            SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);
                            await sql_command.ExecuteNonQueryAsync();

                            MessageBox.Show("Пользователь добавлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь с такой почтой уже существует", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async void execute_button_Click_1(object sender, EventArgs e)
        {
            try
            {
                string command = richTextBox.Text;

                string copy_command = command.ToUpper();
                //MessageBox.Show(command, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (copy_command.Contains("SELECT"))
                {
                    SqlDataReader sql_data_reader = null;

                    try
                    {
                        sql_data_adapter = new SqlDataAdapter(command, My_values.sql_connection);
                        SqlCommandBuilder sql_command_builder = new SqlCommandBuilder(sql_data_adapter);
                        data_table = new DataTable();
                        sql_data_adapter.Fill(data_table);

                        SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                        sql_data_reader = await sql_command.ExecuteReaderAsync();

                        var columns_name = new List<string>();

                        //MessageBox.Show(sql_data_reader.FieldCount.ToString(), "Количество столбцов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        int count_of_columns = sql_data_reader.FieldCount;

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

                        // Код для тестирования
                        sql_dataGridView.Columns.Clear();
                        //tables_dataGridView.Columns.Clear();

                        for (int i = 0; i < count_of_columns; i++)
                        {
                            columns[i] = new DataGridViewTextBoxColumn();
                            columns[i].ReadOnly = true;
                            columns[i].HeaderText = columns_name[i];
                        }

                        for (int i = 0; i < count_of_columns; i++)
                        {
                            sql_dataGridView.Columns.Add(columns[i]);
                        }

                        sql_dataGridView.Rows.Clear();
                        foreach (string[] s in data)
                        {
                            sql_dataGridView.Rows.Add(s);
                        }

                        MessageBox.Show("Команда успешно выполнена", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                else if (copy_command.Contains("INSERT"))
                {
                    SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                    await sql_command.ExecuteNonQueryAsync();
                    MessageBox.Show("Команда успешно выполнена", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (copy_command.Contains("UPDATE"))
                {
                    SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                    await sql_command.ExecuteNonQueryAsync();
                    MessageBox.Show("Команда успешно выполнена", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (copy_command.Contains("DELETE"))
                {
                    SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                    await sql_command.ExecuteNonQueryAsync();
                    MessageBox.Show("Команда успешно выполнена", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Неизвестная команда", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void update_button_Click(object sender, EventArgs e)
        {
            ////textBox1.Text = tables_dataGridView.SelectedCells[0].RowIndex.ToString();

            //textBox1.Text = tables_dataGridView.CurrentCell.Value.ToString();
            //textBox1.Text = tables_dataGridView.SelectedCells[0].RowIndex.ToString();

            //try
            //{
            //    int selected_row_index = tables_dataGridView.CurrentCell.RowIndex;
            //    int selected_column_index = tables_dataGridView.CurrentCell.ColumnIndex;
            //    textBox1.Text = tables_dataGridView.Rows[selected_row_index].Cells[0].Value.ToString(); // Значение ID
            //    textBox1.Text = tables_dataGridView.CurrentCell.ColumnIndex.ToString();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            string command = "SELECT * FROM " + value_table;
            Select_function(command);
        }
        private async void delete_string_button_Click_1(object sender, EventArgs e)
        {
            try
            {
                int selected_row_index = tables_dataGridView.CurrentCell.RowIndex;
                int ID = Convert.ToInt32(tables_dataGridView.Rows[selected_row_index].Cells[0].Value.ToString());

                string command = "DELETE FROM " + value_table + "\n";
                command += "WHERE " + tables_dataGridView.Columns[0].HeaderText + " = " + ID;

                SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                await sql_command.ExecuteNonQueryAsync();

                MessageBox.Show("Строка успешно удалена", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void update_string_button_Click(object sender, EventArgs e)
        {
            try
            {
                int selected_row_index = tables_dataGridView.CurrentCell.RowIndex;
                int ID = Convert.ToInt32(tables_dataGridView.Rows[selected_row_index].Cells[0].Value.ToString());

                string command = "UPDATE " + value_table + "\n";
                command += "SET ";

                //int count_of_columns = ((DataTable)tables_dataGridView.DataSource).Columns.Count; // Не работает
                int count_of_columns = tables_dataGridView.ColumnCount;

                for (int i = 1; i < count_of_columns; i++)
                {
                    command += tables_dataGridView.Columns[i].HeaderText + " = '" + tables_dataGridView.Rows[selected_row_index].Cells[i].Value.ToString() + "'";
                    if (i < count_of_columns - 1)
                    {
                        command += ", ";
                    }
                }
                command += "\n";
                command += "WHERE " + tables_dataGridView.Columns[0].HeaderText + " = " + tables_dataGridView.Rows[selected_row_index].Cells[0].Value.ToString();

                MessageBox.Show(command, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                await sql_command.ExecuteNonQueryAsync();

                MessageBox.Show("Строка успешно обновлена", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void add_string_button_Click(object sender, EventArgs e)
        {
            try
            {
                int selected_row_index = tables_dataGridView.CurrentCell.RowIndex;
                int count_of_columns = tables_dataGridView.ColumnCount;
                //MessageBox.Show(selected_row_index.ToString(), "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //int ID = Convert.ToInt32(tables_dataGridView.Rows[selected_row_index].Cells[0].Value.ToString());

                string[] s = new string[count_of_columns];
                for (int i = 0; i < count_of_columns; i++)
                {
                    s[i] = "";
                }
                tables_dataGridView.Rows.Add(s);

                //int count_of_columns = tables_dataGridView.ColumnCount;

                string command = "INSERT INTO " + value_table + "(";

                for (int i = 1; i < count_of_columns; i++)
                {
                    command += tables_dataGridView.Columns[i].HeaderText;
                    if (i < count_of_columns - 1)
                    {
                        command += ", ";
                    }
                    else
                    {
                        command += ")\n";
                    }
                }
                command += "VALUES (";

                //MessageBox.Show(tables_dataGridView.Rows[selected_row_index].Cells[0].Value.ToString(), "Значение выбранной строки", MessageBoxButtons.OK, MessageBoxIcon.Information);

                for (int i = 1; i < count_of_columns; i++)
                {
                    command += "'" + tables_dataGridView.Rows[selected_row_index].Cells[i].Value.ToString() + "'"; // Эта строка ему не нравится
                    if (i < count_of_columns - 1)
                    {
                        command += ", ";
                    }
                    else
                    {
                        command += ")";
                    }
                }

                //MessageBox.Show(command, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                await sql_command.ExecuteNonQueryAsync();

                MessageBox.Show("Строка успешно добавлена", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void местаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Места";
            string command = "SELECT * FROM Места";
            My_values.Select_function(command, tables_dataGridView);
        }
        private void Admin_form_Load(object sender, EventArgs e)
        {
            try
            {
                // Загрузка картинок
                Image staff_image = new Bitmap(@"E:\Users\Дмитрий\Учебники\7 семестр\Базы данных\Курсовая работа\Course_work_project\CW_windows_forms\CW_windows_forms\Additional_files\airport_staff.jpg");
                this.start_page_tabPage.BackgroundImage = staff_image;
                this.start_page_tabPage.BackgroundImageLayout = ImageLayout.Stretch;

                Image my_image = new Bitmap(@"E:\Users\Дмитрий\Учебники\7 семестр\Базы данных\Курсовая работа\Course_work_project\CW_windows_forms\CW_windows_forms\Additional_files\night_theme.jpg");
                this.BackgroundImage = my_image;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}