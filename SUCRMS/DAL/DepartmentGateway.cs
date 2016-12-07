using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services.Description;
using SUCRMS.Models;

namespace SUCRMS.DAL
{
    public class DepartmentGateway:CommonGateway
    {
        public int Save(Department department)
        {
            string query = "INSERT INTO Department(DepartmentCode,DepartmentName) VALUES(@Code,@Name)";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.Clear();
            command.Parameters.Add("@Code", SqlDbType.VarChar);
            command.Parameters["@Code"].Value = department.Code;

            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters["@Name"].Value = department.Name;

            Connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;

        }

        public bool IsCodeExist(string code)
        {
            string query = "SELECT * FROM Department WHERE DepartmentCode=@Code";
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
            
            string query = "SELECT * FROM Department WHERE DepartmentName=@Name";
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

        public List<Department> GetAllDepartment()
        {
            List<Department> departmentList = new List<Department>();
            string query = "SELECT * FROM Department";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                int serial = 1;
                while (Reader.Read())
                {
                    Department department = new Department();
                    department.Serials = serial;
                    department.Id = Convert.ToInt32(Reader["DepartmentId"]);
                    department.Code = Reader["DepartmentCode"].ToString();
                    department.Name = Reader["DepartmentName"].ToString();
                    
                    departmentList.Add(department);

                    serial++;
                }
                Reader.Close();
            }
            Connection.Close();
            return departmentList;
        }
    }
}