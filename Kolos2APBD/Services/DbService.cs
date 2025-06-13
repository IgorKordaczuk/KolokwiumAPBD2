using Kolos2APBD.Context;
using Kolos2APBD.DTOs;
using Kolos2APBD.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Kolos2APBD.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<GalleryExhibitionDTO> GetGalleryExhibitions(int galleryId)
    {
        var galleryExhibition = await _context.Galleries
            .Select(e => new GalleryExhibitionDTO()
            {
                GalleryId = e.GalleryId,
                GalleryName = e.Name,
                EstablishedDate = e.EstablishedDate,
                Exhibitions = e.Exhibitions.Select(ex => new ExhibitionDTO()
                {
                    Title = ex.Title,
                    StartDate = ex.StartDate,
                    EndDate = ex.EndDate,
                    NumberOfArtworks = ex.NumberOfArtworks,
                    Artworks = ex.ExhibitionArtworks.Select(ex => new ArtworkDTO()
                    {
                        Title = ex.Artwork.Title,
                        YearCreated = ex.Artwork.YearCreated,
                        InsuranceValue = ex.InsuranceValue,
                    }).ToList()

                }).ToList()
            }).FirstOrDefaultAsync(e => e.GalleryId == galleryId);
        
        if (galleryExhibition == null)
            throw new NotFoundException();

        return galleryExhibition;
    }
}