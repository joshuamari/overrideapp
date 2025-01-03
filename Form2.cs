using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace overrideApp
{
    public partial class frmAuth : Form
    {
        public frmAuth()
        {
            InitializeComponent();
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            // Replace with your desired username and password
            string correctPassword = "12345";

            if (txtAuthPw.Text == correctPassword)
            {
                // Authentication successful
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Authentication failed
                MessageBox.Show("Incorrect password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAuthPw.Text = "";
                this.ActiveControl = txtAuthPw;
            }
        }
    }
}


