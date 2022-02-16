using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW_windows_forms
{
    public partial class My_values
    {
        public static SqlConnection sql_connection;
        public static Start_form st_form;
        public static Autorization auto;
        public static Registration reg;
        public static User_form user;
        public static Staff_form staff;
        public static Admin_form admin;
        public static Passport_data_form passport_form;

        public static int value_user_ID = -1;
        public static string value_user_mail = "";
        public static string value_user_password = "";
        public static string value_user_login = "";

        public static string user_passport_series;
        public static string user_passport_number;

        public static async void Select_function(string command, DataGridView my_data_grid_view)
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
                my_data_grid_view.Columns.Clear();

                for (int i = 0; i < count_of_columns; i++)
                {
                    columns[i] = new DataGridViewTextBoxColumn();
                    columns[i].ReadOnly = true;
                    columns[i].HeaderText = columns_name[i];
                }

                for (int i = 0; i < count_of_columns; i++)
                {
                    my_data_grid_view.Columns.Add(columns[i]);
                }

                my_data_grid_view.Rows.Clear();
                foreach (string[] s in data)
                {
                    my_data_grid_view.Rows.Add(s);
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
    }
    static class Program
    {
        static async void Load_database()
        {
            string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Copy_DB\AirportDB_2.mdf;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True";

            My_values.sql_connection = new SqlConnection(connection_string);

            await My_values.sql_connection.OpenAsync();
        }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Load_database();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new Autorization());

            My_values.st_form = new Start_form();
            Application.Run(My_values.st_form);
        }
    }
}