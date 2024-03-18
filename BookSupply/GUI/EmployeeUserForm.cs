using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
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
            string input = "";

            input = textBoxFirstName.Text.Trim();
            if (!Validator.IsValidName(input))
            {
                MessageBox.Show("Invalid First Name.", "Invalid");
                textBoxFirstName.Focus();
                return;
            }

            input = textBoxLastName.Text.Trim();
            if (!Validator.IsValidName(input))
            {
                MessageBox.Show("Invalid Last Name.", "Invalid");
                textBoxLastName.Focus();
                return;
            }

            input = textBoxEmail.Text.Trim();
            if (!Validator.isValidEmail(input))
            {
                MessageBox.Show("Invalid Email.", "Invalid");
                textBoxEmail.Focus();
                return;
            }

            input = textBoxPhone.Text.Trim();
            if (!Validator.IsValidPhoneNumber(input))
            {
                MessageBox.Show("Invalid Phone Number.", "Invalid");
                textBoxPhone.Focus();
                return;
            }
            
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

        private void buttonUpdateEmployee_Click(object sender, EventArgs e)
        {
            string input = "";

            //check if all texbox has information
            if(textBoxEmployeeID.Text == "" || textBoxFirstName.Text == "" || textBoxLastName.Text == "" || 
                textBoxEmail.Text == "" || textBoxJobID.Text == "" || textBoxPhone.Text == "" )
            {
                MessageBox.Show("Please search by EmployeeID before procede with update or \n" + 
                    "fill in all fields before proceeding.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(int.TryParse(textBoxEmployeeID.Text,out int employeeId))
                {
                    Employee employee = new Employee();

                    //before update, check if ID exist and all fields has a valid input
                    input = textBoxEmployeeID.Text.Trim();
                    if(employee.IsUniqueEmployeeId(Convert.ToInt32(input)))
                    {
                        MessageBox.Show("ID not found", "Error ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxEmployeeID.Focus();
                        return;
                    }
                    

                    input = textBoxFirstName.Text.Trim();
                    if(!Validator.IsValidName(input))
                    {
                        MessageBox.Show("Invalid First Name.", "Invalid");
                        textBoxFirstName.Focus();
                        return;
                    }

                    input = textBoxLastName.Text.Trim();
                    if (!Validator.IsValidName(input))
                    {
                        MessageBox.Show("Invalid Last Name.", "Invalid");
                        textBoxLastName.Focus();
                        return;
                    }

                    input = textBoxEmail.Text.Trim();
                    if (!Validator.isValidEmail(input))
                    {
                        MessageBox.Show("Invalid Email.", "Invalid");
                        textBoxEmail.Focus();
                        return;
                    }

                    input = textBoxPhone.Text.Trim();
                    if (!Validator.IsValidPhoneNumber(input))
                    {
                        MessageBox.Show("Invalid Phone Number.", "Invalid");
                        textBoxPhone.Focus();
                        return;
                    }


                    ///////////////////////////////////////////////////////
                    //falta criar a funcao para checar se o JobID existe.//
                    ///////////////////////////////////////////////////////

                    employee.EmployeeId = Convert.ToInt32(textBoxEmployeeID.Text.Trim());
                    employee.FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBoxFirstName.Text.Trim().ToLower());
                    employee.LastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBoxLastName.Text.Trim().ToLower());
                    employee.Email = textBoxEmail.Text.Trim();
                    employee.PhoneNumber = Convert.ToInt64(textBoxPhone.Text.Trim());
                    employee.JobId = Convert.ToInt32(textBoxJobID.Text.Trim());
                    

                    DialogResult result = MessageBox.Show("Are you sure you want to update this employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //employee.UpdateEmployee(employee);
                        try
                        {
                            employee.UpdateEmployee(employee);
                            MessageBox.Show("Employee updated sucessfully.", "Confirmation");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error updating employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Employee ID must be a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void buttonDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (textBoxEmployeeID.Text.Trim() == "")
            {
                MessageBox.Show("Employee ID must be a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you aure you want to delete this employee?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string input = "";
                        Employee employee = new Employee();

                        //before delete, check if ID exists
                        input = textBoxEmployeeID.Text.Trim();
                        if (employee.IsUniqueEmployeeId(Convert.ToInt32(input)))
                        {
                            MessageBox.Show("ID not found", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxEmployeeID.Focus();
                            return;

                        }
                        employee.EmployeeId = Convert.ToInt32(textBoxEmployeeID.Text.Trim());
                        employee.DeleteEmployee(employee.EmployeeId);
                        MessageBox.Show("Employee deleted", "Confirmation");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting employee : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Operation canceled.", "Confirmation");
                }
            }
        }

        private void buttonSaveUser_Click(object sender, EventArgs e)
        {

            User user = new User();
            user.UserName = textBoxUserName.Text.Trim();
            user.Password = textBoxUserPassword.Text.Trim();
            user.EmployeeId = Convert.ToInt32(textBoxUserEmpID.Text.Trim());            
            User.SaveUser(user, user.EmployeeId);
            
        }

        private void EmployeeUserForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonListUser_Click(object sender, EventArgs e)
        {
            listViewUser.Items.Clear();
            User user = new User();
            List<User> listUser = user.GetUserList();           
            DisplayInfos(listUser, listViewUser);
        }


        private void DisplayInfos(List<User> listUser, ListView listV)
        {
            listV.Items.Clear();
            if (listUser != null && listUser.Count > 0)
            {
                foreach (User user in listUser)
                {
                    ListViewItem item = new ListViewItem(user.EmployeeId.ToString());
                    item.SubItems.Add(user.UserName);
                    item.SubItems.Add(user.JobId.ToString());
                    listV.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No employee in the database.", "Missing data");
            }
        }

        private void buttonUpdateUser_Click(object sender, EventArgs e)
        {

            int inputEmployeeId = Convert.ToInt32(textBoxUserEmpID.Text.Trim());
            Console.WriteLine(inputEmployeeId);
            //check if EmployeeID texbox has information
            if (textBoxUserEmpID.Text == "" || textBoxUserName.Text == "" || textBoxUserPassword.Text == "")
            {
                MessageBox.Show("Please search by EmployeeID before procede with update or \n" +
                    "fill in all fields before proceeding.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (inputEmployeeId is int)
                {
                    User user = new User();

                    //before update, check if ID exist and all fields has a valid input
                    //input = textBoxEmployeeID.Text.Trim();
                    //if (employee.IsUniqueEmployeeId(Convert.ToInt32(input)))
                    //{
                    //    MessageBox.Show("ID not found", "Error ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    textBoxEmployeeID.Focus();
                    //    return;
                    //}


                    user.EmployeeId = Convert.ToInt32(textBoxUserEmpID.Text.Trim());
                    user.UserName = textBoxUserName.Text.Trim();
                    user.Password = textBoxUserPassword.Text.Trim();
                    


                    DialogResult result = MessageBox.Show("Are you sure you want to update this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //employee.UpdateEmployee(employee);
                        try
                        {
                            user.UpdateUser(user);
                            MessageBox.Show("Employee updated sucessfully.", "Confirmation");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error updating employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Employee ID must be a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    
}
