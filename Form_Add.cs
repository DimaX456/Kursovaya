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
    public partial class Form_Add : Form
    {
        DataBase database = new DataBase();

        public Form_Add()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            database.openConnection();

            var type = textBoxType1.Text;
            var count = textBoxCount1.Text;
            var postav = textBoxPostav1.Text;
            int price;

            if (int.TryParse(textBoxPrice1.Text, out price))
            {
                var addQuery = $"insert into test_db (type_of, count_of, postavka, price) values ('{type}','{count}','{postav}','{price}')";

                var command = new SqlCommand(addQuery, database.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно сохранен", "Новая запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Укажите цену!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            database.closeConnection();
        }
    }
}
