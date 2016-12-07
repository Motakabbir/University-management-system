using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SUCRMS.Models;
using ViewResult = System.Web.Mvc.ViewResult;

namespace SUCRMS.DAL
{
    public class EnrollCourseGateway:CommonGateway
    {
        public int Save(EnrollCourse enrollCourse)
        {
            string query = "INSERT INTO EnrollCourse(StudenId,CourseId,Date,Status) VALUES(@StudenId,@CourseId,@Date,1)";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.Clear();
            command.Parameters.Add("@StudenId", SqlDbType.Int);
            command.Parameters["@StudenId"].Value = enrollCourse.StudenId;

            command.Parameters.Add("@CourseId", SqlDbType.Int);
            command.Parameters["@CourseId"].Value = enrollCourse.CourseId;

            command.Parameters.Add("@Date", SqlDbType.Date);
            command.Parameters["@Date"].Value = enrollCourse.Date;

            Connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;

        }
        public bool IsCourseExist(int studentId, int CourseId)
        {
            string query = "SELECT * FROM EnrollCourse WHERE StudenId=@StudenId And CourseId=@CourseId";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.Clear();
            command.Parameters.Add("@StudenId", SqlDbType.Int);
            command.Parameters["@StudenId"].Value = studentId;

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

        public bool IsCourseEnrolled(int studentId, int courseId)
        {
            string query = "SELECT * FROM EnrollCourse WHERE StudenId = @StudenId AND CourseId = @CourseId";
            Command = new SqlCommand(query, Connection);
            
            Command.Parameters.Clear();

            Command.Parameters.Add("@StudenId", SqlDbType.Int);
            Command.Parameters["@StudenId"].Value = studentId;

            Command.Parameters.Add("@CourseId", SqlDbType.Int);
            Command.Parameters["@CourseId"].Value = courseId;

            Connection.Open();
            bool IsCourseEnrolled = false;
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                IsCourseEnrolled = true;
            }
            reader.Close();
            Connection.Close();
            return IsCourseEnrolled;
        }

        public List<ResultView> GetAllResult()
        {
            List<ResultView> resultList = new List<ResultView>();
            string query = "SELECT EnrollCourse.StudenId, Course.CourseCode, Course.CourseName, Grade.Grade FROM EnrollCourse LEFT JOIN Result ON Result.StudentId = EnrollCourse.StudenId LEFT JOIN Course ON Course.CourseId = EnrollCourse.CourseId LEFT JOIN Grade ON Grade.GradeId = Result.GradeId WHERE EnrollCourse.Status = 1";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    ResultView resultView = new ResultView();
                    resultView.StudenId = Convert.ToInt32(Reader["StudenId"]);
                    resultView.CourseCode = Reader["CourseCode"].ToString();
                    resultView.CourseName = Reader["CourseName"].ToString();
                    resultView.Grade = Reader["Grade"].ToString();

                    resultList.Add(resultView);
                }
                Reader.Close();
            }
            Connection.Close();
            return resultList;
        }
    }
}