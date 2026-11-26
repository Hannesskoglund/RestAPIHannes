using Microsoft.EntityFrameworkCore;
using RestAPIHannes.Models;

namespace RestAPIHannes.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void MigrateData()
        {
            dbContext.Database.Migrate();
            SeedData();
            dbContext.SaveChanges();
        }

        public void SeedData()
        {
            if (!dbContext.Ads.Any())
            {
                dbContext.Add(new Ad
                {
                    Title = "iPhone 14",
                    Description = "iPhone 14 i mycket gott skick, knappt använd.",
                    Price = 4500m,
                    Category = "Elektronik",
                    CreatedAt = new DateTime(2026, 1, 10),
                    IsActive = true,
                    SellerName = "Anna Andersson",
                    SellerEmail = "anna@example.com"
                });



                dbContext.Add(new Ad
                {
                    Title = "Gaming PC",
                    Description = "Kraftfull gamingdator med RTX 4070 och 32GB RAM.",
                    Price = 12000m,
                    Category = "Elektronik",
                    CreatedAt = new DateTime(2026, 1, 12),
                    IsActive = true,
                    SellerName = "Erik Svensson",
                    SellerEmail = "erik@example.com"
                });




                dbContext.Add(new Ad
                {
                    Title = "IKEA Soffa",
                    Description = "Grå tresitssoffa från IKEA. Fint skick.",
                    Price = 2500m,
                    Category = "Möbler",
                    CreatedAt = new DateTime(2026, 1, 15),
                    IsActive = true,
                    SellerName = "Lisa Karlsson",
                    SellerEmail = "lisa@example.com"
                });




                dbContext.Add(new Ad
                {
                    Title = "Mountainbike",
                    Description = "Mountainbike med 21 växlar. Perfekt för skog och terräng.",
                    Price = 3200m,
                    Category = "Sport & Fritid",
                    CreatedAt = new DateTime(2026, 1, 18),
                    IsActive = true,
                    SellerName = "Johan Nilsson",
                    SellerEmail = "johan@example.com"
                });
            }

            dbContext.SaveChanges();
        }
    }

}
