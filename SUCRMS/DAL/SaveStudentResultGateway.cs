using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SUCRMS.Models;

namespace SUCRMS.DAL
{
    public class SaveStudentResultGateway:CommonGateway
    {
        public int Save(SaveStudentResult saveStudentResult)
        {
            string query = "INSERT INTO Result(CourseId,GradeId,StudentId) VALUES(@CourseId,@GradeId,@StudentId)";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.Clear();
            command.Parameters.Add("@CourseId", SqlDbType.Int);
            command.Parameters["@CourseId"].Value = saveStudentResult.CourseId;

            command.Parameters.Add("@GradeId", SqlDbType.Int);
            command.Parameters["@GradeId"].Value = saveStudentResult.GradeId;

            command.Parameters.Add("@StudentId", SqlDbType.Int);
            command.Parameters["@StudentId"].Value = saveStudentResult.StudentId; 

            Connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;

        }
        public bool IsCourseExist(int studentId, int CourseId)
        {
            string query = "SELECT * FROM Result WHERE StudentId=@StudentId And CourseId=@CourseId";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.Clear();
            command.Parameters.Add("@StudentId", SqlDbType.Int);
            command.Parameters["@StudentId"].Value = studentId;

            command.Parameters.Add("@CourseId", SqlDbType.Int);
            command.Parameters["@CourseId"].Value = CourseId;
            Connection.Open();
            bool isCodeExist = false;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                isCodeExist = true;
            }
            reader.Close();
            Connection.Close();
            return isCodeExist;
        }

    }
}