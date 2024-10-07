using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSupply.DAL
{
    public static class UtilityDB
    {

        /// <summary>
        /// This method returns an active DB Connection
        /// </summary>
        /// Version : 1.1
        /// <returns>conn</returns>

        public static SqlConnection GetDBConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            conn.Open();
            return conn;
        }
        

    }
}
