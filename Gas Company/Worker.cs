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
                    "(WORKER_Id, WORKER_Name, WORKER_PhoneNum, WORKER_HouseTelpNo, WORKER_Email, WORKER_City ,WORKER_Address, Registered_at) " +
                    "VALUES (@WORKER_Id, @WORKER_Name, @WORKER_PhoneNum, @WORKER_HouseTelpNo, @WORKER_Email, @WORKER_City, @WORKER_Address, NOW())";

                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Worker_ID", WorkerID.Text);
                cmd.Parameters.AddWithValue("@Worker_Name", WorkerName.Text);
                cmd.Parameters.AddWithValue("@Worker_PhoneNum", WorkerPhone.Text);
                cmd.Parameters.AddWithValue("@Worker_HouseTelpNo", WorkerTele.Text);
                cmd.Parameters.AddWithValue("@Worker_Email", WorkerEmail.Text);
                cmd.Parameters.AddWithValue("@Worker_City", WorkerCity.Text);
                cmd.Parameters.AddWithValue("@Worker_District", WorkerDistrict.Text);
                cmd.Parameters.AddWithValue("@Worker_Address", WorkerAddress.Text);
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
}
