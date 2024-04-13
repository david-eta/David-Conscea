using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conscea_Api.Models;


public class CertArchive : IComparable<CertArchive>
{
    [Required, Key]
    public Guid Id { get; set; }

    [Required, ForeignKey("Account")]
    public Guid AccountId { get; set; }

    [Required, ForeignKey("Certificate")]
    public string CertId { get; set; }

    [Required]
    public DateTime CertifiedDate { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? ExpiryDate { get; set; }

    public int CompareTo(CertArchive? other)
    {
        if (other != null)
        {
            return this.Id.CompareTo(other.Id); // compares by price
        }
        // if null or otherwise, return 
        return 1;
    }
}
