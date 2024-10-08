﻿using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gas_Company
{
    public partial class report : Form
    {
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public report()
        {
            InitializeComponent();
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            // Avoid duplicated form opening
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void report_Load(object sender, EventArgs e)
        {
            // Fetch today's order and display the total in label3
            FetchTodaysOrder();

            // Fetch today's unfinished order and display in label7
            FetchTodaysUnfinishedOrder();

            /*// Fetch today's working labor count and display in label8
            FetchTodaysWorkingLabor();*/

            // Fetch the count of finished orders this month and display in label9
            FetchMonthlyCompletedOrder();

            // Fetch today's total gas quantity and display in label10
            FetchTodaysTotalGasQuantity();
        }

        private void FetchTodaysOrder()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(*) FROM gas_order WHERE DATE(Order_Time) = CURDATE() AND COMPANY_Id = {GlobalVariables.CompanyId}", connection);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    Console.WriteLine(result);
                    int todayOrderCount = Convert.ToInt32(result);
                    label3.Text = todayOrderCount.ToString();
                }
                connection.Close();
            }
        }
        private void TodayTotalOrder_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM gas_order WHERE DATE(Order_Time) = CURDATE() AND COMPANY_Id = {GlobalVariables.CompanyId}", connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                connection.Close();
            }
        }

        private void FetchTodaysUnfinishedOrder()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(*) FROM gas_order WHERE DATE(Order_Time) = CURDATE() AND DELIVERY_Condition != 'Finished' AND COMPANY_Id = {GlobalVariables.CompanyId}", connection);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int todayUnfinishedOrderCount = Convert.ToInt32(result);
                    label7.Text = todayUnfinishedOrderCount.ToString();
                }
                connection.Close();
            }
        }
        private void TodayUnfinishedOrder_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM gas_order WHERE DATE(Order_Time) = CURDATE() AND DELIVERY_Condition != 'Finished' AND COMPANY_Id = {GlobalVariables.CompanyId}", connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                connection.Close();
            }
        }
        // 未完成(今日工人量)
        /*private void FetchTodaysWorkingLabor()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM gas_order WHERE DATE(Order_Time) = CURDATE() AND DELIVERY_Condition != 'Completed'", connection);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int todayUnfinishedOrderCount = Convert.ToInt32(result);
                    label7.Text = todayUnfinishedOrderCount.ToString();
                }
                connection.Close();
            }
        }*/
        // 未完成(本月以完成訂單)
        private void FetchMonthlyCompletedOrder()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(*) FROM gas_order WHERE DELIVERY_Condition = 'Finished' AND MONTH(Order_Time) = MONTH(CURDATE()) AND COMPANY_Id = {GlobalVariables.CompanyId}", connection);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int monthlyCompletedOrderCount = Convert.ToInt32(result);
                    label9.Text = monthlyCompletedOrderCount.ToString();
                }
                connection.Close();
            }
        }

        private void MonthlyFinishedOrder_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM gas_order WHERE DELIVERY_Condition = 'Finished' AND MONTH(Order_Time) = MONTH(CURDATE()) AND COMPANY_Id = {GlobalVariables.CompanyId}", connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                connection.Close();
            }
        }

        private void FetchTodaysTotalGasQuantity()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT SUM(Gas_Quantity) FROM gas_order WHERE DATE(Order_Time) = CURDATE() AND COMPANY_Id = {GlobalVariables.CompanyId}", connection);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    decimal todayTotalGasQuantity = Convert.ToDecimal(result);
                    label10.Text = todayTotalGasQuantity.ToString();
                }
                connection.Close();
            }
        }

        private void TodayGasAmong_Click(object sender, EventArgs e)
        {
            // 可考慮要放什麼
        }

        private void CustomerManagePage_Click(object sender, EventArgs e)
        {
            openChildForm(new orderReport());
        }

        private void DeliverySchedulePage_Click(object sender, EventArgs e)
        {
            openChildForm(new report());
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to select the file path and name
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
                saveFileDialog.Title = "Save CSV file";
                saveFileDialog.ShowDialog();

                // If the user clicked the "Save" button
                if (saveFileDialog.FileName != "")
                {
                    try
                    {
                        // Create the CSV file and write the column headers
                        StringBuilder csvContent = new StringBuilder();
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            csvContent.Append(dataGridView1.Columns[i].HeaderText);
                            if (i < dataGridView1.Columns.Count - 1)
                                csvContent.Append(",");
                        }
                        csvContent.AppendLine();

                        // Write the data rows to the CSV file
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                if (row.Cells[i].Value != null)
                                    csvContent.Append(row.Cells[i].Value.ToString());
                                if (i < dataGridView1.Columns.Count - 1)
                                    csvContent.Append(",");
                            }
                            csvContent.AppendLine();
                        }

                        // Save the CSV file
                        File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());

                        MessageBox.Show("CSV file saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving CSV file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
