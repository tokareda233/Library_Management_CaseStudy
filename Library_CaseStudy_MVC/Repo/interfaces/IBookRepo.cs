using Library_CaseStudy_MVC.Models;

namespace Library_CaseStudy_MVC.Repo.interfaces
{
    public interface IBookRepo
    {
        public List<Book> GetAll();
        public Book GetById(int id);    
        public void Add(Book book);
        public void Update(Book book);
        public void Delete(int id);
        public void Save();
    }
}
