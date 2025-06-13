using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolos2APBD.Models;

[Table("Exhibition")]
public class Exhibition
{
    [Key]
    public int ExhibitionId { get; set; }
    
    [ForeignKey("GalleryId")]
    public int GalleryId { get; set; }

    [MaxLength(100)]
    public string Title { get; set; } = null!;
    
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    public int NumberOfArtworks { get; set; }
    public Gallery Gallery { get; set; } = null!;
    public ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; } = null!;
    
    
}