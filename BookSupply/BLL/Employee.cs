using BookSupply.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSupply.BLL
{
    public class Employee
    {
        //privates flieds
        private string lastName, firstName, email;
        private int employeeId, jobId, statusId;
        private long phoneNumber;

        //setters and getters
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public long PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int JobId { get => jobId; set => jobId = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Email { get => email; set => email = value; }
        public int StatusId { get => statusId; set => statusId = value; }


        //default constructor
        public Employee()
        {
           
            LastName = string.Empty;
            FirstName = string.Empty;
            Email = string.Empty;
            PhoneNumber = 0;
            JobId = 0;
            //StatusId = 0;
        }

        //parameterized constructor
        public Employee(string FirstName, string LastName, string Email, long PhoneNumber, int JobId, int StatusId)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.JobId = JobId;
            this.StatusId = StatusId;
        }

        public static void SaveEmployee(Employee employee)
        {
            HiTechDB.SaveRecordEmployee(employee);
        }

        public List<Employee> GetEmployeeList()
        {
            return HiTechDB.GetAllEmployees();
        }

        public List<Employee> SearchEmployees(string search, string column)
        {

            return HiTechDB.SearchEmployee(search, column);
        }

        
        public List<Employee> SearchEmployees(string search, string search1, string column, string column1)
        {

            return HiTechDB.SearchEmployee(search, search1, column, column1);
        }

        public bool IsUniqueEmployeeId(string table, string column,int eId)
        {
            return HiTechDB.IsUniqueId(table, column, eId);
        }

        public void UpdateEmployee(Employee updateEmployee)
        {
            HiTechDB.UpdateEmployee(updateEmployee);
        }

        public void DeleteEmployee(int id, int status)
        {
            id = EmployeeId;
            status = StatusId;
            HiTechDB.Delete("Employees", "EmployeeId", id, status);
        }


    }
    
}
