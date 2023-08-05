using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gas_Company
{
    public partial class residual_gas : Form
    {
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        private ResidualChangeWindow f1; // Declare f1 as a class-level variable

        public residual_gas()
        {
            InitializeComponent();
        }

        private void residual_gas_Load(object sender, EventArgs e)
        {
            string query = $"SELECT ca.Accum_Id, c.Customer_Id, c.Customer_Address, c.Customer_Name, ca.Gas_Volume, c.Customer_PhoneNo FROM customer_accumulation ca JOIN customer c ON ca.Customer_Id = c.Customer_Id WHERE ca.Company_Id = {GlobalVariables.CompanyId};";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;

                    // Columns rename
                    dataGridView1.Columns["Accum_Id"].HeaderText = "累積編號";
                    dataGridView1.Columns["Customer_Id"].HeaderText = "顧客編號";
                    dataGridView1.Columns["Customer_Name"].HeaderText = "顧客姓名";
                    dataGridView1.Columns["Customer_Address"].HeaderText = "顧客地址";
                    dataGridView1.Columns["Customer_PhoneNo"].HeaderText = "顧客電話";
                    dataGridView1.Columns["Gas_Volume"].HeaderText = "殘氣量";
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Access the data in the selected row and autofill other fields in the form
                string accumId = selectedRow.Cells["Accum_Id"].Value.ToString();
                string customerName = selectedRow.Cells["Customer_Name"].Value.ToString();
                string gasVolume = selectedRow.Cells["Gas_Volume"].Value.ToString();
                string customerPhone = selectedRow.Cells["Customer_PhoneNo"].Value.ToString();

                // Autofill the other fields (TextBox) in the form
                AccResidual.Text = gasVolume;
                CustomerID.Text = accumId;
                CustomerName.Text = customerName;
                CustomerPhone.Text = customerPhone;
            }
        }


        private void edit_Click_1(object sender, EventArgs e)
        {// Check if a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Access the data in the selected row
                string accumId = selectedRow.Cells["Accum_Id"].Value.ToString();
                string customerName = selectedRow.Cells["Customer_Name"].Value.ToString();
                string gasVolume = selectedRow.Cells["Gas_Volume"].Value.ToString();
                string customerPhone = selectedRow.Cells["Customer_PhoneNo"].Value.ToString();

                // Pass the data to the ResidualChangeWindow form
                f1 = new ResidualChangeWindow(accumId, customerName, gasVolume, customerPhone);
                f1.Show();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.");
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            residual_gas_Load(sender, e);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = txt.Text;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                string query = "SELECT ca.Accum_Id, c.Customer_Id, c.Customer_Address, c.Customer_Name, ca.Gas_Volume, c.Customer_PhoneNo FROM customer_accumulation ca JOIN customer c ON ca.Customer_Id = c.Customer_Id " +
                        "WHERE c.Customer_PhoneNo LIKE @Customer_PhoneNo;";


                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
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
    }
}
