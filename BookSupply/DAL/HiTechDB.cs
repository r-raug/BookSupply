using BookSupply.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookSupply.GUI;
using System.Threading;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq.Expressions;
using System.Media;

namespace BookSupply.DAL
{
    public static class HiTechDB
    {
        // This method saves or updates an employee record in the database
        public static void SaveRecordEmployee(Emp employee)
        {
            // Open database connection
            SqlConnection conn = UtilityDB.GetDBConnection();

            // Insert operation
            // Create and customize a SqlCommand object
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = "INSERT INTO Employees (LastName, FirstName, PhoneNumber, Email, JobId, StatusId) " +
                                    "VALUES (@LastName, @FirstName, @PhoneNumber, @Email, @JobId, @StatusId)";

            // Add parameters to the command
            cmdInsert.Parameters.AddWithValue("@LastName", employee.LastName);
            cmdInsert.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmdInsert.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            cmdInsert.Parameters.AddWithValue("@Email", employee.Email);
            cmdInsert.Parameters.AddWithValue("@JobId", employee.JobId);
            cmdInsert.Parameters.AddWithValue("@StatusId", employee.StatusId);

            cmdInsert.ExecuteNonQuery(); // Execute insert/update operation

            // Close database connection
            conn.Close();
        }

        // This method saves or updates a user record in the database
        public static void SaveRecordUser(User user, int empID)
        {
            // Open database connection
            SqlConnection conn = UtilityDB.GetDBConnection();

            // Create a command to search for an employee ID
            SqlCommand cmdSearchEmployee = new SqlCommand();
            cmdSearchEmployee.Connection = conn;
            cmdSearchEmployee.CommandText = "SELECT * FROM Employees " +
                                                  "WHERE EmployeeId = @EmployeeId";
            cmdSearchEmployee.Parameters.AddWithValue("@EmployeeId", empID);

            // Execute the command
            SqlDataReader employeeReader = cmdSearchEmployee.ExecuteReader();

            // If the employee ID exists in the database
            if (employeeReader.Read())
            {
                // Retrieve the job ID of the employee
                int jobID = Convert.ToInt32(employeeReader["JobId"]);
                employeeReader.Close();

                // Create a command to search for the user
                SqlCommand cmdSearchUser = new SqlCommand();
                cmdSearchUser.Connection = conn;
                cmdSearchUser.CommandText = "SELECT COUNT(*) FROM UserAccounts " +
                                          "WHERE EmployeeId = @EmployeeId";
                cmdSearchUser.Parameters.AddWithValue("@EmployeeId", empID);
                int count = Convert.ToInt32(cmdSearchUser.ExecuteScalar());

                // Check if the user already exists
                if (count > 0)
                {
                    MessageBox.Show("User already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Create a command to insert the user
                    SqlCommand cmdInsert = new SqlCommand();
                    cmdInsert.Connection = conn;
                    cmdInsert.CommandText = "INSERT INTO UserAccounts (Username, Password, EmployeeId, JobId, StatusId) " +
                                        "VALUES (@Username, @Password, @EmployeeId, @JobId, @StatusId)";
                    cmdInsert.Parameters.AddWithValue("@Username", user.UserName);
                    cmdInsert.Parameters.AddWithValue("@Password", user.Password);
                    cmdInsert.Parameters.AddWithValue("@EmployeeId", user.EmployeeId);
                    cmdInsert.Parameters.AddWithValue("@JobId", jobID);
                    cmdInsert.Parameters.AddWithValue("@StatusId", user.StatusId);
                    cmdInsert.ExecuteNonQuery(); // Execute insert/update operation
                }
            }
            else
            {
                MessageBox.Show("Employee ID not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Close database connection
            conn.Close();
        }

        // This method retrieves all records from the Employees table
        public static List<Emp> GetAllEmployees()
        {
            List<Emp> listE = new List<Emp>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader(); // Execute the command
            Emp employee;

            // Loop through all records
            while (reader.Read())
            {
                // Create employee object and add it to the list
                employee = new Emp(
                    reader["FirstName"].ToString(),
                    reader["LastName"].ToString(),
                    reader["Email"].ToString(),
                    Convert.ToInt64(reader["PhoneNumber"]),
                    Convert.ToInt32(reader["JobId"]),
                    Convert.ToInt32(reader["StatusId"])
                );
                employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                listE.Add(employee);
            }

            // Close database connection and return records
            conn.Close();
            return listE;
        }

        // This method retrieves all records from the UserAccounts table
        public static List<User> GetAllUsers()
        {
            List<User> listE = new List<User>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM UserAccounts", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader(); // Execute the command
            User user;

            // Loop through all records
            while (reader.Read())
            {
                // Create user object and add it to the list
                user = new User(
                    Convert.ToInt16(reader["UserId"]),
                    reader["UserName"].ToString(),
                    Convert.ToInt32(reader["EmployeeId"]),
                    Convert.ToInt16(reader["JobId"]),
                    Convert.ToInt16(reader["StatusId"])
                );

                listE.Add(user);
            }

            // Close database connection and return records
            conn.Close();
            return listE;
        }

        // This method searches for an employee
        public static List<Emp> SearchEmployee(string search, string column)
        {
            List<Emp> employees = new List<Emp>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearchID = new SqlCommand();
            cmdSearchID.Connection = conn;
            cmdSearchID.CommandText = "SELECT * FROM Employees " +
                                      "WHERE " + column + " LIKE @Search";
            cmdSearchID.Parameters.AddWithValue("@Search", "%" + search + "%");

            // Execute the command and read the result
            using (SqlDataReader reader = cmdSearchID.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Create employee object and add it to the list
                    Emp employee = new Emp();
                    employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    employee.FirstName = reader["FirstName"].ToString();
                    employee.LastName = reader["LastName"].ToString();
                    employee.Email = reader["Email"].ToString();
                    employee.PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]);
                    employee.JobId = Convert.ToInt16(reader["JobId"]);
                    employee.StatusId = Convert.ToInt16(reader["StatusId"]);

                    employees.Add(employee);
                }
            }

            return employees;
        }

        // This method searches for a user
        public static List<User> SearchUser(string search, string column)
        {
            List<User> users = new List<User>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearchID = new SqlCommand();
            cmdSearchID.Connection = conn;
            cmdSearchID.CommandText = "SELECT * FROM UserAccounts " +
                                      "WHERE " + column + " LIKE @Search";
            cmdSearchID.Parameters.AddWithValue("@Search", "%" + search + "%");

            // Execute the command and read the result
            using (SqlDataReader reader = cmdSearchID.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Create user object and add it to the list
                    User user = new User();
                    user.UserId = Convert.ToInt32(reader["UserId"]);
                    user.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    user.UserName = reader["UserName"].ToString();
                    user.JobId = Convert.ToInt16(reader["JobId"]);
                    user.StatusId = Convert.ToInt16(reader["StatusId"]);
                    users.Add(user);
                }
            }

            return users;
        }

        // This method searches for an employee using first name and last name
        public static List<Emp> SearchEmployee(string fname, string lname, string column1, string column2)
        {
            List<Emp> employees = new List<Emp>();

            try
            {
                using (SqlConnection conn = UtilityDB.GetDBConnection())
                {
                    conn.Open();

                    SqlCommand cmdSearchID = new SqlCommand();
                    cmdSearchID.Connection = conn;
                    cmdSearchID.CommandText = "SELECT * FROM Employees " +
                                              "WHERE " + column1 + " LIKE @Fname AND " + column2 + " LIKE @Lname";
                    cmdSearchID.Parameters.AddWithValue("@Fname", "%" + fname + "%");
                    cmdSearchID.Parameters.AddWithValue("@Lname", "%" + lname + "%");

                    // Execute the command and read the result
                    using (SqlDataReader reader = cmdSearchID.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create employee object and add it to the list
                            Emp employee = new Emp();
                            employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                            employee.FirstName = reader["FirstName"].ToString();
                            employee.LastName = reader["LastName"].ToString();
                            employee.Email = reader["Email"].ToString();
                            employee.PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]);
                            employee.JobId = Convert.ToInt16(reader["JobId"]);
                            employee.StatusId = Convert.ToInt16(reader["StatusId"]);

                            employees.Add(employee);
                        }
                    }

                    conn.Close(); // Close database connection
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching employees: " + ex.Message);
            }

            return employees;
        }

        // This method searches for a job title using the job ID
        public static String SearchJob(int jobID)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearchID = new SqlCommand();
            cmdSearchID.Connection = conn;
            cmdSearchID.CommandText = "SELECT * FROM Jobs " +
                                      "WHERE JobId = @JobId";
            cmdSearchID.Parameters.AddWithValue("@JobId", jobID);
            SqlDataReader reader = cmdSearchID.ExecuteReader();
            if (reader.Read()) // If found
            {
                return reader["JobTitle"].ToString();
            }
            conn.Close();

            return "Not found";

        }

        // This method searches for a status description using the status ID
        public static String SearchStatus(int statusID)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearchID = new SqlCommand();
            cmdSearchID.Connection = conn;
            cmdSearchID.CommandText = "SELECT * FROM Statuses " +
                                      "WHERE StatusId = @StatusId";
            cmdSearchID.Parameters.AddWithValue("@StatusId", statusID);
            SqlDataReader reader = cmdSearchID.ExecuteReader();
            if (reader.Read()) // If found
            {
                return reader["Description"].ToString();
            }
            conn.Close();

            return "Not found";
        }

        // This method updates an employee record in the database
        public static void UpdateEmployee(Emp employeeUpdate)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandText = "UPDATE Employees " +
                                        "SET FirstName = @FirstName, " +
                                        "LastName = @LastName, " +
                                        "PhoneNumber = @PhoneNumber, " +
                                        "Email = @Email, " +
                                        "JobId = @JobId, " +
                                        "StatusId = @StatusId " +
                                        "WHERE EmployeeId = @EmployeeId";

                cmdUpdate.Parameters.AddWithValue("@FirstName", employeeUpdate.FirstName);
                cmdUpdate.Parameters.AddWithValue("@LastName", employeeUpdate.LastName);
                cmdUpdate.Parameters.AddWithValue("@PhoneNumber", employeeUpdate.PhoneNumber);
                cmdUpdate.Parameters.AddWithValue("@Email", employeeUpdate.Email);
                cmdUpdate.Parameters.AddWithValue("@JobId", employeeUpdate.JobId);
                cmdUpdate.Parameters.Add("@StatusId", SqlDbType.Int).Value = employeeUpdate.StatusId;
                cmdUpdate.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeUpdate.EmployeeId;
                cmdUpdate.ExecuteNonQuery();
            }
        }

        // This method updates a user record in the database
        public static void UpdateUser(User userUpdate)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                if (IsUniqueId("UserAccounts", "UserId", userUpdate.EmployeeId) == true)
                {
                    MessageBox.Show("Employee ID not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandText = "UPDATE UserAccounts " +
                                        "SET UserName = @UserName, " +
                                        "Password = @Password, " +
                                        "StatusId = @StatusId " +
                                        "WHERE EmployeeId = @EmployeeId";
                cmdUpdate.Parameters.AddWithValue("@UserName", userUpdate.UserName);
                cmdUpdate.Parameters.AddWithValue("@Password", userUpdate.Password);
                cmdUpdate.Parameters.Add("@StatusId", SqlDbType.Int).Value = userUpdate.StatusId;
                cmdUpdate.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = userUpdate.EmployeeId;
                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("User updated successfully.", "Confirmation");
            }
        }

        // This method checks if a given ID is unique in a table
        public static bool IsUniqueId(string table, string column, int eID)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearchID = new SqlCommand();
            cmdSearchID.Connection = conn;
            cmdSearchID.CommandText = "SELECT * FROM " + table + " " +
                                      "WHERE " + column + " = @ID";
            cmdSearchID.Parameters.AddWithValue("@ID", eID);
            SqlDataReader reader = cmdSearchID.ExecuteReader();
            if (reader.Read()) // If found
            {
                return true;
            }
            conn.Close();
            Console.WriteLine(reader.ToString());
            return false;
        }

        // This method deletes a record from the specified table based on ID
        public static void Delete(string table, string column, int id, int status)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandText = "UPDATE " + table + " " +
                                        "SET StatusId = @StatusId " +
                                        "WHERE " + column + " = @ID";
                cmdUpdate.Parameters.AddWithValue("@StatusId", status);
                cmdUpdate.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                cmdUpdate.ExecuteNonQuery();
            }
        }

        // This method performs user login authentication
        public static void LoginUser(Login login)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = conn;
            cmdLogin.CommandText = "SELECT * FROM UserAccounts " +
                                  "WHERE Username = @Username AND Password = @Password";
            cmdLogin.Parameters.AddWithValue("@Username", login.UserName);
            cmdLogin.Parameters.AddWithValue("@Password", login.Password);
            SqlDataReader reader = cmdLogin.ExecuteReader();
            if (reader.Read())
            {
                login.JobId = reader["JobId"].ToString();
            }
            else
            {
                login.JobId = "0";
            }
            conn.Close();
        }
    }
}
