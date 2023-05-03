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
    public partial class Form3 : Form
    {
        private readonly string connectionString = "Server=localhost;Database=new_test;Uid=root;Pwd=mysqlyu229";

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
            string Employee_Name = txtName.Text;
            string Phone = txtPhone.Text;
            string City = txtCity.Text;
            string District = txtDistrict.Text;
            string Address = txtAddress.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtPassword2.Text;

            if (string.IsNullOrEmpty(Employee_Name) || string.IsNullOrEmpty(Phone) ||
                string.IsNullOrEmpty(City) || string.IsNullOrEmpty(District) || string.IsNullOrEmpty(Address) ||
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

            int Employee_ID;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"INSERT INTO company_employee (Employee_Name, Employee_Phone,Employee_City, Employee_District, Employee_Address, Registered_at)
                            VALUES (@Employee_Name, @Employee_Phone, @Employee_City, @Employee_District, @Employee_Address, @Registered_at);
                            SELECT LAST_INSERT_ID();";
                cmd.Parameters.AddWithValue("@Employee_Name", Employee_Name);
                cmd.Parameters.AddWithValue("@Employee_Phone", Phone);
                cmd.Parameters.AddWithValue("@Employee_City", City);
                cmd.Parameters.AddWithValue("@Employee_District", District);
                cmd.Parameters.AddWithValue("@Employee_Address", Address);
                cmd.Parameters.AddWithValue("@Registered_at", DateTime.Now);
                Employee_ID = Convert.ToInt32(cmd.ExecuteScalar());
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"INSERT INTO Employee_account (Employee_ID, Email, Password)
                            VALUES (@Employee_ID, @Email, @Password);";
                cmd.Parameters.AddWithValue("@Employee_ID", Employee_ID);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("註冊成功！");
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
