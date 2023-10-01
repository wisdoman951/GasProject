using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gas_Company
{
    public partial class WorkerOrdersForm : Form
    {
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];


        public WorkerOrdersForm()
        {
            InitializeComponent();
            PopulateWorkerOrders();
        }

        private void PopulateWorkerOrders()
        {
            /*string query = "SELECT w.WORKER_Name, COUNT(a.ORDER_Id) AS OrderCount " +
                           "FROM `worker` w " +
                           "LEFT JOIN `assign` a ON w.WORKER_Id = a.WORKER_Id " +
                           $"WHERE w.WORKER_Company_Id = {GlobalVariables.CompanyId} " +
                           "GROUP BY w.WORKER_Name";*/

            string query = "SELECT w.WORKER_Name, COUNT(a.ORDER_Id) AS OrderCount " +
                            "FROM `worker` w " +
                            "LEFT JOIN `assign` a ON w.WORKER_Id = a.WORKER_Id " +
                            "LEFT JOIN `gas_order` go ON a.ORDER_Id = go.order_id " +
                            $"WHERE w.WORKER_Company_Id = {GlobalVariables.CompanyId} AND go.DELIVERY_Condition = 0 " +
                            "GROUP BY w.WORKER_Name";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;

                    // You can customize column headers and formatting here
                    dataGridView1.Columns["WORKER_Name"].HeaderText = "派送人員";
                    dataGridView1.Columns["OrderCount"].HeaderText = "訂單數量";
                }
            }

        }
        public void RefreshData()
        {
            PopulateWorkerOrders(); 

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
