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
            employee.FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBoxFirstName.Text.Trim().ToLower());
            employee.LastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBoxLastName.Text.Trim().ToLower());
            employee.PhoneNumber = Convert.ToInt64(textBoxPhone.Text.Trim());
            employee.Email = textBoxEmail.Text.Trim();
            employee.JobId = comboBoxJobId.SelectedIndex + 1;
            employee.StatusId = comboBoxStatusID.SelectedIndex + 1;
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
                    item.SubItems.Add(emp.StatusId.ToString());
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
            if(textBoxEmployeeIDU.Text == "" || textBoxFirstNameU.Text == "" || textBoxLastNameU.Text == "" || 
                textBoxEmailU.Text == "" || comboBoxJobIDU.SelectedIndex == -1 || comboBoxStatusIDU.SelectedIndex == -1 || textBoxPhoneNumberU.Text == "" )
            {
                MessageBox.Show("Please search by EmployeeID before procede with update or \n" + 
                    "fill in all fields before proceeding.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(int.TryParse(textBoxEmployeeIDD.Text,out int employeeId))
                {
                    Employee employee = new Employee();

                    //before update, check if ID exist and all fields has a valid input
                    input = textBoxEmployeeIDU.Text.Trim();
                    if(employee.IsUniqueEmployeeId("Employees","EmployeeId",Convert.ToInt32(input)))
                    {
                        MessageBox.Show("ID not found", "Error ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxEmployeeIDD.Focus();
                        return;
                    }
                    

                    input = textBoxFirstNameU.Text.Trim();
                    if(!Validator.IsValidName(input))
                    {
                        MessageBox.Show("Invalid First Name.", "Invalid");
                        textBoxFirstName.Focus();
                        return;
                    }

                    input = textBoxLastNameU.Text.Trim();
                    if (!Validator.IsValidName(input))
                    {
                        MessageBox.Show("Invalid Last Name.", "Invalid");
                        textBoxLastName.Focus();
                        return;
                    }

                    input = textBoxEmailU.Text.Trim();
                    if (!Validator.isValidEmail(input))
                    {
                        MessageBox.Show("Invalid Email.", "Invalid");
                        textBoxEmail.Focus();
                        return;
                    }

                    input = textBoxPhoneNumberU.Text.Trim();
                    if (!Validator.IsValidPhoneNumber(input))
                    {
                        MessageBox.Show("Invalid Phone Number.", "Invalid");
                        textBoxPhone.Focus();
                        return;
                    }


                    employee.EmployeeId = Convert.ToInt32(textBoxEmployeeIDU.Text.Trim());
                    employee.FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBoxFirstNameU.Text.Trim().ToLower());
                    employee.LastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textBoxLastNameU.Text.Trim().ToLower());
                    employee.Email = textBoxEmailU.Text.Trim();
                    employee.PhoneNumber = Convert.ToInt64(textBoxPhoneNumberU.Text.Trim());
                    employee.JobId = comboBoxJobId.SelectedIndex + 1;
                    employee.StatusId = comboBoxStatusID.SelectedIndex + 1;


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
            if (textBoxEmployeeIDD.Text.Trim() == "")
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
                        input = textBoxEmployeeIDD.Text.Trim();
                        if (employee.IsUniqueEmployeeId("Employees","EmployeeId",Convert.ToInt32(input)))
                        {
                            MessageBox.Show("ID not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxEmployeeIDD.Focus();
                            return;

                        }
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

        private void buttonSaveUser_Click(object sender, EventArgs e)
        {

            User user = new User();
            user.UserName = textBoxUserName.Text.Trim();
            user.Password = textBoxUserPassword.Text.Trim();
            user.EmployeeId = Convert.ToInt32(textBoxUserEmpID.Text.Trim());
            user.StatusId = Convert.ToInt16(comboBoxUserStatusId.SelectedIndex+1);
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
                    ListViewItem item = new ListViewItem(
                    user.UserId.ToString() );
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

                    user.EmployeeId = Convert.ToInt32(textBoxUserEmpID.Text.Trim());
                    user.UserName = textBoxUserName.Text.Trim();
                    user.Password = textBoxUserPassword.Text.Trim();
                    user.StatusId = comboBoxUserStatusId.SelectedIndex + 1;
                    DialogResult result = MessageBox.Show("Are you sure you want to update this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        
                        try
                        {
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

        private void comboBoxJobId_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelJobId.Text = HiTechDB.SearchJob(comboBoxJobId.SelectedIndex + 1 ); 
            
        }

        private void comboBoxStatusID_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelStatusID.Text = HiTechDB.SearchStatus(comboBoxStatusID.SelectedIndex + 1);
        }

        private void comboBoxJobIDu_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelJobIDu.Text = HiTechDB.SearchJob(comboBoxJobIDU.SelectedIndex + 1);
        }

        private void comboBoxStatusIDu_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelStatusIDu.Text = HiTechDB.SearchStatus(comboBoxStatusIDU.SelectedIndex + 1);
        }

        private void buttonDeleteEmployee_Click_1(object sender, EventArgs e)
        {
            if (textBoxEmployeeIDD.Text.Trim() == "")
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
                        input = textBoxEmployeeIDD.Text.Trim();
                        if (!employee.IsUniqueEmployeeId("Employees", "EmployeeId", Convert.ToInt32(input)))
                        {
                            MessageBox.Show("ID not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxEmployeeIDD.Focus();
                            return;

                        }
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

        private void buttonSearchEmployee_Click(object sender, EventArgs e)
        {
            string search, column ;
            switch (comboBoxSearch.SelectedIndex)
            {
                case 0:
                    search = textBoxSearch1.Text.Trim();
                    column = "EmployeeID";
                    Employee employeeInstance = new Employee();
                    List<Employee> listEmp = employeeInstance.SearchEmployees(search, column); 
                    listViewEmployee.Items.Clear();
                    DisplayInfo(listEmp, listViewEmployee);
                    break;
                case 1:
                    search = textBoxSearch1.Text.Trim();
                    column = "FirstName";
                    Employee employeeInstance1 = new Employee();
                    List<Employee> listEmp1 = employeeInstance1.SearchEmployees(search, column);
                    listViewEmployee.Items.Clear();
                    DisplayInfo(listEmp1, listViewEmployee);
                    break;
                case 2:
                    search = textBoxSearch1.Text.Trim();
                    column = "LastName";
                    Employee employeeInstance2 = new Employee();
                    List<Employee> listEmp2 = employeeInstance2.SearchEmployees(search, column);
                    listViewEmployee.Items.Clear();
                    DisplayInfo(listEmp2, listViewEmployee);
                    break;            
                case 3:
                    search = textBoxSearch1.Text.Trim();
                    column = "Email";
                    Employee employeeInstance4 = new Employee();
                    List<Employee> listEmp4 = employeeInstance4.SearchEmployees(search, column);
                    listViewEmployee.Items.Clear();
                    DisplayInfo(listEmp4, listViewEmployee);
                    break;
                case 4:
                    search = textBoxSearch1.Text.Trim();
                    column = "PhoneNumber";
                    Employee employeeInstance5 = new Employee();
                    List<Employee> listEmp5 = employeeInstance5.SearchEmployees(search, column);
                    listViewEmployee.Items.Clear();
                    DisplayInfo(listEmp5, listViewEmployee);
                    break;
                case 5:
                    int temp = comboBoxSearchJobID.SelectedIndex + 1;
                    search = temp.ToString();
                    column = "JobID";
                    Employee employeeInstance6 = new Employee();
                    List<Employee> listEmp6 = employeeInstance6.SearchEmployees(search, column);
                    listViewEmployee.Items.Clear();
                    DisplayInfo(listEmp6, listViewEmployee);
                    break;
                case 6:
                    int temp1 = comboBoxSearchStatusID.SelectedIndex + 1;
                    search = temp1.ToString() ;
                    column = "StatusID";
                    Employee employeeInstance7 = new Employee();
                    List<Employee> listEmp7 = employeeInstance7.SearchEmployees(search, column);
                    listViewEmployee.Items.Clear();
                    DisplayInfo(listEmp7, listViewEmployee);
                    break;

            }
        }

        private void comboBoxSearchUser_SelectedIndexChanged(object sender, EventArgs e)
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
                    labelSearchUser.Text = "Job ID";
                    textBoxUserSearch.Visible = false;
                    labelSearchUser.Visible = true;
                    comboBoxSearchUserStatusID.Visible = false;
                    comboBoxSearchUserJobID.Visible = true;
                    break;
                case 3:
                    labelSearchUser.Text = "Status ID";
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
                    column = "JobID";
                    User userInstance2 = new User();
                    List<User> listUser2 = userInstance2.SearchUsers(search, column);
                    listViewUser.Items.Clear();
                    DisplayInfos(listUser2, listViewUser);
                    break;
                case 3:
                    int temp = comboBoxSearchUserStatusID.SelectedIndex + 1;
                    search = temp.ToString();
                    column = "StatusID";
                    User userInstance3 = new User();
                    List<User> listUser3 = userInstance3.SearchUsers(search, column);
                    listViewUser.Items.Clear();
                    DisplayInfos(listUser3, listViewUser);
                    break;
            }
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            if (textBoxUserID.Text.Trim() == "")
            {
                MessageBox.Show("User ID must be a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you aure you want to delete this user?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string input = "";
                        User user = new User();

                        //before delete, check if ID exists
                        input = textBoxUserID.Text.Trim();
                        if (!user.IsUniqueUserId("UserAccounts","UserId",Convert.ToInt32(input)))
                        {
                            MessageBox.Show("ID not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxEmployeeIDD.Focus();
                            return;

                        }
                        user.UserId = Convert.ToInt32(textBoxUserID.Text.Trim());
                        user.StatusId = 2;
                        user.DeleteUser(user.UserId, user.StatusId);
                        MessageBox.Show("User deleted", "Confirmation");
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

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    
}
