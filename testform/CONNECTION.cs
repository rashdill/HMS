using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySqlConnector;

namespace testform
{
    //CREATE THE CONNECTION
    class CONNECTION
    {
        /* string connectionString;
         MySqlConnection connection;
         connectionString = "server=127.0.0.1;port=3306;username=root;password=;database=hotel";
        connection = new MySqlConnection(connectionString);
        connection.Open();
        MessageBox.Show("Connection Open  !");
        connection.Close();
        */
        private MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=hotel");
        public MySqlConnection getConnection()
        {
            return connection;
        }
        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
