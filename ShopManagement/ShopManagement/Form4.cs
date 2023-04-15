using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagement
{
    public partial class Form4 : Form
    {
        string inputID = "";
        
        public Form4(string orderID)
        {
            InitializeComponent();
            this.inputID = orderID;
        }

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string orderID = DatabaseQuery.getOrderByOrderID(inputID).Rows[0][0].ToString();
            string orderDate = DatabaseQuery.getOrderByOrderID(inputID).Rows[0][1].ToString();
            string customerID = DatabaseQuery.getOrderByOrderID(inputID).Rows[0][2].ToString();
            string customerName = DatabaseQuery.getAgentByID(customerID).Rows[0][1].ToString();
            string customerPhone = DatabaseQuery.getAgentByID(customerID).Rows[0][2].ToString();
            string customerAddress = DatabaseQuery.getAgentByID(customerID).Rows[0][3].ToString();
            DataTable orderDetail = DatabaseQuery.getOrderdetailsByOrderID(inputID);

            int totalAmount = 0;
            for (int i = 0; i < orderDetail.Rows.Count; i++)
            {
                totalAmount += Int32.Parse(orderDetail.Rows[i][4].ToString());
            }

            labID.Text = "Order ID: " + orderID;
            labDate.Text = "Date: " + orderDate.Substring(0, 9);
            labName.Text = "Customer name: " + customerName;
            labPhone.Text = "Phone number: " + customerPhone;
            labAddress.Text = "Address: " + customerAddress;
            dgvDetail.DataSource = orderDetail;
            labAmount.Text = "Total: " + totalAmount.ToString() + " VND";
        }
    }
}
