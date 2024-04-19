using BookSupply.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookSupply.DAL
{
    public class InventoryDB1
    {
        HiTechDBEntities1 db = new HiTechDBEntities1();


        public List<object> SearchBook(string search, string X)
        {
            List<object> searchResults = new List<object>();

            try
            {
                var booksQuery = from book in db.Books
                                 join publisher in db.Publishers on book.PublisherId equals publisher.PublisherId
                                 join category in db.Categories on book.CategoryId equals category.CategoryId
                                 join status in db.Statuses on book.Status equals status.StatusId
                                 where book.BookTitle.Contains(search) // Filter books based on search criteria
                                 select new
                                 {
                                     book.ISBN,
                                     book.BookTitle,
                                     book.UnitPrice,
                                     book.Quantity,
                                     publisher.PublisherName,
                                     category.CategName,
                                     status.Description
                                 };

                var authorsQuery = from authorB in db.AuthorsBooks
                                   join author in db.Authors on authorB.AuthorId equals author.AuthorId
                                   select new
                                   {
                                       authorB.ISBN,
                                       AuthorName = author.FirstName + " " + author.LastName,
                                       authorB.YearPublished,
                                       authorB.Edition

                                   };

                var bookAuthors = from book in booksQuery.ToList()
                                  join author in authorsQuery.ToList() on book.ISBN equals author.ISBN into g
                                  select new
                                  {
                                      book.ISBN,
                                      book.BookTitle,
                                      book.UnitPrice,
                                      book.Quantity,
                                      Authors = string.Join(", ", g.Select(a => a.AuthorName)),
                                      PublisherName = book.PublisherName,
                                      CategName = book.CategName,
                                      Description = book.Description,
                                      YearPublished = g.Select(a => a.YearPublished).FirstOrDefault(),
                                      Edition = g.Select(a => a.Edition).FirstOrDefault()
                                  };

                if (bookAuthors.Any())
                {
                    foreach (var book in bookAuthors)
                    {
                        searchResults.Add(book);
                    }
                }
                else
                {
                    MessageBox.Show("No books found 1.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            return searchResults;
        }


    }
}
