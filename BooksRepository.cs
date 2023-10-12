using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class BooksRepository : IBooksRepository
    {
        private int _nextId = 1;
        private List<Book> _books = new();

        public IEnumerable<Book> Get(string? titleIncludes = null, int? priceFilter = null, string? sortBy = null)
        {
            IEnumerable<Book> result = new List<Book>(_books);
            if (priceFilter != null)
            {
                result = result.Where(b => b.Price > priceFilter);
            }
            if (titleIncludes != null)
            {
                result = result.Where(b => b.Title.Contains(titleIncludes));
            }

            if (sortBy != null)
            {
                sortBy = sortBy.ToLower();
                switch (sortBy)
                {
                    case "title": // fall through to next case
                    case "title_asc":
                        result = result.OrderBy(b => b.Title);
                        break;
                    case "title_desc":
                        result = result.OrderByDescending(b => b.Title);
                        break;
                    case "price":
                    case "price_asc":
                        result = result.OrderBy(b => b.Price);
                        break;
                    case "price_desc":
                        result = result.OrderByDescending(b => b.Price);
                        break;
                    default:
                        break; // do nothing
                }
            }
            return result;
        }

        public Book? GetBookById(int id)
        {
            return _books.Find(book => book.Id == id);
        }

        public Book AddBook(Book book)
        {
            book.Validate();
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }
        public Book? DeleteBook(int id)
        {
            Book? book = GetBookById(id);
            if (book == null)
            {
                return null;
            }
            _books.Remove(book);
            return book;
        }
        public Book? UpdateBook(int id, Book book)
        {
            book.Validate();
            Book? existingBook = GetBookById(id);
            if (existingBook == null)
            {
                return null;
            }
            existingBook.Title = book.Title;
            existingBook.Price = book.Price;
            return existingBook;
        }
    }
}
