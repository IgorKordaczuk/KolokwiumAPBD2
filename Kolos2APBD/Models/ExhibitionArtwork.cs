using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolos2APBD.Models;

[PrimaryKey(nameof(ExhibitionId),nameof(ArtworkId))]
[Table("Exhibition_Artwork")]
public class ExhibitionArtwork
{
    [ForeignKey("Exhibition")]
    public int ExhibitionId { get; set; }
    
    [ForeignKey("Artwork")]
    public int ArtworkId { get; set; }
    
    [Column(TypeName = "numeric")]
    [Precision(10, 2)]
    public double InsuranceValue { get; set; }

    public Artwork Artwork { get; set; } = null!;
    public Exhibition Exhibition { get; set; } = null!;

}