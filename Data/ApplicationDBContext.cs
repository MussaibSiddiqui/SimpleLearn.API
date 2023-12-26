using Microsoft.EntityFrameworkCore;
using SimpleLearn.API.Models.Domain;

namespace SimpleLearn.API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
