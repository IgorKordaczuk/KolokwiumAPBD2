using Kolos2APBD.DTOs;

namespace Kolos2APBD.Services;

public interface IDbService
{
    Task<GalleryExhibitionDTO> GetGalleryExhibitions(int galleryId);
}