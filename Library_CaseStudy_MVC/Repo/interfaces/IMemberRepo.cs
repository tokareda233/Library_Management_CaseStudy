using Library_CaseStudy_MVC.Models;

namespace Library_CaseStudy_MVC.Repo.interfaces
{
    public interface IMemberRepo
    {
        public List<Member> GetAll();
        public Member GetById(int id);
        public void Add(Member Member);
        public void Update(Member book);
        public void Delete(int id);
    }
}
