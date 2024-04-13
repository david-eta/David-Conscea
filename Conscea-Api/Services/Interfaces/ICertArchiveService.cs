// using Conscea_Api.Data;
using Conscea_Api.Models;
// using Conscea_Api.Models.DTOs;

namespace Conscea_Api.Services.Interfaces;

public interface ICertArchiveService {
    public Task<IEnumerable<CertArchive>?> GetAllByUser(Guid userId); // see all certificates owned by a user in db
    public Task<IEnumerable<CertInfo>?> GetAllUserCertsAsync(Guid userId); // see all certificate instances owned by a user
    public Task AddCertification(Guid userId, string certId, DateTime certDate); // Add certification
    public Task AddCertification(Guid userId, string certId, DateTime certDate, DateTime expDate); // Add certification with specified exp. date
    public Task DeleteCertification(Guid userId, string certId); // Delete certification
    public Task UpdateDates(Guid Id, DateTime certDate, DateTime? expDate); // update dates
    // public Task UpdateDates(Guid userId, string certId, DateTime certDate); // update dates
}