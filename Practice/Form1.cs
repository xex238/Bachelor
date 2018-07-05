using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_connecting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pRACTDataSet.lots". При необходимости она может быть перемещена или удалена.
            this.lotsTableAdapter.Fill(this.pRACTDataSet.lots);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sewing_factoryDataSet.Отчёт". При необходимости она может быть перемещена или удалена.
            this.отчётTableAdapter.Fill(this.sewing_factoryDataSet.Отчёт);

            lots.Visible = false; // Делаем табличку невидимой
            Enter.Visible = false;
            login.Visible = false;
            password.Visible = false;
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Enter.Visible = true;
            login.Visible = true;
            password.Visible = true;
            button1.Visible = false;
        }

        private void login_MouseClick(object sender, MouseEventArgs e)
        {
            if (login.Text == "login")
            {
                login.Text = "";
            }
            if (password.Text == "")
            {
                password.Text = "password";
            }
        }

        private void password_MouseClick(object sender, MouseEventArgs e)
        {
            if (password.Text == "password")
            {
                password.Text = "";
            }
            if (login.Text == "")
            {
                login.Text = "login";
            }
        }
    }
}
