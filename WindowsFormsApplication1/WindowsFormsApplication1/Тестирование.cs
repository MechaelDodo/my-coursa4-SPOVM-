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

        private void выйтиИзПрограммыToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                ball = ball + Convert.ToInt32(Answers.Rows[listBox1.SelectedIndex]["Ball"]);
                listBox1.Items.Clear();
                num++;
                if (num < DT.Rows.Count)
                {
                    NewQuest(num);
                }
                else
                {
                    Rezult(ball);
                }
            }
        }

        void NewQuest(int num)
        {
            Answers.Clear();
            label2.Text = Convert.ToString(num + 1) + ") " + Convert.ToString(DT.Rows[num]["Question"]);
            try
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                {
                    using (OleDbCommand command = new OleDbCommand("SELECT Answer, Ball FROM Answers Where ID_quest = @Num", connection))
                    {
                        command.Parameters.AddWithValue("@Num", DT.Rows[num]["ID_quest"]);
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        Answers.Load(command.ExecuteReader());
                        for (int i = 0; i < Answers.Rows.Count; i++)
                        {
                            listBox1.Items.Add(Convert.ToString(Answers.Rows[i]["Answer"]));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Rezult(int ball)
        {
            Answers.Clear();
            button1.Text = "Сохранить \nрезультат";
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            try
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                {
                    using (OleDbCommand command = new OleDbCommand("SELECT Value, Balls FROM Characteristic Where ID_test = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", test);
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        Answers.Load(command.ExecuteReader());
                        BubbleSort(Answers);
                        if (Answers.Rows.Count == 1)
                        {
                            label2.Text = Convert.ToString(Answers.Rows[0]["value"]) + "\n\nВаш балл: " + Convert.ToString(ball);
                            listBox1.Visible = false;
                        }
                        for (int i = 0; i < Answers.Rows.Count - 1; i++)
                        {

                            if (Convert.ToString(Answers.Rows[i]["Value"]) == Convert.ToString(Answers.Rows[i + 1]["Value"]))
                            {
                                if ((ball >= Convert.ToInt32(Answers.Rows[i]["Balls"]) && ball <= Convert.ToInt32(Answers.Rows[i + 1]["Balls"])))
                                {
                                    label2.Text = Convert.ToString(Answers.Rows[i]["value"]);
                                    listBox1.Visible = false;
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (num == 0)
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                label2.Text = Convert.ToString(1) + ") " + Convert.ToString(DT.Rows[0]["Question"]);
                Answers.Clear();
                listBox1.Visible = true;
                try
                {
                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                    {
                        using (OleDbCommand command = new OleDbCommand("SELECT Answer, Ball FROM Answers Where ID_quest = @Num", connection))
                        {
                            command.Parameters.AddWithValue("@Num", DT.Rows[0]["ID_quest"]);
                            command.CommandType = CommandType.Text;
                            connection.Open();
                            Answers.Load(command.ExecuteReader());
                            for (int i = 0; i < Answers.Rows.Count; i++)
                            {
                                listBox1.Items.Add(Convert.ToString(Answers.Rows[i]["Answer"]));
                            }
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
                try
                {
                    if (Is("UsersResults") == true)
                    {
                        using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                        {
                            using (OleDbCommand command = new OleDbCommand("INSERT INTO UsersResults VALUES (@id_us, @id_test, @Char)", connection))
                            {
                                command.Parameters.AddWithValue("@id_us", User.id);
                                command.Parameters.AddWithValue("@id_test", test);
                                command.Parameters.AddWithValue("@Char", label2.Text);
                                connection.Open();
                                command.ExecuteReader();
                                MessageBox.Show("Результат сохранен");

                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("У вас уже существует результат по данному тесту. Желаете перезаписать его?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                            {
                                using (OleDbCommand command = new OleDbCommand("Update UsersResults  set ID_user = @id_us, id_test = @id_test, Characteristic = @Char Where ID_user = @id_us AND id_test = @id_test", connection))
                                {
                                    command.Parameters.AddWithValue("@id_us", User.id);
                                    command.Parameters.AddWithValue("@id_test", test);
                                    command.Parameters.AddWithValue("@Char", label2.Text);
                                    connection.Open();
                                    command.ExecuteReader();
                                    MessageBox.Show("Результат перезаписан");

                                }
                            }
                        }


                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (Test.razd == 6)
            {
                Forms.f3.Show();
                this.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (Is("UsersLikes") == true)
                {
                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                    {
                        using (OleDbCommand command = new OleDbCommand("INSERT INTO UsersLikes VALUES (@id_us, @id_test)", connection))
                        {
                            command.Parameters.AddWithValue("@id_us", User.id);
                            command.Parameters.AddWithValue("@id_test", test);
                            connection.Open();
                            command.ExecuteReader();
                            MessageBox.Show("Теперь данный тест будет отображаться в разделе \"Избранные тесты\" ");

                        }
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Данный тест уже в отмечен, как избранный. Желаете удалить его из избранных тестов?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                        {
                            using (OleDbCommand command = new OleDbCommand("DELETE FROM UsersLikes Where ID_user = @id_us AND ID_test =  @id_test", connection))
                            {
                                if (Test.razd == 5)
                                {
                                    Forms.f3.listBox1.Items.RemoveAt(Test.index);
                                    Forms.f3.ind.RemoveAt(Test.index);
                                }
                                command.Parameters.AddWithValue("@id_us", User.id);
                                command.Parameters.AddWithValue("@id_test", test);
                                connection.Open();
                                command.ExecuteReader();
                                MessageBox.Show("Тест удален из раздела \"избранные тесты\" ");

                            }
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forms.f3.Show();
            this.Close();
        }

        private void выйтиИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();

            Forms.f3.Show();

        }

        private void выйтиИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Forms.MainMenu.Show();
            Forms.f3 = null;
        }

        private void выйтиИзПрограммыToolStripMenuItem1_Click(object sender, EventArgs e){
            this.Close();
            Forms.Form1.Show();
            Forms.f3 = null;
            User.admin = false;
        }

        void BubbleSort(DataTable A)
        {
            for (int i = 0; i < A.Rows.Count; i++)
            {
                for (int j = 0; j < A.Rows.Count - i - 1; j++)
                {
                    if (Convert.ToInt32(A.Rows[j]["Balls"]) > Convert.ToInt32(A.Rows[j + 1]["Balls"]))
                    {
                        int temp = Convert.ToInt32(A.Rows[j]["Balls"]);
                        string temp1 = Convert.ToString(A.Rows[j]["Value"]);
                        A.Rows[j]["Balls"] = A.Rows[j + 1]["Balls"];
                        A.Rows[j]["Value"] = A.Rows[j + 1]["Value"];
                        A.Rows[j + 1]["Balls"] = temp;
                        A.Rows[j + 1]["Value"] = temp1;
                    }
                }
            }
        }

        bool Is(string table)
        {
            DataTable tab = new DataTable();
            try
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                {
                    using (OleDbCommand command = new OleDbCommand("Select ID_user FROM " + table + " WHERE id_user = @id_us AND id_test = @id_test", connection))
                    {
                        command.Parameters.AddWithValue("@id_us", User.id);
                        command.Parameters.AddWithValue("@id_test", test);
                        connection.Open();
                        tab.Load(command.ExecuteReader());
                        if (tab.Rows.Count == 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void Тестирование_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
