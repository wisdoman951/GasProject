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
    public partial class ResidualChangeWindow : Form
    {
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        private string accumId;

        public ResidualChangeWindow(string accumId, string customerName, string gasVolume, string customerPhone)
        {
            InitializeComponent();
            this.accumId = accumId;

            // Autofill the data in the form controls
            AccumulationID.Text = accumId;
            CustomerName.Text = customerName;
            AccVolumn.Text = gasVolume;
            CustomerPhoneNo.Text = customerPhone;
        }

        private void edit_Click(object sender, EventArgs e)
        {
            // Display a confirmation message box
            DialogResult result = MessageBox.Show("確定變更殘氣量?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Update the gas volume in the database
                string gasVolume = AccVolumn.Text;

                string query = "UPDATE customer_accumulation SET Gas_Volume = @gasVolume WHERE Accum_Id = @accumId";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@gasVolume", gasVolume);
                        command.Parameters.AddWithValue("@accumId", accumId);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                MessageBox.Show("殘氣量更新完成", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
