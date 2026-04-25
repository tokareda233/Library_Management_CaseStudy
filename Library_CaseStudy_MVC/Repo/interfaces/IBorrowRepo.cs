using Library_CaseStudy_MVC.Models;

namespace Library_CaseStudy_MVC.Repo.interfaces
{
    public interface IBorrowRepo
    {
        public List<Borrow> GetAll(string? status);
        public Borrow GetById(int id);
        public void Add(Borrow Borrow);
        public void Update(Borrow Borrow);
        public void Delete(int id);
        public void Save();
    }
}
