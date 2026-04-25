using Library_CaseStudy_MVC.Data;
using Library_CaseStudy_MVC.Models;
using Library_CaseStudy_MVC.Repo.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_CaseStudy_MVC.Repo.implementations
{
    public class BorrowRepo : IBorrowRepo
    {
        private readonly AppDbContext _context;
        public BorrowRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Borrow Borrow)
        {
           _context.Borrows.Add(Borrow);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var b = _context.Borrows.Find(id);
            _context.Borrows.Remove(b);
            _context.SaveChanges();
        }

        public List<Borrow> GetAll(string? status)
        {
            var l = _context.Borrows.Include(o => o.Book).Include(o => o.Member).AsQueryable().ToList();
            if (status != null)
            {
                l = _context.Borrows.Where(o => o.status == status).ToList();
            }

            return l.ToList();
            
        }

        public Borrow GetById(int id)
        {
            return _context.Borrows.Include(o => o.Book).Include(o => o.Member).FirstOrDefault(o => o.borrowid == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Borrow Borrow)
        {
           _context.Borrows.Update(Borrow);
            _context.SaveChanges();
        }
    }
}
