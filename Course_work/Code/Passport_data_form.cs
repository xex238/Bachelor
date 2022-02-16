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
    public partial class Passport_data_form : Form
    {
        public Passport_data_form()
        {
            InitializeComponent();
        }

        private void accept_button_Click(object sender, EventArgs e)
        {
            if((series_passport_textBox.Text.Length == 4) && (number_passport_textBox.Text.Length == 6))
            {
                My_values.user_passport_series = series_passport_textBox.Text;
                My_values.user_passport_number = number_passport_textBox.Text;
                My_values.user.buy_ticket_button_Click_continue();
                this.Close();
            }
            else
            {
                //MessageBox.Show(series_passport_textBox.Text.Length.ToString() + " " + number_passport_textBox.Text.Length.ToString(), "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Неверный формат входных данных. Проверьте значения и повторите попытку", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
