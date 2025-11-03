using Microsoft.EntityFrameworkCore;
using BooksApp.Data;
using BooksApp.Model;
using BooksApp.dto;

namespace BooksApp.Repository
{
    public class BooksRepository : IRepository
    {
        private BooksContext _db;
             
        public void Create(Book book)
        {
            using (_db = new BooksContext())
            {
                _db.Books.Add(book);
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        { 
            using (_db = new BooksContext())
            {
                var entity = _db.Books.Where(p => p.BookId == id && p.IsActive).FirstOrDefault();
                if (entity != null)
                {
                    entity.IsActive = false;
                    entity.UpdateDate = DateTime.Now;
                    _db.Books.Attach(entity);
                    _db.Entry(entity).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
        }

        public IEnumerable<Book> GetAll()
        {
            using (_db = new BooksContext())
            {
                return _db.Books.Where(p => p.IsActive == true).ToList();
            }
        }

        public Book GetById(int id)
        {
            using (_db = new BooksContext())
            {
                return _db.Books.Where(p => p.BookId == id && p.IsActive).FirstOrDefault();
            }
        }

        public IEnumerable<Book> SearchBook(SearchBook search)
        {
            using (_db = new BooksContext())
            {
                if(search is null)
                {
                    return _db.Books.Where(p => p.IsActive).ToList();
                }
                else
                {
                    return _db.Books.Where(book => string.IsNullOrEmpty(search.Title) ? book.Title ==  book.Title : book.Title == search.Title
                                                && string.IsNullOrEmpty(search.Author) ? book.Author == book.Author : book.Author == search.Author
                                                && search.ISBN == null? book.ISBN == book.ISBN : book.ISBN == search.ISBN
                                                && search.Year == null ? book.Year == book.Year : book.Year == search.Year).ToList();
                }
                    
            }
        }
    }
}
