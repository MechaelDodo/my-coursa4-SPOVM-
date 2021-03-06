﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ToolTip t = new ToolTip();
            t.SetToolTip(button1, "Справка");
            t.SetToolTip(button2, "Зарегистрироваться");
            t.SetToolTip(button3, "Чтобы начать тестирование, вам необходимо авторизироваться");
            Forms.Form1 = this;
            Forms.MainMenu = new Главное_меню();
            Forms.Razd = new Разделы();
        }

        Form main;

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 spravk = new Form2();
            spravk.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Регистрация RegForm = new Регистрация();
            RegForm.ShowDialog();
            if (User.flag == true)
            {
                Forms.MainMenu.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Логин loginForm = new Логин();
            loginForm.ShowDialog();
            if (User.flag == true)
            {
                Forms.MainMenu.Show();
                this.Hide();
            }
            
            
        }
    }
}
