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
    public partial class frmSettings : Form
{
    public frmSettings()
    {
        InitializeComponent();
    }

        private void btnSave_Click(object sender, EventArgs e)
        {
            @override.Properties.Settings.Default.dbUser = txtUser.Text;
            @override.Properties.Settings.Default.dbPassword = txtPass.Text;
            @override.Properties.Settings.Default.dbPort = Int32.Parse(txtPort.Text);
            DatabaseConfig.User = @override.Properties.Settings.Default.dbUser;
            DatabaseConfig.Password = @override.Properties.Settings.Default.dbPassword;
            DatabaseConfig.Port = @override.Properties.Settings.Default.dbPort;
            @override.Properties.Settings.Default.Save();
            MessageBox.Show("Settings have been saved successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtUser.Text = @override.Properties.Settings.Default.dbUser;
            txtPass.Text = @override.Properties.Settings.Default.dbPassword;
            txtPort.Text = @override.Properties.Settings.Default.dbPort.ToString();
        }
    }
}
