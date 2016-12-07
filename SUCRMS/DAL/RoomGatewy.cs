using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SUCRMS.Models;

namespace SUCRMS.DAL
{
    public class RoomGatewy:CommonGateway
    {
        public List<Room> GetAllRoom()
        {
            List<Room> RoomList = new List<Room>();
            string query = "SELECT * FROM Room";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {

                while (Reader.Read())
                {
                    Room Room = new Room();
                    Room.RoomID = Convert.ToInt32(Reader["RoomId"]);
                    Room.RoomNo = Reader["RoomNo"].ToString();
                    RoomList.Add(Room);
                }
                Reader.Close();
            }
            Connection.Close();
            return RoomList;
        }
    }
}