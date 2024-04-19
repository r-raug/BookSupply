using BookSupply.DAL;
using BookSupply.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BookSupply.BLL
{
    public class Login
    {

        private string userName, password, jobId;
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string JobId { get => jobId; set => jobId = value; }

        public Login()
        {
            UserName = string.Empty;
            Password = string.Empty;
            JobId = string.Empty;
        }

        public void CheckUser()
        {
            
            HiTechDB.LoginUser(this);
            switch (JobId)
            {
                case "1":
                    EmployeeUserForm employeeUserForm = new EmployeeUserForm();
                    employeeUserForm.ShowDialog();
                    break;
                //case "2":
                //    EmployeeUserForm employeeUserForm = new EmployeeUserForm();
                //    employeeUserForm.ShowDialog();
                //    break;

                case "3":
                    InventoryForm inventoryController = new InventoryForm();
                    inventoryController.ShowDialog();
                    break;

                //case "4":
                //    EmployeeUserForm employeeUserForm = new EmployeeUserForm();
                //    employeeUserForm.ShowDialog();
                //    break;

                default:
                    MessageBox.Show("Invalid User / Password");
                    break;
            }
           
        }



    }
}
