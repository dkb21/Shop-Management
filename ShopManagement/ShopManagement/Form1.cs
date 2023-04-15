using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ShopManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvItems.DataSource = DatabaseQuery.getAllItems();

            //string[] row = new string[] { "Cell 1", "Cell 2", "Cell 3" };
            //dgvCart.Rows.Add(row);

        }

        List<string> cart = new List<string>();
        private void btnAddCart_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dgvItems.SelectedRows;

            if(selectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in selectedRows)
                {
                    string id = row.Cells[0].Value.ToString();
                    string name = row.Cells[1].Value.ToString();
                    int quantity = 1;
                    int price = Int32.Parse(row.Cells[3].Value.ToString());

                    for (int i = 0; i < cart.Count(); i++)
                    {
                        if (cart[i] == id) quantity++;
                    }

                    string[] insertToCartTable = new string[] { id, name, quantity.ToString(), price.ToString() };

                    if (quantity == 1) dgvCart.Rows.Add(insertToCartTable);
                    else
                    {
                        foreach (DataGridViewRow cartRow in dgvCart.Rows)
                        {
                            if (cartRow.Cells[0].Value.ToString() == id)
                            {
                                cartRow.Cells[2].Value = quantity.ToString();
                                cartRow.Cells[3].Value = (quantity * price).ToString();
                                break;
                            }
                        }
                    }

                    cart.Add(id);
                    // Sử dụng giá trị của các ô để thực hiện các thao tác khác
                    // ...
                }
            }
        }

        private void btnResetCart_Click(object sender, EventArgs e)
        {
            dgvCart.Rows.Clear();
            cart.Clear();
        }

        private void btnChangeCustomer_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form mới
            Form2 form2 = new Form2();

            // Mở form mới dưới dạng hộp thoại
            form2.ShowDialog();

            if(form2.selectedID != null)
            {
                string selectingID = form2.selectedID;
                string selectingName = DatabaseQuery.getAgentByID(selectingID).Rows[0][1].ToString();
                string selectingPhone = DatabaseQuery.getAgentByID(selectingID).Rows[0][2].ToString();
                string selectingAddress = DatabaseQuery.getAgentByID(selectingID).Rows[0][3].ToString();

                labID.Text = "ID: " + selectingID;
                labName.Text = "Name: " + selectingName;
                labPhone.Text = "Phone number: " + selectingPhone;
                labAddress.Text = "Address: " + selectingAddress;
            }
        }

        private void btnFinishOrder_Click(object sender, EventArgs e)
        {
            bool workable = true;

            if (labID.Text.Length < 5)
            {
                MessageBox.Show("Please select a customer!");
                workable = false;
            }
            if (dgvCart.RowCount == 1) {
                MessageBox.Show("Please add at least 1 item to cart!");
                workable = false;
            }


            if (workable == true)
            {
                DialogResult result = MessageBox.Show("Confirm this order?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DatabaseQuery.addNewOrder(labID.Text.Substring(4));
                    string cartOrderID = DatabaseQuery.getBiggestOrderID().Rows[0][0].ToString();

                    //MessageBox.Show(DatabaseQuery.getBiggestOrderID().Rows[0][0].ToString());

                    int max = dgvCart.Rows.Count-1;
                    //MessageBox.Show(max.ToString());
                    for (int i = 0; i < max; i++)
                    {
                        string cartOrderItemID = (i + 1).ToString();
                        string cartItemID = dgvCart.Rows[i].Cells[0].Value.ToString();
                        int cartQuantity = Int32.Parse(dgvCart.Rows[i].Cells[2].Value.ToString());

                        //MessageBox.Show(cartOrderID + "--" + cartOrderItemID);

                        DatabaseQuery.addOrderItem(cartOrderID, cartOrderItemID, cartItemID, cartQuantity);
                    }

                    MessageBox.Show("Purchased successfully!");

                    // Tạo một instance của form mới
                    Form4 form4 = new Form4(cartOrderID);

                    // Mở form mới dưới dạng hộp thoại
                    form4.ShowDialog();

                    dgvCart.Rows.Clear();
                    cart.Clear();
                }
                else
                {
                    // Xử lý khi người dùng chọn No
                }
            }
        }

        private void btnCreateItem_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form mới
            Form3 form3 = new Form3();

            // Mở form mới dưới dạng hộp thoại
            form3.ShowDialog();

            this.Hide();
        }
    }
}
