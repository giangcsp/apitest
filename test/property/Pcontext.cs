using Microsoft.EntityFrameworkCore;

namespace WebApplication1.property
{
    public class Pcontext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;database=sqltesting;User ID=root;password=giang2399;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>(
                entity =>
                {
                    entity.HasKey(e => e.ID);
                    entity.Property(e => e.PNAME);
                    entity.HasOne(d => d.add).WithMany(p => p.People);
                }

                );
            modelBuilder.Entity<Address>(
                entity =>
                {
                    entity.HasKey(e => e.ID);
                    entity.Property(e => e.ADDR);
                }
                );
            
        }
    }
}
