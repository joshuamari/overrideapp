using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overrideApp
{
    public static class DatabaseConfig
    {
        private static string _server = "localhost"; // Default server
        private static string _database = "kdtphdb"; // Default database
        private static string _user = "root"; // Default user
        private static string _password = ""; // Default password
        private static int _port = 3306; // Default port

        public static string Server
        {
            get { return _server; }
            set { _server = value; }
        }

        public static string Database
        {
            get { return _database; }
            set { _database = value; }
        }

        public static string User
        {
            get { return _user; }
            set { _user = value; }
        }

        public static string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public static int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        // Method to get the connection string
        public static string GetConnectionString()
        {
            return $"Server={_server};Database={_database};Uid={_user};Pwd={_password};Port={_port};";
        }
    }

}
