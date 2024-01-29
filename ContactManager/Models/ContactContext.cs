using Microsoft.EntityFrameworkCore;
namespace ContactManager.Models
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public ContactContext(DbContextOptions<ContactContext> options): base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

			modelBuilder.Entity<Category>().HasData(
				new Category() { CategoryId = "H", Name = "Family" },
				new Category() { CategoryId = "F", Name = "Friend" },
				new Category() { CategoryId = "W", Name = "Work" }
				);

			modelBuilder.Entity<Contact>().HasData(
               new Contact() { ContactId = 1, Firstname = "James", Lastname = "Hetfield", Phone = "123-456-7890", Email = "james_hetfield@insideranken.org", CategoryId="F" },
               new Contact() { ContactId = 2, Firstname = "Lars", Lastname = "Ulrich", Phone = "098-765-4321", Email = "lars_ulrich@insideranken.org", CategoryId = "F" },
               new Contact() { ContactId = 3, Firstname = "Kirk", Lastname = "Hammett", Phone = "135-792-4680", Email = "kirk_hammett@insideranken.org", CategoryId = "F" },
               new Contact() { ContactId = 4, Firstname = "Robert", Lastname = "Trujillo", Phone = "246-801-3579", Email = "robert_trujillo@insideranken.org", CategoryId="F" }
               );
        }
    }
}
