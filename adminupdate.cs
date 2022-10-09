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
    public partial class adminupdate : Form
    {
        public adminupdate()
        {
            InitializeComponent();
        }

        //เปลี่ยนหน้า
        private void button1_Click(object sender, EventArgs e)
        {
            loginadmin B = new loginadmin();
            B.Show();
            this.Hide();
        }

        private void adminupdate_Load(object sender, EventArgs e)
        {
            showEquiment();
        }

        //database
        private MySqlConnection databaseConnection()
        {
            string connecttionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bmexpress;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connecttionString);
            return conn;
        }

        //dataGridView
        private void showEquiment()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT date,tracking,status FROM data "; //ดึงค่า

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        //เเสดงข้อมูลในช่อง
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            date.Text = dataGridView1.Rows[e.RowIndex].Cells["date"].FormattedValue.ToString();
            tracking.Text = dataGridView1.Rows[e.RowIndex].Cells["tracking"].FormattedValue.ToString();
            status.Text = dataGridView1.Rows[e.RowIndex].Cells["status"].FormattedValue.ToString();
        }

        //ปุ่มเพิ่มข้อมูล
        private void button2_Click(object sender, EventArgs e)//เพิ่มข้อมูล
        {
            MySqlConnection conn = databaseConnection();

            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "INSERT INTO data (date,tracking,status) VALUES('" + date + "','" + tracking.Text + "','" + status.Text + "')";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("เพิ่มข้อมูลสำเร็จ");
                showEquiment();

            } else
            {
                MessageBox.Show("fail");
            }
        }
    }
}
