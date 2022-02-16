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
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
        }
        private async void autorization_button_Click(object sender, EventArgs e)
        {
            if((mail_textBox.Text != "") && (password_textBox.Text != ""))
            {
                // Запись почты и пароля в файл, чтобы оставаться в системе
                if(stay_in_system_checkBox.Checked)
                {
                    string file_path = "TextFile.txt";
                    string text = mail_textBox.Text + "\n" + password_textBox.Text;
                    File.WriteAllText(file_path, text);
                }

                SqlDataReader sql_data_reader = null;

                string command = "SELECT * FROM Пользователь WHERE Пользователь.Почта = '" + mail_textBox.Text + "'and Пользователь.Пароль = '" + password_textBox.Text + "'";

                SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);

                List<object> l = new List<object>();

                try
                {
                    sql_data_reader = await sql_command.ExecuteReaderAsync();

                    while(await sql_data_reader.ReadAsync())
                    {
                        l.Add(sql_data_reader["Логин"]);
                        l.Add(sql_data_reader["ID"]);
                        l.Add(sql_data_reader["Роль"]);
                    }

                    My_values.value_user_login = l[0].ToString();
                    My_values.value_user_ID = Convert.ToInt32(l[1]);

                    if (l.Count != 0)
                    {
                        My_values.value_user_mail = mail_textBox.Text;
                        My_values.value_user_password = password_textBox.Text;
                        My_values.auto.Close();
                        My_values.st_form.Hide();

                        if(l[2].ToString() == "Пользователь")
                        {
                            My_values.user = new User_form();
                            My_values.user.Show();
                            My_values.user.Activate();
                        }
                        if(l[2].ToString() == "Персонал")
                        {
                            My_values.staff = new Staff_form();
                            My_values.staff.Show();
                            My_values.staff.Activate();
                        }
                        if(l[2].ToString() == "Администратор")
                        {
                            My_values.admin = new Admin_form();
                            My_values.admin.Show();
                            My_values.admin.Activate();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверная почта или пароль", "Важная информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (sql_data_reader != null)
                    {
                        sql_data_reader.Close();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Поля не заполнены!", "Важная информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Autorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                My_values.st_form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Autorization_Load(object sender, EventArgs e)
        {
            // Чтение почты и пароля с файла
            try
            {
                using (StreamReader sr = new StreamReader("TextFile.txt"))
                {
                    var strline = await sr.ReadToEndAsync();
                    string[] mail_password = strline.Split(new[] { "\n" }, StringSplitOptions.None);
                    mail_textBox.Text = mail_password[0];
                    password_textBox.Text = mail_password[1];
                    stay_in_system_checkBox.Checked = true;
                }
            }
            catch(Exception)
            {

            }
        }
    }
}
