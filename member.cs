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
    public partial class member : Form
    {
        public member()
        {
            InitializeComponent();
        }

        box box = new box(); //เรียกใช้form box

        //เชื่อมdatabase
        private MySqlConnection databaseConnection()
        {
            string connecttionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bmexpress;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connecttionString);
            return conn;
        }
        //โชว์ข้อมูลในในtextbox
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Showmember.CurrentRow.Selected = true;
            textBox1.Text = Showmember.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
            textBox2.Text = Showmember.Rows[e.RowIndex].Cells["phone_number"].FormattedValue.ToString();
        }
        //โชว์ข้อมูลเข้าไปในdatagridview
        private void showEquiment()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM member";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            Showmember.DataSource = ds.Tables[0].DefaultView;
        }
        private void member_Load(object sender, EventArgs e)
        {
            showEquiment();
        }

        //ปุ่มยืนยัน
        private void button1_Click(object sender, EventArgs e) 
        {
            if (textBox1.Text != "" && textBox2.Text != "")  //เช็คกรอกข้อมูล
            {
                //เรียกใชเฟังก์ชั่นcheckphoneจากformboxเพื่อเช็คว่าเบอร์ซ้ำมั้ย
                if (box.checkPhone(textBox2.Text) == false && box.checkNum(textBox2.Text) && textBox2.Text.Length == 10)  //เช็คจำนวนเบอร์โทร
                {
                    //เพิ่มค่าในdatabase
                    MySqlConnection conn = databaseConnection();

                    string sql = "INSERT INTO member (name, phone_number) VALUES('" + textBox1.Text + "','" + textBox2.Text + "')";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    conn.Close();

                    if (rows > 0)
                    {
                        MessageBox.Show("เพิ่มข้อมูลสมาชิกสำเร็จ");
                        showEquiment();

                    }
                } else
                {
                    MessageBox.Show("กรุณากรอกเบอร์โทรศัพท์ให้ถูกต้อง");
                }
            } else
            {
                MessageBox.Show("กรุณากรอกข้อมูล");
            }
            
        }
        
        //ปุ่มย้อนกลับ
        private void button2_Click(object sender, EventArgs e)
        {
            welcome A = new welcome();
            A.Show();
            this.Hide();
        }

        //ปุ่มdelete
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int selectedRow = Showmember.CurrentCell.RowIndex;
            int deleteId = Convert.ToInt32(Showmember.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();
            
            string sql = "DELETE FROM member WHERE id = '" + deleteId + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
            {

                MessageBox.Show("ลบข้อมูลสำเร็จ");
                showEquiment();

            }
        }
    }
}
