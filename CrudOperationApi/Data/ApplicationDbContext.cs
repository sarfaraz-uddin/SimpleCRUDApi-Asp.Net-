using CrudOperationApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CrudOperationApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
