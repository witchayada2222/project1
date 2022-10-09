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
    public partial class receipt : Form
    {
        public receipt()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connecttionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bmexpress;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connecttionString);
            return conn;
        }

        //เปลี่ยนหน้าปุ่มย้อนกลับ
        private void button2_Click(object sender, EventArgs e)
        {
            welcome A = new welcome();
            A.Show();
            this.Hide();
        }

        //ดึงข้อมูลผู้ส่งจากในdatabaseมาโชว์ในใบเสร็จ
        private string[] data(string tracking)
        {
            MySqlConnection conn = databaseConnection();
            string sql = "SELECT name_sender, phone_sender,name FROM data WHERE tracking = '"+tracking+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> list = new List<string>();
            
            //name_sender,phone_sender,nameไปเก็บในlist
            if (reader.Read())
            {
                list.Add(reader.GetString("name_sender"));
                list.Add(reader.GetString("phone_sender"));
                list.Add(reader.GetString("name"));
            }

            conn.Close();

            return list.ToArray(); // รีเทิร์นค่าlistเป็นarray{ name_sender, phone_sender, name }
        }

        //ใส่ข้อมูลในใบเสร็จ
        private void receipt_Load_1(object sender, EventArgs e)
        {
            string tracking = box.trackingnumber;
            //ดึงข้อมูลมาจากฟังก์ชั่นdata
            textBox6.Text = data(tracking)[0];//name_sender
            textBox7.Text = data(tracking)[1];//phone_sender
            textBox5.Text = data(tracking)[2];//name
            textBox1.Text = tracking;//tracking
            textBox4.Text = box.price_full.ToString();//ค่าขนส่ง 

            if (box.member == true)//ถ้าเป็นสมาชิก
            {
                textBox3.Text = (box.price_full * 0.05).ToString();//ส่วนลด
                textBox2.Text = (box.price_full * 0.95).ToString();//รวม
            }
            else
            {
                textBox3.Text = "0";//ส่วนลด
                textBox2.Text = (box.price_full).ToString();//รวม
            }
        }
    }
}
