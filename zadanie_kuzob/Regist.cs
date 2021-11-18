using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace zadanie_kuzob
{
    public partial class Regist : Form
    {
        public Regist()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlConnection DB = new MySqlConnection();
            MySqlCommand command = new MySqlCommand("INSERT INTO `aoaoaa` ( `login`, `password`, `Rul`,`FIO`) VALUES (@login, @pass, @rul, @fio)", db.getConnection());


            command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@rul", MySqlDbType.VarChar).Value = "NULL";

            db.openConnection();
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Введите данные для регистрации");
                return;
            }
            else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("");
                return;
            }
            else if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("СЛЫШЬ," + textBox1.Text + " Типа закончил");
                Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
                this.Close();
            }
            else { MessageBox.Show("Опа-на, ошибочка вышла, исправляй"); }
            db.closeConnection();
        }
    }
}