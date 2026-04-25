using System.ComponentModel.DataAnnotations;

namespace Library_CaseStudy_MVC.Models
{
    public class Member
    {
        [Key]
        public int memberid { get; set; }
        public string name { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public List<Borrow> ?borrows { get; set; }
    }
}
