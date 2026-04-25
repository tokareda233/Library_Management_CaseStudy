using Library_CaseStudy_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_CaseStudy_MVC.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books
        { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Borrow> Borrows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                 .HasMany(o => o.borrows)
                 .WithOne(x => x.Book)
                 .HasForeignKey(x => x.bookid);

            modelBuilder.Entity<Member>()
                .HasMany(o => o.borrows)
                .WithOne(x => x.Member)
                .HasForeignKey(x => x.memberid);


        }
    }
}
