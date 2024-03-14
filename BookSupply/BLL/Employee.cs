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
        private int employeeId, phoneNumber, jobId;


        //setters and getters
        public int EmployeeId { get => employeeId; }
        public int PhoneNumber { get => phoneNumber; set => employeeId = value; }
        public int JobId { get => jobId; set => jobId = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Email { get => email; set => email = value; }

        //parameterized constructor
        public Employee(string FirstName, string LastName, string Email, int PhoneNumber, int JobId)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.JobId = JobId;
        }


    }


    }
}
