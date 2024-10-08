using BookSupply.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSupply.BLL
{
    public class Customers1
    {
        // Private fields
        private string customerName, email, street, province, postalCode;
        private int customerId, status, creditLimit;
        private long phoneNumber;

        // Properties
        public int CustomerId { get => CustomerId1; set => CustomerId1 = value; }
        public long PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string Email { get => email; set => email = value; }
        public string Street { get => street; set => street = value; }
        public string Province { get => province; set => province = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public int Status { get => Status1; set => Status1 = value; }
        public int CustomerId1 { get => customerId; set => customerId = value; }
        public int Status1 { get => status; set => status = value; }
        public int CreditLimit { get => creditLimit; set => creditLimit = value; }

        // Default constructor
        public Customers1()
        {
            CustomerName = string.Empty;
            Email = string.Empty;
            Street = string.Empty;
            Province = string.Empty;
            PostalCode = string.Empty;
            PhoneNumber = 0;
            CustomerId = 0;
            Status = 0; // Alterado para int
            CreditLimit = 0;
        }

        // Parameterized constructor
        public Customers1(string customerName, string email, long phoneNumber,
                          string street, string province, string postalCode)
        {
            CustomerName = customerName;
            Email = email;
            PhoneNumber = phoneNumber;
            Street = street;
            Province = province;
            PostalCode = postalCode;
        }

        // Parameterized constructor
        public Customers1(string customerName, string email, long phoneNumber,
                          string street, string province, string postalCode, int status) // Alterado para int
        {
            CustomerName = customerName;
            Email = email;
            PhoneNumber = phoneNumber;
            Street = street;
            Province = province;
            PostalCode = postalCode;
            Status = status;
        }

        public Customers1(string customerName, string email, long phoneNumber,
                          string street, string province, string postalCode, int status,
                          string contactName) // Alterado para int
        {
            CustomerName = customerName;
            Email = email;
            PhoneNumber = phoneNumber;
            Street = street;
            Province = province;
            PostalCode = postalCode;
            Status = status;
        }

        // Methods
        public static void SaveCustomer(Customers1 customer)
        {
            HiTechDB.SaveRecordCustomer(customer);
        }

        public List<Customers1> GetCustomerList()
        {
            return HiTechDB.GetAllCustomers();
        }

        public List<Customers1> SearchCustomers(string search, string column)
        {
            return HiTechDB.SearchCustomer(search, column);
        }


        public bool IsUniqueCustomerId(int customerId)
        {
            return HiTechDB.IsUniqueId("Customers", "CustomerId", customerId);
        }

        public void UpdateCustomer(Customers1 customers)
        {
            HiTechDB.UpdateCustomer1(customers);
        }


        public void DeleteCustomer(int id, int status)
        {
                HiTechDB.DeleteC(id, status);
            
        }
    }
}
