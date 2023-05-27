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
    public partial class Form_sign_up : Form
    {

        DataBase dataBase = new DataBase();

        public Form_sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
         
            if (checkUser())
            {
                return;
            }
            
            var login = textBoxUsername1.Text;
            var password = textBoxPassword1.Text;

            string querystring = $"insert into register(login_user, password_user, is_admin) values('{login}','{password}', 0)";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            dataBase.openConnection();
            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Поздравляю, вы создали аккаунт!", "Регистрация");
                Form_log_in frm_login = new Form_log_in();
                this.Hide();
                frm_login.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ошибка, аккаунт не создан!");
            }
            dataBase.closeConnection();
        }

        private Boolean checkUser()
        {
            var loginUser = textBoxUsername1.Text;
            var passUser = textBoxPassword1.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, login_user, password_user, is_admin from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else { 
                return false; 
            }
        }

        private void Form_sign_up_Load(object sender, EventArgs e)
        {
            textBoxPassword1.PasswordChar = '●';
            pictureBox1.Visible = false;
        }
    }
}
