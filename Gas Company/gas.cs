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
    public partial class gas : Form

    {
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        private string gasId;
        private DataRow originalRow;
        private bool isEditMode;

        // 有回傳gasId 就代表是要編輯某一個gastank
        public gas()
        {
            InitializeComponent();
            isEditMode = false;
        }
        public gas(string gasId)
        {
            InitializeComponent();
            this.gasId = gasId;

            // Retrieve the original row data
            RetrieveOriginalRowData();

            // Autofill the elements based on the original row data
            GasCompanyID.Text = originalRow["Gas_Company_ID"].ToString();
            GasWeightFull.Text = originalRow["Gas_Weight_Full"].ToString();
            GasWeightEmpty.Text = originalRow["Gas_Weight_Empty"].ToString();
            GasType.Text = originalRow["Gas_Type"].ToString();
            GasVolume.Text = originalRow["Gas_Volume"].ToString();
            GasSupplier.Text = originalRow["Gas_Supplier"].ToString();
            GasPrice.Text = originalRow["Gas_Price"].ToString();
            GasExamineDay.Text = originalRow["Gas_Examine_Day"].ToString();
            GasProduceDay.Text = originalRow["Gas_Produce_Day"].ToString();
        }
        private void gas_Load(object sender, EventArgs e)
        {
            GasCompanyID.Text = GlobalVariables.CompanyId;
        }
        private void RetrieveOriginalRowData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM gas WHERE Gas_ID = @GasId", conn);
                cmd.Parameters.AddWithValue("@GasId", gasId);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    originalRow = dt.Rows[0];
                }
                conn.Close();
            }
        }
        // For 新增資料前的清除動作
        private void ClearFields()
        {
            GasCompanyID.Text = "";
            GasWeightFull.Text = "";
            GasWeightEmpty.Text = "";
            GasType.Text = "";
            GasVolume.Text = "";
            GasSupplier.Text = "";
            GasPrice.Text = "";
            GasExamineDay.Text = "";
            GasProduceDay.Text = "";
        }


        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO gas (Gas_Company_ID, Gas_Weight_Full, Gas_Weight_Empty, " +
                                     "Gas_Type, Gas_Volume, Gas_Supplier, Gas_Price, Gas_Examine_Day, Gas_Produce_Day) " +
                                     "VALUES (@Gas_Company_ID, @Gas_Weight_Full, @Gas_Weight_Empty, " +
                                     "@Gas_Type, @Gas_Volume, @Gas_Supplier, @Gas_Price, " +
                                     "STR_TO_DATE(@Gas_Examine_Day, '%Y年%m月%d日'), STR_TO_DATE(@Gas_Produce_Day, '%Y年%m月%d日'))";

                string updateQuery = "UPDATE gas SET " +
                                     "Gas_Company_ID = @Gas_Company_ID, " +
                                     "Gas_Weight_Full = @Gas_Weight_Full, " +
                                     "Gas_Weight_Empty = @Gas_Weight_Empty, " +
                                     "Gas_Type = @Gas_Type, " +
                                     "Gas_Volume = @Gas_Volume, " +
                                     "Gas_Supplier = @Gas_Supplier, " +
                                     "Gas_Price = @Gas_Price, " +
                                     "Gas_Examine_Day = STR_TO_DATE(@Gas_Examine_Day, '%Y年%m月%d日'), " +
                                     "Gas_Produce_Day = STR_TO_DATE(@Gas_Produce_Day, '%Y年%m月%d日') " +
                                     "WHERE Gas_ID = @Gas_ID";

                MySqlCommand cmd;

                if (isEditMode)
                {
                    cmd = new MySqlCommand(updateQuery, connection);
                    cmd.Parameters.AddWithValue("@Gas_ID", gasId);
                }
                else
                {
                    cmd = new MySqlCommand(insertQuery, connection);
                }

                cmd.Parameters.AddWithValue("@Gas_Company_ID", GasCompanyID.Text);
                cmd.Parameters.AddWithValue("@Gas_Weight_Full", GasWeightFull.Text);
                cmd.Parameters.AddWithValue("@Gas_Weight_Empty", GasWeightEmpty.Text);
                cmd.Parameters.AddWithValue("@Gas_Type", GasType.Text);
                cmd.Parameters.AddWithValue("@Gas_Volume", GasVolume.Text);
                cmd.Parameters.AddWithValue("@Gas_Supplier", GasSupplier.Text);
                cmd.Parameters.AddWithValue("@Gas_Price", GasPrice.Text);
                cmd.Parameters.AddWithValue("@Gas_Examine_Day", GasExamineDay.Text);
                cmd.Parameters.AddWithValue("@Gas_Produce_Day", GasProduceDay.Text);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Save successful!");
                    if (!isEditMode)
                        ClearFields();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Save failed!");
                }
                RetrieveOriginalRowData();
            }
        }
    }
}
