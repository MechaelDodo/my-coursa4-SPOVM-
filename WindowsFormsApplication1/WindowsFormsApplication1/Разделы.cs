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
    public partial class Разделы : Form
    {
        public Разделы()
        {
            InitializeComponent();
        }

        void Разделы_FormClosing(object sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void выйтиИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            User.name = "";
            User.flag = false;
            User.id = 0;
            User.admin = false;
            Forms.Form1.Show();
        }

        private void выйтиИзПрограммыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Разделы_Layout(object sender, LayoutEventArgs e)
        {
            label1.Text = User.name;
        }

        private void выйтиИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.MainMenu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Test.razd = 1;
            this.Hide();
            Form3 f3 = new Form3(vivod(Test.razd));
            Forms.f3 = f3;
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Test.razd = 2;
            Form3 f3 = new Form3(vivod(Test.razd));
            Forms.f3 = f3;
            f3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Test.razd = 3;
            this.Hide();
            Form3 f3 = new Form3(vivod(Test.razd));
            Forms.f3 = f3;
            f3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Test.razd = 4;
            this.Hide();
            Form3 f3 = new Form3(vivod(Test.razd));
            Forms.f3 = f3;
            f3.Show();
        }

        DataTable vivod(int razd)
        {
            DataTable DT = new DataTable();
            try
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                {
                    using (OleDbCommand command = new OleDbCommand("SELECT id_test, Name FROM Test Where Razdel = @razd", connection))
                    {
                        command.Parameters.AddWithValue("@razd", razd);
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        DT.Load(command.ExecuteReader());
                    }    
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return DT;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Test.razd = 7;
            DataTable DT = new DataTable();
            try
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                {
                    using (OleDbCommand command = new OleDbCommand("SELECT id_test, Name FROM Test", connection))
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
            this.Hide();
            Form3 f3 = new Form3(DT);
            Forms.f3 = f3;
            f3.Show();
        }
   
   
    }
}
