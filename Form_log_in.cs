using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kursovaya
{
    public partial class Form_log_in : Form
    {
        DataBase database = new DataBase();
        public Form_log_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var LoginUser = textBoxUsername.Text;
            var LoginPassword = textBoxPassword1.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user, login_user, password_user, is_admin from register where login_user = '{LoginUser}' and password_user = '{LoginPassword}'";

            SqlCommand command = new SqlCommand(querystring, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {

                var user = new checkUser(table.Rows[0].ItemArray[1].ToString(), Convert.ToBoolean(table.Rows[0].ItemArray[3])); //***

                MessageBox.Show("Вы вошли на свой аккаунт!", "Вход", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 frm1 = new Form1(user);
                this.Hide();
                frm1.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Вы указали неправильный Логин или Пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Form_log_in_Load(object sender, EventArgs e)
        {
            textBoxPassword1.PasswordChar = '●';
            pictureBox1.Visible = false;
            textBoxUsername.MaxLength = 50;
            textBoxPassword1.MaxLength = 50;
        }

        private void linkLabelReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_sign_up fm_sign = new Form_sign_up();
            fm_sign.Show();
            this.Hide();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxUsername.Text = "";
            textBoxPassword1.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBoxPassword1.UseSystemPasswordChar = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBoxPassword1.UseSystemPasswordChar = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
        }
    }
}
