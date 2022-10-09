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
    public partial class box : Form
    {
        public box()
        {
            InitializeComponent();
        }

        //ประกาศตัวเเปรให้เป็นpublicเก็บtrackingnumber,price_full,member
        public static string trackingnumber = ""; 
        public static int price_full = 0;
        public static bool member = false;

        private void button2_Click(object sender, EventArgs e)
        {
            welcome A = new welcome();
            A.Show();
            this.Hide();
        }

        private int pricePerWeight() //ใช้คำนวณราคาค่าส่งจากน้ำหนักพัสดุ
        {
            int weight = Convert.ToInt32(textBox1.Text);
            if (weight >= 0 && weight <= 10)
            {
                return 10;
            }
            else if (weight > 10 && weight <= 20)
            {
                return 20;
            }
            else if (weight > 20 && weight <= 30)
            {
                return 30;
            }
            else if (weight > 30 && weight <= 40)
            {
                return 40;
            }
            else if (weight > 40 && weight <= 50)
            {
                return 50;
            }
            else if (weight > 50 && weight <= 60)
            {
                return 60;
            }
            else if (weight > 60 && weight <= 70)
            {
                return 70;
            }
            else if (weight > 70 && weight <= 80)
            {
                return 80;
            }
            else if (weight > 80 && weight <= 90)
            {
                return 90;
            }
            else if (weight > 90 && weight <= 100)
            {
                return 100;
            }
            else if(weight > 100)
            {
                MessageBox.Show("น้ำหนักเกิน");
                textBox1.Text = "100";
                return 100;
            }
            else
            {
                MessageBox.Show("กรุณากรอกน้ำหนักให้ถูกต้อง");
            }
            return 0;
        }
        //คำนวณราคาจากจังหวัด
        private int priceperprovince()
        {
            string province = comboBox1.Text;
            if (province == "เชียงราย")
            {
                return 50;
            } 
            else if (province == "เชียงใหม่")
            {
                return 50;
            }
            else if (province == "น่าน")
            {
                return 50;
            }
            else if (province == "พะเยา")
            {
                return 50;
            }
            else if (province == "แพร่")
            {
                return 50;
            }
            else if (province == "แม่ฮ่องสอน")
            {
                return 50;
            }
            else if (province == "ลำปาง")
            {
                return 50;
            }
            else if (province == "ลำพูน")
            {
                return 50;
            }
            else if (province == "อุตรดิตถ์")
            {
                return 50;
            }
            else if (province == "กาฬสินธุ์")
            {
                return 30;
            }
            else if (province == "ขอนแก่น")
            {
                return 30;
            }
            else if (province == "ชัยภูมิ")
            {
                return 30;
            }
            else if (province == "นครพนม")
            {
                return 30;
            }
            else if (province == "นครราชสีมา")
            {
                return 30;
            }
            else if (province == "บึงกาฬ")
            {
                return 30;
            }
            else if (province == "บุรีรัมย์")
            {
                return 30;
            }
            else if (province == "มหาสารคาม")
            {
                return 30;
            }
            else if (province == "มุกดาหาร")
            {
                return 30;
            }
            else if (province == "ยโสธร")
            {
                return 30;
            }
            else if (province == "ร้อยเอ็ด")
            {
                return 30;
            }
            else if (province == "เลย")
            {
                return 30;
            }
            else if (province == "สกลนคร")
            {
                return 30;
            }
            else if (province == "สุรินทร์")
            {
                return 30;
            }
            else if (province == "ศรีสะเกษ")
            {
                return 30;
            }
            else if (province == "หนองคาย")
            {
                return 30;
            }
            else if (province == "หนองบัวลำภู")
            {
                return 30;
            }
            else if (province == "อุดรธานี")
            {
                return 30;
            }
            else if (province == "อุบลราชธานี")
            {
                return 30;
            }
            else if (province == "อำนาจเจริญ")
            {
                return 30;
            }
            else if (province == "กรุงเทพมหานคร")
            {
                return 40;
            }
            else if (province == "กำแพงเพชร")
            {
                return 40;
            }
            else if (province == "ชัยนาท")
            {
                return 40;
            }
            else if (province == "นครนายก")
            {
                return 40;
            }
            else if (province == "นครปฐม")
            {
                return 40;
            }
            else if (province == "นครสวรรค์")
            {
                return 40;
            }
            else if (province == "นนทบุรี")
            {
                return 40;
            }
            else if (province == "ปทุมธานี")
            {
                return 40;
            }
            else if (province == "พระนครศรีอยุธยา")
            {
                return 40;
            }
            else if (province == "พิจิตร")
            {
                return 40;
            }
            else if (province == "พิษณุโลก")
            {
                return 40;
            }
            else if (province == "เพชรบูรณ์")
            {
                return 40;
            }
            else if (province == "ลพบุรี")
            {
                return 40;
            }
            else if (province == "สมุทรปราการ")
            {
                return 40;
            }
            else if (province == "สมุทรสงคราม")
            {
                return 40;
            }
            else if (province == "สมุทรสาคร")
            {
                return 40;
            }
            else if (province == "สิงห์บุรี")
            {
                return 40;
            }
            else if (province == "สุโขทัย")
            {
                return 40;
            }
            else if (province == "สุพรรณบุรี")
            {
                return 40;
            }
            else if (province == "สระบุรี")
            {
                return 40;
            }
            else if (province == "อ่างทอง")
            {
                return 40;
            }
            else if (province == "อุทัยธานี")
            {
                return 40;
            }
            else if (province == "จันทบุรี")
            {
                return 35;
            }
            else if (province == "ฉะเชิงเทรา")
            {
                return 35;
            }
            else if (province == "ชลบุรี")
            {
                return 35;
            }
            else if (province == "ตราด")
            {
                return 35;
            }
            else if (province == "ปราจีนบุรี")
            {
                return 35;
            }
            else if (province == "ระยอง")
            {
                return 35;
            }
            else if (province == "สระแก้ว")
            {
                return 35;
            }
            else if (province == "กาญจนบุรี")
            {
                return 35;
            }
            else if (province == "ตาก")
            {
                return 35;
            }
            else if (province == "ประจวบคีรีขันธ์")
            {
                return 35;
            }
            else if (province == "เพชรบุรี")
            {
                return 35;
            }
            else if (province == "ราชบุรี")
            {
                return 35;
            }
            else if (province == "กระบี่")
            {
                return 30;
            }
            else if (province == "ชุมพร")
            {
                return 30;
            }
            else if (province == "ตรัง")
            {
                return 30;
            }
            else if (province == "นครศรีธรรมราช")
            {
                return 30;
            }
            else if (province == "นราธิวาส")
            {
                return 30;
            }
            else if (province == "ปัตตานี")
            {
                return 30;
            }
            else if (province == "พังงา")
            {
                return 30;
            }
            else if (province == "พัทลุง")
            {
                return 30;
            }
            else if (province == "ภูเก็ต")
            {
                return 30;
            }
            else if (province == "ระนอง")
            {
                return 30;
            }
            else if (province == "สตูล")
            {
                return 30;
            }
            else if (province == "สงขลา")
            {
                return 30;
            }
            else if (province == "สุราษฎร์ธานี")
            {
                return 30;
            }
            else if (province == "ยะลา")
            {
                return 30;
            }
            
            return 0;
        }

        private void box_Load(object sender, EventArgs e)//โชว์ส่วนลดสมาชิก
        {
            if (box.member == true) //ถ้าเป็นสมาชิก
            {
                textBox9.Text = (box.price_full * 0.05).ToString();

            }
            else
            {
                textBox9.Text = "0";

            }
        }

        private MySqlConnection databaseConnection()
        {
            string connecttionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bmexpress;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connecttionString);
            return conn;
        }
        
        //เช็คว่าข้อความที่ใส่เป็นตัวเลขมั้ย
        public static bool checkNum(string str)
        {
            foreach (char i in str) //เป็นลูปใช้เช็คทีละวตัวอักษรว่าเป็นตัวเลขมั้ย
            { 
                if (!char.IsNumber(i) || char.IsLetter(i))
                {
                    return false;
                }
            }
            return true;
        }
        //เช็คตัวอักษร
        private bool checkAlpha(string str)
        {
            foreach (char i in str)
            {
                if (char.IsNumber(i))
                {
                    return false;
                }
            }
            return true;
        }
        //ปุ่มบันทึกข้อมูล
        private void button3_Click(object sender, EventArgs e)
        {
            if (checkNum(textBox6.Text) && checkNum(textBox3.Text) && textBox6.Text.Length == 10 && textBox3.Text.Length == 10)
            {
                if (checkNum(textBox1.Text))
                {
                    if (checkAlpha(textBox7.Text) && checkAlpha(textBox2.Text))
                    {
                        //เพิ่มข้อมูลขนส่งลงในdatabase
                        MySqlConnection conn = databaseConnection();
                        string r = random(); //เเรนด้อม

                        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string sql = "INSERT INTO data (date,name_sender, phone_sender,address_sender,name,phone_number,weight,address,province,postalnumber,tracking,status) VALUES('" +date+ "','" + textBox7.Text + "','" + textBox6.Text + "','" + textBox8.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox11.Text + "','" + r + "','พัสดุเข้าระบบเรียบร้อยเเล้ว')";

                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();

                        conn.Close();

                        if (rows > 0)
                        {
                            MessageBox.Show("บันทึกข้อมูลเรียบร้อย");
                            trackingnumber = r;
                            receipt C = new receipt();
                            C.Show();
                            this.Hide();
                        }
                    } else
                    {
                        //ชื่อ
                        MessageBox.Show("กรุณากรอกชื่อให้ถูกต้อง");
                    }
                    
                } else
                {
                    //น้ำหนัก
                    MessageBox.Show("กรุณากรอกน้ำหนักให้ถูกต้อง");
                }
            } else
            {
                //เบอร์
                MessageBox.Show("กรุณากรอกเบอร์โทรศัพท์ให้ถูกต้อง");
            }

        }

        //ตรวจสอบเบอร์โทรศัพท์ว่าเป็นสมาชิก
        public bool checkPhone(string phone)
        {
            MySqlConnection conn = databaseConnection();
            string sql = $"SELECT phone_number FROM member";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> phonelist = new List<string>(); 
            while (reader.Read())
            {
                phonelist.Add(reader.GetString("phone_number"));//เอาข้อมูลในdatabaseมาเก็บในphonelistเพื่อเช็คสมาชิก
            }

            foreach (string i in phonelist)
            {
                if (i == phone)
                {
                    return true;
                }
            }
            return false;
        }

        //เช็คเลขพัสดุซ้ำ
        private bool trackingCheck(string tracking)
        {
            string sql = "SELECT * FROM data";
            MySqlConnection conn = databaseConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open ();
            MySqlDataReader dr = cmd.ExecuteReader();
            List<string> list = new List<string>();

            while (dr.Read())
            {
                list.Add(dr.GetString("tracking"));
            }
            conn.Close();
            foreach (string track in list)
            {
                if (track == tracking)
                {
                    return true; // เลขซ้ำ
                }
            }
            return false;
        }

        //เเรนด้อมเลขพัสดุ
        private string random()
        {
            Random random = new Random();
            string number = "";
            bool isDuplicate = true;
            while (isDuplicate == true)
            {
                number = "";
                for (int i = 0; i < 10; i++)
                {
                    number += random.Next(10).ToString();
                }
                if (trackingCheck(number) == false)
                {
                    isDuplicate = false;
                }
            }

            return number;
        }


        //คำนวณ
        private void calculate()
        {
            int w = pricePerWeight();
            int p = priceperprovince();
            member = checkPhone(textBox6.Text);
            double price = 0;
            price_full = w + p;
            if (member == true)
            {
                price = (w + p) * 0.95;
            }
            else
            {
                price = (w + p);
            }
            textBox5.Text = price.ToString();
        }

        //เช็คว่าเป็นmemberเพื่อเเสดงในกล่องเเสดงส่วนลด
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (box.member == true)
            {
                textBox9.Text = (box.price_full * 0.05).ToString();

            }
            else
            {
                textBox9.Text = "0";

            }
        }
        //ช่องเบอร์
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                calculate();

            }
            catch (Exception)
            {

            }
            
        }
        //ช่องน้ำหนัก 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                calculate();
            } 
            catch (Exception )
            {

            }
        }
        //ช่องจังหวัด
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                calculate();
            }
            catch (Exception )
            {

            }
        }
    }
}
