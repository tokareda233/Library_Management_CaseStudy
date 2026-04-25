using Library_CaseStudy_MVC.Data;
using Library_CaseStudy_MVC.Models;
using Library_CaseStudy_MVC.Repo.interfaces;
using Microsoft.Identity.Client;

namespace Library_CaseStudy_MVC.Repo.implementations
{
    public class BookRepo : IBookRepo
    {
        private readonly AppDbContext _context;
        public BookRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var b = _context.Books.Find(id);
            _context.Books.Remove(b);
            _context.SaveChanges();
        }

        public List<Book> GetAll()
        {
          return _context.Books.ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public void Update(Book book)
        {
           _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
