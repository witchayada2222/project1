﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        //เปลี่ยนหน้าปุ่มย้อนกลับ
        private void button1_Click(object sender, EventArgs e)
        {
            welcome A = new welcome();
            A.Show();
            this.Hide();
        }

        //ตรวจสอบpassword
        private void button2_Click(object sender, EventArgs e)
        {
            string correct_password = "123456";

            string password = textBox1.Text;
            if (password == correct_password)
            {
                loginadmin B = new loginadmin();
                B.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัสผ่านให้ถูกต้อง");

            }

        }
    }
}
