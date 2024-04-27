using FluentValidationExample.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentValidationExample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogDataModel> Blogs { get; set; }
    }
}
