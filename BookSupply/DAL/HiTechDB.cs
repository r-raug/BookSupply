using BookSupply.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BookSupply.DAL
{
    public static class HiTechDB
    {

        //this metod save/update an employee record to the database
        public static void SaveRecord(Employee employee)
        {
            //Open DB
            SqlConnection conn = UtilityDB.GetDBConnection();

            //insert operation
            //create and customize an object of type SqlCommand
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = "INSERT INTO Employees (LastName, FirstName, PhoneNumber, Email, JobId) " +
                                    "VALUES (@LastName, @FirstName, @PhoneNumber, @Email, @JobId)";

            cmdInsert.Parameters.AddWithValue("@LastName", employee.LastName);
            cmdInsert.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmdInsert.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            cmdInsert.Parameters.AddWithValue("@Email", employee.Email);
            cmdInsert.Parameters.AddWithValue("@JobId", employee.JobId);

            cmdInsert.ExecuteNonQuery(); //used to insert/update

            //close DB
            conn.Close();
        }




    }
}
