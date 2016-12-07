using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SUCRMS.Models;

namespace SUCRMS.DAL
{
    public class StudentGateway:CommonGateway
    {
        public string Save(Student student)
        {
            int rowsAffected = 0;

            string registrationNo = GenerateRegistrationNo(student);

            if (registrationNo != null)
            {
                string query = "INSERT INTO Student(StudentName,StudentEmail,StudentContactNo,Date,StudentAddress,RegistrationId,DepartmentId) VALUES(@Name,@Email,@ContactNo,@Date,@Address,@RegistrationId,@DepartmentId)";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.Clear();

                command.Parameters.Add("@Name", SqlDbType.VarChar);
                command.Parameters["@Name"].Value = student.Name;

                command.Parameters.Add("@Email", SqlDbType.VarChar);
                command.Parameters["@Email"].Value = student.Email;

                command.Parameters.Add("@ContactNo", SqlDbType.Decimal);
                command.Parameters["@ContactNo"].Value = student.ContactNo;

                command.Parameters.Add("@Date", SqlDbType.Date);
                command.Parameters["@Date"].Value = student.Date;

                command.Parameters.Add("@Address", SqlDbType.Text);
                command.Parameters["@Address"].Value = student.Address;

                command.Parameters.Add("@RegistrationId", SqlDbType.VarChar);
                command.Parameters["@RegistrationId"].Value = registrationNo;

                command.Parameters.Add("@DepartmentId", SqlDbType.Int);
                command.Parameters["@DepartmentId"].Value = student.DepartmentId;

                Connection.Open();

                rowsAffected = command.ExecuteNonQuery();
                Connection.Close();
                //return rowsAffected;
            }
            return registrationNo;
        }

        public string GenerateRegistrationNo(Student student)
        {
            int departmentId = student.DepartmentId;
            string departmentCode = null;
            string count = null;
            int cnt = 0;
            DateTime date = student.Date;
            int year = Convert.ToInt32(date.Year);


            //Geting Department Code 
            string query = "SELECT DepartmentCode FROM Department WHERE DepartmentId = @DepartmentId";
            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.Clear();

            command.Parameters.Add("@DepartmentId", SqlDbType.Int);
            command.Parameters["@DepartmentId"].Value = departmentId;

            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    departmentCode = reader["DepartmentCode"].ToString();
                }
            }
            reader.Close();
            Connection.Close();


            //Get Registration Count Value
            string query2 = "SELECT COUNT(Student.StudentId) AS Count FROM Student WHERE YEAR(Student.Date) = "+year+" AND Student.DepartmentId = @DepartmentId";

            SqlCommand command2 = new SqlCommand(query2, Connection);

            command2.Parameters.Clear();

            command2.Parameters.Add("@DepartmentId", SqlDbType.Int);
            command2.Parameters["@DepartmentId"].Value = departmentId;

            Connection.Open();
            SqlDataReader reader2 = command2.ExecuteReader();

            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    cnt = Convert.ToInt32(reader2["Count"]);
                }
            }
            reader2.Close();
            Connection.Close();

            cnt = cnt + 1;
            count = cnt.ToString();

            if (count.Length == 1)
            {
                count = "00" + count;
            }
            else if (count.Length == 2)
            {
                count = "0" + count;
            }

            string registrationNo = departmentCode + "-" + year + "-" + count;

            return registrationNo;
        }

        public bool IsEmailExist(string email)
        {
            bool isEmailExist = false;
            string query = "SELECT * FROM Student WHERE StudentEmail=@Email";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Email", SqlDbType.VarChar);
            command.Parameters["@Email"].Value = email;

            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                isEmailExist = true;
            }
            reader.Close();
            Connection.Close();
            return isEmailExist;
        }

        public List<Student> GetAllStudent()
        {
            List<Student> studentList = new List<Student>();
            string query = "SELECT * FROM Student";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(Reader["StudentId"]);
                    student.Name = Reader["StudentName"].ToString();
                    student.Email = Reader["StudentEmail"].ToString();
                    student.ContactNo = Convert.ToDouble(Reader["StudentContactNo"]);
                    student.Date = Convert.ToDateTime(Reader["Date"]);
                    student.Address = Reader["StudentAddress"].ToString();
                    student.RegistrationId = Reader["RegistrationId"].ToString();
                    student.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                    studentList.Add(student);
                }
                Reader.Close();
            }
            Connection.Close();
            return studentList;
        }
    }
}