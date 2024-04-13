// using Conscea_Api.Data;
using Conscea_Api.Models;
// using Conscea_Api.Models.DTOs;

namespace Conscea_Api.Services.Interfaces;

public interface ICertInfoService {
    public Task<IEnumerable<CertInfo>> GetAllAsync(); // see all certifications
    public Task AddCertification(string certId, string Name, string Level, string Category, bool Expire); // Add certification
    public Task DeleteCertification(Guid certId); // Delete certification
}