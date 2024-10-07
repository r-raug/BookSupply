﻿using BookSupply.BLL;
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
                    MessageBox.Show("User already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //create and customize an object of type SqlCommand for insert

                    SqlCommand cmdInsert = new SqlCommand();
                    cmdInsert.Connection = conn;
                    cmdInsert.CommandText = "INSERT INTO UserAccounts (Username, Password, EmployeeId, JobId) " +
                                        "VALUES (@Username, @Password, @EmployeeId, @JobId)";
                    cmdInsert.Parameters.AddWithValue("@Username", user.UserName);
                    cmdInsert.Parameters.AddWithValue("@Password", user.Password);
                    cmdInsert.Parameters.AddWithValue("@EmployeeId", user.EmployeeId);
                    cmdInsert.Parameters.AddWithValue("@JobId", jobID);
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
                reader["UserName"].ToString(),
                Convert.ToInt32(reader["EmployeeId"]),
                Convert.ToInt32(reader["JobId"])
                );

                listE.Add(user);
            }
            //close DB and return records
            conn.Close();
            return listE;
        }

        //this method search an employee by ID
        public static Employee SearchEmployees(string search, string column)
        {
            Employee employee = new Employee();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearchID = new SqlCommand();
            cmdSearchID.Connection = conn;
            cmdSearchID.CommandText = "SELECT * FROM Employees " +
                                  "WHERE " + column + " LIKE @Search";
            cmdSearchID.Parameters.AddWithValue("@Search", "%" + search + "%");

            SqlDataReader reader = cmdSearchID.ExecuteReader();
            if (reader.Read()) //found
            {
                employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                employee.FirstName = reader["FirstName"].ToString();
                employee.LastName = reader["LastName"].ToString();
                employee.Email = reader["Email"].ToString();
                employee.PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]);
                employee.JobId = Convert.ToInt16(reader["JobId"]);
                employee.StatusId = Convert.ToInt16(reader["StatusId"]);
            }
            else
            {
                employee = null;
            }

            //close DV and return employee
            conn.Close();
            return employee;
        }

        public static Employee SearchEmployees(string fname, string lname, string column)
        {
            Employee employee = new Employee();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearchID = new SqlCommand();
            cmdSearchID.Connection = conn;
            cmdSearchID.CommandText = "SELECT * FROM Employees " +
                                      "WHERE " + column + " LIKE @Fname AND " + column + " LIKE @Lname";
            cmdSearchID.Parameters.AddWithValue("@Fname", "%" + fname + "%");
            cmdSearchID.Parameters.AddWithValue("@Lname", "%" + lname + "%");

            SqlDataReader reader = cmdSearchID.ExecuteReader();
            if (reader.Read()) //found
            {
                employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                employee.FirstName = reader["FirstName"].ToString();
                employee.LastName = reader["LastName"].ToString();
                employee.Email = reader["Email"].ToString();
                employee.PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]);
                employee.JobId = Convert.ToInt16(reader["JobId"]);
                employee.StatusId = Convert.ToInt16(reader["StatusId"]);
            }
            else
            {
                employee = null;
            }

            //close DV and return employee
            conn.Close();
            return employee;
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
                //cmdUpdate.Parameters.AddWithValue("@EmployeeId", employeeUpdate.EmployeeId);
                cmdUpdate.Parameters.AddWithValue("@FirstName", employeeUpdate.FirstName);
                cmdUpdate.Parameters.AddWithValue("@LastName", employeeUpdate.LastName);
                cmdUpdate.Parameters.AddWithValue("@PhoneNumber", employeeUpdate.PhoneNumber);
                cmdUpdate.Parameters.AddWithValue("@Email", employeeUpdate.Email);
                cmdUpdate.Parameters.AddWithValue("@JobId", employeeUpdate.JobId);
                cmdUpdate.Parameters.Add("@StatusId", SqlDbType.Int).Value = employeeUpdate.StatusId;
                cmdUpdate.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeUpdate.EmployeeId;
                MessageBox.Show(employeeUpdate.EmployeeId.ToString());
                cmdUpdate.ExecuteNonQuery();
            }
        }

        //update an user in database
        public static void UpdateUser(User userUpdate)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                if (IsUniqueId(userUpdate.EmployeeId) == true)
                {
                    MessageBox.Show("Employee ID not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandText = "UPDATE UserAccounts " +
                                        "SET UserName = @UserName, " +
                                        "Password = @Password " +
                                        "WHERE EmployeeId = @EmployeeId";
                cmdUpdate.Parameters.AddWithValue("@UserName", userUpdate.UserName);
                cmdUpdate.Parameters.AddWithValue("@Password", userUpdate.Password);
                cmdUpdate.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = userUpdate.EmployeeId;
                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("User updated sucessfully.", "Confirmation");
            }
        }

        public static bool IsUniqueId(int eID)
        {
            //Employee employee = new Employee();
            //employee = SearchEmployeeID(eID);

            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearchID = new SqlCommand();
            cmdSearchID.Connection = conn;
            cmdSearchID.CommandText = "SELECT * FROM Employees " +
                                      "WHERE EmployeeId = @EmployeeId";
            cmdSearchID.Parameters.AddWithValue("@EmployeeId", eID);
            SqlDataReader reader = cmdSearchID.ExecuteReader();
            if (reader.Read()) //found
            {
                return true;
            }
            conn.Close();

            return false;
        }



        public static void Delete(int id, int status)
        {

            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandText = "UPDATE Employees " +
                                        "SET StatusId = @StatusId " +
                                        "WHERE EmployeeId = @EmployeeId";
                //cmdUpdate.Parameters.AddWithValue("@EmployeeId", employeeUpdate.EmployeeId);
                cmdUpdate.Parameters.AddWithValue("@StatusId", status);
                cmdUpdate.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = id;
                //MessageBox.Show(id.EmployeeId.ToString());
                cmdUpdate.ExecuteNonQuery();
            }
            //SqlConnection conn = UtilityDB.GetDBConnection();

            //try
            //{
            //    SqlCommand cmdDelete = new SqlCommand();
            //    cmdDelete.Connection = conn;
            //    cmdDelete.CommandText = "DELETE Employees "+
            //                            "WHERE EmployeeId = @EmployeeId";
            //    cmdDelete.Parameters.AddWithValue("@EmployeeId", ID);
            //    cmdDelete.ExecuteNonQuery();
            //}catch(Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    conn.Close();
            //}
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
        public static void DeleteCustomer(int id, int status)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandText = "DELETE Customers " +
                                        "WHERE CustomerId = @CustomerId";

                cmdUpdate.Parameters.AddWithValue("@CustomerId", id);

                cmdUpdate.ExecuteNonQuery();
            }
        }
        public static void UpdateCustomer(Customer customer)
        {
            // Abrir conexão com o banco de dados
            SqlConnection conn = UtilityDB.GetDBConnection();

            // Operação de atualização
            // Criar e personalizar um objeto do tipo SqlCommand
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = conn;
            cmdUpdate.CommandText = "UPDATE Customers SET Street = @Street, Province = @Province, PostalCode = @PostalCode, " +
                                    "PhoneNumber = @PhoneNumber, FirstName = @FirstName, Email = @Email, " +
                                    "LastName = @LastName WHERE CustomerID = @CustomerID";

            // Certifique-se de que todos os parâmetros estão sendo adicionados corretamente
            cmdUpdate.Parameters.AddWithValue("@Street", customer.Street);
            cmdUpdate.Parameters.AddWithValue("@Province", customer.Province);
            cmdUpdate.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
            cmdUpdate.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
            cmdUpdate.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmdUpdate.Parameters.AddWithValue("@Email", customer.Email);
            cmdUpdate.Parameters.AddWithValue("@CreditLimit", customer.CreditLimit);
            cmdUpdate.Parameters.AddWithValue("@Status", customer.Status);
            cmdUpdate.Parameters.AddWithValue("@LastName", customer.LastName);
            cmdUpdate.Parameters.AddWithValue("@CustomerID", customer.CustomerId); // Adicione o parâmetro CustomerID

            try
            {
                // Execute a consulta SQL para atualizar o registro
                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Fechar conexão com o banco de dados
                conn.Close();
            }
        }



        public static List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Customers", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader(); // Executar comando contido em cmdSelectAll

            // Loop para listar todos os registros
            while (reader.Read())
            {
                Customer customer = new Customer(
                    reader["FirstName"].ToString(),
                    reader["LastName"].ToString(),
                    reader["Email"].ToString(),
                    Convert.ToInt64(reader["PhoneNumber"]),
                    reader["Street"].ToString(),
                    reader["Province"].ToString(),
                    reader["PostalCode"].ToString(),
                    reader["Status"].ToString(),
                    Convert.ToInt32(reader["CreditLimit"])
                );
                customer.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                customers.Add(customer);
            }

            // Fechar conexão com o banco de dados e retornar registros
            conn.Close();
            return customers;
        }

        public static void SaveRecordCustomer(Customer customer)
        {
            // Abrir conexão com o banco de dados
            SqlConnection conn = UtilityDB.GetDBConnection();

            // Operação de inserção
            // Criar e personalizar um objeto do tipo SqlCommand
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = "INSERT INTO Customers (Street, Province, PostalCode, PhoneNumber, FirstName, Email, CreditLimit, Status,LastName) " +
                                    "VALUES (@Street, @Province, @PostalCode, @PhoneNumber, @FirstName, @Email, @CreditLimit, @Status, @LastName)";

            // Certifique-se de que todos os parâmetros estão sendo adicionados corretamente
            cmdInsert.Parameters.AddWithValue("@Street", customer.Street);
            cmdInsert.Parameters.AddWithValue("@Province", customer.Province);
            cmdInsert.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
            cmdInsert.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
            cmdInsert.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmdInsert.Parameters.AddWithValue("@Email", customer.Email);
            cmdInsert.Parameters.AddWithValue("@CreditLimit", customer.CreditLimit);
            cmdInsert.Parameters.AddWithValue("@Status", customer.Status);
            cmdInsert.Parameters.AddWithValue("LastName", customer.LastName);

            try
            {
                // Execute a consulta SQL para inserir o registro
                cmdInsert.ExecuteNonQuery();
                MessageBox.Show("Customer saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Fechar conexão com o banco de dados
                conn.Close();
            }
        }




        public static Customer SearchCustomer(string search, string column)
        {
            Customer customer = null;
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearch = new SqlCommand();
            cmdSearch.Connection = conn;
            cmdSearch.CommandText = "SELECT * FROM Customers " +
                                    "WHERE " + column + " LIKE @Search";
            cmdSearch.Parameters.AddWithValue("@Search", "%" + search + "%");

            SqlDataReader reader = cmdSearch.ExecuteReader();
            if (reader.Read()) // Encontrado
            {
                customer = new Customer
                {
                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Email = reader["Email"].ToString(),
                    PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]),
                    Street = reader["Street"].ToString(),
                    Province = reader["Province"].ToString(),
                    PostalCode = reader["PostalCode"].ToString(),
                    Status = reader["Status"].ToString(),
                    CreditLimit = Convert.ToInt32(reader["CreditLimit"])
                };
            }

            // Fechar conexão com o banco de dados e retornar cliente
            conn.Close();
            return customer;
        }

        public static Customer SearchCustomer(string firstName, string lastName, string column)
        {
            Customer customer = null;
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearch = new SqlCommand();
            cmdSearch.Connection = conn;
            cmdSearch.CommandText = "SELECT * FROM Customers " +
                                    "WHERE " + column + " LIKE @FirstName AND " + column + " LIKE @LastName";
            cmdSearch.Parameters.AddWithValue("@FirstName", "%" + firstName + "%");
            cmdSearch.Parameters.AddWithValue("@LastName", "%" + lastName + "%");

            SqlDataReader reader = cmdSearch.ExecuteReader();
            if (reader.Read()) // Encontrado
            {
                customer = new Customer
                {
                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Email = reader["Email"].ToString(),
                    PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]),
                    Street = reader["Street"].ToString(),
                    Province = reader["Province"].ToString(),
                    PostalCode = reader["PostalCode"].ToString(),
                    Status = reader["Status"].ToString(),
                    CreditLimit = Convert.ToInt32(reader["CreditLimit"])
                };
            }

            // Fechar conexão com o banco de dados e retornar cliente
            conn.Close();
            return customer;
        }

        public static void DeleteCustomerById(int customerId)
        {
            // String de conexão com o banco de dados
            string connectionString = "your_connection_string_here";

            // Query SQL para excluir o cliente pelo ID
            string query = "DELETE FROM Customers WHERE CustomerId = @CustomerId";

            // Criar uma conexão com o banco de dados usando a string de conexão
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Criar um comando SQL com a query e a conexão
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adicionar o parâmetro para o ID do cliente
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    try
                    {
                        // Abrir a conexão com o banco de dados
                        connection.Open();

                        // Executar o comando SQL para excluir o cliente
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Lidar com qualquer exceção que possa ocorrer durante a execução da consulta SQL
                        throw new Exception("Error deleting customer: " + ex.Message);
                    }
                }
            }













        }
    }
}
