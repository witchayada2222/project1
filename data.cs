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
    public partial class data : Form
    {
        public data()
        {
            InitializeComponent();
        }

        private bool serch = false; //ประกาศให้serch=false

        private void data_Load(object sender, EventArgs e)
        {
            showEquiment();
            serch = true;
        }
        //database
        private MySqlConnection databaseConnection()
        {
            string connecttionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bmexpress;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connecttionString);
            return conn;
        }
        //โชว์datagridview
        private void showEquiment()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();

            //serch
            if (serch == false)   
            {
                cmd.CommandText = "SELECT * FROM data";
            }
            else
            {
                cmd.CommandText = "SELECT * FROM data WHERE name LIKE '%"+ serchdata.Text + "%' or phone_number LIKE '%" + serchdata.Text + "%'";

            }

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        //เปลี่ยนหน้า
        private void button3_Click(object sender, EventArgs e)
        {
            loginadmin A = new loginadmin();
            A.Show();
            this.Hide();
        }

        //โชว์ข้อมูลในtextbox
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["name_sender"].FormattedValue.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["phone_sender"].FormattedValue.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["address_sender"].FormattedValue.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["phone_number"].FormattedValue.ToString();
        }

        //ปุ่มdelete
        private void button2_Click(object sender, EventArgs e) //ลบ
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            int deleteId = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();

            string sql = "DELETE FROM data WHERE id = '" + deleteId + "'";
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
        //ปุ่มเเก้ไขข้อมูล
        private void button1_Click(object sender, EventArgs e) //เเก้
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();

            String sql = "UPDATE data SET name_sender = '" + textBox1.Text + "',phone_sender = '" + textBox2.Text + "',address_sender = '" + textBox3.Text + "',name = '" + textBox4.Text + "',phone_number = '" + textBox5.Text + "'WHERE id = '" + editId + "'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("แก้ไขข้อมูลสำเร็จ");

                showEquiment();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            showEquiment();
        }


        
    }
}
