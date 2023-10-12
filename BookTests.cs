using BookLibrary;

namespace BookTests
{
    [TestClass()]
    public class BookTests
    {
        private readonly Book _book = new() { Id = 1, Title = "Lord of the rings", Price = 500 };
        private readonly Book _nullBook = new() { Id = 2, Price = 500 };
        private readonly Book _shortBook = new() { Id = 3, Title = "Bo", Price = 299 };
        private readonly Book _priceBook = new() { Id = 4, Title = "The wither", Price = -1 };

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("1 Lord of the rings 500", _book.ToString());
        }

        [TestMethod()]
        public void ValidateTitleTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _nullBook.ValidateTitle());
            Assert.ThrowsException<ArgumentException>(() => _shortBook.ValidateTitle());
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _priceBook.ValidatePrice());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            _book.Validate();   
        }
    }
}