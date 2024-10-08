using BookSupply.DAL;
using BookSupply.VALIDATION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookSupply.BLL
{
    public class Emp
    {
        // Private fields
        private string lastName, firstName, email;
        private int employeeId, jobId, statusId;
        private long phoneNumber;

        // Setters and getters
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public long PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int JobId { get => jobId; set => jobId = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Email { get => email; set => email = value; }
        public int StatusId { get => statusId; set => statusId = value; }

        // Default constructor
        public Emp()
        {
            LastName = string.Empty;
            FirstName = string.Empty;
            Email = string.Empty;
            PhoneNumber = 0;
            JobId = 0;
        }

        // Parameterized constructor
        public Emp(string FirstName, string LastName, string Email, long PhoneNumber, int JobId, int StatusId)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.JobId = JobId;
            this.StatusId = StatusId;
        }

        // Save an employee
        public static void SaveEmployee(Emp employee)
        {
            HiTechDB.SaveRecordEmployee(employee);
        }

        // Get a list of all employees
        public List<Emp> GetEmployeeList()
        {
            return HiTechDB.GetAllEmployees();
        }

        // Search employees by a single column
        public List<Emp> SearchEmployees(string search, string column)
        {
            return HiTechDB.SearchEmployee(search, column);
        }

        // Search employees by multiple columns
        public List<Emp> SearchEmployees(string search, string search1, string column, string column1)
        {
            return HiTechDB.SearchEmployee(search, search1, column, column1);
        }

        // Check if an employee ID is unique
        public bool IsUniqueEmployeeId(string table, string column, int eId)
        {
            return HiTechDB.IsUniqueId(table, column, eId);
        }

        // Update an employee
        public void UpdateEmployee()
        {
            // Validate employee data
            if (!Validator.IsValidName(FirstName))
            {
                MessageBox.Show("Invalid First Name.", "Invalid");
                return;
            }

            if (!Validator.IsValidName(LastName))
            {
                MessageBox.Show("Invalid Last Name.", "Invalid");
                return;
            }

            if (!Validator.isValidEmail(Email))
            {
                MessageBox.Show("Invalid Email.", "Invalid");
                return;
            }

            if (!Validator.IsValidPhoneNumber(PhoneNumber.ToString()))
            {
                MessageBox.Show("Invalid Phone Number.", "Invalid");
                return;
            }

            if (!IsUniqueEmployeeId("Employees", "EmployeeId", EmployeeId))
            {
                MessageBox.Show("Employee ID not found.", "Error ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update employee record
            HiTechDB.UpdateEmployee(this);
        }

        // Delete an employee
        public void DeleteEmployee(int id, int status)
        {
            id = EmployeeId;
            status = StatusId;
            HiTechDB.Delete("Employees", "EmployeeId", id, status);
        }
    }
}
