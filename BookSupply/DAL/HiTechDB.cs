using BookSupply.BLL;
using System;
using System.Collections.Generic;
using System.Data;
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


        //this method list all records from the table Employees
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> listE = new List<Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader(); //execute command that are in cmdSelectAll
            Employee employee;

            //Do a loop to list all records
            while (reader.Read())
            {
                employee = new Employee(                
                reader["FirstName"].ToString(),
                reader["LastName"].ToString(),
                reader["Email"].ToString(),
                Convert.ToInt64(reader["PhoneNumber"]),
                Convert.ToInt32(reader["JobId"])
                );
                employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                listE.Add(employee);
            }
            //close DB and return records
            conn.Close();
            return listE;
        }

        //this method search an employee by ID
        public static Employee SearchEmployee(int empID)
        {
            Employee employee = new Employee();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearchID = new SqlCommand();
            cmdSearchID.Connection = conn;
            cmdSearchID.CommandText = "SELECT * FROM Employees " +
                                      "WHERE EmployeeId = @EmployeeId";
            cmdSearchID.Parameters.AddWithValue("@EmployeeId", empID);
            SqlDataReader reader = cmdSearchID.ExecuteReader();
            if(reader.Read()) //found
            {
                employee.FirstName = reader["FirstName"].ToString();
                employee.LastName = reader["LastName"].ToString();
                employee.Email = reader["Email"].ToString();
                employee.PhoneNumber = Convert.ToInt32(reader["PhoneNumber"]);
                employee.JobId = Convert.ToInt32(reader["JobId"]);
            }
            else
            {
                employee = null;
            }

            //close DV and return employee
            conn.Close();
            return employee;
        }


    }
}
