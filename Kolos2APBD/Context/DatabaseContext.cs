using System.Net.Mime;
using Kolos2APBD.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolos2APBD.Context;

public class DatabaseContext : DbContext
{
    // public DbSet<Client> Clients { get; set; }
    // public DbSet<Status> Statuses { get; set; }
    // public DbSet<Product> Products { get; set; }
    // public DbSet<Order> Orders { get; set; }
    // public DbSet<ProductOrder> ProductOrders { get; set; }
    
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Exhibition> Exhibitions { get; set; }
    public DbSet<ExhibitionArtwork> ExhibitionArtworks { get; set; }
    public DbSet<Gallery> Galleries { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>().HasData(new List<Artist>()
        {
            new Artist() {ArtistId = 1, FirstName = "Jane", LastName = "Doe", BirthDate = DateTime.Parse("2025-05-01")},
            new Artist() {ArtistId = 2, FirstName = "Marek", LastName = "Kowalski", BirthDate = DateTime.Parse("2025-06-02")},
            new Artist() {ArtistId = 3, FirstName = "Mirosław", LastName = "Krupiewnicki", BirthDate = DateTime.Parse("2025-07-03")}
        });
        
        modelBuilder.Entity<Artwork>().HasData(new List<Artwork>()
        {
            new Artwork() {ArtworkId = 1, ArtistId = 1, Title = "KolosNamalowany", YearCreated = 2004},
            new Artwork() {ArtworkId = 2, ArtistId = 2, Title = "Oobrotachsferniebieskich", YearCreated = 2005},
            new Artwork() {ArtworkId = 3, ArtistId = 3, Title = "Obrazobrazowy", YearCreated = 2006},
        });

        modelBuilder.Entity<Gallery>().HasData(new List<Gallery>()
        {
            new Gallery() {GalleryId = 1, Name = "Wystawa1", EstablishedDate = DateTime.Parse("2026-07-03")}
        });

        
        modelBuilder.Entity<Exhibition>().HasData(new List<Exhibition>()
        {
            new Exhibition() {ExhibitionId = 1, GalleryId = 1, Title = "Wystawa1", StartDate = DateTime.Parse("2026-07-03"), EndDate = DateTime.Parse("2026-07-10"), NumberOfArtworks = 5},
            new Exhibition() {ExhibitionId = 2, GalleryId = 1, Title = "Wystawa2", StartDate = DateTime.Parse("2026-07-04"), EndDate = DateTime.Parse("2026-07-11"), NumberOfArtworks = 6},
            new Exhibition() {ExhibitionId = 3, GalleryId = 1, Title = "Wystawa3", StartDate = DateTime.Parse("2026-07-05"), EndDate = DateTime.Parse("2026-07-11"), NumberOfArtworks = 7}
        });

        modelBuilder.Entity<ExhibitionArtwork>().HasData(new List<ExhibitionArtwork>()
        {
            new ExhibitionArtwork() {ExhibitionId = 1, ArtworkId = 1, InsuranceValue = 1000},
            new ExhibitionArtwork() {ExhibitionId = 1, ArtworkId = 3, InsuranceValue = 2000},
            new ExhibitionArtwork() {ExhibitionId = 2, ArtworkId = 2, InsuranceValue = 3000}
        });
    }
}