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
    public partial class Staff_form : Form
    {
        string value_table = "";

        public Staff_form()
        {
            InitializeComponent();
        }
        private async void Staff_form_Load(object sender, EventArgs e)
        {
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

                full_name_label.Text = second_name_textbox.Text + " " + first_name_textbox.Text + " " + patronymic_textbox.Text;

                // Загрузка картинок
                Image staff_image = new Bitmap(@"E:\Users\Дмитрий\Учебники\7 семестр\Базы данных\Курсовая работа\Course_work_project\CW_windows_forms\CW_windows_forms\Additional_files\airport_staff.jpg");
                this.start_page_tabPage.BackgroundImage = staff_image;
                this.start_page_tabPage.BackgroundImageLayout = ImageLayout.Stretch;

                Image my_image = new Bitmap(@"E:\Users\Дмитрий\Учебники\7 семестр\Базы данных\Курсовая работа\Course_work_project\CW_windows_forms\CW_windows_forms\Additional_files\night_theme.jpg");
                this.BackgroundImage = my_image;
                this.BackgroundImageLayout = ImageLayout.Stretch;

                Image personal_data_image = new Bitmap(@"E:\Users\Дмитрий\Учебники\7 семестр\Базы данных\Курсовая работа\Course_work_project\CW_windows_forms\CW_windows_forms\Additional_files\star_sky_plain.jpg");
                this.personal_data_tabPage.BackgroundImage = personal_data_image;
                this.personal_data_tabPage.BackgroundImageLayout = ImageLayout.Stretch;
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
        private void выходИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My_values.staff.Hide();
            My_values.st_form.Show();
        }
        private void выходИзПриложенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (My_values.sql_connection != null && My_values.sql_connection.State != ConnectionState.Closed)
            {
                My_values.sql_connection.Close();
            }
            Application.Exit();
        }
        private void Staff_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (My_values.sql_connection != null && My_values.sql_connection.State != ConnectionState.Closed)
            {
                My_values.sql_connection.Close();
            }
            Application.Exit();
        }
        private void персональныеДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(personal_data_tabPage);
        }
        private void авиакомпанияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Авиакомпания";
            string command = "SELECT * FROM Авиакомпания";
            My_values.Select_function(command, tables_dataGridView);
        }
        private void активностьАвиакомпанииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Активность_авиакомпании";
            string command = "SELECT * FROM Активность_авиакомпании";
            My_values.Select_function(command, tables_dataGridView);
        }
        private void вППToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "ВПП";
            string command = "SELECT * FROM ВПП";
            My_values.Select_function(command, tables_dataGridView);
        }
        private void классификацияВППToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Классификация_ВПП";
            string command = "SELECT * FROM Классификация_ВПП";
            My_values.Select_function(command, tables_dataGridView);
        }
        private void маршрутToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Маршрут";
            string command = "SELECT * FROM Маршрут";
            My_values.Select_function(command, tables_dataGridView);
        }
        private void местаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Места";
            string command = "SELECT * FROM Места";
            My_values.Select_function(command, tables_dataGridView);
        }
        private void метеопрогнозToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Метеопрогноз";
            string command = "SELECT * FROM Метеопрогноз";
            My_values.Select_function(command, tables_dataGridView);
        }
        private void правилапоперевозкебагажаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Правила_по_перевозке_багажа";
            string command = "SELECT * FROM Правила_по_перевозке_багажа";
            My_values.Select_function(command, tables_dataGridView);
        }
        private void рейсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Рейс";
            string command = "SELECT * FROM Рейс";
            My_values.Select_function(command, tables_dataGridView);
        }
        private void самолётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Самолёт";
            string command = "SELECT * FROM Самолёт";
            My_values.Select_function(command, tables_dataGridView);
        }
        private void статистическиеДанныеОПассажирахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Статистические_данные_о_пассажирах";
            string command = "SELECT * FROM Статистические_данные_о_пассажирах";
            My_values.Select_function(command, tables_dataGridView);
        }
        private void статусБилетаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Статус_билета";
            string command = "SELECT * FROM Статус_билета";
            My_values.Select_function(command, tables_dataGridView);
        }
        private void статусБрониToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Статус_брони";
            string command = "SELECT * FROM Статус_брони";
            My_values.Select_function(command, tables_dataGridView);
        }
        private void статусСамолётаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tables_tabPage);
            value_table = "Статус_самолёта";
            string command = "SELECT * FROM Статус_самолёта";
            My_values.Select_function(command, tables_dataGridView);
        }
    }
}