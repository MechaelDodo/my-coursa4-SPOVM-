using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Регистрация : Form
    {
        public Регистрация()
        {
            InitializeComponent();
        }

        private void Регистрация_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            bool flag = true;
            try
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                {
                    using (OleDbCommand command = new OleDbCommand("SELECT Login FROM Users Where Login = @Login", connection))
                    {
                        command.Parameters.AddWithValue("@Login", textBox2.Text.ToLower());
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        DT.Load(command.ExecuteReader());
                        if (DT.Rows.Count != 0)
                        {
                            MessageBox.Show("Такой логин уже существует");
                            flag = false;
                        }
                        if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                        {
                            MessageBox.Show("Все поля обязательны для заполнения");
                            flag = false;
                        }
                        if (flag == true)
                        {
                            command.Parameters.Clear();
                            command.CommandText = "INSERT INTO Users ([Name], Login, [Password]) VALUES (@Name, @Login, @Password);";
                            command.Parameters.AddWithValue("@Name", textBox1.Text);
                            command.Parameters.AddWithValue("@Login", textBox2.Text);
                            command.Parameters.AddWithValue("@Password", textBox3.Text);
                            command.ExecuteNonQuery();
                            command.CommandText = "SELECT id_user FROM Users Where Login = '" + textBox2.Text + "'";
                            DT.Load(command.ExecuteReader());
                            User.id = Convert.ToInt32(DT.Rows[0]["id_user"]);
                            User.name = textBox1.Text;
                            this.Close();
                            User.flag = true;
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
