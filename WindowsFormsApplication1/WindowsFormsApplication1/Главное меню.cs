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
    public partial class Главное_меню : Form
    {
        public Главное_меню()
        {
            InitializeComponent();
        }

        private void Главное_меню_Load(object sender, EventArgs e)
        {

        }

        private void выйтиИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void выйтиИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            User.name = "";
            User.flag = false;
            User.id = 0;
            User.admin = false;
            Forms.Form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forms.Razd.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            try
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                {
                    using (OleDbCommand command = new OleDbCommand("SELECT id_test, Name FROM Test where id_test in (SELECT id_test FROM UsersLikes where id_user = " + User.id + ")", connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        DT.Load(command.ExecuteReader());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (DT.Rows.Count == 0)
            {
                MessageBox.Show("У вас нету избранных тестов");
            }
            else
            {
                this.Hide();
                Test.razd = 5;
                Form3 f3 = new Form3(DT);
                Forms.f3 = f3;
                f3.Show();
            }
        }
        private void Главное_меню_Layout(object sender, LayoutEventArgs e)
        {
            label1.Text = User.name;
            if (User.admin == true)
            {
                редактироватьТестыToolStripMenuItem.Visible = true;
            }
            else
            {
                редактироватьТестыToolStripMenuItem.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            Test.razd = 6;
            try
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                {
                    using (OleDbCommand command = new OleDbCommand("SELECT id_test, Name FROM Test where id_test in (SELECT id_test FROM UsersResults where id_user = " + User.id + ")", connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        DT.Load(command.ExecuteReader());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (DT.Rows.Count == 0)
            {
                MessageBox.Show("У вас нету сохраненных результатов");
            }
            else
            {
                this.Hide();
                Form3 f3 = new Form3(DT);
                Forms.f3 = f3;
                f3.Show();
            }
        }

        private void редактироватьТестыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Редактор red = new Редактор();
            red.Show();
            this.Hide();
        }

    }
}
