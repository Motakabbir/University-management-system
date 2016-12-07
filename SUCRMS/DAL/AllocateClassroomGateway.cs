using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SUCRMS.Models;

namespace SUCRMS.DAL
{
    public class AllocateClassroomGateway:CommonGateway
    {
        public int Save(AllocateClassroom allocateClassroom)
        {
            string from = allocateClassroom.TimeFrom.ToShortTimeString();
            string to = allocateClassroom.TimeTo.ToShortTimeString();

            string query = "INSERT INTO AllocateClassrooms(CourseId,RoomId,DayId,TimeFrom,TimeTo,Status) VALUES(@CourseId,@RoomId,@DayId,'"+from+"','"+to+"',@Status)";
            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.Clear();

            command.Parameters.Add("@CourseId", SqlDbType.VarChar);
            command.Parameters["@CourseId"].Value = allocateClassroom.CourseId;

            command.Parameters.Add("@RoomId", SqlDbType.VarChar);
            command.Parameters["@RoomId"].Value = allocateClassroom.RoomId;

            command.Parameters.Add("@DayId", SqlDbType.VarChar);
            command.Parameters["@DayId"].Value = allocateClassroom.DayId;

            command.Parameters.Add("@Status", SqlDbType.VarChar);
            command.Parameters["@Status"].Value = 1;

            Connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            Connection.Close();

            return rowsAffected;
        }

        public bool IsScheduleExist(DateTime timeFrom, DateTime timeTo)
        {
            bool isScheduleExist = false;
            string from = timeFrom.ToShortTimeString();
            string to = timeTo.ToShortTimeString();

            string query = "SELECT * FROM AllocateClassrooms WHERE TimeFrom > = '" + from + "' AND TimeFrom <= '" + to + "' AND Status = 1";
            SqlCommand command = new SqlCommand(query, Connection);

            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                isScheduleExist = true;
            }
            reader.Close();
            Connection.Close();
            return isScheduleExist;
        }

        public int UnallocationClassRoomGetway(AllocateClassroom allocateClassroom)
        {
           
            //courseAssign.Status = 1;
            string query = "Update AllocateClassrooms Set [Status]=0";

            SqlCommand command = new SqlCommand(query, Connection);
            Connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;

        }
    }
}