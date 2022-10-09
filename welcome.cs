using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace project
{
    git push -u origin main
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

        //ปุ่มเปลี่ยนหน้า
        private void button1_Click(object sender, EventArgs e) 
        {
            member A = new member();
            A.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            box B = new box();
            B.Show();
            this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tracking C = new tracking();
            C.Show();
            this.Hide();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            login A = new login();
            A.Show();
            this.Hide();
        }

    }
}
