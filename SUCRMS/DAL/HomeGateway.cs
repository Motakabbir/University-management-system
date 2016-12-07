using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SUCRMS.Models;

namespace SUCRMS.DAL
{
    public class HomeGateway:CommonGateway
    {
        public int CountDepartment()
        {
            int countDepartment = 0;
            string query = "SELECT COUNT(Department.DepartmentId) AS CountDepartment From Department";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    countDepartment = Convert.ToInt32(Reader["CountDepartment"]);
                }
                Reader.Close();
            }
            Connection.Close();
            return countDepartment;
        }

        public int CountStudent()
        {
            int countStudent = 0;
            string query = "SELECT COUNT(Student.StudentId) AS CountStudent From Student";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    countStudent = Convert.ToInt32(Reader["CountStudent"]);
                }
                Reader.Close();
            }
            Connection.Close();
            return countStudent;
        }

        public int CountTeacher()
        {
            int countTeacher = 0;
            string query = "SELECT COUNT(Teacher.TeacherId) AS CountTeacher From Teacher";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    countTeacher = Convert.ToInt32(Reader["CountTeacher"]);
                }
                Reader.Close();
            }
            Connection.Close();
            return countTeacher;
        }

        public int CountCourse()
        {
            int countCourse = 0;
            string query = "SELECT COUNT(Course.CourseId) AS CountCourse From Course";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    countCourse = Convert.ToInt32(Reader["CountCourse"]);
                }
                Reader.Close();
            }
            Connection.Close();
            return countCourse;
        }
    }
}