using Crud_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_Back.Data
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext(DbContextOptions options) : base(options)
        {
        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
      
    }
}
