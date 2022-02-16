using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW_windows_forms
{
    public partial class Start_form : Form
    {
        int width = 0;
        int height = 0;
        public Start_form()
        {
            InitializeComponent();
        }
        private void Start_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (My_values.sql_connection != null && My_values.sql_connection.State != ConnectionState.Closed)
            {
                My_values.sql_connection.Close();
                Application.Exit();
            }
        }
        private void login_button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                My_values.auto = new Autorization();
                My_values.auto.ShowDialog();
                My_values.auto.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void registration_button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                My_values.reg = new Registration();
                My_values.reg.ShowDialog();
                My_values.reg.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Start_form_Load(object sender, EventArgs e)
        {
            height = this.Height;
            width = this.Width;

            registration_button.Location = new Point((this.Width / 2) - (registration_button.Size.Width / 2), registration_button.Location.Y);
            login_button.Location = new Point((this.Width / 2) - (login_button.Size.Width / 2), login_button.Location.Y);
        }
        private void Start_form_SizeChanged(object sender, EventArgs e)
        {
            double k_width = (double)(this.Width / (double)width);
            double k_heigth = (double)(this.Height / (double)height);

            string s = "Начальная ширина = " + width;
            s += "Начальная высота = " + height;
            s += "Изменённая ширина = " + this.Width;
            s += "Изменённая высота = " + this.Height;

            s = k_heigth + " " + k_width;

            //MessageBox.Show(s, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //registration_button.Location = new Point(registration_button.Location.X * this.Width / width, registration_button.Location.Y * this.Height / height);

            //registration_button.Location = new Point((this.Width / 2) - (registration_button.Size.Width / 2), (this.Height / 2) - (registration_button.Size.Height / 2));
            //login_button.Location = new Point((this.Width / 2) - (login_button.Size.Width / 2), (this.Height / 2) - (login_button.Size.Width / 2));

            registration_button.Location = new Point((this.Width / 2) - (registration_button.Size.Width / 2), registration_button.Location.Y);
            login_button.Location = new Point((this.Width / 2) - (login_button.Size.Width / 2), login_button.Location.Y);

            width = this.Width;
            height = this.Height;
        }
    }
}