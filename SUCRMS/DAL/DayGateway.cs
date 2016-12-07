using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SUCRMS.Models;

namespace SUCRMS.DAL
{
    public class DayGateway:CommonGateway
    {
        public List<Day> GetAllDay()
        {
            List<Day> DayList = new List<Day>();
            string query = "SELECT * FROM Day";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
               
                while (Reader.Read())
                {
                    Day Day = new Day();
                    Day.DayId = Convert.ToInt32(Reader["DayId"]);
                    Day.DayName = Reader["Day"].ToString();
                    DayList.Add(Day);
                }
                Reader.Close();
            }
            Connection.Close();
            return DayList;
        }
    }
}