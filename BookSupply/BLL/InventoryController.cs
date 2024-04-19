using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookSupply.DAL;
using BookSupply.VALIDATION;


namespace BookSupply.BLL
{
    public class InventoryController
    {

        HiTechDBEntities1 db = new HiTechDBEntities1();

        // Filter statuses based on provided IDs
        public List<string> FilterStatuses(int num1, int num2)
        {
            var filteredStatuses = db.Statuses
            .Where(stat => stat.StatusId == num1 || stat.StatusId == num2)
            .Select(stat => stat.Description)
            .ToList();

            return filteredStatuses;
        }

        // Validate ISBN format and uniqueness
        public bool validationIsbn(string bisbn)
        {
            if (VALIDATION.Validator.isValidISBN(bisbn) == false)
            {
                MessageBox.Show("Please, enter a valid ISBN (10 digits).");
                return false;
            }

            if (decimal.TryParse(bisbn, out decimal isbn))
            {
                if (db.Books.Any(book => book.ISBN == isbn))
                {
                    MessageBox.Show("ISBN already exists.");
                    return false;
                }
            }

            return true;
        }

        // Validate email format and uniqueness
        public bool validateEmail(string Aemail)
        {
            if (string.IsNullOrEmpty(Aemail))
            {
                MessageBox.Show("Please, enter an email.");
                return false;
            }

            if (VALIDATION.Validator.isValidEmail(Aemail) == false)
            {
                MessageBox.Show("Please, enter a valid email.");
                return false;
            }

            if (db.Authors.Any(email => email.Email == Aemail))
            {
                MessageBox.Show("Email already exists.");
                return false;
            }

            return true;
        }

        // Validate first name format
        public bool validateFName(string name)
        {
            if (!Validator.IsValidName(name))
            {
                MessageBox.Show("Invalid First Name.");
                return false;
            }
            return true;
        }

        // Validate last name format
        public bool validateLName(string name)
        {
            if (!Validator.IsValidName(name))
            {
                MessageBox.Show("Invalid Last Name.");
                return false;
            }
            return true;
        }

        // Validate ISBN format and existence for update
        public bool validationIsbnUPDATE(string bisbn)
        {
            if (VALIDATION.Validator.isValidISBN(bisbn) == false)
            {
                MessageBox.Show("Please, enter a valid ISBN (10 digits).");
                return false;
            }

            if (decimal.TryParse(bisbn, out decimal isbn))
            {
                if (!db.Books.Any(book => book.ISBN == isbn))
                {
                    MessageBox.Show("ISBN not found.");
                    return false;
                }
            }
            return true;
        }

        // Validate author ID format and existence
        public bool validationAuthorID(string aID)
        {
            if (string.IsNullOrEmpty(aID) || !decimal.TryParse(aID, out _))
            {
                MessageBox.Show("Please, enter a valid author ID.");
                return false;
            }

            if (decimal.TryParse(aID, out decimal id))
            {
                if (!db.Authors.Any(authorID => authorID.AuthorId == id))
                {
                    MessageBox.Show("Author ID not found.");
                    return false;
                }
            }
            return true;
        }

        // Validate book title format
        public bool validationTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please, enter a book title.");
                return false;
            }
            return true;
        }

        // Validate price format
        public bool validationPrice(string price)
        {
            if (string.IsNullOrEmpty(price) || !double.TryParse(price, out _))
            {
                MessageBox.Show("Please, enter a unit price with decimal number.");
                return false;
            }
            return true;
        }

        // Validate author IDs format and existence
        public bool validationAuthorId(string authorIds)
        {
            if (string.IsNullOrEmpty(authorIds))
            {
                MessageBox.Show("Please enter at least one author ID.");
                return false;
            }

            // Create a list of IDs by splitting the input string
            string[] ids = authorIds.Split(',');

            // List to store unique author IDs
            HashSet<long> uniqueAuthorIds = new HashSet<long>();

            foreach (string id in ids)
            {
                if (!long.TryParse(id.Trim(), out long authorId))
                {
                    MessageBox.Show($"Invalid author ID: {id.Trim()}.");
                    return false;
                }

                // Verify if the author ID is unique
                if (uniqueAuthorIds.Contains(authorId))
                {
                    MessageBox.Show($"Duplicate author ID: {authorId}.");
                    return false;
                }

                uniqueAuthorIds.Add(authorId);

                // Verify if the author ID exists in the database
                if (!db.Authors.Any(author => author.AuthorId == authorId))
                {
                    MessageBox.Show($"Author ID {authorId} not found.");
                    return false;
                }
            }

            return true;
        }

        // Validate quantity format
        public bool validationQuantity(string qtd)
        {
            if (string.IsNullOrEmpty(qtd) || !int.TryParse(qtd, out _))
            {
                MessageBox.Show("Please, enter a quantity.");
                return false;
            }
            return true;
        }

        // Validate publisher ID format and existence
        public bool validationPublisherId(string pubId)
        {
            if (string.IsNullOrEmpty(pubId) || !long.TryParse(pubId, out _))
            {
                MessageBox.Show("Please, enter a valid publisher ID.");
                return false;
            }
            if (decimal.TryParse(pubId, out decimal pubid))
            {
                if (!db.Publishers.Any(pub => pub.PublisherId == pubid))
                {
                    MessageBox.Show("Publisher ID not found.");
                    return false;
                }
            }
            return true;
        }

        // Validate category ID
        public bool validationCategoryId(int catId)
        {
            if (catId == -1)
            {
                MessageBox.Show("Please, select a category.");
                return false;
            }
            return true;
        }

        // Validate status ID
        public bool validationStatusId(int statusId)
        {
            if (statusId == -1)
            {
                MessageBox.Show("Please, select a status.");
                return false;
            }
            return true;
        }

        // Validate year format
        public bool validationYear(string years)
        {
            if (string.IsNullOrEmpty(years) ||
                !int.TryParse(years, out int year) ||
                year < 1000 || year > 9999)
            {
                MessageBox.Show("Please, enter a valid year (yyyy).");
                return false;
            }
            return true;
        }

        // Validate edition format
        public bool validationEdition(string edition)
        {
            if (string.IsNullOrEmpty(edition) || !int.TryParse(edition, out _))
            {
                MessageBox.Show("Please, enter an edition.");
                return false;
            }
            return true;
        }

        // Save a new publisher
        public static void savePublisher(int cbStatus, string pubName, string pubWeb)
        {
            HiTechDBEntities1 db = new HiTechDBEntities1();
            var status = 0;
            if (cbStatus == 0)
            {
                status = 1;
            }
            else
            {
                status = 2;
            }

            if (pubName == "")
            {
                MessageBox.Show("Please, enter a publisher name.");
                return;
            }
            if (cbStatus == -1)
            {
                MessageBox.Show("Please, select a status.");
                return;
            }
            if (db.Publishers.Any(pub => pub.PublisherName.ToLower().Trim() == pubName.ToLower().Trim()))
            {
                MessageBox.Show("Publisher already exists.");
                return;
            }
            var newPublisher = new BLL.Publisher
            {
                PublisherName = pubName,
                WebAddress = pubWeb,
                StatusId = status

            };
            db.Publishers.Add(newPublisher);
            db.SaveChanges();
            MessageBox.Show("Publisher saved successfully.");
        }

        // Update an existing publisher
        public static void updatePublisher(int cbStatus, string pubName, string pubID, string pubWeb)
        {
            HiTechDBEntities1 db = new HiTechDBEntities1();
            if (string.IsNullOrEmpty(pubID))
            {
                MessageBox.Show("Please, enter a publisher ID.");
                return;
            }
            var publisher = db.Publishers.Find(Convert.ToInt32(pubID));
            if (publisher == null)
            {
                MessageBox.Show("Publisher ID not found.");
                return;
            }
            if (string.IsNullOrEmpty(pubName))
            {
                MessageBox.Show("Please, enter a publisher name.");
                return;
            }
            if (cbStatus == -1)
            {
                MessageBox.Show("Please, select a status.");
                return;
            }

            if (publisher != null)
            {
                publisher.PublisherName = pubName;
                publisher.WebAddress = pubWeb;
                publisher.StatusId = cbStatus + 1;
                db.SaveChanges();
                MessageBox.Show("Publisher updated successfully.");
            }
            else
            {
                MessageBox.Show("Publisher ID not found.");
            }
        }

        // Delete a publisher
        public static void deletePublisher(string pubID)
        {
            HiTechDBEntities1 db = new HiTechDBEntities1();
            if (string.IsNullOrEmpty(pubID))
            {
                MessageBox.Show("Please, enter a publisher ID.");
                return;
            }

            var publisherID = db.Publishers.Find(Convert.ToInt32(pubID));
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

        // Delete a book
        public static void deleteBook(string isbn)
        {
            HiTechDBEntities1 db = new HiTechDBEntities1();
            if (string.IsNullOrEmpty(isbn))
            {
                MessageBox.Show("Please, enter a book ISBN.");
                return;
            }
            var isbnD = db.Books.Find(Convert.ToDecimal(isbn));
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

        // Delete an author
        public static void deleteAuthor(string authorID)
        {
            HiTechDBEntities1 db = new HiTechDBEntities1();
            if (string.IsNullOrEmpty(authorID))
            {
                MessageBox.Show("Please, enter an author ID.");
                return;
            }
            var authorId = db.Authors.Find(Convert.ToDecimal(authorID));
            if (authorId != null)
            {
                authorId.StatusID = 3;
                db.SaveChanges();
                MessageBox.Show("Author deleted successfully.");
            }
            else
            {
                MessageBox.Show("Author not found.");
            }
        }
    }
}
