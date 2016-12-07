using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SUCRMS.Models;

namespace SUCRMS.DAL
{
    public class CourseAssignToTeacherGateway:CommonGateway
    {
        public int Save(CourseAssignToTeacher courseAssignToTeacher)
        {
            string query = "INSERT INTO CourseAssigntoTeacher(TeacherId,CourseId,Status) VALUES(@TeacherId,@CourseId,@Status)";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.Clear();
            command.Parameters.Add("@TeacherId", SqlDbType.Int);
            command.Parameters["@TeacherId"].Value = courseAssignToTeacher.TeacherId;

            command.Parameters.Add("@CourseId", SqlDbType.Int);
            command.Parameters["@CourseId"].Value = courseAssignToTeacher.CourseId;

            command.Parameters.Add("@Status", SqlDbType.Int);
            command.Parameters["@Status"].Value = 1;

            Connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public bool IsCourseAssigned(int courseId)
        {
            string query = "SELECT * FROM CourseAssigntoTeacher WHERE CourseId=@CourseId AND Status = 1";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.Clear();
            command.Parameters.Add("@CourseId", SqlDbType.Int);
            command.Parameters["@CourseId"].Value = courseId;

            Connection.Open();
            bool isCourseAssigned = false;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                isCourseAssigned = true;
            }
            reader.Close();
            Connection.Close();
            return isCourseAssigned;
        }

        public int UpdateTeacherRemainCredit(int teacherId, double courseCredit)
        {
            string query = "UPDATE Teacher SET RemainingCredit = (RemainingCredit - @CourseCredit) WHERE TeacherId = @TeacherId;";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.Clear();
            command.Parameters.Add("@CourseCredit", SqlDbType.Decimal);
            command.Parameters["@CourseCredit"].Value = courseCredit;

            command.Parameters.Add("@TeacherId", SqlDbType.Int);
            command.Parameters["@TeacherId"].Value = teacherId;

            Connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public int UnallocationCourseAssignToTeacher(CourseAssignToTeacher courseAssignToTeacher)
        {

            //courseAssign.Status = 1;
            string query = "Update CourseAssigntoTeacher Set Status = 0";

            SqlCommand command = new SqlCommand(query, Connection);
            Connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            Connection.Close();


            string query2 = "Update Teacher Set RemainingCredit = CreditTobeTaken";

            SqlCommand command2 = new SqlCommand(query2, Connection);
            Connection.Open();

            command2.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;

        }
    }
}