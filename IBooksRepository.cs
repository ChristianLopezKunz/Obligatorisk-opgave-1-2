using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public interface IBooksRepository
    {
        IEnumerable<Book> Get(string? titleIncludes = null, int? priceFilter = null, string? sortBy = null);
        Book AddBook(Book book);
        Book? GetBookById(int id);
        Book? DeleteBook(int id);
        Book? UpdateBook(int id, Book book);
    }
}
