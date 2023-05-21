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
using static Gas_Company.Form2;

namespace Gas_Company
{
    public partial class CustomerInformation : Form
    {
        public CustomerInformation()
        {
            InitializeComponent();
        }

        public void SetData(List<CustomerData> customerDataList)
        {
            foreach (CustomerData customerData in customerDataList)
            {
                // Access the CustomerData object
                string customerId = customerData.CustomerId;
                string customerName = customerData.CustomerName;
                string customerPhone = customerData.CustomerPhone;
                string customerSex = customerData.CustomerSex;
                string familyMemberId = customerData.FamilyMemberId;
                string customerEmail = customerData.CustomerEmail;

                // Fill the customerinfo
                CustomerID.Text = customerId;
                CustomerName.Text = customerName;
                CustomerPhone.Text = customerPhone;
                CustomerSex.Text = customerSex;
                CustomerFamilyMember.Text = familyMemberId;
                CustomerEmail.Text = customerEmail;
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
                this.Close();  // Close the form
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
