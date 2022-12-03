using Microsoft.EntityFrameworkCore;
using PracticeWebAPI.Models;

namespace PracticeWebAPI.Data
{
    public class ContactAPIDbContext : DbContext
    {
        public ContactAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> contacts { get; set; } 
    }
}
