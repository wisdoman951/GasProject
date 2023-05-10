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
            string query = "SELECT * FROM `coustomer`";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    CustomerField.DataSource = table;

                    // You can check each column's name here
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.WriteLine(column.ColumnName);
                    }

                }
            }
        }


        private void CustomerField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = CustomerField.Rows[e.RowIndex];

                // Access the data in the selected row and autofill other fields in the form
                string customerName = selectedRow.Cells["Coustomer_Name"].Value.ToString();
                string customerSex = selectedRow.Cells["Coustomer_Sex"].Value.ToString();
                string customerPhone = selectedRow.Cells["Coustomer_Phone"].Value.ToString();
                string customerNumber = selectedRow.Cells["Coustomer_HouseTel"].Value.ToString();
                string customerEmail = selectedRow.Cells["Coustomer_Email"].Value.ToString();
                string customerCity = selectedRow.Cells["Coustomer_City"].Value.ToString();
                string customerDistrict = selectedRow.Cells["Coustomer_District"].Value.ToString();
                string customerAddress = selectedRow.Cells["Coustomer_Address"].Value.ToString();

                // Retrieve other fields as needed

                // Autofill the other fields(Textbox) in the form
                CustomerName.Text = customerName;
                CustomerSex.Text = customerSex;
                CustomerPhone.Text = customerPhone;
                CustomerNumber.Text = customerNumber;
                CustomerEmail.Text = customerEmail;
                CustomerCity.Text = customerCity;
                CustomerDistrict.Text = customerDistrict;
                CustomerAddress.Text = customerAddress;
            }
        }

        private void CSearchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                string query = "SELECT * FROM `coustomer` WHERE Coustomer_ID LIKE @Coustomer_ID OR Coustomer_Name LIKE @Coustomer_Name OR Coustomer_Phone LIKE @Coustomer_Phone OR Coustomer_City LIKE @Coustomer_City";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Coustomer_ID", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("@Coustomer_Name", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("@Coustomer_Phone", "%" + searchTerm + "%");
                        command.Parameters.AddWithValue("@Coustomer_City", "%" + searchTerm + "%");

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
                                CustomerField.DataSource = table;
                            }
                        }
                    }
                }
            }
        }

        private void CDeleteButton_Click(object sender, EventArgs e)
        {
            if (CustomerField.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定删除此行資料？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string id = CustomerField.SelectedRows[0].Cells[0].Value.ToString();
                    string query = "DELETE FROM `coustomer` WHERE `ID` = @ID";
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ID", id);
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            connection.Close();
                            if (rowsAffected > 0)
                            {
                                CustomerField.Rows.RemoveAt(CustomerField.SelectedRows[0].Index);
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
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM coustomer", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                CustomerField.DataSource = dt;
                conn.Close();
            }
        }

        private void CAddButton_Click(object sender, EventArgs e)
        {
            /*string connStr = ConfigurationManager.AppSettings["ConnectionString"];
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                //string insertQuery = "INSERT INTO coustomer (Coustomer_ID,Coustomer_Name,Coustomer_Sex,Coustomer_Phone,Coustomer_HouseTel,Coustomer_Email,Coustomer_City,Coustomer_District,Coustomer_Address,Coustomer_FamilyMember_ID,Company_ID,Registered_at) " +
                //    "VALUES (@Coustomer_ID,@Coustomer_Name,@Coustomer_Sex,@Coustomer_Phone,@Coustomer_HouseTel,@Coustomer_Email,@Coustomer_City,@Coustomer_District,@Coustomer_Address,@Coustomer_FamilyMember_ID,Company_ID,NOW())";
                string insertQuery = "INSERT INTO coustomer Coustomer_Name,Coustomer_Sex,Coustomer_Phone,Coustomer_HouseTel,Coustomer_Email,Coustomer_City,Coustomer_District,Coustomer_Address,Coustomer_FamilyMember_ID,Company_ID,Registered_at) " +
                    "VALUES (@Coustomer_Name,@Coustomer_Sex,@Coustomer_Phone,@Coustomer_HouseTel,@Coustomer_Email,@Coustomer_City,@Coustomer_District,@Coustomer_Address,@Coustomer_FamilyMember_ID,Company_ID,NOW())";

                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                //cmd.Parameters.AddWithValue("@Coustomer_ID", CustomerName.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Name", CustomerName.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Sex", CustomerSex.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Phone", CustomerPhone.Text);
                cmd.Parameters.AddWithValue("@Coustomer_HouseTel", CustomerNumber.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Email", CustomerEmail.Text);
                cmd.Parameters.AddWithValue("@Coustomer_City", CustomerCity.Text);
                cmd.Parameters.AddWithValue("@Coustomer_District", CustomerDistrict.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Address", CustomerAddress.Text);
                //cmd.Parameters.AddWithValue("@Coustomer_FamilyMember_ID", family.Text);
                //cmd.Parameters.AddWithValue("@Company_ID", company.Text);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("登錄成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("登錄失敗！");
                }
            }*/
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void CustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
