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
        }

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

                    // You can check each column's name here
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.WriteLine(column.ColumnName);
                    }

                }
            }
        }
    }
}
