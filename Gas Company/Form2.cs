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
using Mysqlx.Crud;
using static Google.Protobuf.Reflection.FieldOptions.Types;

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
            // Here is to see the orders
            string query = "SELECT o.ORDER_Id, c.CUSTOMER_PhoneNo, o.DELIVERY_Address, o.DELIVERY_Time, c.CUSTOMER_Name, od.Order_type, od.Order_weight, o.Gas_Quantity, o.COMPANY_Id FROM `gas_order` o JOIN`customer` c ON o.CUSTOMER_Id = c.CUSTOMER_Id JOIN `gas_order_detail` od ON o.ORDER_Id = od.Order_ID;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;

                    // You can check each column's name here
                    /*foreach (DataColumn column in table.Columns)
                    {
                        Console.WriteLine(column.ColumnName);
                    }*/

                }
            }
            // Here is to load in the available workers


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
                string customerName = selectedRow.Cells["Customer_Name"].Value.ToString();
                string customerPhone = selectedRow.Cells["Customer_PhoneNo"].Value.ToString();
                string deliveryTime = selectedRow.Cells["Delivery_Time"].Value.ToString();
                string deliveryAddress = selectedRow.Cells["Delivery_Address"].Value.ToString();
                string orderWeight = selectedRow.Cells["Order_weight"].Value.ToString();
                string orderType = selectedRow.Cells["Order_type"].Value.ToString();
                string orderQuantity = selectedRow.Cells["Gas_Quantity"].Value.ToString();

                // Autofill the other fields(Textbox) in the form
                OrderID.Text = orderId;
                CustomerName.Text = customerName;
                CustomerPhone.Text = customerPhone;
                DeliveryTime.Text = deliveryTime;
                DeliveryAddress.Text = deliveryAddress;
                GasType.Text = orderType;
                GasWeight.Text = orderWeight;
                GasQuantity.Text = orderQuantity;
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
                    string query = "DELETE FROM `gas_order` WHERE `Order_ID` = @Order_ID";
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
                string query = "SELECT * FROM `gas_order` WHERE Order_ID LIKE @Order_ID OR Customer_ID LIKE @Customer_ID OR Customer_Phone LIKE Customer_Phone OR Delivery_Address LIKE Delivery_Address";
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
        // 顯示客戶資料
        public class CustomerData
        {
            public string CustomerId { get; set; }            
            public string CustomerName { get; set; }
            public string CustomerPhone { get; set; }
            public string CustomerSex { get; set; }
            public string FamilyMemberId { get; set; }
            public string CustomerEmail { get; set; }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT *
                                FROM customer
                                WHERE CUSTOMER_Id = (
                                    SELECT CUSTOMER_Id
                                    FROM gas_order_history
                                    WHERE ORDER_Id = @order_id
                                )
                                ";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@order_id", OrderID.Text);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        List<CustomerData> customerDataList = new List<CustomerData>();
                        while (reader.Read())
                        {
                            CustomerData customerData = new CustomerData
                            {
                                CustomerId = reader.GetString("CUSTOMER_Id"),
                                CustomerName = reader.GetString("CUSTOMER_Name"),
                                CustomerPhone = reader.GetString("CUSTOMER_PhoneNo"),
                                CustomerSex = reader.GetString("CUSTOMER_Sex"),
                                FamilyMemberId = reader.GetString("CUSTOMER_FamilyMemberId"),
                                CustomerEmail = reader.GetString("CUSTOMER_Email")
                            };
                            customerDataList.Add(customerData);
                        }
                        CustomerInformation customerInformation = new CustomerInformation();
                        customerInformation.Show();
                        customerInformation.SetData(customerDataList);
                    }
                }
            }
        }

        private void print_Click(object sender, EventArgs e)
        {

        }

        private void DeliveryMan_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT WORKER_Id, WORKER_Name FROM worker";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing items in the ComboBox
                        DeliveryMan.Items.Clear();

                        // Loop through the result set and add worker names to the ComboBox
                        while (reader.Read())
                        {
                            string workerName = reader.GetString("WORKER_Name");

                            // Add worker name to the ComboBox
                            DeliveryMan.Items.Add(workerName);
                        }
                    }
                }
            }
        }
        // 歷史訂單
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT *
                                FROM gas_order_history
                                WHERE CUSTOMER_Id = (
                                    SELECT CUSTOMER_Id
                                    FROM gas_order_history
                                    WHERE ORDER_Id = @order_id
                                )
                                ORDER BY DELIVERY_Time DESC;
                                ";

                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string order_id = selectedRow.Cells["Order_Id"].Value.ToString();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@order_id", order_id);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable historyOrders = new DataTable();
                        adapter.Fill(historyOrders);

                        // Create an instance of the HistoryOrder form
                        HistoryOrder historyOrderForm = new HistoryOrder();

                        // Pass the historyOrders DataTable to the form
                        historyOrderForm.SetData(historyOrders);

                        // Display the form
                        historyOrderForm.ShowDialog();

                    }
                }
            }
        }
    }
}
