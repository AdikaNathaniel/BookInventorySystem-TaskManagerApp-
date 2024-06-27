using BlazorWebAssemblyDotNetCrud.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookInventory.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<VideoGame> VideoGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame { Id = 1, Title = "Chemistry InScope", Publisher = "CD Jakes", ReleaseYear = 2021 },
                new VideoGame { Id = 2, Title = "Emaths InScope", Publisher = "CDA Jakes", ReleaseYear = 2019 },
                new VideoGame { Id = 3, Title = "Biology InScope", Publisher = "CDU Jakes", ReleaseYear = 2017 }
                );
        }
    }

}
