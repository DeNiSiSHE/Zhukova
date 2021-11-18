using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace zadanie_kuzob
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String log_user = textBox1.Text;
            String pass_user = textBox2.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `aoaoaa` WHERE `login` = @userLogin AND `password` = @userPass", db.getConnection());
            command.Parameters.Add("@userLogin", MySqlDbType.VarChar).Value = log_user;
            command.Parameters.Add("@userPass", MySqlDbType.VarChar).Value = pass_user;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (log_user == "" && pass_user == "")
            {
                MessageBox.Show("Значения пустые");
            }
            else if (log_user == "" || pass_user == "")
            {
                MessageBox.Show("Вы заполнили не все поля");
            }
            else if (table.Rows.Count > 0)
            {
                Hide();
                Form3cs avtoriz = new Form3cs();
                avtoriz.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Какая-та ошикбка");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            {
                Hide();
                Regist reg = new Regist();
                reg.ShowDialog();
                this.Close();
            }

        }
    }
}
