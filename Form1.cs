using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;
using System.Net.Http;
using Org.BouncyCastle.Asn1.Cmp;
using System.Diagnostics;
using Org.BouncyCastle.Tls;

namespace overrideApp
{
    public partial class Form1 : Form
    {
        string defaultUser = Environment.UserName;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userTxt.Text = defaultUser;
            DatabaseConfig.User = @override.Properties.Settings.Default.dbUser;
            DatabaseConfig.Password = @override.Properties.Settings.Default.dbPassword;
            DatabaseConfig.Port = @override.Properties.Settings.Default.dbPort;
            try
            {
                // Access the JSON content as a byte array
                byte[] jsonBytes = @override.Properties.Resources.DefaultOptions;

                // Convert byte array to string
                string jsonContent = Encoding.UTF8.GetString(jsonBytes);

                // Deserialize the JSON into a string array
                string[] options = JsonConvert.DeserializeObject<string[]>(jsonContent);

                // Add the options to the ComboBox
                serverTxt.Items.AddRange(options);

                // Optionally set the first item as selected
                if (serverTxt.Items.Count > 0)
                {
                    serverTxt.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading options: {ex.Message}");
            }

        }

        private string fetchCookie(int userID, string server) {
            string passkey = null;
            DatabaseConfig.Database = "kdtphdb";
            string connectionString = DatabaseConfig.GetConnectionString();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT fldUserHash FROM kdtlogin WHERE fldEmployeeNum = @userID";

                try
                {
                    // Open connection to database
                    conn.Open();

                    // Run query
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        passkey = result.ToString();  // Return the passkey if found
                    }
                    else
                    {
                        // Handle the case where the passkey isn't found in the database
                        MessageBox.Show("No passkey found for the username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (MySqlException ex)
                {
                    // Handle MySQL errors (connection failure, query issues, etc.)
                    MessageBox.Show($"Database connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Catch any other general exceptions (unexpected issues)
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return passkey;
        }
        private int fetchIDByUsername(string username, string server)
        {
            DatabaseConfig.Database = "kdtphdb_new";
            string connectionString = DatabaseConfig.GetConnectionString();
            string query = "SELECT id FROM employee_list WHERE username = @username";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    object result = cmd.ExecuteScalar(); // Executes the query and returns the first result
                    if (result != null)
                    {
                        return Convert.ToInt32(result); // Return the User ID
                    }
                    else
                    {
                        return -1; // User not found
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"MySQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = userTxt.Text.ToLower().Trim();
            string server = serverTxt.SelectedItem.ToString();
            int userId = fetchIDByUsername(username,server);
            if (userId != -1)
            {
                // If user ID is found, use it to fetch the passkey
                string passkey = fetchCookie(userId, server);

                if (passkey != null)
                {
                    //MessageBox.Show($"Passkey: {passkey}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetCookiesInBrowser(username, passkey, server);
                }
                else
                {
                    MessageBox.Show("Passkey not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ActiveControl = userTxt;
                }
            }
            else
            {
                MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = userTxt;
            }
        }
        private async Task SetCookiesInBrowser(string username, string passkey, string server)
        {
            string url = $"http://{server}/override.php?username={username}&passkey={passkey}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send the GET request
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Get the response body
                        //string responseBody = await response.Content.ReadAsStringAsync();
                        //MessageBox.Show(responseBody, "Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    }
                    else
                    {
                        // Show an error message if the request failed
                        MessageBox.Show($"Request failed with status code: {response.StatusCode}", "Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSettings formSettings = new frmSettings();
            if(formSettings.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Settings have been updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void serverTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseConfig.Server = serverTxt.Text;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            userTxt.Text = Environment.UserName;
        }
    }
}
