using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Lepilina.Models
{
    public class AppDbContext: DbContext
    {
        public DbSet<Position> Position {  get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Images> Images { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>().HasKey(a => a.accounts_id);
            modelBuilder.Entity<Position>().HasKey(p => p.position_id);
            modelBuilder.Entity<Users>().HasKey(u => u.users_id);
            modelBuilder.Entity<Category>().HasKey(c => c.category_id);
            modelBuilder.Entity<Products>().HasKey(p => p.products_id);
            modelBuilder.Entity<Images>().HasKey(i => i.images_id);

            modelBuilder.Entity<Accounts>().HasOne(a => a.Users).WithMany().HasForeignKey(a => a.users_id);
            modelBuilder.Entity<Users>().HasOne(a => a.Position).WithMany().HasForeignKey(a => a.position_id);
            modelBuilder.Entity<Products>().HasOne(a => a.Category).WithMany().HasForeignKey(a => a.category_id);
            modelBuilder.Entity<Images>().HasOne(a => a.Products).WithMany().HasForeignKey(a => a.products_id);

        }

    }
}
