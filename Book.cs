namespace BookLibrary
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{Id} {Title} {Price}";
        }

        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException(nameof(Title), "Title cannot be null");
            }
            if (Title.Length < 3)
            {
                throw new ArgumentException("Title needs to be atleast 3 characters" + Title);
            }
        }

        public void ValidatePrice()
        {
            if (Price < 0 || Price >= 1200)
            {
                throw new ArgumentOutOfRangeException(nameof(Price), "The price cannot be negative or exceed 1200");
            }
        }

        public void Validate()
        {
            ValidateTitle();
            ValidatePrice();
        }
    }
}