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
    public partial class Registration : Form
    {
        //int width = 0;
        //int height = 0;
        public Registration()
        {
            InitializeComponent();
        }
        private async void registration_button_Click(object sender, EventArgs e)
        {
            if((mail_textbox.Text != "") && (login_textbox.Text != "") && (password_textbox.Text != "") && (repeat_password_textbox.Text != "") && (first_name_textbox.Text != "") && (second_name_textbox.Text != ""))
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
                    if (password_textbox.Text != repeat_password_textbox.Text)
                    {
                        MessageBox.Show("Пароли не совпадают", "Важная информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        try
                        {
                            string command = "INSERT INTO Пользователь (Почта, Логин, Пароль, Имя, Фамилия, Дата_рождения, Роль) VALUES ('" + mail_textbox.Text + "', '" + login_textbox.Text + "', '" + password_textbox.Text + "', '" + first_name_textbox.Text + "', '" + second_name_textbox.Text + "', '" + date_choose.Value.ToString("yyyy-MM-dd") + "', 'Пользователь')";

                            SqlCommand sql_command = new SqlCommand(command, My_values.sql_connection);
                            await sql_command.ExecuteNonQueryAsync();

                            MessageBox.Show("Пользователь зарегистрирован", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь с такой почтой уже существует. Проверьте правильность введённого пароля.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Поля не заполнены!", "Важная информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            My_values.st_form.Show();
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            //information_label.BackColor = Color.Transparent;
            //mail_label.BackColor = Color.Transparent;
            //login_label.BackColor = Color.Transparent;
            //password_label.BackColor = Color.Transparent;
            //repeat_password_label.BackColor = Color.Transparent;
            //born_data_label.BackColor = Color.Transparent;
            //first_name_label.BackColor = Color.Transparent;
            //second_name_label.BackColor = Color.Transparent;
        }
        private void Registration_SizeChanged(object sender, EventArgs e)
        {
            //double k_width = (double)(this.Width / (double)width);
            //double k_heigth = (double)(this.Height / (double)height);

            //registration_button.Location = new Point((this.Width / 2) - (registration_button.Size.Width / 2), registration_button.Location.Y);
            //information_label.Location = new Point((this.Width / 2) - (information_label.Size.Width / 2), information_label.Location.Y);

            //mail_label.Location = new Point((this.Width / 2) - (mail_label.Size.Width / 2), mail_label.Location.Y);
            //login_label.Location = new Point((this.Width / 2) - (login_label.Size.Width / 2), login_label.Location.Y);
            //password_label.Location = new Point((this.Width / 2) - (password_label.Size.Width / 2), password_label.Location.Y);
            //repeat_password_label.Location = new Point((this.Width / 2) - (repeat_password_label.Size.Width / 2), repeat_password_label.Location.Y);
            //born_data_label.Location = new Point((this.Width / 2) - (born_data_label.Size.Width / 2), born_data_label.Location.Y);
            //second_name_label.Location = new Point((this.Width / 2) - (second_name_label.Size.Width / 2), second_name_label.Location.Y);
            //first_name_label.Location = new Point((this.Width / 2) - (first_name_label.Size.Width / 2), first_name_label.Location.Y);

            //mail_textbox.Location = new Point((this.Width / 2) - (mail_textbox.Size.Width / 2), mail_textbox.Location.Y);
            //login_textbox.Location = new Point((this.Width / 2) - (login_textbox.Size.Width / 2), login_textbox.Location.Y);
            //password_textbox.Location = new Point((this.Width / 2) - (password_textbox.Size.Width / 2), password_textbox.Location.Y);
            //repeat_password_textbox.Location = new Point((this.Width / 2) - (repeat_password_textbox.Size.Width / 2), repeat_password_textbox.Location.Y);
            //date_choose.Location = new Point((this.Width / 2) - (date_choose.Size.Width / 2), date_choose.Location.Y);
            //second_name_textbox.Location = new Point((this.Width / 2) - (second_name_textbox.Size.Width / 2), second_name_textbox.Location.Y);
            //first_name_textbox.Location = new Point((this.Width / 2) - (first_name_textbox.Size.Width / 2), first_name_textbox.Location.Y);
        }
    }
}
