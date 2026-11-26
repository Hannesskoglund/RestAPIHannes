using Microsoft.EntityFrameworkCore;
using RestAPIHannes.Models;

namespace RestAPIHannes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Advert> Ads { get; set; }
    }

}
