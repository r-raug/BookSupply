using BookSupply.BLL;
using BookSupply.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace BookSupply.GUI
{
    public partial class InventoryForm : Form
    {
        private InventoryController inventoryController;

        public InventoryForm()
        {
            InitializeComponent();
            inventoryController = new InventoryController();
        }

        HiTechDBEntities1 db = new HiTechDBEntities1();



        private void buttonListBooks_Click(object sender, EventArgs e)
        {
            listViewBooks.Items.Clear();
            var listB = (from books in db.Books 
                         join publisher in db.Publishers on books.PublisherId equals publisher.PublisherId
                         join category in db.Categories on books.CategoryId equals category.CategoryId
                         join status in db.Statuses on books.Status equals status.StatusId
                         join authorB in db.AuthorsBooks on books.ISBN equals authorB.ISBN
                         join author in db.Authors on authorB.AuthorId equals author.AuthorId
                         orderby books.ISBN
                         select new { 
                        books.ISBN, books.BookTitle, books.UnitPrice, books.Quantity, publisher.PublisherName,
                        category.CategName, status.Description, authorB.YearPublished, authorB.Edition, author.FirstName, author.LastName}).ToList();
            if(listB.Count == 0)
            {
                MessageBox.Show("No books in the database.");
                return;
            }
            foreach(var books in listB) {ListViewItem item = new ListViewItem(books.ISBN.ToString());
                           item.SubItems.Add(books.BookTitle);
                           item.SubItems.Add(books.FirstName + " " + books.LastName);
                           item.SubItems.Add(books.UnitPrice.ToString());
                           item.SubItems.Add(books.Quantity.ToString());
                           item.SubItems.Add(books.YearPublished.ToString());
                           item.SubItems.Add(books.Edition.ToString());
                           item.SubItems.Add(books.PublisherName);
                           item.SubItems.Add(books.CategName);
                           item.SubItems.Add(books.Description);
                           listViewBooks.Items.Add(item);
                       }
        }

        private void buttonListAllPublishers_Click(object sender, EventArgs e)
        {
            listViewPublishers.Items.Clear();
            var listP = (from publisher in db.Publishers
                         join Status in db.Statuses on publisher.StatusId equals Status.StatusId
                         select new
                         {
                             publisher.PublisherId, publisher.PublisherName,
                             publisher.WebAddress, Status.Description
                         }).ToList();
            if (listP.Count == 0)
            {
                MessageBox.Show("No publishers in the database.");
                return;
            }
            foreach (var publisher in listP)
            {
                ListViewItem item = new ListViewItem(publisher.PublisherId.ToString());
                item.SubItems.Add(publisher.PublisherName);
                item.SubItems.Add(publisher.WebAddress);
                item.SubItems.Add(publisher.Description);
                listViewPublishers.Items.Add(item);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var status = 0;
            if (comboBoxSaveStatus.SelectedIndex == 0)
            {
                status = 1;
            }
            else
            {
                status = 2;
            }

            if (textBoxPublisherName.Text == "")
            {
                MessageBox.Show("Please, enter a publisher name.");
            }
            if(comboBoxSaveStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select a status.");
            }
            if (db.Publishers.Any(pub => pub.PublisherName.ToLower().Trim() == textBoxPublisherName.Text.ToLower().Trim()))
                {
                    MessageBox.Show("Publisher already exists.");
                    return;
                }
                var newPublisher = new BLL.Publisher
                {
                    PublisherName = textBoxPublisherName.Text,
                    WebAddress = textBoxWebAddress.Text,
                    StatusId = status

                };
                db.Publishers.Add(newPublisher);
                db.SaveChanges();
                MessageBox.Show("Publisher saved successfully.");
        }

        private void buttonUpdatePublisher_Click(object sender, EventArgs e)
        {
            var publisherID = db.Publishers.Find(Convert.ToInt32(textBoxPublisherID.Text));
            if (db.Publishers.Any(pub => pub.PublisherName.ToLower().Trim() == textBoxPublisherName.Text.ToLower().Trim()))
            {
                MessageBox.Show("Publisher ID not found.");
                return;
            }
            if(textBoxUPublisherName.Text == "")
            {
                MessageBox.Show("Please, enter a publisher name.");
                return;
            }
            if (comboBoxUpdateStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select a status.");
                return;
            }
            if(publisherID != null)
            {
                publisherID.PublisherName = textBoxUPublisherName.Text;
                publisherID.WebAddress = textBoxUwebAddress.Text;
                publisherID.StatusId = comboBoxUpdateStatus.SelectedIndex + 1;
                db.SaveChanges();
                MessageBox.Show("Publisher updated successfully.");
            }else
            {
                MessageBox.Show("Publisher ID not found.");
            }      
        }

        private void buttonDeletePublisher_Click(object sender, EventArgs e)
        {
            var publisherID = db.Publishers.Find(Convert.ToInt32(textBoxDeletePublisherID.Text));
            if (publisherID != null)
            {                
                publisherID.StatusId = 3;
                db.SaveChanges();
                MessageBox.Show("Publisher deleted successfully.");
            }
            else
            {
                MessageBox.Show("Publisher ID not found.");
            }
        }

        private void buttonSearchPublisher_Click(object sender, EventArgs e)
        {
            if(comboBoxSearchPublisher == null)
            {
                MessageBox.Show("Please, select a search criteria.");
                return;
            }

            switch (comboBoxSearchPublisher.SelectedIndex)
            {
                case 0:
                    if(textBoxSearchPublisher.Text == "")
                    {
                        MessageBox.Show("Please, enter a publisher ID.");
                        return;
                    }
                    var searchPubId = db.Publishers.Find(Convert.ToInt32(textBoxSearchPublisher.Text));
                    if (searchPubId != null)
                    {
                        listViewPublishers.Items.Clear();
                        ListViewItem item = new ListViewItem(searchPubId.PublisherId.ToString());
                        item.SubItems.Add(searchPubId.PublisherName);
                        item.SubItems.Add(searchPubId.WebAddress);
                        item.SubItems.Add(searchPubId.StatusId.ToString());
                        listViewPublishers.Items.Add(item);
                    }
                    else
                    {
                        MessageBox.Show("Publisher ID not found.");
                    }
                    break;
                case 1:
                    var searchPubName = db.Publishers.Where(pub => pub.PublisherName.Contains(textBoxSearchPublisher.Text)).ToList();
                    if (searchPubName.Count > 0)
                    {
                        listViewPublishers.Items.Clear();
                        foreach (var publisher in searchPubName)
                        {
                            ListViewItem item = new ListViewItem(publisher.PublisherId.ToString());
                            item.SubItems.Add(publisher.PublisherName);
                            item.SubItems.Add(publisher.WebAddress);
                            item.SubItems.Add(publisher.StatusId.ToString());
                            listViewPublishers.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Publisher name not found.");
                    }
                    break;                
                case 2:
                    if (!int.TryParse(textBoxSearchPublisher.Text, out int searchPubStatusId))
                    {
                        MessageBox.Show("Please enter a valid Status ID.");
                        return;
                    }

                    var searchPubStatus = db.Publishers.Where(pub => pub.StatusId == searchPubStatusId).ToList();
                    if (searchPubStatus.Count > 0)
                    {
                        listViewPublishers.Items.Clear();
                        foreach (var publisher in searchPubStatus)
                        {
                            ListViewItem item = new ListViewItem(publisher.PublisherId.ToString());
                            item.SubItems.Add(publisher.PublisherName);
                            item.SubItems.Add(publisher.WebAddress);
                            item.SubItems.Add(publisher.StatusId.ToString());
                            listViewPublishers.Items.Add(item);
                        }
                    }else
                    {
                        MessageBox.Show("Publisher status not found.");
                    }
                    break;
                default:
                    MessageBox.Show("Invalid search criteria.");
                    break;
            }
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            var filterStatus = inventoryController.FilterStatuses(4, 5);
            comboBoxSCategoryID.DataSource = db.Categories.Select(cat => cat.CategName).ToList();
            comboBoxSCategoryID.SelectedIndex = -1;
            comboBoxUCategoryID.DataSource = db.Categories.Select(cat => cat.CategName).ToList();
            comboBoxUCategoryID.SelectedIndex = -1;
            comboBoxSStatusID.DataSource = filterStatus;
            comboBoxSStatusID.SelectedIndex = -1;
            comboBoxUStatusID.DataSource = filterStatus;
            comboBoxUStatusID.SelectedIndex = -1;
        }

        private void buttonSaveBook_Click(object sender, EventArgs e)
        {
            if(textBoxSISBN.Text == "" || !long.TryParse(textBoxSISBN.Text, out _) || textBoxSISBN.Text.Length != 10)
            {
                MessageBox.Show("Please, enter a valid ISBN (10 digits).");
                return;
            }
            if (decimal.TryParse(textBoxSISBN.Text, out decimal isbn))
            {
                if (db.Books.Any(book => book.ISBN == isbn))
                {
                    MessageBox.Show("Book already exists.");
                    return;
                }
            }
            if (textBoxSBookTitle.Text == "")
            {
                MessageBox.Show("Please, enter a book title.");
                return;
            }
            if(textBoxSPrice.Text == "" || !double.TryParse(textBoxSPrice.Text, out _))
            {
                MessageBox.Show("Please, enter a unit price with decimal number.");
                return;
            }
            if (textBoxSAuthorID.Text == "" || !long.TryParse(textBoxSAuthorID.Text, out _) )
            {
                MessageBox.Show("Please, enter an valid author ID.");
                return;
            }
            if (decimal.TryParse(textBoxSAuthorID.Text, out decimal authorid))
            {
                if (!db.Authors.Any(author => author.AuthorId == authorid))
                {
                    MessageBox.Show("Author ID not found.");
                    return;
                }
            }
            if (textBoxSQuantity.Text == "" || !int.TryParse(textBoxSQuantity.Text, out _))
            {
                MessageBox.Show("Please, enter a quantity.");
                return;
            }
            if(textBoxSPublisherID.Text == "" || !long.TryParse(textBoxSPublisherID.Text, out _))
            {
                MessageBox.Show("Please, enter a valid publisher ID.");
                return;
            }
            if (decimal.TryParse(textBoxSPublisherID.Text, out decimal pubid))
            {
                if (!db.Publishers.Any(pub => pub.PublisherId == pubid))
                {
                    MessageBox.Show("Publisher ID not found.");
                    return;
                }
            }
            if (comboBoxSCategoryID.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select a category.");
                return;
            }
            if(comboBoxSStatusID.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select a status.");
                return;
            }

            if (textBoxSYear.Text == "" ||
                !int.TryParse(textBoxSYear.Text, out int year) ||
                year < 1000 || year > 9999)
            {
                MessageBox.Show("Please, enter a valid year.");
                return;
            }
            if (textBoxSEdition.Text == "" || !int.TryParse(textBoxSEdition.Text, out _))
            {
                MessageBox.Show("Please, enter an edition.");
                return;
            }

            var newBook = new BLL.Book
            {
                ISBN = Convert.ToDecimal(textBoxSISBN.Text),
                BookTitle = textBoxSBookTitle.Text,
                UnitPrice = Convert.ToDecimal(textBoxSPrice.Text),
                Quantity = Convert.ToInt32(textBoxSQuantity.Text),
                PublisherId = Convert.ToInt32(textBoxSPublisherID.Text),
                CategoryId = comboBoxSCategoryID.SelectedIndex + 1,
                Status = comboBoxSStatusID.SelectedIndex + 4
            };
            db.Books.Add(newBook);

            var newAuthorBook = new BLL.AuthorsBook
            {
                ISBN = Convert.ToDecimal(textBoxSISBN.Text),
                AuthorId = Convert.ToInt32(textBoxSAuthorID.Text),
                YearPublished = Convert.ToInt32(textBoxSYear.Text),
                Edition = Convert.ToInt32(textBoxSEdition.Text)
            };
            db.AuthorsBooks.Add(newAuthorBook);

            db.SaveChanges();
            MessageBox.Show("Book saved successfully.");

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxUISBN.Text == "" || !long.TryParse(textBoxUISBN.Text, out _) || textBoxUISBN.Text.Length != 10)
            {
                MessageBox.Show("Please, enter a valid ISBN (10 digits).");
                return;
            }
            if (decimal.TryParse(textBoxUISBN.Text, out decimal isbn))
            {
                if (!db.Books.Any(book => book.ISBN == isbn))
                {
                    MessageBox.Show("Book not found.");
                    return;
                }
            }
            if (textBoxUBookTitle.Text == "")
            {
                MessageBox.Show("Please, enter a book title.");
                return;
            }
            if (textBoxUPrice.Text == "" || !double.TryParse(textBoxUPrice.Text, out _))
            {
                MessageBox.Show("Please, enter a unit price with decimal number.");
                return;
            }
            if (textBoxUAuthorID.Text == "" || !long.TryParse(textBoxUAuthorID.Text, out _))
            {
                MessageBox.Show("Please, enter an valid author ID.");
                return;
            }
            if (decimal.TryParse(textBoxUAuthorID.Text, out decimal authorid))
            {
                if (!db.Authors.Any(author => author.AuthorId == authorid))
                {
                    MessageBox.Show("Author ID not found.");
                    return;
                }
            }
            if (textBoxUQuantity.Text == "" || !int.TryParse(textBoxUQuantity.Text, out _))
            {
                MessageBox.Show("Please, enter a quantity.");
                return;
            }
            if (textBoxUPublisherID.Text == "" || !long.TryParse(textBoxUPublisherID.Text, out _))
            {
                MessageBox.Show("Please, enter a valid publisher ID.");
                return;
            }
            if (decimal.TryParse(textBoxUPublisherID.Text, out decimal pubid))
            {
                if (!db.Publishers.Any(pub => pub.PublisherId == pubid))
                {
                    MessageBox.Show("Publisher ID not found.");
                    return;
                }
            }
            if (comboBoxUCategoryID.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select a category.");
                return;
            }
            if (comboBoxUStatusID.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select a status.");
                return;
            }

            if (textBoxUYear.Text == "" ||
                !int.TryParse(textBoxUYear.Text, out int year) ||
                year < 1000 || year > 9999)
            {
                MessageBox.Show("Please, enter a valid year.");
                return;
            }
            if (textBoxUEdition.Text == "" || !int.TryParse(textBoxUEdition.Text, out _))
            {
                MessageBox.Show("Please, enter an edition.");
                return;
            }

            var isbnB = db.Books.Find(Convert.ToDecimal(textBoxUISBN.Text));
            var authorBook = db.AuthorsBooks.FirstOrDefault(ab => ab.ISBN == isbn);
            if (isbnB != null)
            {
                isbnB.BookTitle = textBoxUBookTitle.Text;
                isbnB.UnitPrice = Convert.ToDecimal(textBoxUPrice.Text);
                isbnB.Quantity = Convert.ToInt32(textBoxUQuantity.Text);
                isbnB.PublisherId = Convert.ToInt32(textBoxUPublisherID.Text);
                isbnB.CategoryId = comboBoxUCategoryID.SelectedIndex + 1;
                isbnB.Status = comboBoxUStatusID.SelectedIndex + 4;
                authorBook.AuthorId = Convert.ToInt32(textBoxUAuthorID.Text);
                authorBook.YearPublished = Convert.ToInt32(textBoxUYear.Text);
                authorBook.Edition = Convert.ToInt32(textBoxUEdition.Text);
                db.SaveChanges();
                MessageBox.Show("Book updated successfully.");
            }
            else
            {
                MessageBox.Show("Book not found.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var isbnD = db.Books.Find(Convert.ToDecimal(textBoxDISBN.Text));
            if (isbnD != null)
            {
                isbnD.Status = 3;
                db.SaveChanges();
                MessageBox.Show("Book deleted successfully.");
            }
            else
            {
                MessageBox.Show("Book not found.");
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            if(comboBoxSearchBook.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select a search criteria.");
                return;
            }
            switch (comboBoxSearchBook.SelectedIndex)
            {
                case 0:
                    if (textBoxSearchBook.Text == "" || !long.TryParse(textBoxSearchBook.Text, out _))
                    {
                        MessageBox.Show("Please, enter a valid ISBN.");
                        return;
                    }
                    var searchISBN = Convert.ToDecimal(textBoxSearchBook.Text);

                    var result = (from book in db.Books
                                  join authorBook in db.AuthorsBooks on book.ISBN equals authorBook.ISBN
                                  join author in db.Authors on authorBook.AuthorId equals author.AuthorId
                                  join category in db.Categories on book.CategoryId equals category.CategoryId
                                  join status in db.Statuses on book.Status equals status.StatusId
                                  where book.ISBN == searchISBN
                                  select new
                                  {
                                      book.ISBN, book.BookTitle, book.UnitPrice, book.Quantity, book.PublisherId, book.CategoryId, book.Status,
                                      authorBook.YearPublished, authorBook.Edition, author.FirstName, author.LastName, category.CategName, status.Description
                                  }).FirstOrDefault();
                    if (result != null)
                    {
                        listViewBooks.Items.Clear();
                        ListViewItem item = new ListViewItem(result.ISBN.ToString());
                        item.SubItems.Add(result.BookTitle);
                        item.SubItems.Add(result.FirstName + " " + result.LastName);
                        item.SubItems.Add(result.Quantity.ToString());
                        item.SubItems.Add(result.UnitPrice.ToString());                        
                        item.SubItems.Add(result.YearPublished.ToString());
                        item.SubItems.Add(result.Edition.ToString());
                        item.SubItems.Add(result.PublisherId.ToString());
                        item.SubItems.Add(result.CategName);
                        item.SubItems.Add(result.Description);
                        listViewBooks.Items.Add(item);
                    }
                    else
                    {
                        MessageBox.Show("Book not found.");
                    }
                    break;
                                  
            }
        }
    }
}
