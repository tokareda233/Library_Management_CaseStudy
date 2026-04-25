using Library_CaseStudy_MVC.Data;
using Library_CaseStudy_MVC.Models;
using Library_CaseStudy_MVC.Repo.interfaces;

namespace Library_CaseStudy_MVC.Repo.implementations
{
    public class MemberRepo : IMemberRepo
    {
        private readonly AppDbContext _context;
        public MemberRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Member Member)
        {
            _context.Members.Add(Member);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var i = _context.Members.Find(id);
            _context.Members.Remove(i);
            _context.SaveChanges();

        }

        public List<Member> GetAll()
        {
            return _context.Members.ToList();
        }

        public Member GetById(int id)
        {
            return _context.Members.Find(id);
        }

        public void Update(Member book)
        {
           _context.Members.Update(book);
            _context.SaveChanges();
        }
    }
}
