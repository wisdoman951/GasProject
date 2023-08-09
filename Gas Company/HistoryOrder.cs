using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gas_Company
{
    public partial class HistoryOrder : Form
    {
        private DataTable data;
        public HistoryOrder()
        {
            InitializeComponent();
        }

        public void SetData(DataTable historyOrders)
        {
            data = historyOrders;

            // Process the data and display it in the form controls
            dataGridView1.DataSource = data;

            //dataGridView1.Columns["CUSTOMER_Id"].Visible = false;
        }

        private void HistoryOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
