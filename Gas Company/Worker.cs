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
        private int originalPermission;

        public Worker()
        {
            InitializeComponent();
        }
        private void Worker_Load(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM `worker` WHERE WORKER_Company_Id = {GlobalVariables.CompanyId}";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    // Columns rename
                    dataGridView1.Columns["WORKER_Id"].HeaderText = "員工編號";
                    dataGridView1.Columns["WORKER_Name"].HeaderText = "員工姓名";
                    dataGridView1.Columns["WORKER_Sex"].HeaderText = "員工性別";
                    dataGridView1.Columns["WORKER_PhoneNum"].HeaderText = "員工電話";
                    dataGridView1.Columns["WORKER_HouseTelpNo"].HeaderText = "員工家用電話";
                    dataGridView1.Columns["WORKER_Address"].HeaderText = "員工地址";
                    dataGridView1.Columns["WORKER_Password"].HeaderText = "員工密碼";
                    dataGridView1.Columns["WORKER_Email"].HeaderText = "員工電子郵件";
                    dataGridView1.Columns["Permission"].HeaderText = "員工權限";
                    dataGridView1.Columns["WORKER_Company_Id"].HeaderText = "員工所屬公司";
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PermissionValue.SelectedIndexChanged -= PermissionValue_SelectedIndexChanged;

                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Access the data in the selected row and autofill other fields in the form
                string workerId = selectedRow.Cells["WORKER_Id"].Value.ToString();
                string workerName = selectedRow.Cells["WORKER_Name"].Value.ToString();
                string workerSex = selectedRow.Cells["WORKER_Sex"].Value.ToString();
                string workerPhoneNo = selectedRow.Cells["WORKER_PhoneNum"].Value.ToString();
                string workerTelpNo = selectedRow.Cells["WORKER_HouseTelpNo"].Value.ToString();
                string workerEmail = selectedRow.Cells["WORKER_Email"].Value.ToString();
                string workerAddress = selectedRow.Cells["WORKER_Address"].Value.ToString();
                string workerPermission = selectedRow.Cells["Permission"].Value.ToString();
                string workerNote = selectedRow.Cells["Worker_Notes"].Value.ToString();

                // Autofill the other fields(Textbox) in the form
                WorkerID.Text = workerId;
                WorkerName.Text = workerName;
                WorkerPhone.Text = workerPhoneNo;
                WorkerTele.Text = workerTelpNo;
                WorkerEmail.Text = workerEmail;
                WorkerAddress.Text = workerAddress;
                PermissionValue.Text = workerPermission;
                WorkerNote.Text = workerNote;

                originalPermission = Convert.ToInt32(workerPermission);
                PermissionValue.SelectedIndexChanged += PermissionValue_SelectedIndexChanged;

            }
        }

        private void WorkerDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定删除此行資料？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string workerId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string query = "DELETE FROM `worker` WHERE `WORKER_Id` = @WORKER_Id";
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@WORKER_Id", workerId);
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

        private void PermissionValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected value from the combobox
            int selectedPermission = Convert.ToInt32(PermissionValue.SelectedItem);

            if (selectedPermission != originalPermission)
            {
                // Display a confirmation message box
                DialogResult result = MessageBox.Show("確認變更帳號權限?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Update the permission in the database
                    UpdatePermission(selectedPermission);
                }
                else
                {
                    // Reset the combobox selection to the original value
                    PermissionValue.SelectedItem = originalPermission;
                }
            }
        }
        private void UpdatePermission(int permission)
        {
            // Assuming you have the worker ID stored in a variable named "workerId"

            // Update the permission in the database
            string updateQuery = "UPDATE worker SET Permission = @Permission WHERE WORKER_Id = @WorkerId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Permission", permission);
                    cmd.Parameters.AddWithValue("@WorkerId", WorkerID.Text);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("權限變更成功", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {

            WorkerID.Text = "";
            WorkerName.Text = "";
            WorkerPhone.Text = "";
            WorkerTele.Text = "";
            WorkerEmail.Text = "";
            WorkerAddress.Text = "";
            PermissionValue.Text = "";
            WorkerNote.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                string query = $"SELECT * FROM `worker` WHERE Customer_ID LIKE @Customer_ID OR Customer_Name LIKE @Customer_Name OR Customer_PhoneNo LIKE @Customer_PhoneNo WHERE WORKER_Company_Id = {GlobalVariables.CompanyId}";

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

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Worker_Load(sender, e);
        }

        private void WorkerAddButton_Click(object sender, EventArgs e)
        {
            //開啟基本用戶資料頁面
            //新增一筆資料
            WorkerManage f1 = new WorkerManage(null);
            if (f1.ShowDialog() == DialogResult.OK)
            {
                // Perform data refresh or any other required actions after the form is closed
                Worker_Load(sender, e);
            }
        }

        private void WorkerEditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells["WORKER_Id"].Value.ToString();

                // Pass the selected ID to the customer_form for editing
                WorkerManage f1 = new WorkerManage(id);
                if (f1.ShowDialog() == DialogResult.OK)
                {
                    // Perform data refresh or any other required actions after the form is closed
                    Worker_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show("請選擇要編輯的資料行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
