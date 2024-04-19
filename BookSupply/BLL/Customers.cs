using BookSupply.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSupply.BLL
{
    public class Customers
    {
        // Private fields
        private string lastName, firstName, email, street, province, postalCode, status;
        private int customerId, creditLimit;
        private long phoneNumber;

        // Properties
        public int CustomerId { get => customerId; set => customerId = value; }
        public long PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Email { get => email; set => email = value; }
        public string Street { get => street; set => street = value; }
        public string Province { get => province; set => province = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string Status { get => status; set => status = value; }
        public int CreditLimit { get => creditLimit; set => creditLimit = value; }

        // Default constructor
        public Customers()
        {
            LastName = string.Empty;
            FirstName = string.Empty;
            Email = string.Empty;
            Street = string.Empty;
            Province = string.Empty;
            PostalCode = string.Empty;
            Status = string.Empty;
            PhoneNumber = 0;
            CustomerId = 0;
            CreditLimit = 0;
        }

        // Parameterized constructor
        public Customers(string firstName, string lastName, string email, long phoneNumber,
                    string street, string province, string postalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Street = street;
            Province = province;
            PostalCode = postalCode;
        }
        // Parameterized constructor
        public Customers(string firstName, string lastName, string email, long phoneNumber,
                        string street, string province, string postalCode, string status, int creditLimit)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Street = street;
            Province = province;
            PostalCode = postalCode;
            Status = status;
            CreditLimit = creditLimit;
        }

        public Customers(string firstName, string lastName, string email, long phoneNumber,
                string street, string province, string postalCode, string status,
                string contactName, int creditLimit)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Street = street;
            Province = province;
            PostalCode = postalCode;
            Status = status;
            CreditLimit = creditLimit;
        }



        // Methods
        public static void SaveCustomer(Customer customer)
        {
            HiTechDB.SaveRecordCustomer(customer);
        }

        public List<Customer> GetCustomerList()
        {
            return HiTechDB.GetAllCustomers();
        }

        public Customer SearchCustomer(string search, string column)
        {
            return HiTechDB.SearchCustomer(search, column);
        }

        public bool IsUniqueCustomerId(int customerId)
        {
            return HiTechDB.IsUniqueId(customerId);
        }

        public void UpdateCustomer(Customer updateCustomer)
        {
            HiTechDB.UpdateCustomer(updateCustomer);
        }

        public void DeleteCustomer(int id, int status)
        {
            CustomerId = id;
            HiTechDB.Delete(id, status);
        }


    }

}
