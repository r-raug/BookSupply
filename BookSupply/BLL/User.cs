using BookSupply.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSupply.BLL
{
    public class User
    {
        // Fields
        private string userName, password;
        private int userId, employeeId, jobId, statusId;

        // Properties
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public int JobId { get => jobId; set => jobId = value; }
        public int StatusId { get => statusId; set => statusId = value; }
        public int UserId { get => userId; set => userId = value; }

        // Constructors
        public User()
        {
            UserName = string.Empty;
            Password = string.Empty;
            EmployeeId = 0;
        }

        public User(int userId, string userName, int employeeId, int jobId, int statusId)
        {
            UserId = userId;
            UserName = userName;
            EmployeeId = employeeId;
            JobId = jobId;
            StatusId = statusId;
        }

        // Save user to the database
        public static void SaveUser(User user, int empId)
        {
            HiTechDB.SaveRecordUser(user, empId);
        }

        // Get list of all users
        public List<User> GetUserList()
        {
            return HiTechDB.GetAllUsers();
        }

        // Update user information
        public void UpdateUser(User updateUser)
        {
            HiTechDB.UpdateUser(updateUser);
        }

        // Search users based on criteria
        public List<User> SearchUsers(string search, string column)
        {
            return HiTechDB.SearchUser(search, column);
        }

        // Check if user ID is unique
        public bool IsUniqueUserId(string table, string column, int eId)
        {
            return HiTechDB.IsUniqueId(table, column, eId);
        }

        // Delete a user
        public void DeleteUser(int id, int status)
        {
            id = EmployeeId;
            status = StatusId;
            HiTechDB.Delete("UserAccounts", "StatusId", id, status);
        }
    }
}
