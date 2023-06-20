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
    public partial class gas : Form
    {
        public gas()
        {
            InitializeComponent();
        }

        private void gas_Load(object sender, EventArgs e)
        {

        }

        private void AddComfirmButton_Click(object sender, EventArgs e)
        {
            // Perform validation
            if (string.IsNullOrEmpty(GasCompanyID.Text) || string.IsNullOrEmpty(GasWeightFull.Text) ||
                string.IsNullOrEmpty(GasWeightEmpty.Text) || string.IsNullOrEmpty(GasType.Text) ||
                string.IsNullOrEmpty(GasVolume.Text) || string.IsNullOrEmpty(GasSupplier.Text) ||
                string.IsNullOrEmpty(GasExamineDay.Text) || string.IsNullOrEmpty(GasProduceDay.Text))
            {
                MessageBox.Show("All fields are required. Please fill in all the fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop further processing
            }

            //連接資料庫
            string connStr = ConfigurationManager.AppSettings["ConnectionString"];
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                //新增一筆資料
                string insertQuery = "INSERT INTO gas (Gas_Company_ID, Gas_Weight_Full, Gas_Weight_Empty, Gas_Type, Gas_Volume, Gas_supplier, Gas_Examine_Day, Gas_Produce_Day, Gas_price, Gas_Registration_Time) " +
                    "VALUES (@Gas_Company_ID, @Gas_Weight_Full, @Gas_Weight_Empty, @Gas_Type, @Gas_Volume, @Gas_supplier, STR_TO_DATE(@Gas_Examine_Day, '%Y年%m月%d日'), STR_TO_DATE(@Gas_Produce_Day, '%Y年%m月%d日'), NOW())";

                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Gas_Company_ID", GasCompanyID.Text);
                cmd.Parameters.AddWithValue("@Gas_Weight_Full", GasWeightFull.Text);
                cmd.Parameters.AddWithValue("@Gas_Weight_Empty", GasWeightEmpty.Text);
                cmd.Parameters.AddWithValue("@Gas_Type", GasType.Text);
                cmd.Parameters.AddWithValue("@Gas_Volume", GasVolume.Text);
                cmd.Parameters.AddWithValue("@Gas_Supplier", GasSupplier.Text);
                cmd.Parameters.AddWithValue("@Gas_Examine_Day", GasExamineDay.Text);
                cmd.Parameters.AddWithValue("@Gas_Produce_Day", GasProduceDay.Text);
                cmd.Parameters.AddWithValue("@Gas_Price", GasPrice.Text);

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
