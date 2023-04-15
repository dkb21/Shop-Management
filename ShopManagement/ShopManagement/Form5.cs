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
    public partial class Form5 : Form
    {
        private string customerID = "";
        public Form5(string customerID)
        {
            InitializeComponent();
            this.customerID = customerID;
        }
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection selectedRows = dgvHistory.SelectedRows;

                string orderID = selectedRows[0].Cells[0].Value.ToString();

                Form4 form4 = new Form4(orderID);
                form4.ShowDialog();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string name = DatabaseQuery.getAgentByID(customerID).Rows[0][1].ToString();
            dgvHistory.DataSource = DatabaseQuery.getAllOrderByAgentID(customerID);

            labTitle.Text = name + "'s purchase history:";
        }
    }
}
