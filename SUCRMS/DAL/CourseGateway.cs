using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SUCRMS.Models;

namespace SUCRMS.DAL
{
    public class CourseGateway:CommonGateway
    {
        public int Save(Course course)
        {
            string query = "INSERT INTO Course(CourseCode,CourseName,CourseCredit,CourseDescription,DepartmentId,SemesterId) VALUES(@Code,@Name,@Credit,@Description,@DepartmentId,@SemesterId)";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.Clear();
            
            command.Parameters.Add("@Code", SqlDbType.VarChar);
            command.Parameters["@Code"].Value = course.Code;

            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters["@Name"].Value = course.Name;

            command.Parameters.Add("@Credit", SqlDbType.Decimal);
            command.Parameters["@Credit"].Value = course.Credit;

            command.Parameters.Add("@Description", SqlDbType.Text);
            command.Parameters["@Description"].Value = course.Description;

            command.Parameters.Add("@DepartmentId", SqlDbType.Int);
            command.Parameters["@DepartmentId"].Value = course.DepartmentId;

            command.Parameters.Add("@SemesterId", SqlDbType.Int);
            command.Parameters["@SemesterId"].Value = course.SemesterId;

            Connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public bool IsCodeExist(string code)
        {
            string query = "SELECT * FROM Course WHERE CourseCode=@Code";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Code", SqlDbType.VarChar);
            command.Parameters["@Code"].Value = code;

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

        public bool IsNameExist(string name)
        {
            string query = "SELECT * FROM Course WHERE CourseName=@Name";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters["@Name"].Value = name;

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

        public List<Course> GetAllCourse()
        {
            List<Course> courseList = new List<Course>();
            string query = "SELECT * FROM Course";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                int serial = 1;
                while (Reader.Read())
                {
                    Course course = new Course();
                    course.Serials = serial;
                    course.Id = Convert.ToInt32(Reader["CourseId"]);
                    course.Code = Reader["CourseCode"].ToString();
                    course.Name = Reader["CourseName"].ToString();
                    course.Credit = Convert.ToDouble(Reader["CourseCredit"]);
                    course.Description = Reader["CourseDescription"].ToString();
                    course.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                    course.SemesterId = Convert.ToInt32(Reader["SemesterId"]);
                    courseList.Add(course);

                    serial++;
                }
                Reader.Close();
            }
            Connection.Close();
            return courseList;
        }

        public List<Course> GetCourseInfoByDepartmentId(int departmentId)
        {
            List<Course> courseList = new List<Course>();
            string query = "SELECT Course.CourseId, Course.CourseCode, Course.CourseName, Semester.SemesterName, CASE WHEN Teacher.TeacherName is null THEN 'Not Assigned Yet' ELSE Teacher.TeacherName END AS TeacherName FROM Course LEFT JOIN Semester ON Semester.SemesterId = Course.SemesterId LEFT JOIN CourseAssigntoTeacher ON Course.CourseId = CourseAssigntoTeacher.CourseId LEFT JOIN Teacher ON Teacher.TeacherId = CourseAssigntoTeacher.TeacherId WHERE Course.DepartmentId = @DepartmentId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("@DepartmentId", SqlDbType.Int);
            Command.Parameters["@DepartmentId"].Value = departmentId;
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                int serial = 1;
                while (Reader.Read())
                {
                    Course course = new Course();

                    course.Id = Convert.ToInt32(Reader["CourseId"]);
                    course.Code = Reader["CourseCode"].ToString();
                    course.Name = Reader["CourseName"].ToString();
                    course.Semester = Reader["SemesterName"].ToString();
                    course.TeacherName = Reader["TeacherName"].ToString();
                    course.Serials = serial;

                    courseList.Add(course);

                    serial++;
                }
                Reader.Close();
            }
            Connection.Close();
            return courseList;
        }
    }
}