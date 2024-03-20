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
        private int employeeId, jobId, statusId;
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string UserName { get => userName; set => userName = value; }    
        public string Password { get => password; set => password = value; }
        public int JobId { get => jobId; set => jobId = value; }
        public int StatusId { get => statusId; set => statusId = value; }

        public User()
        {
            UserName = string.Empty;
            Password = string.Empty;
            EmployeeId = 0;
        }

        public User(string userName, int employeeId, int jobId, int statusId)
        {
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

    }
}
