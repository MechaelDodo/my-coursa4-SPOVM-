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
    public partial class ВопросыОтветы : Form
    {

        public ВопросыОтветы()
        {
            InitializeComponent();

            DataGridViewTextBoxColumn firstColumn = new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "ID";
            firstColumn.Name = "ID";
            firstColumn.ReadOnly = true;
            DataGridViewTextBoxColumn secondColumn = new DataGridViewTextBoxColumn();
            secondColumn.HeaderText = "Вопросы";
            secondColumn.Name = "Question";
            secondColumn.Width = 408;

            dataGridView1.Columns.Add(firstColumn);
            dataGridView1.Columns.Add(secondColumn);
            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }

        public ВопросыОтветы(int ind)
        {

            InitializeComponent();

            button2.Visible = false;
            button2.Text = "Редактировать ответы";

            DataGridViewTextBoxColumn firstColumn = new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "ID";
            firstColumn.Name = "ID";
            firstColumn.ReadOnly = true;
            DataGridViewTextBoxColumn secondColumn = new DataGridViewTextBoxColumn();
            secondColumn.HeaderText = "Ответы";
            secondColumn.Name = "Answer";
            secondColumn.Width = 348;
            DataGridViewTextBoxColumn thirdColumn = new DataGridViewTextBoxColumn();
            thirdColumn.HeaderText = "Балл";
            thirdColumn.Name = "Ball";
            thirdColumn.Width = 60;

            dataGridView1.Columns.Add(firstColumn);
            dataGridView1.Columns.Add(secondColumn);
            dataGridView1.Columns.Add(thirdColumn);
            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            flag = true;

   
        }

        public ВопросыОтветы(Test New)
        {
            InitializeComponent();
            NewTest = New;
            DT = new DataTable();
            try
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                {
                    using (OleDbCommand command = new OleDbCommand("select max(ID_quest) from Questions;", connection))
                    {

                        connection.Open();
                        DT.Load(command.ExecuteReader());
                        ID = Convert.ToInt32(DT.Rows[0]["Expr1000"]) + 1;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DataGridViewTextBoxColumn firstColumn = new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "ID";
            firstColumn.Name = "ID";
            firstColumn.ReadOnly = true;
            DataGridViewTextBoxColumn secondColumn = new DataGridViewTextBoxColumn();
            secondColumn.HeaderText = "Вопросы";
            secondColumn.Name = "Question";
            secondColumn.Width = 408;  
          
            dataGridView1.Columns.Add(firstColumn);
            dataGridView1.Columns.Add(secondColumn);
            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;



        }

        public ВопросыОтветы(int ind, Test New){

            
            InitializeComponent();

            button2.Visible = false;
            DT = new DataTable();
            NewTest = New;
            a = ind;
            if (NewTest.id_answ == 0){
                try
                {
                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                    {
                        using (OleDbCommand command = new OleDbCommand("select max(ID_answ) from Answers;", connection))
                        {

                            connection.Open();
                            DT.Load(command.ExecuteReader());
                            NewTest.id_answ = Convert.ToInt32(DT.Rows[0]["Expr1000"]) + 1;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           


            DataGridViewTextBoxColumn firstColumn = new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "ID";
            firstColumn.Name = "ID";
            firstColumn.ReadOnly = true;
            DataGridViewTextBoxColumn secondColumn = new DataGridViewTextBoxColumn();
            secondColumn.HeaderText = "Ответы";
            secondColumn.Name = "Answer";
            secondColumn.Width = 348;
            DataGridViewTextBoxColumn thirdColumn = new DataGridViewTextBoxColumn();
            thirdColumn.HeaderText = "Балл";
            thirdColumn.Name = "Ball";
            thirdColumn.Width = 60;

            dataGridView1.Columns.Add(firstColumn);
            dataGridView1.Columns.Add(secondColumn);
            dataGridView1.Columns.Add(thirdColumn);
            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            flag = true;
        }

        public ВопросыОтветы(Test New, int a)
        {
            InitializeComponent();
            NewTest = New;
            DT = new DataTable();
            button2.Visible = false;
            try
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                {
                    using (OleDbCommand command = new OleDbCommand("select max(ID_char) from Characteristic;", connection))
                    {
                        connection.Open();
                        DT.Load(command.ExecuteReader());
                        ID = Convert.ToInt32(DT.Rows[0]["Expr1000"]) + 1;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DataGridViewTextBoxColumn firstColumn = new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "ID";
            firstColumn.Name = "ID";
            firstColumn.ReadOnly = true;
            DataGridViewTextBoxColumn secondColumn = new DataGridViewTextBoxColumn();
            secondColumn.HeaderText = "Характеристика";
            secondColumn.Name = "Value";
            secondColumn.Width = 348;
            DataGridViewTextBoxColumn thirdColumn = new DataGridViewTextBoxColumn();
            thirdColumn.HeaderText = "Балл";
            thirdColumn.Name = "Ball";
            thirdColumn.Width = 60;

            dataGridView1.Columns.Add(firstColumn);
            dataGridView1.Columns.Add(secondColumn);
            dataGridView1.Columns.Add(thirdColumn);

            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            this.a = a;

        }


        public ВопросыОтветы(String str)
        {
            InitializeComponent();

            DataGridViewTextBoxColumn firstColumn = new DataGridViewTextBoxColumn();
            firstColumn.HeaderText = "ID";
            firstColumn.Name = "ID";
            firstColumn.ReadOnly = true;
            DataGridViewTextBoxColumn secondColumn = new DataGridViewTextBoxColumn();
            secondColumn.HeaderText = "Характеристика";
            secondColumn.Name = "Value";
            secondColumn.Width = 348;
            DataGridViewTextBoxColumn thirdColumn = new DataGridViewTextBoxColumn();
            thirdColumn.HeaderText = "Балл";
            thirdColumn.Name = "Ball";
            thirdColumn.Width = 60;

            dataGridView1.Columns.Add(firstColumn);
            dataGridView1.Columns.Add(secondColumn);
            dataGridView1.Columns.Add(thirdColumn);

            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;


            button2.Text = str;
            button2.Visible = false;
            dataGridView1.AllowUserToAddRows = false;

        }

        DataTable DT;
        int ID;
        bool flag;
        Test NewTest;
        int a;

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text != "Редактировать ответы")
            {
                ВопросыОтветы otvet = new ВопросыОтветы(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value), NewTest);
                otvet.ShowDialog();
                
            }
            else
            {
                ВопросыОтветы otvet = new ВопросыОтветы(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                otvet.ShowDialog();

            }
            
        }

        DataRow row;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                {
                    if (button2.Text == "Характеристики")
                    {
                        Forms.questions = null;
                    }
                    
                }
               
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (flag == true){
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value = Convert.ToString(NewTest.id_answ);
                NewTest.id_answ++;
            }
            else
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value = Convert.ToString(ID);
                ID++;
            }

            if (dataGridView1.CurrentRow.Index != 0)
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    if (dataGridView1.Rows[dataGridView1.CurrentRow.Index-1].Cells[i].Value == null)
                    {
                        MessageBox.Show("Все ячейки обязательны для заполнения");
                        dataGridView1.AllowUserToAddRows = false;
                        break;

                    }
                }
               
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int k = 0;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[i].Value != null)
                    {
                        k++;
                        if (k == dataGridView1.ColumnCount)
                        {
                            dataGridView1.AllowUserToAddRows = true;
                        }
                }
            }

            if (button2.Text == "Редактировать ответы" && button2.Visible == true){
                try
                {
                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                    {
                        using (OleDbCommand command = new OleDbCommand("Update Questions set Question = @par Where ID_quest = "+Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value)+"", connection))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@par",dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value);
                            command.ExecuteNonQuery();
                          
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (button2.Text == "Редактировать ответы" && button2.Visible == false)
            {
                string name;
                if (dataGridView1.CurrentCell.ColumnIndex == 1)
                {
                    name = "Answer";
                }
                else
                {
                    name = "Ball";
                }

                try
                {
                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                    {
                        using (OleDbCommand command = new OleDbCommand("Update Answers set "+name+" = @par Where ID_answ = " + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value) + "", connection))
                        {
                            connection.Open();
                            if (dataGridView1.CurrentCell.ColumnIndex == 1)
                            {
                                command.Parameters.AddWithValue("@par", dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@par", dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);
                            }
                            command.ExecuteNonQuery();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            if (button2.Text == "Характеристики")
            {
                string name;
                if (dataGridView1.CurrentCell.ColumnIndex == 1)
                {
                    name = "Value";
                }
                else
                {
                    name = "Balls";
                }

                try
                {
                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                    {
                        using (OleDbCommand command = new OleDbCommand("Update Characteristic set [" + name + "] = @par Where ID_char = " + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value) + "", connection))
                        {
                            connection.Open();
                            if (dataGridView1.CurrentCell.ColumnIndex == 1)
                            {
                                command.Parameters.AddWithValue("@par", dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@par", dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);
                            }
                            command.ExecuteNonQuery();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (button2.Text == "Редактировать ответы" && button2.Visible == true){
                try
                {
                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                    {
                        using (OleDbCommand command = new OleDbCommand("Delete * FROM Answers Where ID_quest = " + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value) + "", connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            command.CommandText = "Delete * FROM Questions Where ID_quest = " + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value) + "";
                           
                            command.ExecuteNonQuery();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
                    

                try
                {
                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb"))
                    {
                        using (OleDbCommand command = new OleDbCommand("Delete * FROM Answers Where ID_answ = " + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value) + "", connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
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
