using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookSupply.BLL;
using BookSupply.DAL;
using BookSupply.VALIDATION;

namespace BookSupply.GUI
{
    public partial class EmployeeUserForm : Form
    {
        // Constructor
        public EmployeeUserForm()
        {
            InitializeComponent();
        }

        // Event handler for saving an employee
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Input validation for employee fields
            string input = "";

            // Validate first name
            input = textBoxFirstName.Text.Trim();
            if (!Validator.IsValidName(input))
            {
                MessageBox.Show("Invalid First Name.", "Invalid");
                textBoxFirstName.Focus();
                return;
            }

            // Validate last name
            input = textBoxLastName.Text.Trim();
            if (!Validator.IsValidName(input))
            {
                MessageBox.Show("Invalid Last Name.", "Invalid");
                textBoxLastName.Focus();
                return;
            }

            // Validate email
            input = textBoxEmail.Text.Trim();
            if (!Validator.isValidEmail(input))
            {
                MessageBox.Show("Invalid Email.", "Invalid");
                textBoxEmail.Focus();
                return;
            }

            // Validate phone number
            input = textBoxPhone.Text.Trim();
            if (!Validator.IsValidPhoneNumber(input))
            {
                MessageBox.Show("Invalid Phone Number.", "Invalid");
                textBoxPhone.Focus();
                return;
            }

            // Create an employee object and populate its properties
            Emp employee = new Emp();
            employee.FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBoxFirstName.Text.Trim().ToLower());
            employee.LastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBoxLastName.Text.Trim().ToLower());
            employee.PhoneNumber = Convert.ToInt64(textBoxPhone.Text.Trim());
            employee.Email = textBoxEmail.Text.Trim();
            employee.JobId = comboBoxJob.SelectedIndex + 1;
            employee.StatusId = comboBoxStatusID.SelectedIndex + 1;

            // Save the employee
            Emp.SaveEmployee(employee);
            MessageBox.Show("Saved");
        }

        // Event handler for listing employees
        private void buttonList_Click(object sender, EventArgs e)
        {
            // Clear the list view
            listViewEmployee.Items.Clear();
            // Retrieve the list of employees
            Emp employee = new Emp();
            List<Emp> listEmp = employee.GetEmployeeList();
            // Display the list of employees in the list view
            DisplayInfo(listEmp, listViewEmployee);
        }

        // Method to display employee information in a list view
        private void DisplayInfo(List<Emp> listEmp, ListView listV)
        {
            listV.Items.Clear();
            if (listEmp != null)
            {
                // Iterate through the list of employees and add them to the list view
                foreach (Emp emp in listEmp)
                {
                    ListViewItem item = new ListViewItem(emp.EmployeeId.ToString());
                    item.SubItems.Add(emp.FirstName);
                    item.SubItems.Add(emp.LastName);
                    item.SubItems.Add(emp.PhoneNumber.ToString());
                    item.SubItems.Add(emp.Email);
                    item.SubItems.Add(emp.JobId.ToString());
                    item.SubItems.Add(emp.StatusId.ToString());
                    listV.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No employee in the database.", "Missing data");
            }
        }

        // Event handler for updating an employee
        private void buttonUpdateEmployee_Click(object sender, EventArgs e)
        {
            // Validate employee ID
            if (!int.TryParse(textBoxEmployeeIDU.Text, out int employeeId))
            {
                MessageBox.Show("Employee ID must be a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate input fields
            if (string.IsNullOrWhiteSpace(textBoxFirstNameU.Text) ||
                string.IsNullOrWhiteSpace(textBoxLastNameU.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmailU.Text) ||
                comboBoxJobIDU.SelectedIndex == -1 ||
                comboBoxStatusIDU.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(textBoxPhoneNumberU.Text))
            {
                MessageBox.Show("Please fill in all fields before proceeding.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create an employee object with updated information
            Emp employee = new Emp
            {
                EmployeeId = employeeId,
                FirstName = textBoxFirstNameU.Text.Trim(),
                LastName = textBoxLastNameU.Text.Trim(),
                Email = textBoxEmailU.Text.Trim(),
                PhoneNumber = Convert.ToInt64(textBoxPhoneNumberU.Text.Trim()),
                JobId = comboBoxJobIDU.SelectedIndex + 1,
                StatusId = comboBoxStatusIDU.SelectedIndex + 1
            };

            // Confirm the update operation with the user
            DialogResult result = MessageBox.Show("Are you sure you want to update this employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Update the employee
                    employee.UpdateEmployee();
                    MessageBox.Show("Employee updated successfully.", "Confirmation");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Event handler for deleting an employee
        private void buttonDeleteEmployee_Click(object sender, EventArgs e)
        {
            // Validate employee ID input
            if (textBoxEmployeeIDD.Text.Trim() == "")
            {
                MessageBox.Show("Employee ID must be a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Confirm the deletion operation with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string input = "";
                        Emp employee = new Emp();

                        // Check if the employee ID exists before deletion
                        input = textBoxEmployeeIDD.Text.Trim();
                        if (!employee.IsUniqueEmployeeId("Employees", "EmployeeId", Convert.ToInt32(input)))
                        {
                            MessageBox.Show("ID not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxEmployeeIDD.Focus();
                            return;
                        }

                        // Delete the employee
                        employee.EmployeeId = Convert.ToInt32(textBoxEmployeeIDD.Text.Trim());
                        employee.StatusId = 2;
                        employee.DeleteEmployee(employee.EmployeeId, employee.StatusId);
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

        // Event handler for saving a user
        private void buttonSaveUser_Click(object sender, EventArgs e)
        {
            // Create a user object and populate its properties
            User user = new User();
            user.UserName = textBoxUserName.Text.Trim();
            user.Password = textBoxUserPassword.Text.Trim();
            user.EmployeeId = Convert.ToInt32(textBoxUserEmpID.Text.Trim());
            user.StatusId = Convert.ToInt16(comboBoxUserStatusId.SelectedIndex + 1);
            // Save the user
            User.SaveUser(user, user.EmployeeId);
        }

        // Event handler for listing users
        private void buttonListUser_Click(object sender, EventArgs e)
        {
            // Clear the list view
            listViewUser.Items.Clear();
            // Retrieve the list of users
            User user = new User();
            List<User> listUser = user.GetUserList();
            // Display the list of users in the list view
            DisplayInfos(listUser, listViewUser);
        }

        // Method to display user information in a list view
        private void DisplayInfos(List<User> listUser, ListView listV)
        {
            listV.Items.Clear();
            if (listUser != null && listUser.Count > 0)
            {
                // Iterate through the list of users and add them to the list view
                foreach (User user in listUser)
                {
                    ListViewItem item = new ListViewItem(user.UserId.ToString());
                    item.SubItems.Add(user.EmployeeId.ToString());
                    item.SubItems.Add(user.UserName);
                    item.SubItems.Add(user.JobId.ToString());
                    item.SubItems.Add(user.StatusId.ToString());
                    listV.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No data in the database.", "Missing data");
            }
        }

        // Event handler for updating a user
        private void buttonUpdateUser_Click(object sender, EventArgs e)
        {
            // Validate employee ID input
            int inputEmployeeId = Convert.ToInt32(textBoxUserEmpID.Text.Trim());
            Console.WriteLine(inputEmployeeId);
            // Check if EmployeeID textbox has information
            if (textBoxUserEmpID.Text == "" || textBoxUserName.Text == "" || textBoxUserPassword.Text == "")
            {
                MessageBox.Show("Please search by EmployeeID before proceeding with update or fill in all fields before proceeding.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (inputEmployeeId is int)
                {
                    User user = new User();

                    user.EmployeeId = Convert.ToInt32(textBoxUserEmpID.Text.Trim());
                    user.UserName = textBoxUserName.Text.Trim();
                    user.Password = textBoxUserPassword.Text.Trim();
                    user.StatusId = comboBoxUserStatusId.SelectedIndex + 1;
                    // Confirm the update operation with the user
                    DialogResult result = MessageBox.Show("Are you sure you want to update this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Update the user
                            user.UpdateUser(user);
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

        // Other event handlers and methods...

        // Event handler for logging out
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void buttonSearchEmployee_Click(object sender, EventArgs e)
        {
            string search, column;
            switch (comboBoxSearch.SelectedIndex)
            {
                case 0:
                    search = textBoxSearch1.Text.Trim();
                    column = "EmployeeID";
                    Emp employeeInstance = new Emp();
                    List<Emp> listEmp = employeeInstance.SearchEmployees(search, column);
                    listViewEmployee.Items.Clear();
                    DisplayInfo(listEmp, listViewEmployee);
                    break;
                case 1:
                    search = textBoxSearch1.Text.Trim();
                    column = "FirstName";
                    Emp employeeInstance1 = new Emp();
                    List<Emp> listEmp1 = employeeInstance1.SearchEmployees(search, column);
                    listViewEmployee.Items.Clear();
                    DisplayInfo(listEmp1, listViewEmployee);
                    break;
                case 2:
                    search = textBoxSearch1.Text.Trim();
                    column = "LastName";
                    Emp employeeInstance2 = new Emp();
                    List<Emp> listEmp2 = employeeInstance2.SearchEmployees(search, column);
                    listViewEmployee.Items.Clear();
                    DisplayInfo(listEmp2, listViewEmployee);
                    break;
                case 3:
                    search = textBoxSearch1.Text.Trim();
                    column = "Email";
                    Emp employeeInstance4 = new Emp();
                    List<Emp> listEmp4 = employeeInstance4.SearchEmployees(search, column);
                    listViewEmployee.Items.Clear();
                    DisplayInfo(listEmp4, listViewEmployee);
                    break;
                case 4:
                    search = textBoxSearch1.Text.Trim();
                    column = "PhoneNumber";
                    Emp employeeInstance5 = new Emp();
                    List<Emp> listEmp5 = employeeInstance5.SearchEmployees(search, column);
                    listViewEmployee.Items.Clear();
                    DisplayInfo(listEmp5, listViewEmployee);
                    break;
                case 5:
                    int temp = comboBoxSearchJobID.SelectedIndex + 1;
                    search = temp.ToString();
                    column = "JobId";
                    Emp employeeInstance6 = new Emp();
                    List<Emp> listEmp6 = employeeInstance6.SearchEmployees(search, column);
                    listViewEmployee.Items.Clear();
                    DisplayInfo(listEmp6, listViewEmployee);
                    break;
                case 6:
                    int temp1 = comboBoxSearchStatusID.SelectedIndex + 1;
                    search = temp1.ToString();
                    column = "StatusId";
                    Emp employeeInstance7 = new Emp();
                    List<Emp> listEmp7 = employeeInstance7.SearchEmployees(search, column);
                    listViewEmployee.Items.Clear();
                    DisplayInfo(listEmp7, listViewEmployee);
                    break;
            }
        }

        private void buttonSearchUser_Click(object sender, EventArgs e)
        {
            string search, column;
            switch (comboBoxSearchUser.SelectedIndex)
            {
                case 0:
                    search = textBoxUserSearch.Text.Trim();
                    column = "EmployeeID";
                    User userInstance = new User();
                    List<User> listUser = userInstance.SearchUsers(search, column);
                    listViewUser.Items.Clear();
                    DisplayInfos(listUser, listViewUser);
                    break;
                case 1:
                    search = textBoxUserSearch.Text.Trim();
                    column = "UserName";
                    User userInstance1 = new User();
                    List<User> listUser1 = userInstance1.SearchUsers(search, column);
                    listViewUser.Items.Clear();
                    DisplayInfos(listUser1, listViewUser);
                    break;
                case 2:
                    int temp1 = comboBoxSearchUserJobID.SelectedIndex + 1;
                    search = temp1.ToString();
                    column = "JobId";
                    User userInstance2 = new User();
                    List<User> listUser2 = userInstance2.SearchUsers(search, column);
                    listViewUser.Items.Clear();
                    DisplayInfos(listUser2, listViewUser);
                    break;
                case 3:
                    int temp = comboBoxSearchUserStatusID.SelectedIndex + 1;
                    search = temp.ToString();
                    column = "StatusId";
                    User userInstance3 = new User();
                    List<User> listUser3 = userInstance3.SearchUsers(search, column);
                    listViewUser.Items.Clear();
                    DisplayInfos(listUser3, listViewUser);
                    break;
            }

        }

       
        private void comboBoxSearchUser_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBoxSearchUser.SelectedIndex)
            {
                case 0:
                    labelSearchUser.Text = "Employee ID";
                    textBoxUserSearch.Visible = true;
                    labelSearchUser.Visible = true;
                    comboBoxSearchUserStatusID.Visible = false;
                    comboBoxSearchUserJobID.Visible = false;
                    break;
                case 1:
                    labelSearchUser.Text = "User Name";
                    textBoxUserSearch.Visible = true;
                    labelSearchUser.Visible = true;
                    comboBoxSearchUserStatusID.Visible = false;
                    comboBoxSearchUserJobID.Visible = false;
                    break;
                case 2:
                    labelSearchUser.Text = "Job Title";
                    textBoxUserSearch.Visible = false;
                    labelSearchUser.Visible = true;
                    comboBoxSearchUserStatusID.Visible = false;
                    comboBoxSearchUserJobID.Visible = true;
                    break;
                case 3:
                    labelSearchUser.Text = "Status";
                    textBoxUserSearch.Visible = false;
                    labelSearchUser.Visible = true;
                    comboBoxSearchUserStatusID.Visible = true;
                    comboBoxSearchUserJobID.Visible = false;
                    break;
                default:
                    MessageBox.Show("Invalid selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSearch.SelectedIndex)
            {
                case 0:
                    labelSearch1.Text = "Employee ID";
                    textBoxSearch1.Visible = true;
                    labelSearch1.Visible = true;
                    comboBoxSearchStatusID.Visible = false;
                    comboBoxSearchJobID.Visible = false;
                    break;
                case 1:
                    labelSearch1.Text = "First Name";
                    textBoxSearch1.Visible = true;
                    labelSearch1.Visible = true;
                    comboBoxSearchStatusID.Visible = false;
                    comboBoxSearchJobID.Visible = false;
                    break;
                case 2:
                    labelSearch1.Text = "Last Name";
                    textBoxSearch1.Visible = true;
                    labelSearch1.Visible = true;
                    comboBoxSearchStatusID.Visible = false;
                    comboBoxSearchJobID.Visible = false;
                    break;
                case 3:
                    labelSearch1.Text = "Email";
                    textBoxSearch1.Visible = true;
                    labelSearch1.Visible = true;
                    comboBoxSearchStatusID.Visible = false;
                    comboBoxSearchJobID.Visible = false;
                    break;
                case 4:
                    labelSearch1.Text = "Phone";
                    textBoxSearch1.Visible = true;
                    labelSearch1.Visible = true;
                    comboBoxSearchStatusID.Visible = false;
                    comboBoxSearchJobID.Visible = false;
                    break;
                case 5:
                    labelSearch1.Text = "Job ID";
                    comboBoxSearchJobID.Visible = true;
                    labelSearch1.Visible = true;
                    textBoxSearch1.Visible = false;
                    comboBoxSearchStatusID.Visible = false;
                    break;
                case 6:
                    labelSearch1.Text = "Status ID";
                    comboBoxSearchStatusID.Visible = true;
                    textBoxSearch1.Visible = false;
                    labelSearch1.Visible = true;
                    comboBoxSearchJobID.Visible = false;
                    break;
                default:
                    MessageBox.Show("Invalid selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
