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
        private int employeeId, jobId;
        private long phoneNumber;

        //setters and getters
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public long PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int JobId { get => jobId; set => jobId = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Email { get => email; set => email = value; }

        //default constructor
        public Employee()
        {
           
            LastName = string.Empty;
            FirstName = string.Empty;
            Email = string.Empty;
            PhoneNumber = 0;
            JobId = 0;
        }

        //parameterized constructor
        public Employee(string FirstName, string LastName, string Email, long PhoneNumber, int JobId)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.JobId = JobId;
        }

        public static void SaveEmployee(Employee employee)
        {
            HiTechDB.SaveRecord(employee);
        }

        public List<Employee> GetEmployeeList()
        {
            return HiTechDB.GetAllEmployees();
        }

        public Employee SearchEmployee(int id)
        {
            return HiTechDB.SearchEmployee(id);
        }


    }
    
}
