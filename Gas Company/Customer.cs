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

namespace Gas_Company
{
    public partial class Customer : Form
    {
        private readonly string connectionString = "Server=localhost;Database=new_test;Uid=root;Pwd=89010607";

        public Customer()
        {
            InitializeComponent();
        }

        private void customer_Load(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
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
                                dataGridView1.DataSource = table;
                            }
                        }
                    }
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定删除此行資料？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
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

        private void button14_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM coustomer", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;password=mysqlyu229;database=new_test;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string insertQuery = "INSERT INTO coustomer (Coustomer_ID,Coustomer_Name,Coustomer_Sex,Coustomer_Phone,Coustomer_HouseTel,Coustomer_Email,Coustomer_City,Coustomer_District,Coustomer_Address,Coustomer_FamilyMember_ID,Company_ID,Registered_at) VALUES (@Coustomer_ID,@Coustomer_Name,@Coustomer_Sex,@Coustomer_Phone,@Coustomer_HouseTel,@Coustomer_Email,@Coustomer_City,@Coustomer_District,@Coustomer_Address,@Coustomer_FamilyMember_ID,Company_ID,NOW())";

                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Coustomer_ID", Uname.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Name", sex.Text);
                //cmd.Parameters.AddWithValue("@Coustomer_Sex", sex.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Phone", phone.Text);
                cmd.Parameters.AddWithValue("@Coustomer_HouseTel", tel.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Email", email.Text);
                cmd.Parameters.AddWithValue("@Coustomer_City", city.Text);
                cmd.Parameters.AddWithValue("@Coustomer_District", district.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Address", address.Text);
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
            }
        }
    }
}
