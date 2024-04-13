namespace Conscea_Api.Models.DTOs;


public class CertInfoEntryDTO
{
    public string CertId { get; set; }
    public string Name { get; set; }
    public string Level { get; set; }
    public string Category { get; set; }
    public bool Expire { get; set; }
}