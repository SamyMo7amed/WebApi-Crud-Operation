using Crud_operaiton.Modles.Entities;
using Microsoft.EntityFrameworkCore;
namespace Crud_operaiton.Data
{
    public class AppDbContext : DbContext   
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) 
        {
            
        }

        public DbSet<Employee> Employees { get; set; }  
    }
}
