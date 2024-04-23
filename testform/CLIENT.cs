using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using System.Threading.Tasks;
using System.Data;
namespace testform
{
    //create a class Add,Edit,Remove
    class CLIENT
    {
        CONNECTION Conn = new CONNECTION();

        //to insert a new client

        public bool insertClient(String fname,String lname,String phone,String country)
        {
            MySqlCommand command = new MySqlCommand();
            String insertQuery = "INSERT INTO `client`( `first_name`, `last_name`, `phone`, `country`) VALUES (@fnm,@lnm,@phn,@cnt)";
            command.CommandText = insertQuery;
            command.Connection = Conn.getConnection();
            //@fnm,@lnm,@phn,@cnt
            command.Parameters.Add("@fnm", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lnm", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;
            Conn.openConnection();
            if(command.ExecuteNonQuery() == 1)
            {
                Conn.closeConnection();
                return true;
            }
            else 
            {
                Conn.closeConnection();
                return false;
            }
            
           
        }
        //to get the client list
        public DataTable getClient()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `client`" , Conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);


            return  table;
        }

        //edit client data
        public bool editClient(int id, String fname, String lname, String phone, String country)
        {
            MySqlCommand command = new MySqlCommand();
            String editQuery = "UPDATE `client` SET `first_name`=@fnm,`last_name`=@lnm,`phone`=@phn,`country`=@cnt WHERE `id`=@cid";
            command.CommandText = editQuery;
            command.Connection = Conn.getConnection();
            //@cid,@fnm,@lnm,@phn,@cnt
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fnm", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lnm", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;
            Conn.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                Conn.closeConnection();
                return true;
            }
            else
            {
                Conn.closeConnection();
                return false;
            }
        }

        //delete client
        public bool RemoveClient(int id)
        {
            MySqlCommand command = new MySqlCommand();
            String removeQuery = "DELETE FROM `client` WHERE `id`=@cid";
            command.CommandText = removeQuery;
            command.Connection = Conn.getConnection();
            //@cid,@fnm,@lnm,@phn,@cnt

            Conn.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                Conn.closeConnection();
                return true;
            }
            else
            {
                Conn.closeConnection();
                return false;
            }

        }

        // delete the selected client
        public bool removeClient(int id)
        {

            MySqlCommand command = new MySqlCommand();
            String removeQuery = "DELETE FROM `client` WHERE `id`=@cid";
            command.CommandText = removeQuery;
            command.Connection = Conn.getConnection();
            //@cid,@fnm,@lnm,@phn,@cnt
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;
            Conn.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                Conn.closeConnection();
                return true;
            }
            else
            {
                Conn.closeConnection();
                return false;
            }

        }


    }
}
