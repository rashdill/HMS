using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data;
namespace testform
{
    //manage roooms

    class ROOM
    {
        CONNECTION Conn = new CONNECTION();

        // to get a list of room's Type

        public DataTable roomTypeList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM  `rooms_category`", Conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }
        //to get a list of rooms by type
       /* public DataTable roomByType(int type)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `rooms` WHERE `type`=@typ ", Conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.Parameters.Add("@typ", MySqlDbType.Int32).Value = type;
            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }*/

        //`rooms_category`

        //insert a new room


        public bool addRoom(int number, int type, String phone, String free)
        {
            MySqlCommand command = new MySqlCommand();
            String insertQuery = "INSERT INTO `rooms`(`number`, `type`, `phone`, `free`) VALUES (@num,@tp,@phn,@fr))";
            command.CommandText = insertQuery;
            command.Connection = Conn.getConnection();
            //@num,@tp,@phn,@fr
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@tp", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@fr", MySqlDbType.VarChar).Value = free;
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
        //to get a list of all rooms
        public DataTable getRooms()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `rooms`", Conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }

        //to edit the selected room


        public bool editRoom(int number, int type, String phone, String free)
        {
            MySqlCommand command = new MySqlCommand();
            String editQuery = "UPDATE `rooms` SET `type`=@tp,`phone`=@phn,`free`=@fr WHERE `number`=@num";
            command.CommandText = editQuery;
            command.Connection = Conn.getConnection();
            //@num,@tp,@phn,@fr
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@tp", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@fr", MySqlDbType.VarChar).Value = free;
            Conn.openConnection();
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
        //delete selected room
        public bool removeRoom(int number)
        {

            MySqlCommand command = new MySqlCommand();
            String removeQuery = "DELETE FROM `rooms` WHERE `number`=@num";
            command.CommandText = removeQuery;
            command.Connection = Conn.getConnection();
            
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
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
