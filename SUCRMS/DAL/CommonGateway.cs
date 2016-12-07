using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace SUCRMS.DAL
{
    public class CommonGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["SUCRMS"].ConnectionString;
        private static SqlConnection connection;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public static SqlConnection Connection
        {
            get { return connection; }

        }

        public static SqlCommand Command
        {
            get { return command; }
            set { command = value; }
        }

        public static SqlDataReader Reader
        {
            get { return reader; }
            set { reader = value; }
        }

        public  CommonGateway()
        {
            connection = new SqlConnection(connectionString);
        }
    }
}