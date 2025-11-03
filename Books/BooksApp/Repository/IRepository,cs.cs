using BooksApp.dto;
using BooksApp.Model;

namespace BooksApp.Repository
{
    public interface IRepository
    {
        public void Create(Book book);
        public IEnumerable<Book> GetAll();
        public IEnumerable<Book> SearchBook(SearchBook book);
        public void Delete(int id);
    }
}
