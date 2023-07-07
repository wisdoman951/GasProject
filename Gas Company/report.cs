using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gas_Company
{
    public partial class report : Form
    {
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {
            // Fetch today's order and display the total in label3
            FetchTodaysOrder();

            // Fetch today's unfinished order and display in label7
            FetchTodaysUnfinishedOrder();

            // Fetch today's working labor count and display in label8
            FetchTodaysWorkingLabor();

            // Fetch the count of finished orders this month and display in label9
            FetchMonthlyCompletedOrder();

            // Fetch today's total gas quantity and display in label10
            FetchTodaysTotalGasQuantity();
        }

        private void FetchTodaysOrder()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM gas_order WHERE DATE(Order_Time) = CURDATE()", connection);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int todayOrderCount = Convert.ToInt32(result);
                    label3.Text = todayOrderCount.ToString();
                }
                connection.Close();
            }
        }

        private void FetchTodaysUnfinishedOrder()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM gas_order WHERE DATE(Order_Time) = CURDATE() AND DELIVERY_Condition != 'Completed'", connection);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int todayUnfinishedOrderCount = Convert.ToInt32(result);
                    label7.Text = todayUnfinishedOrderCount.ToString();
                }
                connection.Close();
            }
        }
        // 未完成(今日工人量)
        /*private void FetchTodaysWorkingLabor()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM gas_order WHERE DATE(Order_Time) = CURDATE() AND DELIVERY_Condition != 'Completed'", connection);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int todayUnfinishedOrderCount = Convert.ToInt32(result);
                    label7.Text = todayUnfinishedOrderCount.ToString();
                }
                connection.Close();
            }
        }*/
        // 未完成(本月以完成訂單)
        private void FetchMonthlyCompletedOrder()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM gas_order WHERE DELIVERY_Condition = 'Finished' AND MONTH(Order_Time) = MONTH(CURDATE())", connection);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int monthlyCompletedOrderCount = Convert.ToInt32(result);
                    label9.Text = monthlyCompletedOrderCount.ToString();
                }
                connection.Close();
            }
        }


        private void FetchTodaysTotalGasQuantity()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT SUM(Gas_Quantity) FROM gas_order WHERE DATE(Order_Time) = CURDATE()", connection);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    decimal todayTotalGasQuantity = Convert.ToDecimal(result);
                    label10.Text = todayTotalGasQuantity.ToString();
                }
                connection.Close();
            }
        }
    }
}
