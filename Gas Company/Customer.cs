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
            string query = $"SELECT * FROM `customer` WHERE Company_Id = {GlobalVariables.CompanyId};";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    // Change the original column order
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

                    // Loop through the columns and set their display order
                    foreach (string columnName in columnOrder)
                    {
                        if (dataGridView1.Columns.Contains(columnName))
                        {
                            dataGridView1.Columns[columnName].DisplayIndex = Array.IndexOf(columnOrder, columnName);
                        }
                    }
                    // Columns rename
                    dataGridView1.Columns["CUSTOMER_Id"].HeaderText = "客戶編號";
                    dataGridView1.Columns["CUSTOMER_Name"].HeaderText = "客戶姓名";
                    dataGridView1.Columns["CUSTOMER_Sex"].HeaderText = "客戶性別";
                    dataGridView1.Columns["CUSTOMER_PhoneNo"].HeaderText = "客戶電話";
                    dataGridView1.Columns["CUSTOMER_Postal_Code"].HeaderText = "客戶郵遞區號";
                    dataGridView1.Columns["CUSTOMER_Address"].HeaderText = "客戶地址";
                    dataGridView1.Columns["CUSTOMER_HouseTelpNo"].HeaderText = "客戶家用電話";
                    dataGridView1.Columns["CUSTOMER_Password"].HeaderText = "客戶密碼";
                    dataGridView1.Columns["CUSTOMER_Email"].HeaderText = "客戶電子郵件";
                    dataGridView1.Columns["CUSTOMER_FamilyMemberId"].HeaderText = "客戶關係家人";
                    dataGridView1.Columns["COMPANY_Id"].HeaderText = "客戶瓦斯行";
                    dataGridView1.Columns["COMPANY_HistoryID"].HeaderText = "客戶歷史瓦斯行";
                    dataGridView1.Columns["CUSTOMER_Notes"].HeaderText = "客戶備註";
                    dataGridView1.Columns["CUSTOMER_Registration_Time"].HeaderText = "客戶註冊時間";

                }
            }
        }


        private void CustomerField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Access the data in the selected row and autofill other fields in the form

                string customerId = selectedRow.Cells["Customer_Id"].Value.ToString();
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
                CustomerID.Text = customerId;
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
                string query = $"SELECT * FROM `customer` WHERE Customer_ID LIKE @Customer_ID OR Customer_Name LIKE @Customer_Name OR Customer_PhoneNo LIKE @Customer_PhoneNo WHERE Company_Id = {GlobalVariables.CompanyId};";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Customer_ID", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("@Customer_Name", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("@Customer_PhoneNo", "%" + searchTerm + "%");

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

        private void CDeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定删除此行資料？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string customerId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
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

        private void CUpdateButton_Click(object sender, EventArgs e)
        {
            customer_Load(sender, e);
        }

        private void CAddButton_Click(object sender, EventArgs e)
        {
            //開啟基本用戶資料頁面
            //新增一筆資料
            customer_form f1 = new customer_form(null);
            if (f1.ShowDialog() == DialogResult.OK)
            {
                // Perform data refresh or any other required actions after the form is closed
                RefreshData();
            }
        }

        private void HistoryOrderButton_Click(object sender, EventArgs e)
        {
            string customerId = CustomerID.Text;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT *
                                FROM gas_order_history
                                WHERE CUSTOMER_Id IN (
                                    SELECT CUSTOMER_Id
                                    FROM gas_order_history
                                    WHERE CUSTOMER_Id = @customerId
                                )
                                ORDER BY DELIVERY_Time DESC;
                                ";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customerId", customerId);

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

        private void edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells["CUSTOMER_Id"].Value.ToString();

                // Pass the selected ID to the customer_form for editing
                customer_form f1 = new customer_form(id);
                if (f1.ShowDialog() == DialogResult.OK)
                {
                    // Perform data refresh or any other required actions after the form is closed
                    RefreshData();
                }
            }
            else
            {
                MessageBox.Show("請選擇要編輯的資料行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // 操作完要REFRESH一下
        private void RefreshData()
        {
            string query = $"SELECT * FROM `customer` WHERE COMPANY_Id = {GlobalVariables.CompanyId}";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
            }
        }
    }
}
