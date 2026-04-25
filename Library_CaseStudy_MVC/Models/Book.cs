using System.ComponentModel.DataAnnotations;

namespace Library_CaseStudy_MVC.Models
{
    public class Book
    {
        [Key]
        public int boodid {  get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string author { get; set; }
        [Range(0,100)]
        public int availablecopiesnum { get; set; }
        public List<Borrow>? borrows { get; set; }

    }
}
