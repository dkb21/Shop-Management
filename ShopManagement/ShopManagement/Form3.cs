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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtID.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Please fill out the form!");
            }
            else
            {
                string id = txtID.Text;
                string name = txtName.Text;
                string size = txtSize.Text;
                int price = Int32.Parse(txtPrice.Text);

                DialogResult result = MessageBox.Show("Create this new item?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DatabaseQuery.addItem(id, name, size, price);

                    MessageBox.Show("Created successfully!");

                    this.Close();
                }
                else
                {
                    // Xử lý khi người dùng chọn No
                }
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Tạo một instance của form mới
            Form1 form1 = new Form1();

            // Mở form mới dưới dạng hộp thoại
            form1.Show();
        }
    }
}
