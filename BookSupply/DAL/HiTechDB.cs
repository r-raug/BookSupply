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

        //this method save/update an employee record to the database
        public static void SaveRecordEmployee(Employee employee)
        {
            //Open DB
            SqlConnection conn = UtilityDB.GetDBConnection();

            //insert operation
            //create and customize an object of type SqlCommand
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = "INSERT INTO Employees (LastName, FirstName, PhoneNumber, Email, JobId, StatusId) " +
                                    "VALUES (@LastName, @FirstName, @PhoneNumber, @Email, @JobId, @StatusId)";

            cmdInsert.Parameters.AddWithValue("@LastName", employee.LastName);
            cmdInsert.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmdInsert.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            cmdInsert.Parameters.AddWithValue("@Email", employee.Email);
            cmdInsert.Parameters.AddWithValue("@JobId", employee.JobId);
            cmdInsert.Parameters.AddWithValue("@StatusId", employee.StatusId);

            cmdInsert.ExecuteNonQuery(); //used to insert/update

            //close DB
            conn.Close();
        }

        //this method save/update an user record to the database
        public static void SaveRecordUser(User user, int empID)
        {
            //Open DB
            SqlConnection conn = UtilityDB.GetDBConnection();

            
            //create and customize an object of type SqlCommand for search an ID            
            SqlCommand cmdSearchEmployee = new SqlCommand();
            cmdSearchEmployee.Connection = conn;
            cmdSearchEmployee.CommandText = "SELECT * FROM Employees " +
                                                  "WHERE EmployeeId = @EmployeeId";
            cmdSearchEmployee.Parameters.AddWithValue("@EmployeeId", empID);
            
            
            
            SqlDataReader employeeReader = cmdSearchEmployee.ExecuteReader();
            if (employeeReader.Read()) //If ID exist in the database
            {
                int jobID = Convert.ToInt32(employeeReader["JobId"]);
                employeeReader.Close();
                

                SqlCommand cmdSearchUser = new SqlCommand();
                cmdSearchUser.Connection = conn;
                cmdSearchUser.CommandText = "SELECT COUNT(*) FROM UserAccounts " +
                                          "WHERE EmployeeId = @EmployeeId";
                cmdSearchUser.Parameters.AddWithValue("@EmployeeId", empID);
                int count = Convert.ToInt32(cmdSearchUser.ExecuteScalar());
                //verify if the user already exist
                if (count > 0)
                {
                    MessageBox.Show("User already exist.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else {
                    //create and customize an object of type SqlCommand for insert
                    
                    SqlCommand cmdInsert = new SqlCommand();
                    cmdInsert.Connection = conn;
                    cmdInsert.CommandText = "INSERT INTO UserAccounts (Username, Password, EmployeeId, JobId, StatusId) " +
                                        "VALUES (@Username, @Password, @EmployeeId, @JobId, @StatusId)";
                    cmdInsert.Parameters.AddWithValue("@Username", user.UserName);
                    cmdInsert.Parameters.AddWithValue("@Password", user.Password);
                    cmdInsert.Parameters.AddWithValue("@EmployeeId", user.EmployeeId);
                    cmdInsert.Parameters.AddWithValue("@JobId", jobID);
                    cmdInsert.Parameters.AddWithValue("@StatusId", user.StatusId);
                    cmdInsert.ExecuteNonQuery(); //used to insert/update
                }
            }
            else
            {
                MessageBox.Show("Employee ID not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                Convert.ToInt32(reader["JobId"]),
                Convert.ToInt32(reader["StatusId"])
                );
                employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                listE.Add(employee);
            }
            //close DB and return records
            conn.Close();
            return listE;
        }

        //this method list all records from the table Users
        public static List<User> GetAllUsers()
        {
            List<User> listE = new List<User>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM UserAccounts", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader(); //execute command that are in cmdSelectAll
            User user;

            //Do a loop to list all records
            while (reader.Read())
            {
                user = new User(
                Convert.ToInt16(reader["UserId"]),
                reader["UserName"].ToString(),
                Convert.ToInt32(reader["EmployeeId"]),
                Convert.ToInt16(reader["JobId"]),
                Convert.ToInt16(reader["StatusId"])
                );
                
                listE.Add(user);
            }
            //close DB and return records
            conn.Close();
            return listE;
        }

        //this method search an employee
        public static List<Employee> SearchEmployee(string search, string column)
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearchID = new SqlCommand();
            cmdSearchID.Connection = conn;
            cmdSearchID.CommandText = "SELECT * FROM Employees " +
                                  "WHERE " + column + " LIKE @Search";
            cmdSearchID.Parameters.AddWithValue("@Search", "%" + search + "%");

            using (SqlDataReader reader = cmdSearchID.ExecuteReader())
            {
                while (reader.Read()) 
                {
                    Employee employee = new Employee(); 
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

        public static List<User> SearchUser(string search, string column)
        {
            List<User> users = new List<User>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearchID = new SqlCommand();
            cmdSearchID.Connection = conn;
            cmdSearchID.CommandText = "SELECT * FROM UserAccounts " +
                                  "WHERE " + column + " LIKE @Search";
            cmdSearchID.Parameters.AddWithValue("@Search", "%" + search + "%");

            using (SqlDataReader reader = cmdSearchID.ExecuteReader())
            {
                while (reader.Read())
                {
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

        public static List<Employee> SearchEmployee(string fname, string lname, string column1, string column2)
        {
            List<Employee> employees = new List<Employee>();

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

                    using (SqlDataReader reader = cmdSearchID.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee();
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
                    conn.Close();
                } // A conexão será fechada automaticamente aqui, quando sair do bloco using
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar funcionários: " + ex.Message);
            }

            return employees;
        }

        public static String SearchJob(int jobID)
        {
            //Employee employee = new Employee();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearchID = new SqlCommand();
            cmdSearchID.Connection = conn;
            cmdSearchID.CommandText = "SELECT * FROM Jobs " +
                                      "WHERE JobId = @JobId";
            cmdSearchID.Parameters.AddWithValue("@JobId", jobID);
            SqlDataReader reader = cmdSearchID.ExecuteReader();
            if (reader.Read()) //found
            {
                return reader["JobTitle"].ToString();
            }
            conn.Close();

            return "Not found";          
            
        }

        public static String SearchStatus(int statusID)
        {
            //Employee employee = new Employee();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearchID = new SqlCommand();
            cmdSearchID.Connection = conn;
            cmdSearchID.CommandText = "SELECT * FROM Statuses " +
                                      "WHERE StatusId = @StatusId";
            cmdSearchID.Parameters.AddWithValue("@StatusId", statusID);
            SqlDataReader reader = cmdSearchID.ExecuteReader();
            if (reader.Read()) //found
            {
                return reader["Description"].ToString();
            }
            conn.Close();

            return "Not found";


        }


        //update an employee in database
        public static void UpdateEmployee(Employee employeeUpdate)
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

        //update an user in database
        public static void UpdateUser(User userUpdate)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                if(IsUniqueId("UserAccounts", "UserId", userUpdate.EmployeeId) == true)
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
                MessageBox.Show("User updated sucessfully.", "Confirmation");
            }
        }

        public static bool IsUniqueId(string table,string column, int eID)
        {
            

            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearchID = new SqlCommand();
            cmdSearchID.Connection = conn;
            cmdSearchID.CommandText = "SELECT * FROM " + table + " " +
                                      "WHERE " + column + " = @ID";
            cmdSearchID.Parameters.AddWithValue("@ID", eID);
            SqlDataReader reader = cmdSearchID.ExecuteReader();
            if (reader.Read()) //found
            {
                return true;
            }
            conn.Close();
            Console.WriteLine(reader.ToString());
            return false;
        }

        

        public static void Delete(string table, string column, int id, int status)
        {

            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandText = "UPDATE " + table + " " +
                                        "SET StatusId = @StatusId " +                                        
                                        "WHERE " + column + " = @ID";
                //cmdUpdate.Parameters.AddWithValue("@EmployeeId", employeeUpdate.EmployeeId);
                cmdUpdate.Parameters.AddWithValue("@StatusId", status);                
                cmdUpdate.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                //MessageBox.Show(id.EmployeeId.ToString());
                cmdUpdate.ExecuteNonQuery();
            }            
        }

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
