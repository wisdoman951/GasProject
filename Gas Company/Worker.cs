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
    public partial class Worker : Form
    {
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public Worker()
        {
            InitializeComponent();
        }


        //// Insert Employee
        private void EmployeeAddButton_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string insertQuery = "INSERT INTO worker " +
                                     "(WORKER_Id, WORKER_Name,WORKER_PhoneNum, WORKER_HouseTelpNo, WORKER_Email, WORKER_Address, Permission, Registered_at) " +
                                     "VALUES (LAST_INSERT_ID(), @WORKER_Name, @WORKER_PhoneNum, @WORKER_HouseTelpNo, @WORKER_Email, @WORKER_Address, @Permission, NOW())";

                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@WORKER_Name", WorkerName.Text);
                cmd.Parameters.AddWithValue("@WORKER_PhoneNum", WorkerPhone.Text);
                cmd.Parameters.AddWithValue("@WORKER_HouseTelpNo", WorkerTele.Text);
                cmd.Parameters.AddWithValue("@WORKER_Email", WorkerEmail.Text);
                cmd.Parameters.AddWithValue("@WORKER_Address", WorkerAddress.Text);
                cmd.Parameters.AddWithValue("@Permission", PermissionValue.Text);

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

        private void Worker_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM `worker`";

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
