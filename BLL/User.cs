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
        private string userName, password;
        private int userId, employeeId, jobId, statusId;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string UserName { get => userName; set => userName = value; }    
        public string Password { get => password; set => password = value; }
        public int JobId { get => jobId; set => jobId = value; }
        public int StatusId { get => statusId; set => statusId = value; }
        public int UserId { get => userId; set => userId = value; }

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

        public static void SaveUser(User user,int empId)
        {

            HiTechDB.SaveRecordUser(user,empId);
        }

        public List<User> GetUserList()
        {
            return HiTechDB.GetAllUsers();
        }

        public void UpdateUser(User updateUser)
        {
            HiTechDB.UpdateUser(updateUser);
        }

        public List<User> SearchUsers(string search, string column)
        {

            return HiTechDB.SearchUser(search, column);
        }

        public bool IsUniqueUserId(string table, string column,int eId)
        {
            return HiTechDB.IsUniqueId(table, column, eId);
        }

        public void DeleteUser(int id, int status)
        {
            id = EmployeeId;
            status = StatusId;
            HiTechDB.Delete("UserAccounts", "StatusId", id, status);
        }
    }
}
