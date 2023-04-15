using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagement
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dgvCustomers.DataSource = DatabaseQuery.getAllAgents();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPhone.Text == "" || txtAddress.Text == "") {
                MessageBox.Show("Please fill out the form!");
            }
            else
            {
                string name = txtName.Text;
                string phone = txtPhone.Text;
                string address = txtAddress.Text;

                DialogResult result = MessageBox.Show("Add this customer?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DatabaseQuery.addAgent(name, phone, address);
                    dgvCustomers.DataSource = DatabaseQuery.getAllAgents();

                    txtName.Text = "";
                    txtPhone.Text = "";
                    txtAddress.Text = "";
                }
                else
                {
                    // Xử lý khi người dùng chọn No
                }
            }
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            if(dgvCustomers.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection selectedRows = dgvCustomers.SelectedRows;

                string id = selectedRows[0].Cells[0].Value.ToString();
                selectedID = id;

                this.Close();
            }

        }

        public string selectedID { get; private set; }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection selectedRows = dgvCustomers.SelectedRows;

                string id = selectedRows[0].Cells[0].Value.ToString();
                
                Form5 form5 = new Form5(id);
                form5.ShowDialog();
            }
        }
    }
}
