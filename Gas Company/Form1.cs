using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gas_Company
{
    public partial class Form1 : Form
    {
        //private readonly string connectionString = "Server=localhost;Database=new_test;Uid=root;Pwd=88888888";
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("請輸入帳號密碼");
                return;
            }

            
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                Console.WriteLine("POWJETRPOIAJW4MTGWP039846MUP9B8W3P6498NBW3P94TNPB9384UTB");

                Console.WriteLine(connectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT Employee_ID FROM employee_account WHERE Email = @Email AND Password = @Password;";
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    int Employee_ID = Convert.ToInt32(result);
                    MessageBox.Show($"{Employee_ID} 登入成功！");
                    Form2 mainForm = new Form2();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("帳號或密碼錯誤。");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 mainForm = new Form3();
            mainForm.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
