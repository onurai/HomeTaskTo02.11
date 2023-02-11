using HomeTaskTo_02._10.Models;

namespace HomeTaskTo_02._10.Services
{
    public interface IBookService
    {
        public List<Book> GetAll();
        public Book Get(string id);
        public bool Create(Book book);
        public bool Update(string id, Book book);

        public bool Remove(string id);
    }
}
