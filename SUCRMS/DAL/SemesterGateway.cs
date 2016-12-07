using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SUCRMS.Models;

namespace SUCRMS.DAL
{
    public class SemesterGateway : CommonGateway
    {
        public List<Semester> GetAllSemester()
        {
            List<Semester> semesterList = new List<Semester>();
            string query = "SELECT * FROM Semester";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Semester semester = new Semester();
                    semester.Id = Convert.ToInt32(Reader["SemesterId"]);
                    semester.Name = Reader["SemesterName"].ToString();
                    semesterList.Add(semester);
                }
                Reader.Close();
            }
            Connection.Close();
            return semesterList;
        }
    }
}