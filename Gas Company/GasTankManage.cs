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

namespace Gas_Company
{

    public partial class GasTankManage : Form
    {   // connect to gas table
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public GasTankManage()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged; // Assign the event handler


        }
        // 篩出所有桶重
        private DataView dataView; // Declare a class-level variable to store the DataView

        private void GasTankManage_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM `gas`";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataView = table.DefaultView;

                    // Set the sorting mode for the "GAS_Examine_Day" column to automatic
                    dataGridView1.Columns["GAS_Examine_Day"].SortMode = DataGridViewColumnSortMode.Automatic;

                    // Set the initial sorting order for the "GAS_Examine_Day" column to ascending
                    dataGridView1.Sort(dataGridView1.Columns["GAS_Examine_Day"], ListSortDirection.Ascending);
                    // Columns rename
                    dataGridView1.Columns["GAS_Id"].HeaderText = "瓦斯桶編號";
                    dataGridView1.Columns["GAS_Company_Id"].HeaderText = "所屬公司編號";
                    dataGridView1.Columns["GAS_Weight_Full"].HeaderText = "滿桶重量";
                    dataGridView1.Columns["GAS_Weight_Empty"].HeaderText = "空桶重量";
                    dataGridView1.Columns["GAS_Type"].HeaderText = "瓦斯桶種類";
                    dataGridView1.Columns["GAS_Price"].HeaderText = "瓦斯價格";
                    dataGridView1.Columns["GAS_Volume"].HeaderText = "瓦斯桶容量";
                    dataGridView1.Columns["GAS_Examine_Day"].HeaderText = "檢驗日期";
                    dataGridView1.Columns["GAS_Produce_Day"].HeaderText = "出廠日期";
                    dataGridView1.Columns["GAS_Supplier"].HeaderText = "供應商";
                    dataGridView1.Columns["Gas_Registration_Time"].HeaderText = "瓦斯桶註冊時間";
                    dataGridView1.Columns["last_worker_id"].HeaderText = "最後經手員工";
                    PopulateComboBox();
                }
            }   
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Access the data in the selected row and autofill other fields in the form
                string gasId = selectedRow.Cells["GAS_Id"].Value.ToString();
                string gasWeightFull = selectedRow.Cells["GAS_Weight_Full"].Value.ToString();
                string gasWeightEmpty = selectedRow.Cells["GAS_Weight_Empty"].Value.ToString();
                string gasType = selectedRow.Cells["GAS_Type"].Value.ToString();
                string gasProduceDay = selectedRow.Cells["GAS_Produce_Day"].Value.ToString();
                string gasExamineDay = selectedRow.Cells["GAS_Examine_Day"].Value.ToString();
                string supplier = selectedRow.Cells["GAS_Supplier"].Value.ToString();

                // Autofill the other fields(Textbox) in the form
                GasId.Text = gasId;
                GasWeightFull.Text = gasWeightFull;
                GasWeightEmpty.Text = gasWeightEmpty;
                GasType.Text = gasType;
                GasProduceDay.Text = gasProduceDay;
                GasExamineDay.Text = gasExamineDay;
                Supplier.Text = supplier;
            }
        }
        private void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "GAS_Examine_Day") // Replace "GAS_Examine_Day" with the actual name of the column
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
                {
                    DateTime examineDate = Convert.ToDateTime(e.Value);

                    // Compare with current date
                    DateTime currentDate = DateTime.Now;
                    int daysDifference = (int)(examineDate - currentDate).TotalDays;

                    // Set the background color based on the date comparison
                    if (daysDifference <= 0)
                    {
                        // Date has passed, set row background color to red
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (daysDifference <= 30)
                    {
                        // Within 30 days, set row background color to yellow
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else
                    {
                        // More than 30 days, use the default row background color
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                    }
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedValue))
            {
                dataView.RowFilter = $"GAS_Weight_Empty = '{selectedValue}'";
            }
            else
            {
                dataView.RowFilter = ""; // Show all data when the combobox is cleared
            }
        }
        private void PopulateComboBox()
        {
            HashSet<string> uniqueValues = new HashSet<string>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string value = row.Cells["GAS_Weight_Empty"].Value?.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    uniqueValues.Add(value);
                }
            }

            List<string> sortedValues = new List<string>(uniqueValues);
            sortedValues.Sort();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(sortedValues.ToArray());
            
            dataView.RowFilter = ""; // Clear any existing filter
        }

        
    }
}
