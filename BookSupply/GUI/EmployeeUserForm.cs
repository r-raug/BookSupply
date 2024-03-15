using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookSupply.BLL;
using BookSupply.VALIDATION;

namespace BookSupply.GUI
{
    public partial class EmployeeUserForm : Form
    {
        public EmployeeUserForm()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //string input ="";
            Employee employee = new Employee();
            employee.FirstName = textBoxFirstName.Text.Trim();
            employee.LastName = textBoxLastName.Text.Trim();
            employee.PhoneNumber = Convert.ToInt64(textBoxPhone.Text.Trim());
            employee.Email = textBoxEmail.Text.Trim();
            employee.JobId = Convert.ToInt32(textBoxJobID.Text.Trim());
            Employee.SaveEmployee(employee);
            MessageBox.Show("Saved");
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            listViewEmployee.Items.Clear();
            Employee employee = new Employee();
            List<Employee> listEmp = employee.GetEmployeeList();
            DisplayInfo(listEmp, listViewEmployee);
        }

        private void DisplayInfo(List<Employee> listEmp, ListView listV)
        {
            listV.Items.Clear();
            if(listEmp != null)
            {
                foreach(Employee emp in listEmp)
                {
                    ListViewItem item = new ListViewItem(emp.EmployeeId.ToString());
                    item.SubItems.Add(emp.FirstName);
                    item.SubItems.Add(emp.LastName);
                    item.SubItems.Add(emp.PhoneNumber.ToString());
                    item.SubItems.Add(emp.Email);
                    item.SubItems.Add(emp.JobId.ToString());
                    listV.Items.Add(item);
                }

            }
            else
            {
                MessageBox.Show("No employee in the database.", "Missing data");
            }
        }
    }
}
