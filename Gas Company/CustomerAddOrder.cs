using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gas_Company
{
    public partial class CustomerAddOrder : Form
    {
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public CustomerAddOrder()
        {
            InitializeComponent();
        }

        public CustomerAddOrder(string customerId)
        {
            InitializeComponent();
            CustomerId = customerId;
            Console.WriteLine(CustomerId);
            PopulateDeliveryManComboBox();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT o.ORDER_Id, o.CUSTOMER_Id, o.Expect_Time, c.CUSTOMER_PhoneNo, o.DELIVERY_Address, o.Delivery_Time, c.CUSTOMER_Name, od.Order_type, od.Order_weight, o.Gas_Quantity, ca.Gas_Volume
                                FROM `gas_order` o
                                JOIN `customer` c ON o.CUSTOMER_Id = c.CUSTOMER_Id
                                JOIN `gas_order_detail` od ON o.ORDER_Id = od.Order_ID
                                JOIN `customer_accumulation` ca ON o.CUSTOMER_Id = ca.Customer_Id
                                WHERE o.COMPANY_Id = @CompanyId
                                AND o.DELIVERY_Condition = 1
                                AND o.CUSTOMER_Id = @CustomerId
                                ORDER BY o.Delivery_Time DESC
                                LIMIT 1;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyId", GlobalVariables.CompanyId);
                    command.Parameters.AddWithValue("@CustomerId", CustomerId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CustomerName.Text = reader["CUSTOMER_Name"].ToString();
                            CustomerPhone.Text = reader["Customer_PhoneNo"].ToString();
                            DeliveryAddress.Text = reader["DELIVERY_Address"].ToString();
                            GasType.Text = reader["Order_type"].ToString();
                            GasWeight.Text = reader["Order_weight"].ToString();
                            GasQuantity.Text = reader["Gas_Quantity"].ToString();
                            GasVolume.Text = reader["Gas_Volume"].ToString();
                        }
                    }
                }
                PopulateDeliveryManComboBox();
                InitializeDeliveryTimePicker();
            }
        }
        List<string> deliveryTimeIntervals = new List<string>
        {
            "08:00", "10:00", "12:00", "14:00", "16:00", "18:00", "20:00"
        };
        private void InitializeDeliveryTimePicker()
        {
            // Set the format and custom format for the DateTimePicker
            DeliveryTimePicker.Format = DateTimePickerFormat.Custom;
            DeliveryTimePicker.CustomFormat = "yyyy-MM-dd";

            // Populate the intervals into a ComboBox or any other control for user selection
            IntervalComboBox.DataSource = deliveryTimeIntervals;
        }
        public string CustomerId { get; }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = CustomerPhone.Text;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string fetchQuery = @"SELECT *
                                  FROM gas_order
                                  WHERE DELIVERY_Phone = @searchTerm
                                  AND DELIVERY_Condition = 1
                                  ORDER BY DELIVERY_Time DESC
                                  LIMIT 1";

                    using (MySqlCommand fetchCommand = new MySqlCommand(fetchQuery, connection))
                    {
                        fetchCommand.Parameters.AddWithValue("@searchTerm", searchTerm);
                        using (MySqlDataReader reader = fetchCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int customerId = reader.GetInt32("CUSTOMER_Id");
                                int companyId = reader.GetInt32("COMPANY_Id");
                                string deliveryCondition = reader.GetString("DELIVERY_Condition");
                                string deliveryAddress = reader.GetString("DELIVERY_Address");
                                string deliveryPhone = reader.GetString("DELIVERY_Phone");

                                string selectedDate = DeliveryTimePicker.Value.ToString("yyyy-MM-dd");
                                string selectedTime = IntervalComboBox.SelectedItem.ToString();
                                string selectedDeliveryTime = $"{selectedDate} {selectedTime}";


                                //下面桶資訊先不要從歷史資訊抓然後插入，顧客可能想改
                                //int gasQuantity = reader.GetInt32("Gas_Quantity");
                                string gasQuantity = GasQuantity.Text;
                                //int orderQuantity = reader.GetInt32("Order_Quantity");
                                string orderQuantity = GasQuantity.Text;
                                //string orderType = reader.GetString("Order_type");
                                string orderType = GasType.Text;
                                //int orderWeight = reader.GetInt32("Order_weight");
                                string orderWeight = GasWeight.Text;
                                string exchange = reader.GetString("Exchange");
                                reader.Close();

                                // Step 3: Construct and execute the insert statements
                                string insertOrderQuery = @"INSERT INTO gas_order
                                                    (CUSTOMER_Id, COMPANY_Id, DELIVERY_Condition, Exchange, DELIVERY_Address, DELIVERY_Phone, Gas_Quantity, Order_Time, EXPECT_Time, Delivery_Method)
                                                    VALUES
                                                    (@customerId, @companyId, @deliveryCondition, @exchange, @deliveryAddress, @deliveryPhone, @gasQuantity, NOW(), @expTime, @deliveryMethod)";

                                using (MySqlCommand insertOrderCommand = new MySqlCommand(insertOrderQuery, connection))
                                {
                                    // Bind parameters for the insert statement
                                    insertOrderCommand.Parameters.AddWithValue("@customerId", customerId);
                                    insertOrderCommand.Parameters.AddWithValue("@companyId", companyId);
                                    insertOrderCommand.Parameters.AddWithValue("@deliveryCondition", 0);
                                    insertOrderCommand.Parameters.AddWithValue("@deliveryAddress", deliveryAddress);
                                    insertOrderCommand.Parameters.AddWithValue("@expTime", selectedDeliveryTime);
                                    insertOrderCommand.Parameters.AddWithValue("@deliveryPhone", deliveryPhone);
                                    insertOrderCommand.Parameters.AddWithValue("@gasQuantity", gasQuantity);
                                    insertOrderCommand.Parameters.AddWithValue("@exchange", exchange);
                                    insertOrderCommand.Parameters.AddWithValue("@selectedDeliveryTime", selectedDeliveryTime);
                                    insertOrderCommand.Parameters.AddWithValue("@deliveryMethod", 1);

                                    // Execute the insert statement for gas_order
                                    int rowsAffected = insertOrderCommand.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        // The row was successfully inserted
                                        MessageBox.Show("成功加入訂單", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        // Get the generated ORDER_Id value
                                        long orderId = insertOrderCommand.LastInsertedId;

                                        // Use the orderId variable to insert into gas_order_detail table
                                        string insertOrderDetailQuery = @"INSERT INTO gas_order_detail
                                                                  (Order_ID, Order_Quantity, Order_type, Order_weight)
                                                                  VALUES
                                                                  (@orderId, @orderQuantity, @orderType, @orderWeight)";

                                        using (MySqlCommand insertOrderDetailCommand = new MySqlCommand(insertOrderDetailQuery, connection))
                                        {
                                            // Bind parameters for the insert statement
                                            insertOrderDetailCommand.Parameters.AddWithValue("@orderId", orderId);
                                            insertOrderDetailCommand.Parameters.AddWithValue("@orderQuantity", orderQuantity);
                                            insertOrderDetailCommand.Parameters.AddWithValue("@orderType", orderType);
                                            insertOrderDetailCommand.Parameters.AddWithValue("@orderWeight", orderWeight);

                                            // Execute the insert statement for gas_order_detail
                                            insertOrderDetailCommand.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        // Handle case when the row insertion failed
                                        MessageBox.Show("訂單新增失敗", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                // Handle case when no matching data is found
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
        }
        // 工人下拉式選單
        private void PopulateDeliveryManComboBox()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT WORKER_Name FROM worker WHERE WORKER_Company_Id = {GlobalVariables.CompanyId}";

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
        private void IntervalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the delivery time based on the selected interval
            string selectedInterval = IntervalComboBox.SelectedItem.ToString();
            DateTime selectedTime = DateTime.ParseExact(selectedInterval, "HH:mm", CultureInfo.InvariantCulture);

            // Set the selected time to the DateTimePicker control
            DeliveryTimePicker.Value = selectedTime;
        }
    }
}
