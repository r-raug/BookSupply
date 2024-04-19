using BookSupply.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookSupply.GUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            textBoxLoginPassword.UseSystemPasswordChar = true;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            
            string username = textBoxLoginUser.Text.Trim();
            string password = textBoxLoginPassword.Text.Trim();
            login.UserName = username;
            login.Password = password;
            textBoxLoginUser.Clear();
            textBoxLoginPassword.Clear();
            login.CheckUser();            
  
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
