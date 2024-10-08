using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookSupply.BLL;
using System.Windows.Forms.VisualStyles;
using BookSupply.VALIDATION;
using BookSupply.DAL;
using System.Data.SqlClient;

namespace BookSupply.GUI
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }       


        private void ClearCustomerFields()
        {
            textBoxCustomerName.Text = string.Empty;           
            textBoxEmailC.Text = string.Empty;
            textBoxPhoneC.Text = string.Empty;
            textBoxStreet.Text = string.Empty;
            comboBoxProvince.Text = string.Empty;
            textBoxPostalCode.Text = string.Empty;
            comboBoxStatus.Text = string.Empty; // Alterado para int
        }



        private void DisplayCustomerInfo(List<Customers1> customerList, ListView listView)
        {
            listView.Items.Clear();
            if (customerList != null)
            {
                foreach (Customers1 customer in customerList)
                {
                    ListViewItem item = new ListViewItem(customer.CustomerId.ToString());
                    item.SubItems.Add(customer.CustomerName); 
                    item.SubItems.Add(customer.PhoneNumber.ToString());
                    item.SubItems.Add(customer.Email);
                    item.SubItems.Add(customer.Street); 
                    item.SubItems.Add(customer.Province);
                    item.SubItems.Add(customer.PostalCode);
                    item.SubItems.Add(customer.Status.ToString());
                    
                    listView.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Não há clientes no banco de dados.", "Dados ausentes");
            }
        }

    


        private void buttonLogout_Click(object sender, EventArgs e)
        {
            
            
             Close();
            
        }

        private void buttonSaveC_Click_1(object sender, EventArgs e)
        {
            string input = "";
            input = textBoxCustomerName.Text.Trim();
            if (!Validator.IsValidName(input))
            {
                MessageBox.Show("Invalid Customer Name.", "Invalid");
                textBoxCustomerName.Focus();
                return;
            }

            // Remova a validação para o sobrenome, pois estamos usando apenas o nome completo

            input = textBoxEmailC.Text.Trim();
            if (!Validator.isValidEmail(input))
            {
                MessageBox.Show("Invalid Email.", "Invalid");
                textBoxEmailC.Focus();
                return;
            }

            input = textBoxPhoneC.Text.Trim();
            if (!Validator.IsValidPhoneNumber(input))
            {
                MessageBox.Show("Invalid Phone Number.", "Invalid");
                textBoxPhoneC.Focus();
                return;
            }

            // Validar textBoxStreet
            string street = textBoxStreet.Text.Trim();
            if (string.IsNullOrEmpty(street))
            {
                MessageBox.Show("Street cannot be empty.", "Invalid");
                textBoxStreet.Focus();
                return;
            }

            // Validar comboBoxProvince
            if (comboBoxProvince.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a province.", "Invalid");
                comboBoxProvince.Focus();
                return;
            }

            // Validar textBoxPostalCode
            string postalCode = textBoxPostalCode.Text.Trim();
            if (string.IsNullOrEmpty(postalCode))
            {
                MessageBox.Show("Invalid Postal Code.", "Invalid");
                textBoxPostalCode.Focus();
                return;
            }

            // Validar comboBoxStatus
            if (comboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a status.", "Invalid");
                comboBoxStatus.Focus();
                return;
            }


            Customers1 customer = new Customers1(
                textBoxCustomerName.Text,              
                textBoxEmailC.Text,
                Convert.ToInt64(textBoxPhoneC.Text),
                textBoxStreet.Text,
                comboBoxProvince.Text,
                textBoxPostalCode.Text,
                Convert.ToInt32(comboBoxStatus.Text) // Alterado para int
            );

            // Salvar o cliente no banco de dados

            Customers1.SaveCustomer(customer);

            // Limpar os campos do formulário após salvar
            ClearCustomerFields();
        }

        private void buttonUpdateCust_Click_1(object sender, EventArgs e)
        {
            string input = "";

            // Verifica se o campo de nome do cliente está vazio
            if (textBoxCustomerNameU.Text == "")
            {
                MessageBox.Show("Customer Name must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se o campo de e-mail está vazio
            if (textBoxEmailCustU.Text == "")
            {
                MessageBox.Show("Email must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se o campo de telefone está vazio
            if (textBoxPhoneCustU.Text == "")
            {
                MessageBox.Show("Phone Number must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se o campo de rua está vazio
            if (textBoxStreetU.Text == "")
            {
                MessageBox.Show("Street must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se o campo de província está vazio
            if (comboBoxProvinceU.Text == "")
            {
                MessageBox.Show("Province must be selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se o campo de código postal está vazio
            if (textBoxPostalCodeU.Text == "")
            {
                MessageBox.Show("Postal Code must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validação dos campos
            input = textBoxCustomerNameU.Text.Trim();
            if (!Validator.IsValidName(input))
            {
                MessageBox.Show("Invalid Customer Name.", "Invalid");
                textBoxCustomerName.Focus();
                return;
            }

            input = textBoxEmailCustU.Text.Trim();
            if (!Validator.isValidEmail(input))
            {
                MessageBox.Show("Invalid Email.", "Invalid");
                textBoxEmailCustU.Focus();
                return;
            }

            input = textBoxPhoneCustU.Text.Trim();
            if (!Validator.IsValidPhoneNumber(input))
            {
                MessageBox.Show("Invalid Phone Number.", "Invalid");
                textBoxPhoneCustU.Focus();
                return;
            }

            // Criação de uma instância de Customers1 com os dados do formulário
            Customers1 customer = new Customers1();
            customer.CustomerName = textBoxCustomerNameU.Text.Trim();
            customer.Email = textBoxEmailCustU.Text.Trim();
            customer.PhoneNumber = Convert.ToInt64(textBoxPhoneCustU.Text.Trim());
            customer.Street =  textBoxStreetU.Text.Trim();
            customer.Province = comboBoxProvinceU.Text.Trim();
            customer.PostalCode = textBoxPostalCodeU.Text.Trim();
          

            // Chama o método UpdateCustomer passando a instância de Customers1
            customer.UpdateCustomer(customer);
        }

        private void buttonListAllC_Click_1(object sender, EventArgs e)
        {
            listViewCustomers.Items.Clear();
            Customers1 customer = new Customers1();
            List<Customers1> customerList = customer.GetCustomerList();
            DisplayCustomerInfo(customerList, listViewCustomers);

        }


        private void buttonSearchCust_Click(object sender, EventArgs e)
        {
            string search, column;          

            switch (comboBoxSearchC.SelectedIndex)
            {
                case 0:
                    search = textBoxSearchC.Text.Trim();
                    column = "CustomerId";
                    Customers1 customerInstance0 = new Customers1();
                    List<Customers1> customersList0 = customerInstance0.SearchCustomers(search, column);
                    listViewCustomers.Items.Clear();
                    if (customersList0.Count > 0)
                    {
                        DisplayCustomerInfo(customersList0, listViewCustomers);
                    }
                    break;

                case 1:
                    search = textBoxSearchC.Text.Trim();
                    column = "CustomerName";
                    Customers1 customerInstance1 = new Customers1();
                    List<Customers1> listCustomers1 = customerInstance1.SearchCustomers(search, column);
                    listViewCustomers.Items.Clear();
                    DisplayCustomerInfo(listCustomers1, listViewCustomers);
                    break;               
            }
        }





        private void buttonCustDelete_Click_1(object sender, EventArgs e)
        {
            if (textBoxCustomerIdToDelete.Text.Trim() == "")
            {
                MessageBox.Show("Customer ID must be a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string input = "";
                        Customers1 cust = new Customers1();

                        //before delete, check if ID exists
                        input = textBoxCustomerIdToDelete.Text.Trim();
                        if (!cust.IsUniqueCustomerId(Convert.ToInt32(input)))
                        {
                            MessageBox.Show("ID not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxCustomerIdToDelete.Focus();
                            return;
                        }

                        // Define o ID e o status para excluir o cliente
                        int customerId = Convert.ToInt32(textBoxCustomerIdToDelete.Text.Trim());
                        int status = 2; // Define o status aqui, se necessário
                        cust.DeleteCustomer(customerId,status);
                        // Chama o método para excluir o cliente
                       
                       
                        

                        MessageBox.Show("Customer deleted", "Confirmation");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Operation canceled.", "Confirmation");
                }
            }
        }


        private void comboBoxSearchC_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSearchC.SelectedIndex)
            {
                case 0:
                    labelSearch1C.Text = "Customer ID";
                    textBoxSearchC.Visible = true;
                    labelSearch1C.Visible = true;                   
                    break;
                case 1:
                    labelSearch1C.Text = "Customer Name";
                    textBoxSearchC.Visible = true;
                    labelSearch1C.Visible = true;                   
                    break;
            }
        }
    }
}
