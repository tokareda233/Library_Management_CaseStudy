using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_CaseStudy_MVC.Models
{
    public class Borrow
    {
        [Key]
        public int borrowid { get; set; }

        public DateOnly borroedate { get; set; }
        public DateOnly returndate { get; set; }
        public string status { get; set; }
        [ForeignKey("bookid")]
        public int bookid { get; set; }
        public Book? Book { get; set; }
        [ForeignKey("memberid")]
        public int memberid { get; set; }
        public Member? Member { get; set; }
    }
}
