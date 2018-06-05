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
    public partial class Логин : Form
    {
        public Логин()
        {
            InitializeComponent();
        }

        public bool flag;
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            try
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))//connection
                {
                    using (OleDbCommand command = new OleDbCommand("SELECT * FROM Users Where Login = @Login AND [Password] = @Password", connection))//
                    {
                        command.Parameters.AddWithValue("@Login", textBox1.Text.ToLower());//ToLower
                        command.Parameters.AddWithValue("@Password", textBox2.Text);
                        command.CommandType = CommandType.Text; //
                        
                        connection.Open();
                        DT.Load(command.ExecuteReader());
                        connection.Close();

                        if (DT.Rows.Count == 0)
                        {
                            MessageBox.Show("Неверные данные");
                        }
                        else
                        {
                            User.id = Convert.ToInt32(DT.Rows[0]["id_user"]);
                            User.name = DT.Rows[0]["Name"].ToString();
                            this.Close();
                            User.flag = true;
                            if (Convert.ToBoolean(DT.Rows[0]["Admin"]) == true)
                            {
                                User.admin = true;
                            }
                        }


                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();  
        }
    }
}
