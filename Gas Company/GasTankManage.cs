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
using System.ComponentModel.Design;

namespace Gas_Company
{

    public partial class GasTankManage : Form
    {   // connect to gas table
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        private DataView dataView;

        public GasTankManage()
        {
            InitializeComponent();
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        }
        // 篩出所有桶重
        //private DataView dataView; // Declare a class-level variable to store the DataView

        private void GasTankManage_Load(object sender, EventArgs e)
        {
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;

            string query = $"SELECT * FROM `gas` WHERE GAS_Company_Id = {GlobalVariables.CompanyId}";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataView = table.DefaultView;

                    table.Columns.Remove("GAS_Company_Id");
                    // Set the sorting mode for the "GAS_Examine_Day" column to automatic
                    dataGridView1.Columns["GAS_Examine_Day"].SortMode = DataGridViewColumnSortMode.Automatic;

                    // Set the initial sorting order for the "GAS_Examine_Day" column to ascending
                    dataGridView1.Sort(dataGridView1.Columns["GAS_Examine_Day"], ListSortDirection.Ascending);
                    // Columns rename
                    dataGridView1.Columns["GAS_Id"].HeaderText = "瓦斯桶編號";
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

            comboBox2.Items.Clear();
            // Populate the filter ComboBox
            comboBox2.Items.Add("大於 30 年");
            comboBox2.Items.Add("20 到 30 年");
            comboBox2.Items.Add("20 年內");

            // Set the sorting mode for the "GAS_Examine_Day" column to automatic
            dataGridView1.Columns["GAS_Examine_Day"].SortMode = DataGridViewColumnSortMode.Automatic;

            // Set the initial sorting order for the "GAS_Examine_Day" column to ascending
            dataGridView1.Sort(dataGridView1.Columns["GAS_Examine_Day"], ListSortDirection.Ascending);

            // Wire up the CellFormatting event handler
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


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "GAS_Produce_day" || dataGridView1.Columns[e.ColumnIndex].Name == "GAS_Examine_day")
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    var produceCellValue = dataGridView1.Rows[e.RowIndex].Cells["GAS_Produce_day"].Value;
                    var examineCellValue = dataGridView1.Rows[e.RowIndex].Cells["GAS_Examine_day"].Value;

                    if (produceCellValue != null && examineCellValue != null && DateTime.TryParse(produceCellValue.ToString(), out DateTime produceDate) && DateTime.TryParse(examineCellValue.ToString(), out DateTime examineDate))
                    {
                        DateTime currentDate = DateTime.Now;

                        TimeSpan produceDifference = currentDate.Subtract(produceDate);
                        TimeSpan examineDifference = currentDate.Subtract(examineDate);

                        int produceYearsDifference = (int)(produceDifference.TotalDays / 365.25);
                        int examineYearsDifference = (int)(examineDifference.TotalDays / 365.25);

                        if (produceYearsDifference < 20)
                        {
                            // Gas tank produced within 20 years
                            if (examineYearsDifference >= 5 || currentDate >= produceDate.AddDays(20 * 365.25))
                            {
                                // More than 5 years since the last examination or reached the date after 20 years old, set row background color to yellow
                                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                            }
                        }
                        else if (produceYearsDifference <= 30)
                        {
                            // Gas tank produced between 21 and 30 years
                            if (examineYearsDifference >= 2 || examineDate < produceDate.AddDays(20 * 365.25))
                            {
                                // More than 2 years since the last examination or reached the date after 20 years old, set row background color to yellow
                                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                            }
                        }
                        else
                        {
                            // Gas tank produced more than 30 years, set row background color to gray
                            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
                        }
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
        }

        private void GasDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定删除此行資料？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string gasId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string query = "DELETE FROM `gas` WHERE `GAS_Id` = @GAS_Id";
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@GAS_Id", gasId);
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


        private void ResetFilterButton_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = GasExamineDay.Value.Date;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["GAS_Examine_Day"].Value is DateTime examineDate)
                {
                    if (examineDate < selectedDate)
                    {
                        row.Visible = true; // Show the row
                    }
                    else
                    {
                        row.Visible = false; // Hide the row
                    }
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            GasTankManage_Load(sender, e);

            // Autofill the other fields(Textbox) in the form
            GasId.Text = "";
            GasWeightFull.Text = "";
            GasWeightEmpty.Text = "";
            GasType.Text = "";
            GasProduceDay.Text = "";
            GasExamineDay.Text = "";
            Supplier.Text = "";
            Note.Text = "";
            comboBox1.Text = "";
        }


        private void GasAdd_Click(object sender, EventArgs e)
        {
            gas f1;
            f1 = new gas();
            f1.ShowDialog();
        }
        private void edit_Click(object sender, EventArgs e)
        {
            // Get the selected row
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the Gas_ID of the selected row
                string gasId = dataGridView1.SelectedRows[0].Cells["Gas_ID"].Value.ToString();

                // Pass the gasId to the edit form
                gas editForm = new gas(gasId);
                editForm.ShowDialog();

                // Refresh the DataGridView after editing
                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void RefreshDataGridView()
        {
            // Refresh the DataGridView
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM gas WHERE GAS_Company_Id = @CompanyId", conn);
                cmd.Parameters.AddWithValue("@CompanyId", GlobalVariables.CompanyId);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = comboBox2.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedFilter))
            {
                switch (selectedFilter)
                {
                    case "大於 30 年":
                        FilterRowsByProduceDay(30, 100);
                        break;
                    case "20 到 30 年":
                        FilterRowsByProduceDay(20, 30);
                        break;
                    case "20 年內":
                        FilterRowsByProduceDay(0, 20);
                        break;
                }
            }
            else
            {
                // Show all data when the ComboBox is cleared
                dataView.RowFilter = "";
            }
        }
        private void FilterRowsByProduceDay(int minYears, int maxYears)
        {
            if (minYears < -10000 || minYears > 10000)
            {
                throw new ArgumentOutOfRangeException(nameof(minYears), "Year value must be between -10000 and 10000.");
            }

            if (maxYears < -10000 || maxYears > 10000)
            {
                throw new ArgumentOutOfRangeException(nameof(maxYears), "Year value must be between -10000 and 10000.");
            }

            // Calculate the minimum and maximum dates based on the years provided
            DateTime currentDate = DateTime.Now;
            DateTime minDate = currentDate.AddYears(-maxYears);
            DateTime maxDate = currentDate.AddYears(-minYears);

            // Build the filter expression
            string filterExpression = $"GAS_Produce_Day >= '{minDate:yyyy-MM-dd}' AND GAS_Produce_Day <= '{maxDate:yyyy-MM-dd}'";

            // Apply the filter
            dataView.RowFilter = filterExpression;
        }

    }
}
