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
            new Category { Id = 1, Name = "Music" },
            new Category { Id = 2, Name = "SciFi"},
            new Category { Id = 3, Name = "Era" },
            new Category { Id = 4, Name = "Action" },
            new Category { Id = 5, Name = "Modern" },
            new Category { Id = 6, Name = "Digital" },
            new Category { Id = 7, Name = "Cartoon" },
            new Category { Id = 8, Name = "CdS" },
            new Category { Id = 9, Name = "Anime" }
        );

        modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "NFT1",
                    Price = 100,
                    Rating = 1,
                    CategoryId = 1,
                   
                },
                new Product
                {
                    Id = 2,
                    Name = "NFT2",
                    Price = 3000,
                    Rating = 4,
                    CategoryId = 2,
                    
                },
                new Product
                {
                    Id = 3,
                    Name = "NFT3",
                    Price = 890,
                    Rating = 5,
                    CategoryId = 3,
                   
                },
                new Product
                {
                    Id = 4,
                    Name = "NFT4",
                    Price = 100,
                    Rating = 5,
                    CategoryId = 5,

                },
                new Product
                {
                    Id = 5,
                    Name = "NFT5",
                    Price = 3000,
                    Rating = 4,
                    CategoryId = 6,

                },
                new Product
                {
                    Id = 6,
                    Name = "NFT6",
                    Price = 890,
                    Rating = 5,
                    CategoryId = 8,

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
                Stars = 3
            },
            new Rating
            {
                Id = 4,
                ProductId = 4,
                Stars = 3
            },
            new Rating
            {
                Id = 5,
                ProductId = 5,
                Stars = 5
            },
            new Rating
            {
                Id = 6,
                ProductId = 6,
                Stars = 4
            }
        );

    }
}
