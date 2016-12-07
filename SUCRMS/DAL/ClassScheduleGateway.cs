using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SUCRMS.Models;

namespace SUCRMS.DAL
{
    public class ClassScheduleGateway:CommonGateway
    {
        public List<ClassSchedule> GetScheduleByDepartmentId(int departmentId)
        {
            List<ClassSchedule> classScheduleList = new List<ClassSchedule>();

            string query = "SELECT Course.CourseId, Course.CourseCode, Course.CourseName, Room.RoomNo, Day.Day, CONVERT(varchar(15), CAST(t1.TimeFrom AS TIME),100) AS TimeFrom, CONVERT(varchar(15), CAST(t1.TimeTo AS TIME),100) AS TimeTo FROM Course LEFT JOIN (SELECT * FROM AllocateClassrooms WHERE AllocateClassrooms.Status = 1) AS t1 ON Course.CourseId = t1.CourseId LEFT JOIN Room ON Room.RoomId = t1.RoomId LEFT JOIN Day ON Day.DayId = t1.DayId WHERE Course.DepartmentId = @DepartmentId ORDER BY Course.CourseId";

            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("@DepartmentId", SqlDbType.Int);
            Command.Parameters["@DepartmentId"].Value = departmentId;
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    ClassSchedule classSchedule = new ClassSchedule();

                    classSchedule.CourseId = Convert.ToInt32(Reader["CourseId"]);
                    classSchedule.CourseCode = Reader["CourseCode"].ToString();
                    classSchedule.CourseName = Reader["CourseName"].ToString();
                    classSchedule.RoomNo = Reader["RoomNo"].ToString();
                    classSchedule.Day = Reader["Day"].ToString();
                    classSchedule.TimeFrom = Reader["TimeFrom"].ToString();
                    classSchedule.TimeTo = Reader["TimeTo"].ToString();

                    classScheduleList.Add(classSchedule);
                }
                Reader.Close();
            }
            Connection.Close();
            return classScheduleList;
        }
    }
}