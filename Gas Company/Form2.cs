using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Mysqlx.Session;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Crypto.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Configuration;

namespace Gas_Company
{
    public partial class Form2 : Form
    {
        //Server: The server name or IP address where the MySQL database is hosted.
        //Database: The name of the database to connect to..
        //Uid: The username used to authenticate the connection.
        //Pwd: The password associated with the provided username.
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public Form2()
        {
            InitializeComponent();
        }

        //// Real-time time clock
        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            date.Text = DateTime.Now.ToLongDateString();
            time.Text = DateTime.Now.ToLongTimeString();
            week.Text = DateTime.Now.ToString("dddd"); // dddd: Represents the full name of the day of the week (e.g., Monday, Tuesday, ..., Sunday). instaed of abbreviation.
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        //// Simple form display format initiation
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            // Avoid duplicated form opening
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        //// Data paint on panel
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            string query = "SELECT * FROM `new_order`";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;

                    // You can check each column's name here
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.WriteLine(column.ColumnName);
                    }

                }
            }
        }

        // Open 主頁面
        private void GasOrderPage_Click(object sender, EventArgs e)
        {
            activeForm.Close();
        }

        // Open 客戶管理視窗
        private void CustomerManagePage_Click(object sender, EventArgs e)
        {
            openChildForm(new Customer());
        }

        // Open 殘氣累積視窗
        private void ResidualGasPage_Click(object sender, EventArgs e)
        {
            //openChildForm(new ResidualGas());
        }

        // Open 瓦斯桶管理視窗
        private void GasTankManagePage_Click(object sender, EventArgs e)
        {
            openChildForm(new GasTankManage());
        }

        // Open 員工資料視窗
        private void WorkerPage_Click(object sender, EventArgs e)
        {
            openChildForm(new Worker());
        }


        //// Auto-fill when certain row is selected.
        ////* 需求需確認: 要哪些資料? *////
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Access the data in the selected row and autofill other fields in the form
                string orderId = selectedRow.Cells["Order_ID"].Value.ToString();
                string customerName = selectedRow.Cells["Customer_ID"].Value.ToString();
                string customerPhone = selectedRow.Cells["Customer_Phone"].Value.ToString();
                string deliveryTime = selectedRow.Cells["Delivery_Time"].Value.ToString();
                string deliveryAddress = selectedRow.Cells["Delivery_Address"].Value.ToString();


                // Retrieve other fields as needed

                // Autofill the other fields(Textbox) in the form
                Order_ID.Text = orderId;
                Customer_ID.Text = customerName;
                Customer_Phone.Text = customerPhone;
                Delivery_Time.Text = deliveryTime;
                Delivery_Address.Text = deliveryAddress;

            }
        }

        //// 插入資料
        private void InsertButton_Click(object sender, EventArgs e)
        {

        }

        ////刪除資料視窗
        // dataGridView1: data table side.
        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1) // If mouse selected one row.
            {
                DialogResult result = MessageBox.Show("确定删除此行資料？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) // If user confirm delete
                {
                    string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string query = "DELETE FROM `new_order` WHERE `Order_ID` = @Order_ID";
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Order_ID", id);
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            connection.Close();
                            if (rowsAffected > 0)
                            {
                                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                                MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("請選擇要刪除的資料行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string searchTerm = txt.Text;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                string query = "SELECT * FROM `new_order` WHERE Order_ID LIKE @Order_ID OR Customer_ID LIKE @Customer_ID OR Customer_Phone LIKE Customer_Phone OR Delivery_Address LIKE Delivery_Address";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Order_ID", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("@Customer_ID", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("@Customer_Phone", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("@Delivery_Address", "%" + searchTerm + "%");


                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            if (table.Rows.Count == 0)
                            {
                                MessageBox.Show("未找到結果。請重試。", "搜索失敗", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                dataGridView1.DataSource = table;
                            }
                        }
                    }
                }
            }
        }
        // Open ??
        private void button17_Click(object sender, EventArgs e)
        {
            CustomerInformation mainForm = new CustomerInformation();
            mainForm.Show();

        }

        private void print_Click(object sender, EventArgs e)
        {

        }

        
    }
}
