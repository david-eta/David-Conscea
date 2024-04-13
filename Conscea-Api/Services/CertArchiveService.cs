// using System.Reflection.Metadata.Ecma335;
// using System.Runtime.CompilerServices;
// using Conscea_Api.Models.DTOs;
// using Microsoft.AspNetCore.Mvc;

using Conscea_Api.Data;
using Conscea_Api.Models;
using Conscea_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Conscea_Api.Services;

public class CertArchiveService : ICertArchiveService
{

    private readonly ConsceaContext _ctx;

    public CertArchiveService(ConsceaContext ctx) { _ctx = ctx; }

    public async Task AddCertification(Guid userId, string certId, DateTime certDate)
    {
        CertInfo? my_cert = await _ctx.CertInfos.Where(s=>s.Id==certId).Select(s=>s).FirstOrDefaultAsync();
        if (my_cert is null)
            throw new InvalidOperationException("Certification with specified ID does not exist.");
        try
        {
            var my_item = _ctx.CertInfos.Find(certId);
            CertArchive cert = new CertArchive {
                Id = Guid.NewGuid(),
                CertId = certId,
                AccountId = userId,
                CertifiedDate = certDate,
                ExpiryDate = certDate.AddDays(360)
            };
            _ctx.SaveChanges();

            return;
        } catch
        {
            throw;
        }
    }

    public async Task AddCertification(Guid userId, string certId, DateTime certDate, DateTime expDate)
    {
        CertInfo? my_cert = await _ctx.CertInfos.Where(s=>s.Id==certId).Select(s=>s).FirstOrDefaultAsync();
        if (my_cert is null)
            throw new InvalidOperationException("Certification with specified ID does not exist.");
        try
        {
            var my_item = _ctx.CertInfos.Find(certId);
            CertArchive cert = new CertArchive {
                Id = Guid.NewGuid(),
                CertId = certId,
                AccountId = userId,
                CertifiedDate = certDate,
                ExpiryDate = expDate,
            };
            _ctx.SaveChanges();

            return;
        } catch
        {
            throw;
        }
    }

    public async Task DeleteCertification(Guid userId, string certId)
    {
        // Find the specific certification entry for the given user and certification IDs
        var certification = await _ctx.CertArchives.Where(c => c.CertId == certId && c.AccountId == userId).FirstOrDefaultAsync();

        // Check if the certification was actually found
        if (certification == null){
            throw new KeyNotFoundException("No certification found with the specified ID for this user.");
        }

        // Remove the certification from the database
        _ctx.CertArchives.Remove(certification);
        _ctx.SaveChanges();
    }


    public Task<IEnumerable<CertArchive>?> GetAllByUser(Guid userId)
    {
        var items = _ctx.CertArchives.Where(cert => cert.AccountId == userId).Select(i => i).ToList();

        return Task.FromResult<IEnumerable<CertArchive>?>(items);
    }

    public async Task<IEnumerable<CertInfo>?> GetAllUserCertsAsync(Guid userId)
    {
        // Get all CertArchive entries for the given userId
        var certIds = await _ctx.CertArchives
                                .Where(cert => cert.AccountId == userId)
                                .Select(cert => cert.CertId)
                                .ToListAsync();

        // Use the collected certIds to find all matching CertInfo entries
        var certInfos = await _ctx.CertInfos
                                .Where(info => certIds.Contains(info.Id))
                                .ToListAsync();

        return certInfos;
    }
 
    // TODO: 
    public async Task UpdateDates(Guid Id, DateTime certDate, DateTime? expDate)
    {
        // Find the specific certification entry for the given user and certification IDs
        // var cert = await _ctx.CertArchives
        //                     .FirstOrDefaultAsync(c => c.CertId == certId && c.AccountId == userId);
        var cert = _ctx.CertArchives.Find(Id);
    
        // Check if the certification was actually found
        if (cert == null)
        {
            throw new KeyNotFoundException("No certification found with the specified ID for this user.");
        }

        // Update the expiry date based on certDate plus 360 days
        
        cert.CertifiedDate = certDate;
        if (expDate == null)
            cert.ExpiryDate = certDate.AddDays(360); // assume it lasts for a year
        

        // Save changes to the database
        await _ctx.SaveChangesAsync();
    }
}
