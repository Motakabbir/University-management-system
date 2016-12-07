using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SUCRMS.Models;

namespace SUCRMS.DAL
{
    public class GradeGateway:CommonGateway
    {
        public List<Grade> GetAllGrade()
        {
            List<Grade> gradeList = new List<Grade>();
            string query = "SELECT * FROM Grade";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Grade grade = new Grade();
                    grade.Id = Convert.ToInt32(Reader["GradeId"]);
                    grade.Name = Reader["Grade"].ToString();
                    gradeList.Add(grade);
                }
                Reader.Close();
            }
            Connection.Close();
            return gradeList;
        }
    }
}