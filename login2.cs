using System;
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
    public partial class loginadmin : Form
    {
        public loginadmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data A = new data();
            A.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminupdate A = new adminupdate();
            A.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            welcome A = new welcome();
            A.Show();
            this.Hide();
        }
    }
}
