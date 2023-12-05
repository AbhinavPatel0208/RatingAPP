using Microsoft.EntityFrameworkCore;
using RatingWeb.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
            new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
            new Category { Id = 3, Name = "History", DisplayOrder = 3 }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "NFT1",
                Price = 100,
                Rating = 1,
                CategoryId = 1,
                ImageUrl = "" 
            },
            new Product
            {
                Id = 2,
                Name = "NFT2",
                Price = 3000,
                Rating = 4,
                CategoryId = 2,
                ImageUrl = "" 
            },
            new Product
            {
                Id = 3,
                Name = "NFT3",
                Price = 890,
                Rating = 5,
                CategoryId = 3,
                ImageUrl = "" 
            }
        );

        modelBuilder.Entity<Rating>().HasData(
            new Rating
            {
                Id = 1,
                ProductId = 1,
                Stars = 3 
            },
            new Rating
            {
                Id = 2,
                ProductId = 2,
                Stars = 5 
            },
            new Rating
            {
                Id = 3,
                ProductId = 3,
                Stars = 4
            }
        );
    }
}
