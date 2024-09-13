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
using static Google.Protobuf.Reflection.FieldOptions.Types;

namespace Gas_Company
{
        public partial class Customer : Form
        {
            private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            readonly string customerId = "";


            public Customer()
            {
                InitializeComponent();
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 只點選 cell 就可以選擇整個 row
            }

            private void customer_Load(object sender, EventArgs e)
            {
            string query = $@"SELECT 
                            c.*,
                            ROUND(((sh.SENSOR_Weight / 1000) - i.Gas_Empty_Weight), 1) AS CurrentGasAmount,
                            a.Alert_Volume,
                            sh.SENSOR_Weight,
                            i.Sensor_Id,
                            COALESCE(go.OrderStatus, '未訂購') AS OrderStatus,
                            COALESCE(go.DaysSinceLastOrder, '無訂單記錄') AS DaysSinceLastOrder
                        FROM customer c
                        LEFT JOIN iot i ON c.CUSTOMER_Id = i.CUSTOMER_Id
                        LEFT JOIN alert a ON i.Sensor_Id = a.Sensor_Id
                        LEFT JOIN (
                            SELECT *,
                                ROW_NUMBER() OVER (PARTITION BY SENSOR_Id ORDER BY SENSOR_Time DESC) AS rn
                            FROM sensor_history
                        ) sh ON i.Sensor_Id = sh.SENSOR_Id AND sh.rn = 1
                        LEFT JOIN (
                            SELECT 
                                CUSTOMER_Id, 
                                CASE
                                    WHEN EXISTS (
                                        SELECT 1 
                                        FROM gas_order
                                        WHERE CUSTOMER_Id = go.CUSTOMER_Id 
                                        AND DELIVERY_Condition IN (0, 1)
                                    ) THEN '已訂購'
                                    ELSE '未訂購'
                                END AS OrderStatus,
                                COALESCE(DATEDIFF(CURDATE(), MAX(DELIVERY_Time)), '無訂單記錄') AS DaysSinceLastOrder
                            FROM gas_order go
                            GROUP BY CUSTOMER_Id
                        ) go ON c.CUSTOMER_Id = go.CUSTOMER_Id
                        WHERE c.Company_Id = @CompanyId;";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                        {
                            adapter.SelectCommand.Parameters.AddWithValue("@CompanyId", GlobalVariables.CompanyId);
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            dataGridView1.DataSource = table;
                            //客戶要求不要顯示出這些欄位
                            table.Columns.Remove("CUSTOMER_Password");
                            table.Columns.Remove("COMPANY_Id");
                            table.Columns.Remove("COMPANY_HistoryID");

                            // Change the original column order
                            string[] columnOrder = {
                                                    "CUSTOMER_Id",
                                                    "CurrentGasAmount",
                                                    "OrderStatus",
                                                    "CUSTOMER_Name",
                                                    "CUSTOMER_Address",
                                                    "Sensor_Id",
                                                    "Alert_Volume",
                                                    "SENSOR_Weight",
                                                    "CUSTOMER_PhoneNo",
                                                    "CUSTOMER_Sex",
                                                    "CUSTOMER_Postal_Code",
                                                    "CUSTOMER_HouseTelpNo",
                                                    "CUSTOMER_Email",
                                                    "CUSTOMER_FamilyMemberId",
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

                        foreach (DataRow row in table.Rows)
                        {
                            // Check if CurrentGasAmount is less than 0
                            if (row["CurrentGasAmount"] != DBNull.Value && Convert.ToDecimal(row["CurrentGasAmount"]) < 0)
                            {
                                // Set CurrentGasAmount to 0
                                row["CurrentGasAmount"] = 0;
                            }
                        }
                        dataGridView1.DataSource = table;


                        // Columns rename
                        dataGridView1.Columns["CUSTOMER_Id"].HeaderText = "客戶編號";
                        dataGridView1.Columns["CurrentGasAmount"].HeaderText = "當前瓦斯量";
                        dataGridView1.Columns["OrderStatus"].HeaderText = "訂購狀態";
                        dataGridView1.Columns["CUSTOMER_Name"].HeaderText = "客戶姓名";
                        dataGridView1.Columns["Sensor_Id"].HeaderText = "感測器編號";
                        dataGridView1.Columns["Alert_Volume"].HeaderText = "通報門檻";
                        dataGridView1.Columns["SENSOR_Weight"].Visible = false;
                        dataGridView1.Columns["LastOrderTime"].Visible = false;
                        dataGridView1.Columns["CUSTOMER_Sex"].HeaderText = "客戶性別";
                        dataGridView1.Columns["CUSTOMER_PhoneNo"].HeaderText = "客戶電話";
                        dataGridView1.Columns["CUSTOMER_Postal_Code"].HeaderText = "客戶郵遞區號";
                        dataGridView1.Columns["CUSTOMER_Address"].HeaderText = "客戶地址";
                        dataGridView1.Columns["CUSTOMER_HouseTelpNo"].HeaderText = "客戶家用電話";
                        dataGridView1.Columns["CUSTOMER_Email"].HeaderText = "客戶電子郵件";
                        dataGridView1.Columns["CUSTOMER_FamilyMemberId"].HeaderText = "客戶關係家人";
                        dataGridView1.Columns["CUSTOMER_Notes"].HeaderText = "客戶備註";
                        dataGridView1.Columns["CUSTOMER_Registration_Time"].HeaderText = "客戶註冊時間";
                        dataGridView1.Columns["DaysSinceLastOrder"].HeaderText = "已訂購天數";

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
                CustomerPhone.Text = customerPhone;
                CustomerNumber.Text = customerNumber;
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
                string query = $@"
                                SELECT c.*, a.Alert_Volume, sh.SENSOR_Weight, i.Sensor_Id
                                FROM customer c
                                LEFT JOIN iot i ON c.CUSTOMER_Id = i.CUSTOMER_Id
                                LEFT JOIN alert a ON i.Sensor_Id = a.Sensor_Id
                                LEFT JOIN (
                                    SELECT *,
                                        ROW_NUMBER() OVER (PARTITION BY SENSOR_Id ORDER BY SENSOR_Time DESC) AS rn
                                    FROM sensor_history
                                ) sh ON i.Sensor_Id = sh.SENSOR_Id AND sh.rn = 1
                                WHERE c.Company_Id = {GlobalVariables.CompanyId}
                                AND (c.Customer_ID LIKE @Customer_ID OR c.Customer_Name LIKE @Customer_Name OR c.Customer_PhoneNo LIKE @Customer_PhoneNo OR c.Customer_Address LIKE @Customer_Address);";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Customer_ID", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("@Customer_Name", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("@Customer_PhoneNo", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("@Customer_Address", "%" + searchTerm + "%");


                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            table.Columns.Remove("CUSTOMER_Password");
                            table.Columns.Remove("COMPANY_Id");
                            table.Columns.Remove("COMPANY_HistoryID");
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
            customer_form f1 = new customer_form(customerId);
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
                        historyOrder historyOrderForm = new historyOrder();

                        // Pass the historyOrders DataTable to the form
                        historyOrderForm.SetData(historyOrders);

                        // Display the form
                        historyOrderForm.ShowDialog();

                    }
                }
            }
        }

        
        // 操作完要REFRESH一下
        private void RefreshData(object sender, EventArgs e)
        {
            customer_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
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
                                            "CUSTOMER_Email",
                                            "CUSTOMER_FamilyMemberId",
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

                    table.Columns.Remove("CUSTOMER_Password");
                    table.Columns.Remove("COMPANY_Id");
                    table.Columns.Remove("COMPANY_HistoryID");
                    // Columns rename
                    dataGridView1.Columns["CUSTOMER_Id"].HeaderText = "客戶編號";
                    dataGridView1.Columns["CUSTOMER_Name"].HeaderText = "客戶姓名";
                    dataGridView1.Columns["CUSTOMER_Sex"].HeaderText = "客戶性別";
                    dataGridView1.Columns["CUSTOMER_PhoneNo"].HeaderText = "客戶電話";
                    dataGridView1.Columns["CUSTOMER_Postal_Code"].HeaderText = "客戶郵遞區號";
                    dataGridView1.Columns["CUSTOMER_Address"].HeaderText = "客戶地址";
                    dataGridView1.Columns["CUSTOMER_HouseTelpNo"].HeaderText = "客戶家用電話";
                    dataGridView1.Columns["CUSTOMER_Email"].HeaderText = "客戶電子郵件";
                    dataGridView1.Columns["CUSTOMER_FamilyMemberId"].HeaderText = "客戶關係家人";
                    dataGridView1.Columns["CUSTOMER_Notes"].HeaderText = "客戶備註";
                    dataGridView1.Columns["CUSTOMER_Registration_Time"].HeaderText = "客戶註冊時間";

                }
            }
        }
        private void CAddButton_Click(object sender, EventArgs e)
        {
            //開啟基本用戶資料頁面
            //新增一筆資料
            customer_form f1 = new customer_form(null);
            if (f1.ShowDialog() == DialogResult.OK)
            {
                // Perform data refresh or any other required actions after the form is closed
                RefreshData(sender, e);
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
                    RefreshData(sender, e);
                }
            }
            else
            {
                MessageBox.Show("請選擇要編輯的資料行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void AddOrderButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string customerId = dataGridView1.SelectedRows[0].Cells["CUSTOMER_Id"].Value.ToString();

                // Pass the selected ID to the customer_form for editing
                CustomerAddOrder f2 = new CustomerAddOrder(customerId);
                if (f2.ShowDialog() == DialogResult.OK)
                {
                    // Perform data refresh or any other required actions after the form is closed
                    RefreshData(sender, e);
                }
            }
            else
            {
                MessageBox.Show("請選擇要新增訂單的顧客", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // 當前瓦斯量
                object currentGasAmountObject = dataGridView1.Rows[e.RowIndex].Cells["CurrentGasAmount"].Value;
                decimal currentGasAmount = currentGasAmountObject != DBNull.Value ? Convert.ToDecimal(currentGasAmountObject) : 0;

                // 訂單狀態
                object orderStatus = dataGridView1.Rows[e.RowIndex].Cells["OrderStatus"].Value;
                string orderStatusString = orderStatus != null ? orderStatus.ToString() : "";

                // 客戶性別格式化
                if (dataGridView1.Columns[e.ColumnIndex].Name == "CUSTOMER_Sex")
                {
                    if (e.Value != null && e.Value.ToString() == "1")
                    {
                        e.Value = "女";
                    }
                    else if (e.Value != null && e.Value.ToString() == "0")
                    {
                        e.Value = "男";
                    }
                }

                // 檢查訂單狀態和瓦斯量，以決定是否將背景設為黃色
                if (dataGridView1.Columns[e.ColumnIndex].Name == "OrderStatus")
                {
                    if (currentGasAmount < 3 && (orderStatusString == "未訂購" || orderStatusString == "無訂單記錄"))
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
        }
    }
}
