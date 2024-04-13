using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Conscea_Api.Models;


public class CertInfo : IComparable<CertInfo>
{
    [Required, Key]
    public string Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Level { get; set; }

    public string Category { get; set; }

    public bool Expire { get; set; }
    public CertInfo() { }
    public int CompareTo(CertInfo? other)
    {
        if (other != null)
            return this.Id.CompareTo(other.Id); // compares by price
        
        // if null or otherwise, return 
        return 1;
    }

    // public ICollection<CertArchive> CertArchives { get; }
}