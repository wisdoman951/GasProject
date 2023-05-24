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

namespace Gas_System
{
    public partial class coustomer : Form
    {
        

        public coustomer()
        {
            InitializeComponent();
        }

        private void coustomer_Load(object sender, EventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //連接資料庫
            string connStr = ConfigurationManager.AppSettings["ConnectionString"]; ;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                //新增一筆資料
                string insertQuery = "INSERT INTO coustomer (Coustomer_ID,Coustomer_Name,Coustomer_Sex,Coustomer_Phone,Coustomer_HouseTel,Coustomer_Email,Coustomer_City,Coustomer_District,Coustomer_Address,Coustomer_FamilyMember_ID,Company_ID,Registered_at) VALUES (@Coustomer_ID,@Coustomer_Name,@Coustomer_Sex,@Coustomer_Phone,@Coustomer_HouseTel,@Coustomer_Email,@Coustomer_City,@Coustomer_District,@Coustomer_Address,@Coustomer_FamilyMember_ID,Company_ID,NOW())";

                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Coustomer_ID", number.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Name", Uname.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Sex", sex.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Phone", phone.Text);
                cmd.Parameters.AddWithValue("@Coustomer_HouseTel", tel.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Email", email.Text);
                cmd.Parameters.AddWithValue("@Coustomer_City", city.Text);
                cmd.Parameters.AddWithValue("@Coustomer_District", district.Text);
                cmd.Parameters.AddWithValue("@Coustomer_Address", address.Text);
                cmd.Parameters.AddWithValue("@Coustomer_FamilyMember_ID", family.Text);
                cmd.Parameters.AddWithValue("@Company_ID", company.Text);



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
