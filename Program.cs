using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace overrideApp { 
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmAuth());
            // Show the authorization form
            frmAuth authForm = new frmAuth();
            if (authForm.ShowDialog() == DialogResult.OK)
            {
                // If authentication is successful, show the main form
                Application.Run(new Form1());
            }
            else
            {
                // If authentication fails, close the application
                MessageBox.Show("Authentication failed. The application will now close.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
