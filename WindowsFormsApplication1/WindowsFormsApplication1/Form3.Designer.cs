﻿namespace WindowsFormsApplication1
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выйтиИзАккаунтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиИзПрограммыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиИзПрограммыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиИзПрограммыToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.ForeColor = System.Drawing.Color.Black;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 26;
            this.listBox1.Location = new System.Drawing.Point(81, 138);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(549, 338);
            this.listBox1.TabIndex = 0;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LavenderBlush;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(595, 4);
            this.label1.MaximumSize = new System.Drawing.Size(80, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LavenderBlush;
            this.menuStrip1.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выйтиИзАккаунтаToolStripMenuItem,
            this.выйтиИзПрограммыToolStripMenuItem,
            this.выйтиИзПрограммыToolStripMenuItem1,
            this.выйтиИзПрограммыToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MaximumSize = new System.Drawing.Size(699, 24);
            this.menuStrip1.MinimumSize = new System.Drawing.Size(699, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(699, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выйтиИзАккаунтаToolStripMenuItem
            // 
            this.выйтиИзАккаунтаToolStripMenuItem.Name = "выйтиИзАккаунтаToolStripMenuItem";
            this.выйтиИзАккаунтаToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.выйтиИзАккаунтаToolStripMenuItem.Text = "Разделы";
            this.выйтиИзАккаунтаToolStripMenuItem.Click += new System.EventHandler(this.выйтиИзАккаунтаToolStripMenuItem_Click);
            // 
            // выйтиИзПрограммыToolStripMenuItem
            // 
            this.выйтиИзПрограммыToolStripMenuItem.Name = "выйтиИзПрограммыToolStripMenuItem";
            this.выйтиИзПрограммыToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.выйтиИзПрограммыToolStripMenuItem.Text = "Главное меню";
            this.выйтиИзПрограммыToolStripMenuItem.Click += new System.EventHandler(this.выйтиИзПрограммыToolStripMenuItem_Click);
            // 
            // выйтиИзПрограммыToolStripMenuItem1
            // 
            this.выйтиИзПрограммыToolStripMenuItem1.Name = "выйтиИзПрограммыToolStripMenuItem1";
            this.выйтиИзПрограммыToolStripMenuItem1.Size = new System.Drawing.Size(129, 20);
            this.выйтиИзПрограммыToolStripMenuItem1.Text = "Выйти из аккаунта";
            this.выйтиИзПрограммыToolStripMenuItem1.Click += new System.EventHandler(this.выйтиИзПрограммыToolStripMenuItem1_Click);
            // 
            // выйтиИзПрограммыToolStripMenuItem2
            // 
            this.выйтиИзПрограммыToolStripMenuItem2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.выйтиИзПрограммыToolStripMenuItem2.Name = "выйтиИзПрограммыToolStripMenuItem2";
            this.выйтиИзПрограммыToolStripMenuItem2.Size = new System.Drawing.Size(146, 20);
            this.выйтиИзПрограммыToolStripMenuItem2.Text = "Выйти из программы";
            this.выйтиИзПрограммыToolStripMenuItem2.Click += new System.EventHandler(this.выйтиИзПрограммыToolStripMenuItem2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(276, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 40);
            this.label2.TabIndex = 18;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.ФонСпискаТестов;
            this.ClientSize = new System.Drawing.Size(698, 521);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(714, 555);
            this.MinimumSize = new System.Drawing.Size(714, 555);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выйтиИзАккаунтаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиИзПрограммыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиИзПрограммыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выйтиИзПрограммыToolStripMenuItem2;
        private System.Windows.Forms.Label label2;
    }
}