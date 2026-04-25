using Library_CaseStudy_MVC.Models;

namespace Library_CaseStudy_MVC.ViewModels
{
    public class borrowVM
    {
        public int borrowid {  get; set; }
        public int bookid { get; set; }
        public int memberid { get; set; }
        public List<Book>? books { get; set; }
        public List<Member>? members { get; set; }
         public DateOnly borrowdate { get; set; }
        public DateOnly returndate { get; set; }
        public string status { get; set; }
    }
}
