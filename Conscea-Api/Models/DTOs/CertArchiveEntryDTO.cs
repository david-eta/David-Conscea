namespace Conscea_Api.Models.DTOs;


public class CertArchiveEntryDTO
{
    public int AccountId { get; set; }
    public string CertInfoId { get; set; }
    public DateTime CertifiedDate { get; set; }
    public DateTime? ExpireDate { get; set; }
    public AccountEntryDTO Account { get; set; }
    public CertInfoEntryDTO CertInfo { get; set; }
}
