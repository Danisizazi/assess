
using BooksApp.dto;
using BooksApp.Model;
using BooksApp.Repository;

namespace BooksApp.Services
{
    public class BookService
    {
        private BooksRepository _repository;

        public BookService()
        {
            _repository = new BooksRepository();
        }
        internal void CreateBook(Book book)
        {
            _repository.Create(book);
        }

        internal void Delete(int id)
        {
            _repository.Delete(id);
        }

        internal IEnumerable<Book> GetAllBooks()
        {
            return _repository.GetAll();
        }

        internal Book GetById(int id)
        {
           return _repository.GetById(id);
        }

        internal IEnumerable<Book> SearchBook(SearchBook book)
        {
            return _repository.SearchBook(book);
        }
    }
}
