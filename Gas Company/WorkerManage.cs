using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gas_Company
{
    public partial class WorkerManage : Form
    {
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        private string workerId;

        public WorkerManage(string id)
        {
            InitializeComponent();
            workerId = id;

        }
        private void WorkerManage_Load(object sender, EventArgs e)
        {
            if (workerId != null)
            {
                // Editing an existing worker
                Console.WriteLine($"WorkerId: {workerId}"); // Log the value of workerId
                LoadWorkerData();
                Text = "編輯員工";
            }
            else
            {
                // Adding a new worker
                Console.WriteLine("WorkerId is null"); // Log a message indicating workerId is null
                Text = "新增員工";
            }
        }

        private void LoadWorkerData()
        {
            string query = $"SELECT * FROM `worker` WHERE WORKER_Id = @WorkerId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@WorkerId", workerId);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Access the data from the reader and set the values in the form controls
                            WorkerName.Text = reader.GetString("WORKER_Name");
                            WorkerSex.Text = reader.GetString("WORKER_Sex");
                            WorkerPhoneNum.Text = reader.GetString("WORKER_PhoneNum");
                            WorkerHouseTelpNo.Text = reader.GetString("WORKER_HouseTelpNo");
                            WorkerEmail.Text = reader.GetString("WORKER_Email");
                            WorkerPassword.Text = reader.GetString("WORKER_Password");
                            WorkerAddress.Text = reader.GetString("WORKER_Address");
                            WorkerPermission.Text = reader.GetInt32("Permission").ToString();
                            WorkerNote.Text = reader.GetString("WORKER_Notes");
                        }
                    }

                    connection.Close();
                }
            }
        }

        private void ComfirmButton_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlCommand cmd;

                if (!string.IsNullOrEmpty(workerId))
                {
                    // Editing an existing worker
                    string updateQuery = "UPDATE worker SET " +
                                            "WORKER_Name = @WORKER_Name, " +
                                            "WORKER_PhoneNum = @WORKER_PhoneNum, " +
                                            "WORKER_HouseTelpNo = @WORKER_HouseTelpNo, " +
                                            "WORKER_Email = @WORKER_Email, " +
                                            "WORKER_Address = @WORKER_Address, " +
                                            "Permission = @Permission, " +
                                            "WORKER_Notes = @WORKER_Notes " +
                                            "WHERE WORKER_Id = @WorkerId";

                    cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@WorkerId", workerId);
                }
                else
                {
                    // Adding a new worker
                    string insertQuery = "INSERT INTO worker " +
                                            "(WORKER_Name, WORKER_PhoneNum, WORKER_HouseTelpNo, WORKER_Email, WORKER_Address, Permission, Registered_at, WORKER_Notes) " +
                                            "VALUES (@WORKER_Name, @WORKER_PhoneNum, @WORKER_HouseTelpNo, @WORKER_Email, @WORKER_Address, @Permission, NOW(), @Worker_Notes)";

                    cmd = new MySqlCommand(insertQuery, conn);
                }

                cmd.Parameters.AddWithValue("@WORKER_Name", WorkerName.Text);
                cmd.Parameters.AddWithValue("@WORKER_PhoneNum", WorkerPhoneNum.Text);
                cmd.Parameters.AddWithValue("@WORKER_HouseTelpNo", WorkerHouseTelpNo.Text);
                cmd.Parameters.AddWithValue("@WORKER_Email", WorkerEmail.Text);
                cmd.Parameters.AddWithValue("@WORKER_Address", WorkerAddress.Text);
                cmd.Parameters.AddWithValue("@Permission", WorkerPermission.Text);
                cmd.Parameters.AddWithValue("@Worker_Notes", WorkerNote.Text);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("保存成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("保存失敗！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
