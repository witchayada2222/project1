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
    public partial class tracking : Form
    {
        public tracking()
        {
            InitializeComponent();
        }
        public static string trackingnumber = "";

        //database
        private MySqlConnection databaseConnection()
        {
            string connecttionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bmexpress;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connecttionString);
            return conn;
        }

        //เปลี่ยนหน้า
        private void button2_Click(object sender, EventArgs e)
        {
            welcome A = new welcome();
            A.Show();
            this.Hide();
        }

        //เช็คเลขพัสดุจากdatabase
        private bool checktracking(string tracking)
        {
            MySqlConnection conn = databaseConnection();
            string sql = "SELECT tracking FROM data";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> alltrack = new List<string>();
            while (reader.Read()) //วนค่าจากคอลัมtrackingเอามาเก็บในตัวเเปรalltrack
            {
                alltrack.Add(reader.GetString("tracking"));
            }

            conn.Close();

            foreach (string i in alltrack) //เช็คว่ามีเลขพัสดุมั้ย
            {
                if (i == tracking)
                {
                    return true;
                }
            }
            return false;
        }

        //ปุ่มเช็คเลขพัสดุ
        private void button1_Click(object sender, EventArgs e)
        {
            string tracking = textBox1.Text;
            if (checktracking(tracking))
            {
                trackingnumber = tracking;
                MessageBox.Show("พัสดุเข้าระบบเรียบร้อย");
                status A = new status();
                A.Show();
                this.Hide(); //ไปที่หน้าstatus
            }
            else
            {
                MessageBox.Show("ยังไม่มีข้อมูลในระบบ");
            }
        }
    }
}
