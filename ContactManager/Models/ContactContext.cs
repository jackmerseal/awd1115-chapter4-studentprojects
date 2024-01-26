using Microsoft.EntityFrameworkCore;
namespace ContactManager.Models
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; } = null!;
        public ContactContext(DbContextOptions<ContactContext> options): base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
               new Contact() { ContactId = 1, Firstname = "James", Lastname = "Hetfield", Phone = "1234567890", Email = "james_hetfield@insideranken.org" },
               new Contact() { ContactId = 2, Firstname = "Lars", Lastname = "Ulrich", Phone = "0987654321", Email = "lars_ulrich@insideranken.org" },
               new Contact() { ContactId = 3, Firstname = "Kirk", Lastname = "Hammett", Phone = "1357924680", Email = "kirk_hammett@insideranken.org" },
               new Contact() { ContactId = 4, Firstname = "Robert", Lastname = "Trujillo", Phone = "2468013579", Email = "robert_trujillo@insideranken.org" }
               );
        }
    }
}
