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
using System.Configuration;

namespace Gas_Company
{
    public partial class Customer : Form
    {
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public Customer()
        {
            InitializeComponent();
        }

        private void customer_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM `customer`";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    CustomerField.DataSource = table;
                    string[] columnOrder = {
                                            "CUSTOMER_Id",
                                            "CUSTOMER_Name",
                                            "CUSTOMER_Address",
                                            "CUSTOMER_PhoneNo",
                                            "CUSTOMER_Sex",
                                            "CUSTOMER_Postal_Code",
                                            "CUSTOMER_HouseTelpNo",
                                            "CUSTOMER_Password",
                                            "CUSTOMER_Email",
                                            "CUSTOMER_FamilyMemberId",
                                            "COMPANY_Id",
                                            "COMPANY_HistoryID",
                                            "CUSTOMER_Notes",
                                            "CUSTOMER_Registration_Time"
                                        };

                    // Loop through the columns and set their display index
                    foreach (string columnName in columnOrder)
                    {
                        if (CustomerField.Columns.Contains(columnName))
                        {
                            CustomerField.Columns[columnName].DisplayIndex = Array.IndexOf(columnOrder, columnName);
                        }
                    }
                    // Columns rename
                    CustomerField.Columns["CUSTOMER_Id"].HeaderText = "客戶編號";
                    CustomerField.Columns["CUSTOMER_Name"].HeaderText = "客戶姓名";
                    CustomerField.Columns["CUSTOMER_Sex"].HeaderText = "客戶性別";
                    CustomerField.Columns["CUSTOMER_PhoneNo"].HeaderText = "客戶電話";
                    CustomerField.Columns["CUSTOMER_Postal_Code"].HeaderText = "客戶郵遞區號";
                    CustomerField.Columns["CUSTOMER_Address"].HeaderText = "客戶地址";
                    CustomerField.Columns["CUSTOMER_HouseTelpNo"].HeaderText = "客戶家用電話";
                    CustomerField.Columns["CUSTOMER_Password"].HeaderText = "客戶密碼";
                    CustomerField.Columns["CUSTOMER_Email"].HeaderText = "客戶電子郵件";
                    CustomerField.Columns["CUSTOMER_FamilyMemberId"].HeaderText = "客戶關係家人";
                    CustomerField.Columns["COMPANY_Id"].HeaderText = "客戶瓦斯行";
                    CustomerField.Columns["COMPANY_HistoryID"].HeaderText = "客戶歷史瓦斯行";
                    CustomerField.Columns["CUSTOMER_Notes"].HeaderText = "客戶備註";
                    CustomerField.Columns["CUSTOMER_Registration_Time"].HeaderText = "客戶註冊時間";
                    // You can check each column's name here
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.WriteLine(column.ColumnName);
                    }

                }
            }
        }


        private void CustomerField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = CustomerField.Rows[e.RowIndex];

                // Access the data in the selected row and autofill other fields in the form
                string customerName = selectedRow.Cells["Customer_Name"].Value.ToString();
                string customerSex = selectedRow.Cells["Customer_Sex"].Value.ToString();
                string customerPhone = selectedRow.Cells["Customer_PhoneNo"].Value.ToString();
                string customerNumber = selectedRow.Cells["Customer_HouseTelpNo"].Value.ToString();
                string customerEmail = selectedRow.Cells["Customer_Email"].Value.ToString();
                //string customerCity = selectedRow.Cells["Customer_City"].Value.ToString();
                //string customerDistrict = selectedRow.Cells["Customer_District"].Value.ToString();
                string customerAddress = selectedRow.Cells["Customer_Address"].Value.ToString();
                string customerNote = selectedRow.Cells["Customer_Notes"].Value.ToString();

                // Autofill the other fields(Textbox) in the form
                CustomerName.Text = customerName;
                CustomerSex.Text = customerSex;
                CustomerPhone.Text = customerPhone;
                CustomerNumber.Text = customerNumber;
                CustomerEmail.Text = customerEmail;
                //CustomerCity.Text = customerCity;
                //CustomerDistrict.Text = customerDistrict;
                CustomerAddress.Text = customerAddress;
                CustomerNote.Text = customerNote;
            }
        }

        private void CSearchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                string query = "SELECT * FROM `customer` WHERE Customer_ID LIKE @Customer_ID OR Customer_Name LIKE @Customer_Name OR Customer_Phone LIKE @Customer_Phone OR Customer_City LIKE @Customer_City";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Customer_ID", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("@Customer_Name", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("@Customer_Phone", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("@Customer_City", "%" + searchTerm + "%");

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
                                CustomerField.DataSource = table;
                            }
                        }
                    }
                }
            }
        }

        private void CDeleteButton_Click(object sender, EventArgs e)
        {
            if (CustomerField.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定删除此行資料？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string customerId = CustomerField.SelectedRows[0].Cells[0].Value.ToString();
                    string query = "DELETE FROM `customer` WHERE `customer_Id` = @customerId";
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@customerId", customerId);
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            connection.Close();
                            if (rowsAffected > 0)
                            {
                                CustomerField.Rows.RemoveAt(CustomerField.SelectedRows[0].Index);
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

        private void CUpdateButton_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM customer", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                CustomerField.DataSource = dt;
                conn.Close();
            }
        }

        private void CAddButton_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.AppSettings["ConnectionString"];
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                //string insertQuery = "INSERT INTO customer (CCUSTOMER_Id, CUSTOMER_Name, CUSTOMER_Sex, CUSTOMER_PhoneNo, CUSTOMER_HouseTelpNo, CUSTOMER_Email, CUSTOMER_City, CUSTOMER_District, CUSTOMER_Address, CUSTOMER_FamilyMemberId, COMPANY_Id, CUSTOMER_Registration_Time) " +
                //    "VALUES (LAST_INSERT_ID(), @CUSTOMER_Name, @CUSTOMER_Sex, @CUSTOMER_PhoneNo, @CUSTOMER_HouseTelpNo, @CUSTOMER_Email, @CUSTOMER_City, @CUSTOMER_District, @CUSTOMER_Address, @CUSTOMER_FamilyMemberId, @COMPANY_Id, NOW())";
                string insertQuery = "INSERT INTO customer (CUSTOMER_Id, CUSTOMER_Name, CUSTOMER_Sex, CUSTOMER_PhoneNo, CUSTOMER_Email, CUSTOMER_Address, CUSTOMER_Registration_Time) " +
                    "VALUES (LAST_INSERT_ID(), @CUSTOMER_Name, @CUSTOMER_Sex, @CUSTOMER_PhoneNo, @CUSTOMER_Email, @CUSTOMER_Address, NOW())";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                {

                    cmd.Parameters.AddWithValue("@CUSTOMER_Name", CustomerName.Text);
                    cmd.Parameters.AddWithValue("@CUSTOMER_Sex", CustomerSex.Text);
                    cmd.Parameters.AddWithValue("@CUSTOMER_PhoneNo", CustomerPhone.Text);
                    cmd.Parameters.AddWithValue("@CUSTOMER_HouseTelpNo", CustomerNumber.Text);
                    cmd.Parameters.AddWithValue("@CUSTOMER_Email", CustomerEmail.Text);
                    cmd.Parameters.AddWithValue("@CUSTOMER_Address", CustomerAddress.Text);
                    //cmd.Parameters.AddWithValue("@CUSTOMER_FamilyMemberId", family.Text);
                    //cmd.Parameters.AddWithValue("@COMPANY_Id", company.Text);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("登錄成功！");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("登錄失敗！");
                    }
                }

                
            }
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void CustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void HistoryOrderButton_Click(object sender, EventArgs e)
        {
            string customerPhone = CustomerPhone.Text;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT *
                                FROM gas_order_history
                                WHERE DELIVERY_Phone = (
                                    SELECT DELIVERY_Phone
                                    FROM gas_order_history
                                    WHERE DELIVERY_Phone = @customerPhone
                                )
                                ORDER BY DELIVERY_Time DESC;
                                ";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customerPhone", customerPhone);

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
