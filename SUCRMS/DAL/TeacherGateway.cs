using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SUCRMS.Models;

namespace SUCRMS.DAL
{
    public class TeacherGateway:CommonGateway
    {
        public int Save(Teacher teacher)
        {
            string query = "INSERT INTO Teacher(TeacherName,TeacherAddress,TeacherEmail,TeacherContactNo,DesignationId,DepartmentId,CreditTobeTaken,RemainingCredit) VALUES(@Name,@Address,@Email,@ContactNo,@DesignationId,@DepartmentId,@CreditTobeTaken,@RemainingCredit)";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.Clear();

            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters["@Name"].Value = teacher.Name;

            command.Parameters.Add("@Address", SqlDbType.Text);
            command.Parameters["@Address"].Value = teacher.Address;

            command.Parameters.Add("@Email", SqlDbType.VarChar);
            command.Parameters["@Email"].Value = teacher.Email;

            command.Parameters.Add("@ContactNo", SqlDbType.Decimal);
            command.Parameters["@ContactNo"].Value = teacher.ContactNo;

            command.Parameters.Add("@DesignationId", SqlDbType.Int);
            command.Parameters["@DesignationId"].Value = teacher.DesignationId;

            command.Parameters.Add("@DepartmentId", SqlDbType.Int);
            command.Parameters["@DepartmentId"].Value = teacher.DepartmentId;

            command.Parameters.Add("@CreditTobeTaken", SqlDbType.Decimal);
            command.Parameters["@CreditTobeTaken"].Value = teacher.CreditTobeTaken;

            command.Parameters.Add("@RemainingCredit", SqlDbType.Decimal);
            command.Parameters["@RemainingCredit"].Value = teacher.CreditTobeTaken;

            Connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public bool IsEmailExist(string email)
        {
            string query = "SELECT * FROM Teacher WHERE TeacherEmail=@Email";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Email", SqlDbType.VarChar);
            command.Parameters["@Email"].Value = email;

            Connection.Open();
            bool isEmailExist = false;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                isEmailExist = true;
            }
            reader.Close();
            Connection.Close();
            return isEmailExist;
        }

        public List<Teacher> GetAllTeacher()
        {
            List<Teacher> teacherList = new List<Teacher>();
            string query = "SELECT * FROM Teacher";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                int serial = 1;
                while (Reader.Read())
                {
                    Teacher teacher = new Teacher();
                    teacher.Serials = serial;
                    teacher.Id = Convert.ToInt32(Reader["TeacherId"]);
                    teacher.Name = Reader["TeacherName"].ToString();
                    teacher.Address = Reader["TeacherAddress"].ToString();
                    teacher.Email = Reader["TeacherEmail"].ToString();
                    teacher.ContactNo = Convert.ToDouble(Reader["TeacherContactNo"]);
                    teacher.DesignationId = Convert.ToInt32(Reader["DesignationId"]);
                    teacher.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                    teacher.CreditTobeTaken = Convert.ToDouble(Reader["CreditTobeTaken"]);
                    teacher.RemainingCredit = Convert.ToDouble(Reader["RemainingCredit"]);
                    teacherList.Add(teacher);

                    serial++;
                }
                Reader.Close();
            }
            Connection.Close();
            return teacherList;
        }
       
    }
}