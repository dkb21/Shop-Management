using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ShopManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        { 
            bool canLogin = true;

            DataTable check = DatabaseQuery.getAccountByUsername(txtUsername.Text);

            if (check.Rows.Count == 0) {
                MessageBox.Show("Username is not exist!");
                canLogin = false;
            }

            else
            {
                if (check.Rows[0][1].ToString() != txtPassword.Text)
                {
                    MessageBox.Show("Password is incorrect!");
                    canLogin = false;
                }

                if (canLogin)
                {
                    MessageBox.Show("Login successfully");
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                }
            }

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (DatabaseQuery.getAccountByUsername(txtUsername.Text).Rows.Count > 0)
            {
                MessageBox.Show("Username already exist!");
            }

            else
            {
                DatabaseQuery.addAccount(txtUsername.Text, txtPassword.Text);
                
                MessageBox.Show("Account created!");
            }
        }
    }
}
