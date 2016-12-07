using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SUCRMS.Models;

namespace SUCRMS.DAL
{
    public class DesignationGateway:CommonGateway
    {
        public List<Designation> GetAllDesignation()
        {
            List<Designation> designationList = new List<Designation>();
            string query = "SELECT * FROM Designation";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Designation designation = new Designation();
                    designation.Id = Convert.ToInt32(Reader["DesignationId"]);
                    designation.Name = Reader["DesignationName"].ToString();
                    designationList.Add(designation);
                }
                Reader.Close();
            }
            Connection.Close();
            return designationList;
        }

    }
}