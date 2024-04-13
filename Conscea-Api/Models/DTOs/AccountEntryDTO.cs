namespace Conscea_Api.Models.DTOs;


public class AccountEntryDTO
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string? Grade { get; set; }
    public string? Role { get; set; }
    public bool IsOnline { get; set; }

    // don't think this is necessary
    // public ICollection<CertArchiveDTO> CertArchives { get; set; }
}