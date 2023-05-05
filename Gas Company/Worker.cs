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
    public partial class Worker : Form
    {
        public Worker()
        {
            InitializeComponent();
        }
        private void EmployeeAddButton_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;password=89010607;database=new_test;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string insertQuery = "INSERT INTO worker (Coustomer_ID,Coustomer_Name,Coustomer_Sex,Coustomer_Phone,Coustomer_HouseTel,Coustomer_Email,Coustomer_City,Coustomer_District,Coustomer_Address,Coustomer_FamilyMember_ID,Company_ID,Registered_at) VALUES (@Coustomer_ID,@Coustomer_Name,@Coustomer_Sex,@Coustomer_Phone,@Coustomer_HouseTel,@Coustomer_Email,@Coustomer_City,@Coustomer_District,@Coustomer_Address,@Coustomer_FamilyMember_ID,Company_ID,NOW())";

                // 5/5 name changing here
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Coustomer_ID", WorkerID.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Phone", WorkerPhone.Text);
                cmd.Parameters.AddWithValue("@Coustomer_HouseTel", WorkerTele.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Email", WorkerEmail.Text);
                cmd.Parameters.AddWithValue("@Coustomer_City", WorkerCity.Text);
                cmd.Parameters.AddWithValue("@Coustomer_District", WorkerDistrict.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Address", WorkerAddress.Text);
                //cmd.Parameters.AddWithValue("@Coustomer_Name", EmployeeSex.Text);
                //cmd.Parameters.AddWithValue("@Coustomer_FamilyMember_ID", family.Text);
                //cmd.Parameters.AddWithValue("@Company_ID", company.Text);
                //cmd.Parameters.AddWithValue("@Coustomer_Sex", sex.Text);
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
