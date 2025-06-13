namespace Kolos2APBD.DTOs;

public class GalleryExhibitionDTO
{
    public int GalleryId { get; set; }
    public string GalleryName { get; set; } = null!;
    public DateTime EstablishedDate { get; set; }
    public List<ExhibitionDTO> Exhibitions { get; set; } = null!;
}

public class ExhibitionDTO
{
    public string Title { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int NumberOfArtworks { get; set; }
    public List<ArtworkDTO> Artworks { get; set; } = null!;
}

public class ArtworkDTO
{
    public string Title { get; set; } = null!;
    public int YearCreated { get; set; }
    public double InsuranceValue { get; set; }
    public ArtistDTO Artist { get; set; } = null!;
}

public class ArtistDTO
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
}