using HomeTaskTo_02._10.Models;

namespace HomeTaskTo_02._10.Services
{
    public class BookService : IBookService
    {
        private static List<Book> _books = new List<Book>();

        public List<Book> GetAll()
        {
            return _books;
        }

        public Book Get(string id)
        {
            var existingBook = _books.FirstOrDefault(x => x.Id == id);
            return existingBook;
        }

        public bool Create(Book book)
        {
            if (book == null)
            {
                return false;
            }
            _books.Add(book);
            return true;
        }

        public bool Update(string id, Book book)
        {
            var existingBook = _books.FirstOrDefault(x => x.Id == id);
            if (existingBook == null)
            {
                return false;
            }
            existingBook.BookName = book.BookName;
            existingBook.Price = book.Price;
            existingBook.Category = book.Category;
            existingBook.Author = book.Author;
            return true;
        }
        public bool Remove(string id)
        {
            var existingBook = _books.FirstOrDefault(x => x.Id == id);
            if (existingBook == null)
            {
                return false;
            }
            _books.Remove(existingBook);
            return true;
        }
    }
}
