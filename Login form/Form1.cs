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

namespace Login_form
{
    public partial class Form1 : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password= ; database=csharp_users_db");
        public Form1()
        {
            InitializeComponent();
        }

        private void labelclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelclose_MouseLeave(object sender, EventArgs e)
        {
            labelclose.ForeColor = Color.White;
        }

        private void labelclose_MouseEnter(object sender, EventArgs e)
        {
            labelclose.ForeColor = Color.Black;
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            string username = usertxt.Text;
            string password = pwdtxt.Text;

            DataTable
                 table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //User Name = use1, Password = pass

            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `username`= @usn and `password` = @pass", db.GetConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Yes");
            }
            else
            {
                MessageBox.Show("NO");
            }
        }
    }
}
