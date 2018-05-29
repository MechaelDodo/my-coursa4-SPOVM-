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
    public partial class Тестирование : Form
    {
        public Тестирование()
        {
            InitializeComponent();
        }
        int num;
        int ball;
        int test;
        DataTable Answers;
        DataTable DT;

        private void Тестирование_Load(object sender, EventArgs e)
        {

        }

        public Тестирование(DataTable DT, int test)
        {
            InitializeComponent();
            label1.Text = User.name;
            panel1.AutoScroll = true;
            this.DT = DT;
            this.test = test;
            Answers = new DataTable();

            if (Test.razd == 6)
            {
                button1.Text = "Назад";
                button2.Visible = false;
                button3.Visible = false;
                try
                {
                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                    {
                        using (OleDbCommand command = new OleDbCommand("SELECT Characteristic FROM UsersResults where id_user = " + User.id + " AND id_test = " + test + "", connection))
                        {
                            command.CommandType = CommandType.Text;
                            connection.Open();
                            Answers.Load(command.ExecuteReader());
                            label2.Text = Convert.ToString(Answers.Rows[0]["Characteristic"]);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {

                button1.Text = "Начать тестирование";
                num = 0;
                try
                {
                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                    {
                        using (OleDbCommand command = new OleDbCommand("SELECT Описание FROM Test Where ID_test = @test", connection))
                        {
                            command.Parameters.AddWithValue("@test", test);
                            command.CommandType = CommandType.Text;
                            connection.Open();
                            Answers.Load(command.ExecuteReader());
                            label2.Text = Convert.ToString(Answers.Rows[0]["Описание"]);

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
}
