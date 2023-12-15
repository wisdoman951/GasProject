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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Gas_Company
{
    public partial class Form3 : Form
    {
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public Form3()
        {
            InitializeComponent();
        }


        private void label8_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            string employee_Name = txtName.Text;
            string phone = txtPhone.Text;
            string city = txtCity.Text;
            string district = txtDistrict.Text;
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtPassword2.Text;

            if (string.IsNullOrEmpty(employee_Name) || string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(city) || string.IsNullOrEmpty(district) || string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("所有欄位皆為必填。");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("密碼和確認密碼不相符。");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert into manager_account table
                    cmd.CommandText = @"INSERT INTO manager_account (MANAGER_Name, MANAGER_PhoneNo, MANAGER_Email, MANAGER_City, MANAGER_District, MANAGER_Address, MANAGER_Password, Register_at)
                VALUES (@MANAGER_Name, @MANAGER_PhoneNo, @MANAGER_Email, @MANAGER_City, @MANAGER_District, @MANAGER_Address, @MANAGER_Password, @Register_at);
                SELECT LAST_INSERT_ID();";
                    cmd.Parameters.AddWithValue("@MANAGER_Name", employee_Name);
                    cmd.Parameters.AddWithValue("@MANAGER_PhoneNo", phone);
                    cmd.Parameters.AddWithValue("@MANAGER_Email", email);
                    cmd.Parameters.AddWithValue("@MANAGER_City", city);
                    cmd.Parameters.AddWithValue("@MANAGER_District", district);
                    cmd.Parameters.AddWithValue("@MANAGER_Address", address);
                    cmd.Parameters.AddWithValue("@MANAGER_Password", password);
                    cmd.Parameters.AddWithValue("@Register_at", DateTime.Now);
                    int managerId = Convert.ToInt32(cmd.ExecuteScalar()); // Get the last insert ID

                    // Insert into company table
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"INSERT INTO company (COMPANY_Name, COMPANY_Phone_No, COMPANY_City, COMPANY_District, COMPANY_Address, COMPANY_Text_Id, COMPANY_Registration_Time)
                VALUES (@COMPANY_Name, @COMPANY_Phone_No, @COMPANY_City, @COMPANY_District, @COMPANY_Address, @COMPANY_Text_Id, @COMPANY_Registration_Time)";
                    cmd.Parameters.AddWithValue("@COMPANY_Name", employee_Name);
                    cmd.Parameters.AddWithValue("@COMPANY_Phone_No", phone);
                    cmd.Parameters.AddWithValue("@COMPANY_City", city);
                    cmd.Parameters.AddWithValue("@COMPANY_District", district);
                    cmd.Parameters.AddWithValue("@COMPANY_Address", address);
                    cmd.Parameters.AddWithValue("@COMPANY_Text_Id", managerId); // Use manager ID as COMPANY_Text_Id
                    cmd.Parameters.AddWithValue("@COMPANY_Registration_Time", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("註冊成功！");
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

    }
}
