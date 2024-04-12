using BookSupply.BLL;
using BookSupply.VALIDATION;
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
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.Entity.SqlServer;




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
            //Save a new publisher

            InventoryController.savePublisher(comboBoxSaveStatus.SelectedIndex, textBoxPublisherName.Text, textBoxWebAddress.Text);
            
        }

        private void buttonUpdatePublisher_Click(object sender, EventArgs e)
        {

            InventoryController.updatePublisher(comboBoxUpdateStatus.SelectedIndex, textBoxUPublisherName.Text, textBoxPublisherID.Text, textBoxUwebAddress.Text);

        }

        private void buttonDeletePublisher_Click(object sender, EventArgs e)
        {
            InventoryController.deletePublisher(textBoxDeletePublisherID.Text);

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
            comboBoxSAuthorStatus.DataSource = filterStatus;
            comboBoxSAuthorStatus.SelectedIndex = -1;
            comboBoxUAuthorStatus.DataSource = filterStatus;
            comboBoxUAuthorStatus.SelectedIndex = -1;
        }

        private void buttonSaveBook_Click(object sender, EventArgs e)
        {            

            if(!inventoryController.validationIsbn(textBoxSISBN.Text) ||
                !inventoryController.validationTitle(textBoxSBookTitle.Text) ||
                !inventoryController.validationAuthorId(textBoxSAuthorID.Text) ||
                !inventoryController.validationPublisherId(textBoxSPublisherID.Text) ||
                !inventoryController.validationQuantity(textBoxSQuantity.Text) ||
                !inventoryController.validationPrice(textBoxSPrice.Text) ||
                !inventoryController.validationCategoryId(comboBoxSCategoryID.SelectedIndex) ||
                !inventoryController.validationStatusId(comboBoxSStatusID.SelectedIndex) || 
                !inventoryController.validationYear(textBoxSYear.Text) ||
                !inventoryController.validationEdition(textBoxSEdition.Text))
            {
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
            //update a book

            if (!inventoryController.validationIsbnUPDATE(textBoxUISBN.Text) ||
                !inventoryController.validationTitle(textBoxUBookTitle.Text) ||
                !inventoryController.validationAuthorId(textBoxUAuthorID.Text) ||
                !inventoryController.validationPublisherId(textBoxUPublisherID.Text) ||
                !inventoryController.validationQuantity(textBoxUQuantity.Text) ||
                !inventoryController.validationPrice(textBoxUPrice.Text) ||
                !inventoryController.validationCategoryId(comboBoxUCategoryID.SelectedIndex) ||
                !inventoryController.validationStatusId(comboBoxUStatusID.SelectedIndex) ||
                !inventoryController.validationYear(textBoxUYear.Text) ||
                !inventoryController.validationEdition(textBoxUEdition.Text))
            {
                return;
            }

            var isbnsearch = Convert.ToDecimal(textBoxUISBN.Text);
            var isbnB = db.Books.Find(Convert.ToDecimal(textBoxUISBN.Text));
            var authorBook = db.AuthorsBooks.FirstOrDefault(ab => ab.ISBN == isbnsearch);
            if (isbnB != null || authorBook != null)
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

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            if (comboBoxSearchBook.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select a search criteria.");
                return;
            }

            switch (comboBoxSearchBook.SelectedIndex)
            {
                case 0:
                    if (textBoxSearchBook.Text == "")
                    {
                        MessageBox.Show("Please, enter a valid ISBN.");
                        return;
                    }
                    var searchISBN = textBoxSearchBook.Text.Trim();

                    var results = (from book in db.Books
                                   join publisher in db.Publishers on book.PublisherId equals publisher.PublisherId
                                   join category in db.Categories on book.CategoryId equals category.CategoryId
                                   join status in db.Statuses on book.Status equals status.StatusId
                                   join authorBook in db.AuthorsBooks on book.ISBN equals authorBook.ISBN
                                   join author in db.Authors on authorBook.AuthorId equals author.AuthorId
                                   where book.ISBN.ToString().Contains(searchISBN)
                                   select new
                                   {
                                       book.ISBN,
                                       book.BookTitle,
                                       book.UnitPrice,
                                       book.Quantity,
                                       publisher.PublisherName,
                                       book.Status,
                                       authorBook.YearPublished,
                                       authorBook.Edition,
                                       author.FirstName,
                                       author.LastName,
                                       category.CategName,
                                       status.Description
                                   }).ToList();

                    if (results.Count > 0)
                    {
                        listViewBooks.Items.Clear();
                        foreach (var result in results)
                        {
                            ListViewItem item = new ListViewItem(result.ISBN.ToString());
                            item.SubItems.Add(result.BookTitle);
                            item.SubItems.Add(result.FirstName + " " + result.LastName);
                            item.SubItems.Add(result.Quantity.ToString());
                            item.SubItems.Add(result.UnitPrice.ToString());
                            item.SubItems.Add(result.YearPublished.ToString());
                            item.SubItems.Add(result.Edition.ToString());
                            item.SubItems.Add(result.PublisherName.ToString());
                            item.SubItems.Add(result.CategName);
                            item.SubItems.Add(result.Description);
                            listViewBooks.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No books found.");
                    }
                    break;

                case 1:
                    if (textBoxSearchBook.Text == "")
                    {
                        MessageBox.Show("Please, enter a valid Book Title.");
                        return;
                    }
                    var searchBT = textBoxSearchBook.Text.Trim();

                    var resultBT = (from book in db.Books
                                    join publisher in db.Publishers on book.PublisherId equals publisher.PublisherId
                                    join category in db.Categories on book.CategoryId equals category.CategoryId
                                    join status in db.Statuses on book.Status equals status.StatusId
                                    join authorBook in db.AuthorsBooks on book.ISBN equals authorBook.ISBN
                                    join author in db.Authors on authorBook.AuthorId equals author.AuthorId
                                    where book.BookTitle.ToString().Contains(searchBT)
                                    select new
                                    {
                                        book.ISBN,
                                        book.BookTitle,
                                        book.UnitPrice,
                                        book.Quantity,
                                        publisher.PublisherName,
                                        book.Status,
                                        authorBook.YearPublished,
                                        authorBook.Edition,
                                        author.FirstName,
                                        author.LastName,
                                        category.CategName,
                                        status.Description
                                    }).ToList();

                    if (resultBT.Count > 0)
                    {
                        listViewBooks.Items.Clear();
                        foreach (var result in resultBT)
                        {
                            ListViewItem item = new ListViewItem(result.ISBN.ToString());
                            item.SubItems.Add(result.BookTitle);
                            item.SubItems.Add(result.FirstName + " " + result.LastName);
                            item.SubItems.Add(result.Quantity.ToString());
                            item.SubItems.Add(result.UnitPrice.ToString());
                            item.SubItems.Add(result.YearPublished.ToString());
                            item.SubItems.Add(result.Edition.ToString());
                            item.SubItems.Add(result.PublisherName.ToString());
                            item.SubItems.Add(result.CategName);
                            item.SubItems.Add(result.Description);
                            listViewBooks.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No books found.");
                    }
                    break;


                case 2:
                    if (textBoxSearchBook.Text == "")
                    {
                        MessageBox.Show("Please, enter a valid Author First Name.");
                        return;
                    }
                    var searchAF = textBoxSearchBook.Text.Trim();

                    var resultAF = (from book in db.Books
                                    join publisher in db.Publishers on book.PublisherId equals publisher.PublisherId
                                    join category in db.Categories on book.CategoryId equals category.CategoryId
                                    join status in db.Statuses on book.Status equals status.StatusId
                                    join authorBook in db.AuthorsBooks on book.ISBN equals authorBook.ISBN
                                    join author in db.Authors on authorBook.AuthorId equals author.AuthorId
                                    where author.FirstName.ToString().Contains(searchAF)
                                     select new
                                     {
                                         book.ISBN,
                                         book.BookTitle,
                                         book.UnitPrice,
                                         book.Quantity,
                                         publisher.PublisherName,
                                         book.Status,
                                         authorBook.YearPublished,
                                         authorBook.Edition,
                                         author.FirstName,
                                         author.LastName,
                                         category.CategName,
                                         status.Description
                                     }).ToList();

                    if (resultAF.Count > 0)
                    {
                        listViewBooks.Items.Clear();
                        foreach (var result in resultAF)
                        {
                            ListViewItem item = new ListViewItem(result.ISBN.ToString());
                            item.SubItems.Add(result.BookTitle);
                            item.SubItems.Add(result.FirstName + " " + result.LastName);
                            item.SubItems.Add(result.Quantity.ToString());
                            item.SubItems.Add(result.UnitPrice.ToString());
                            item.SubItems.Add(result.YearPublished.ToString());
                            item.SubItems.Add(result.Edition.ToString());
                            item.SubItems.Add(result.PublisherName.ToString());
                            item.SubItems.Add(result.CategName);
                            item.SubItems.Add(result.Description);
                            listViewBooks.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No books found.");
                    }
                    break;

                case 3:
                    if (textBoxSearchBook.Text == "")
                    {
                        MessageBox.Show("Please, enter a valid Author Last Name.");
                        return;
                    }
                    var searchAL = textBoxSearchBook.Text.Trim();

                    var resultAL = (from book in db.Books
                                    join publisher in db.Publishers on book.PublisherId equals publisher.PublisherId
                                    join category in db.Categories on book.CategoryId equals category.CategoryId
                                    join status in db.Statuses on book.Status equals status.StatusId
                                    join authorBook in db.AuthorsBooks on book.ISBN equals authorBook.ISBN
                                    join author in db.Authors on authorBook.AuthorId equals author.AuthorId
                                    where author.LastName.ToString().Contains(searchAL)
                                    select new
                                    {
                                        book.ISBN,
                                        book.BookTitle,
                                        book.UnitPrice,
                                        book.Quantity,
                                        publisher.PublisherName,
                                        book.Status,
                                        authorBook.YearPublished,
                                        authorBook.Edition,
                                        author.FirstName,
                                        author.LastName,
                                        category.CategName,
                                        status.Description
                                    }).ToList();

                    if (resultAL.Count > 0)
                    {
                        listViewBooks.Items.Clear();
                        foreach (var result in resultAL)
                        {
                            ListViewItem item = new ListViewItem(result.ISBN.ToString());
                            item.SubItems.Add(result.BookTitle);
                            item.SubItems.Add(result.FirstName + " " + result.LastName);
                            item.SubItems.Add(result.Quantity.ToString());
                            item.SubItems.Add(result.UnitPrice.ToString());
                            item.SubItems.Add(result.YearPublished.ToString());
                            item.SubItems.Add(result.Edition.ToString());
                            item.SubItems.Add(result.PublisherName.ToString());
                            item.SubItems.Add(result.CategName);
                            item.SubItems.Add(result.Description);
                            listViewBooks.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No books found.");
                    }
                    break;

                case 4:
                    if (textBoxSearchBook.Text == "")
                    {
                        MessageBox.Show("Please, enter a valid Publisher name.");
                        return;
                    }
                    var searchPub = textBoxSearchBook.Text.Trim();

                    var resultPub = (from book in db.Books
                                     join publisher in db.Publishers on book.PublisherId equals publisher.PublisherId
                                     join category in db.Categories on book.CategoryId equals category.CategoryId
                                     join status in db.Statuses on book.Status equals status.StatusId
                                     join authorBook in db.AuthorsBooks on book.ISBN equals authorBook.ISBN
                                     join author in db.Authors on authorBook.AuthorId equals author.AuthorId
                                     where publisher.PublisherName.ToString().Contains(searchPub)
                                    select new
                                    {
                                        book.ISBN,
                                        book.BookTitle,
                                        book.UnitPrice,
                                        book.Quantity,
                                        publisher.PublisherName,
                                        book.Status,
                                        authorBook.YearPublished,
                                        authorBook.Edition,
                                        author.FirstName,
                                        author.LastName,
                                        category.CategName,
                                        status.Description
                                    }).ToList();

                    if (resultPub.Count > 0)
                    {
                        listViewBooks.Items.Clear();
                        foreach (var result in resultPub)
                        {
                            ListViewItem item = new ListViewItem(result.ISBN.ToString());
                            item.SubItems.Add(result.BookTitle);
                            item.SubItems.Add(result.FirstName + " " + result.LastName);
                            item.SubItems.Add(result.Quantity.ToString());
                            item.SubItems.Add(result.UnitPrice.ToString());
                            item.SubItems.Add(result.YearPublished.ToString());
                            item.SubItems.Add(result.Edition.ToString());
                            item.SubItems.Add(result.PublisherName.ToString());
                            item.SubItems.Add(result.CategName);
                            item.SubItems.Add(result.Description);
                            listViewBooks.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No books found.");
                    }
                    break;


            }
        }

        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            InventoryController.deleteBook(textBoxDISBN.Text);
        }

        private void buttonListAuthors_Click(object sender, EventArgs e)
        {
            listViewAuthors.Items.Clear();
            var listA = (from authors in db.Authors
                         join Status in db.Statuses on authors.StatusID equals Status.StatusId
                         select new
                         {
                             authors.AuthorId,
                             authors.FirstName,
                             authors.LastName,
                             authors.Email,
                             Status.Description
                         }).ToList();
            if (listA.Count == 0)
            {
                MessageBox.Show("No authors in the database.");
                return;
            }
            foreach (var authors in listA)
            {
                ListViewItem item = new ListViewItem(authors.AuthorId.ToString());
                item.SubItems.Add(authors.FirstName);
                item.SubItems.Add(authors.LastName);
                item.SubItems.Add(authors.Email);
                item.SubItems.Add(authors.Description);
                listViewAuthors.Items.Add(item);
            }
        }

        private void buttonDeleteAuthor_Click(object sender, EventArgs e)
        {
            InventoryController.deleteAuthor(textBoxDAuthorID.Text);
        }

        private void buttonSaveAuthor_Click(object sender, EventArgs e)
        {
            if (!inventoryController.validateFName(textBoxSAuthorFName.Text) ||
                !inventoryController.validateLName(textBoxSAuthorLName.Text) ||
                !inventoryController.validateEmail(textBoxSAuthorEmail.Text) ||
                !inventoryController.validationStatusId(comboBoxSAuthorStatus.SelectedIndex))               
            {
                return;
            }
            var newAuthor = new Author
            {
                FirstName = textBoxSAuthorFName.Text,
                LastName = textBoxSAuthorLName.Text,
                Email = textBoxSAuthorEmail.Text,
                StatusID = comboBoxSAuthorStatus.SelectedIndex + 1
            };
            db.Authors.Add(newAuthor);
            db.SaveChanges();
            MessageBox.Show("Author saved successfully.");
        }

        private void buttonUpdateAuthor_Click(object sender, EventArgs e)
        {

            if (
                !inventoryController.validationAuthorID(textBoxAuthorIDUpdate.Text) ||
                !inventoryController.validateFName(textBoxUAuthorFName.Text) ||
                !inventoryController.validateLName(textBoxUAuthorLName.Text) ||
                !inventoryController.validateEmail(textBoxUAuthorEmail.Text) ||
                !inventoryController.validationStatusId(comboBoxUAuthorStatus.SelectedIndex))
            {
                return;
            }

           // var idsearch = Convert.ToDecimal(textBoxUAuthorID.Text);
            var idsearchB = db.Authors.Find(Convert.ToDecimal(textBoxAuthorIDUpdate.Text));            
            if (idsearchB != null )
            {
                idsearchB.FirstName = textBoxUAuthorFName.Text;
                idsearchB.LastName = textBoxUAuthorLName.Text;
                idsearchB.Email = textBoxUAuthorEmail.Text;
                idsearchB.StatusID = comboBoxUAuthorStatus.SelectedIndex + 1;                
                db.SaveChanges();
                MessageBox.Show("Author updated successfully.");
            }
            else
            {
                MessageBox.Show("Author not found.");
            }

        }

        private void buttonSearchAuthor_Click(object sender, EventArgs e)
        {
            if (comboBoxSearchAuthor.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select a search criteria.");
                return;
            }

            switch (comboBoxSearchAuthor.SelectedIndex)
            {
                case 0:
                    if (textBoxSearchAuthor.Text == "" || !long.TryParse(textBoxSearchAuthor.Text, out _))
                    {
                        MessageBox.Show("Please, enter a valid Author ID.");
                        return;
                    }
                    var searchID = textBoxSearchAuthor.Text.Trim();

                    var results = (from author in db.Authors
                                   join status in db.Statuses on author.StatusID equals status.StatusId
                                   where author.AuthorId.ToString().Contains(searchID)
                                   select new
                                   {
                                       author.AuthorId,
                                       author.FirstName,
                                       author.LastName,
                                       author.Email,
                                       status.Description
                                   }).ToList();

                    if (results.Count > 0)
                    {
                        listViewAuthors.Items.Clear();
                        foreach (var result in results)
                        {
                            ListViewItem item = new ListViewItem(result.AuthorId.ToString());
                            item.SubItems.Add(result.FirstName);
                            item.SubItems.Add(result.LastName);
                            item.SubItems.Add(result.Email);
                            item.SubItems.Add(result.Description);
                            listViewAuthors.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Author not found.");
                    }
                    break;
                case 1:
                    if (textBoxSearchAuthor.Text == "" )
                    {
                        MessageBox.Show("Please, enter a valid Name.");
                        return;
                    }
                    var searchF = textBoxSearchAuthor.Text;

                    var resultF = (from author in db.Authors
                                   join status in db.Statuses on author.StatusID equals status.StatusId
                                   where author.FirstName.ToString().Contains(searchF)
                                   select new
                                   {
                                       author.AuthorId,
                                       author.FirstName,
                                       author.LastName,
                                       author.Email,
                                       status.Description
                                   }).ToList();

                    if (resultF.Count > 0)
                    {
                        listViewAuthors.Items.Clear();
                        foreach (var result in resultF)
                        {
                            ListViewItem item = new ListViewItem(result.AuthorId.ToString());
                            item.SubItems.Add(result.FirstName);
                            item.SubItems.Add(result.LastName);
                            item.SubItems.Add(result.Email);
                            item.SubItems.Add(result.Description);
                            listViewAuthors.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Author not found.");
                    }
                    break;
                    case 2:
                    if (textBoxSearchAuthor.Text == "")
                    {
                        MessageBox.Show("Please, enter a valid Name.");
                        return;
                    }
                    var searchL = textBoxSearchAuthor.Text;

                    var resultL = (from author in db.Authors
                                   join status in db.Statuses on author.StatusID equals status.StatusId
                                   where author.LastName.ToString().Contains(searchL)
                                   select new
                                   {
                                       author.AuthorId,
                                       author.FirstName,
                                       author.LastName,
                                       author.Email,
                                       status.Description
                                   }).ToList();

                    if (resultL.Count > 0)
                    {
                        listViewAuthors.Items.Clear();
                        foreach (var result in resultL)
                        {
                            ListViewItem item = new ListViewItem(result.AuthorId.ToString());
                            item.SubItems.Add(result.FirstName);
                            item.SubItems.Add(result.LastName);
                            item.SubItems.Add(result.Email);
                            item.SubItems.Add(result.Description);
                            listViewAuthors.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Author not found.");
                    }
                    break;

                    case 3:
                    if (textBoxSearchAuthor.Text == "")
                    {
                        MessageBox.Show("Please, enter a valid Email.");
                        return;
                    }
                    var searchE = textBoxSearchAuthor.Text;

                    var resultE = (from author in db.Authors
                                   join status in db.Statuses on author.StatusID equals status.StatusId
                                   where author.Email.ToString().Contains(searchE)
                                   select new
                                   {
                                       author.AuthorId,
                                       author.FirstName,
                                       author.LastName,
                                       author.Email,
                                       status.Description
                                   }).ToList();

                    if (resultE.Count > 0)
                    {
                        listViewAuthors.Items.Clear();
                        foreach (var result in resultE)
                        {
                            ListViewItem item = new ListViewItem(result.AuthorId.ToString());
                            item.SubItems.Add(result.FirstName);
                            item.SubItems.Add(result.LastName);
                            item.SubItems.Add(result.Email);
                            item.SubItems.Add(result.Description);
                            listViewAuthors.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Author not found.");
                    }
                    break;

                    

            }
        }
    }
}
