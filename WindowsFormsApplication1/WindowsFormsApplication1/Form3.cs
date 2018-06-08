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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            label1.Text = User.name;
        }

        public List<int> ind;

        public Form3(DataTable DT)
        {
            InitializeComponent();
            ind = new List<int>();
            for (int i = 0; i < DT.Rows.Count; i++ )
            {
                listBox1.Items.Add(DT.Rows[i]["name"]);
                ind.Add(Convert.ToInt32(DT.Rows[i]["id_test"]));
            }
            if (Test.razd == 1){
                label2.Text = "Семья";
            }
            else if (Test.razd == 2)
            {
                label2.Text = "Карьера";
            }
            else if (Test.razd == 3)
            {
                label2.Text = "Личность";
            }
            else if (Test.razd == 4)
            {
                label2.Text = "Отношения";
            }
            else if (Test.razd == 5)
            {
                label2.Text = "Избранное";
            }
            else if (Test.razd == 6)
            {
                label2.Text = "Результаты";
            }
            else if (Test.razd == 7)
            {
                label2.Text = "Все тесты";
            }
            label1.Text = User.name;
        }

      
        private void выйтиИзПрограммыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            User.name = "";
            User.id = 0;
            User.flag = false;
            this.Close();
            Forms.f3 = null;
            User.admin = false;
            Forms.Form1.Show();
        }

        private void выйтиИзПрограммыToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void выйтиИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.MainMenu.Show();
            Forms.f3 = null;
            this.Close();
        }

        private void выйтиИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Razd.Show();
            Forms.f3 = null;
            this.Close();
        }

   
        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                DataTable DT = new DataTable();
                try
                {
                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                    {
                        using (OleDbCommand command = new OleDbCommand("SELECT ID_Quest, Question FROM Questions Where ID_test = @ind", connection))
                        {
                            command.Parameters.AddWithValue("@ind", ind[listBox1.SelectedIndex]);
                            command.CommandType = CommandType.Text;
                            connection.Open();
                            DT.Load(command.ExecuteReader());
                            Тестирование test = new Тестирование(DT, ind[listBox1.SelectedIndex]);
                            Test.index = listBox1.SelectedIndex;
                            this.Hide();
                            test.Show();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                
            }
        }

        public void delete(int index)
        {
            listBox1.Items.RemoveAt(index);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        
           
        
    }
}
