using BookSupply.BLL;
using BookSupply.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookSupply.GUI
{
    public partial class OrderClerksForm : Form
    {
        public OrderClerksForm()
        {
            InitializeComponent();
            comboBoxCustomerId.DataSource = GetCustomerIds();
            comboBoxEmployeeId.DataSource = GetEmployeeIds();
            comboBoxOrderId.DataSource = GetOrdersId();
            comboBoxISBN.DataSource = GetISBNs();


        }

        public static List<long> GetISBNs()
        {
            List<long> isbns;
            using (var context = new HiTechDBEntities1())
            {
                isbns = context.Books.Select(b => (long)b.ISBN).ToList();
            }
            return isbns;
        }


        public static  List<int> GetOrdersId()
        {
            List<int> ordersId;
            using (var context = new HiTechDBEntities1())
            {
                ordersId = context.Orders.Select(o => (int)o.OrderId).ToList();
            }
            return ordersId;
        }

        public static List<int> GetEmployeeIds()
        {
            List<int> employeeIds;
            using (var context = new HiTechDBEntities1())
            {
                employeeIds = context.Employees.Select(emp => (int)emp.EmployeeId).ToList();
            }
            return employeeIds;
        }






        private void buttonAddO_Click_1(object sender, EventArgs e)
        {
            // Verifica se todos os campos obrigatórios foram preenchidos
            if (string.IsNullOrWhiteSpace(textBoxOrderId.Text) ||
                string.IsNullOrWhiteSpace(comboBoxOrderStatus.Text) ||
                string.IsNullOrWhiteSpace(comboBoxOrderType.Text) ||
                string.IsNullOrWhiteSpace(comboBoxEmployeeId.Text) ||
                string.IsNullOrWhiteSpace(comboBoxCustomerId.Text))
            {
                MessageBox.Show("All fields must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cria uma nova instância de Order com os dados do formulário
            Order newOrder = new Order
            {
                OrderId = Convert.ToInt32(textBoxOrderId.Text),
                OrderDate = DateTime.Now,
                ShippingDate = DateTime.Now.AddDays(4),
                OrderStatus = Convert.ToInt32(comboBoxOrderStatus.Text),
                OrderType = comboBoxOrderType.Text,
                EmployeeId = Convert.ToInt32(comboBoxEmployeeId.Text),
                CustomerId = Convert.ToInt32(comboBoxCustomerId.Text)
            };

            using (var context = new HiTechDBEntities1()) // Assuming BookSupplyContext is correct
            {
                // Adiciona a nova ordem ao contexto do Entity Framework
                context.Orders.Add(newOrder);

                try
                {
                    // Salva as alterações no banco de dados
                    context.SaveChanges();
                    MessageBox.Show("Order added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void buttonUpdateO_Click(object sender, EventArgs e)
        {
            // Check if the OrderId TextBox is filled
            if (!string.IsNullOrEmpty(textBoxOrderId.Text))
            {
                int orderId = Convert.ToInt32(textBoxOrderId.Text);

                using (var context = new HiTechDBEntities1())
                {
                    // Retrieve the order from the database
                    Order existingOrder = context.Orders.FirstOrDefault(o => o.OrderId == orderId);

                    if (existingOrder != null)
                    {
                        // Apply the changes
                        existingOrder.OrderDate = DateTime.Now;
                        existingOrder.ShippingDate = DateTime.Now.AddDays(4);
                        existingOrder.OrderStatus = Convert.ToInt32(comboBoxOrderStatus.Text);
                        existingOrder.OrderType = comboBoxOrderType.Text;
                        existingOrder.EmployeeId = Convert.ToInt32(comboBoxEmployeeId.Text);
                        existingOrder.CustomerId = Convert.ToInt32(comboBoxCustomerId.Text);

                        // Save the changes to the database
                        context.SaveChanges();

                        MessageBox.Show("Order updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Order not found.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Order ID.");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Check if the OrderId TextBox is filled
            if (!string.IsNullOrEmpty(textBoxOrderId.Text))
            {
                int orderId = Convert.ToInt32(textBoxOrderId.Text);

                using (var context = new HiTechDBEntities1())
                {
                    // Retrieve the order from the database
                    Order existingOrder = context.Orders.FirstOrDefault(o => o.OrderId == orderId);

                    if (existingOrder != null)
                    {
                        // Set the order status to cancelled
                        existingOrder.OrderStatus = 3;

                        // Save the changes to the database
                        context.SaveChanges();

                        MessageBox.Show("Order cancelled successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Order not found.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Order ID.");
            }
        }

        private void buttonSearchO_Click(object sender, EventArgs e)
        {
            // Verifique se o TextBox de pesquisa está preenchido
            if (!string.IsNullOrEmpty(textBoxSearchO.Text))
            {
                using (var context = new HiTechDBEntities1())
                {
                    // Determine qual opção de pesquisa foi selecionada na ComboBox
                    string searchOption = comboBoxSearchO.SelectedItem.ToString();
                    string searchString = textBoxSearchO.Text;

                    // Limpe os itens existentes no ListView
                    listViewOrder.Items.Clear();

                    // Realize a consulta com base na opção de pesquisa selecionada
                    switch (searchOption)
                    {
                        case "Order ID":
                            int orderId = Convert.ToInt32(searchString);
                            var ordersById = context.Orders.Where(o => o.OrderId == orderId).ToList();
                            AddOrdersToListView(ordersById);
                            break;
                        case "Customer ID":
                            int customerId = Convert.ToInt32(searchString);
                            var ordersByCustomerId = context.Orders.Where(o => o.CustomerId == customerId).ToList();
                            AddOrdersToListView(ordersByCustomerId);
                            break;
                        case "Employee ID":
                            int employeeId = Convert.ToInt32(searchString);
                            var ordersByEmployeeId = context.Orders.Where(o => o.EmployeeId == employeeId).ToList();
                            AddOrdersToListView(ordersByEmployeeId);
                            break;
                        case "Status ID":
                            int statusId = Convert.ToInt32(searchString);
                            var ordersByStatusId = context.Orders.Where(o => o.OrderStatus == statusId).ToList();
                            AddOrdersToListView(ordersByStatusId);
                            break;
                        default:
                            MessageBox.Show("Invalid search option.");
                            return;
                    }

                    // Exiba uma mensagem se não houver resultados
                    if (listViewOrder.Items.Count == 0)
                    {
                        MessageBox.Show("No orders found matching the search criteria.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a search term.");
            }
        }
        private void AddOrdersToListView(List<Order> orders)
        {
            foreach (var order in orders)
            {
                // Crie um item de lista para cada ordem e adicione-o ao ListView
                ListViewItem item = new ListViewItem(order.OrderId.ToString());
                item.SubItems.Add(order.OrderDate.ToShortDateString());
                item.SubItems.Add(order.ShippingDate.ToString());
                item.SubItems.Add(order.OrderStatus.ToString());
                item.SubItems.Add(order.OrderType);
                item.SubItems.Add(order.EmployeeId.ToString());
                item.SubItems.Add(order.CustomerId.ToString());

                listViewOrder.Items.Add(item);
            }
        }

        private void buttonListAllO_Click(object sender, EventArgs e)
        {
            using (var context = new HiTechDBEntities1())
            {
                // Limpe os itens existentes no ListView
                listViewOrder.Items.Clear();

                // Recupere todas as ordens do banco de dados
                var allOrders = context.Orders.ToList();

                // Ordenar a lista de pedidos pelo ID do pedido
                allOrders = allOrders.OrderBy(order => order.OrderId).ToList();

                // Adicione todas as ordens ao ListView
                AddOrdersToListView(allOrders);

                // Exiba uma mensagem se não houver ordens
                if (listViewOrder.Items.Count == 0)
                {
                    MessageBox.Show("No orders found.");
                }
            }
        }


        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        public static List<int> GetCustomerIds()
        {
            List<int> customerIds;
            using (var context = new HiTechDBEntities1()) // Substitua YourDbContext pelo seu contexto do Entity Framework
            {
                customerIds = context.Customers.Select(c => (int)c.CustomerId).ToList();
            }
            return customerIds;
        }

        private void buttonAddOrderLine_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos obrigatórios foram preenchidos
            if (string.IsNullOrWhiteSpace(comboBoxOrderId.Text) ||
                string.IsNullOrWhiteSpace(comboBoxISBN.Text) ||
                string.IsNullOrWhiteSpace(textBoxQuantity.Text))
            {
                MessageBox.Show("All fields must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int orderId = Convert.ToInt32(comboBoxOrderId.Text);
            long isbn = Convert.ToInt64(comboBoxISBN.Text);
            int quantityOrdered = Convert.ToInt32(textBoxQuantity.Text);

            // Verifica se a quantidade solicitada está disponível no estoque
            if (!IsQuantityAvailable(isbn, quantityOrdered))
            {
                MessageBox.Show("Requested quantity is not available in stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cria uma nova instância de OrderLine com os dados do formulário
            OrderLine newOrderLine = new OrderLine
            {
                OrderId = orderId,
                ISBN = isbn,
                QuantityOrdered = quantityOrdered
            };

            using (var context = new HiTechDBEntities1())
            {
                // Adiciona a nova linha de pedido ao contexto do Entity Framework
                context.OrderLines.Add(newOrderLine);

                try
                {
                    // Salva as alterações no banco de dados
                    context.SaveChanges();
                    MessageBox.Show("Order Line added successfully.");

                    // Reduz a quantidade disponível do livro no estoque
                    ReduceBookQuantity(isbn, quantityOrdered);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding order line: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método para reduzir a quantidade disponível do livro no estoque
        private void ReduceBookQuantity(long isbn, int quantityOrdered)
        {
            using (var context = new HiTechDBEntities1())
            {
                // Consulta o livro no banco de dados
                var book = context.Books.FirstOrDefault(b => b.ISBN == isbn);

                if (book != null)
                {
                    // Reduz a quantidade disponível do livro no estoque
                    book.Quantity -= quantityOrdered;
                    context.SaveChanges();
                }
            }
        }


        private bool IsQuantityAvailable(long isbn, int quantityRequested)
        {
            using (var context = new HiTechDBEntities1())
            {

                var book = context.Books.FirstOrDefault(b => b.ISBN == isbn);


                return book != null && book.Quantity >= quantityRequested;
            }
        }



        private void buttonListAllOrderLine_Click(object sender, EventArgs e)
        {
            using (var context = new HiTechDBEntities1())
            {
                // Limpe os itens existentes no ListView
                listViewOrderLine.Items.Clear();

                // Recupere todas as linhas de pedidos do banco de dados
                var allOrderLines = context.OrderLines.ToList();

                // Adicione todas as linhas de pedidos ao ListView
                AddOrderLinesToListView(allOrderLines);

                // Exiba uma mensagem se não houver linhas de pedidos
                if (listViewOrderLine.Items.Count == 0)
                {
                    MessageBox.Show("No order lines found.");
                }
            }
        }

        private void AddOrderLinesToListView(List<OrderLine> orderLines)
        {
            foreach (var orderLine in orderLines)
            {
                
                ListViewItem item = new ListViewItem(orderLine.OrderId.ToString());
                item.SubItems.Add(orderLine.ISBN.ToString());
                item.SubItems.Add(orderLine.QuantityOrdered.ToString());

                listViewOrderLine.Items.Add(item);
            }
        }

    }
}
