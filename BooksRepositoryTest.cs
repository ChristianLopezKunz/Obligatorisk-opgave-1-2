using BookLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BookTests
{
    [TestClass]
    public class BooksRepositoryTest
    {
        private IBooksRepository _repo;
        private readonly Book _badBook = new() { Title = "Løvernes konge", Price = 1400 };

        [TestInitialize]
        public void Init()
        {
            _repo = new BooksRepository();

            _repo.AddBook(new Book() { Title = "Gummi tarzan", Price = 999 });
            _repo.AddBook(new Book() { Title = "Samis kogebog", Price = 299 });
            _repo.AddBook(new Book() { Title = "Mikkels vilde eventyr", Price = 749 });
            _repo.AddBook(new Book() { Title = "Kong frederik", Price = 1199 });
            _repo.AddBook(new Book() { Title = "Kaffe historien", Price = 99 });
        }

        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Book> books = _repo.Get();
            Assert.AreEqual(5, books.Count());
            Assert.AreEqual(books.First().Title, "Gummi tarzan");

            IEnumerable<Book> bookByTitle = _repo.Get(sortBy: "title");
            Assert.AreEqual(bookByTitle.First().Title, "Gummi tarzan");

            IEnumerable<Book> bookByPrice = _repo.Get(sortBy: "price");
            Assert.AreEqual(bookByPrice.First().Title, "Kaffe historien");
        }

        [TestMethod()]
        public void GetBookByIdTest()
        {
            Assert.IsNotNull( _repo.GetBookById(1));
            Assert.IsNull( _repo.GetBookById(100));
        }

        [TestMethod()]
        public void AddBookTest()
        {
            Book b = new Book() { Title = "TestThomas", Price = 300 };
            Assert.AreEqual(6, _repo.AddBook(b).Id);
            Assert.AreEqual(6, _repo.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.AddBook(_badBook));
        }

        [TestMethod()]
        public void RemoveBookTest()
        {
            Assert.IsNull(_repo.DeleteBook(50));
            Assert.AreEqual(1, _repo.DeleteBook(1)?.Id);
            Assert.AreEqual(4, _repo.Get().Count());
        }

        [TestMethod()]
        public void UpdateBookTest()
        {
            Assert.AreEqual(5, _repo.Get().Count());
            Book b = new() { Title = "TestTommy", Price = 250 };
            Assert.IsNull(_repo.UpdateBook(100, b));
            Assert.AreEqual(1, _repo.UpdateBook(1, b)?.Id);
            Assert.AreEqual(5, _repo.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.UpdateBook(1, _badBook));
        }
    }
}
