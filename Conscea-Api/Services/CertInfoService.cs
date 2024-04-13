// using System.Reflection.Metadata.Ecma335;
// using System.Runtime.CompilerServices;
// using Conscea_Api.Models.DTOs;
// using Microsoft.AspNetCore.Mvc;

using Conscea_Api.Data;
using Conscea_Api.Models;
using Conscea_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Conscea_Api.Services;

public class CertInfoService : ICertInfoService
{

    private readonly ConsceaContext _ctx;

    public CertInfoService(ConsceaContext ctx) { _ctx = ctx; }

    public async Task AddCertification(string certId, string name, string level, string category, bool expire)
    {
        
        CertInfo? cert = await _ctx.CertInfos.FindAsync(certId);

        if (cert != null)
            throw new KeyNotFoundException("Certification with this ID already exists.");
        try
        {
            var my_item = _ctx.CertInfos.Find(certId);
            CertInfo certificate = new CertInfo {
                Id = certId,
                Name = name,
                Level = level,
                Category = category,
                Expire = expire,
            };
            await _ctx.CertInfos.AddAsync(certificate);
            await _ctx.SaveChangesAsync();

            return;
        } catch { throw; }
    }

public Task DeleteCertification(Guid id)
    {
        try {
            var certificate = _ctx.CertInfos.Find(id);
            _ctx.CertInfos.Remove(certificate);
            _ctx.SaveChanges();

        } catch { throw; }       

        return Task.CompletedTask;
    }


    public Task<IEnumerable<CertInfo>> GetAllAsync()
    {
        try {
            return Task.FromResult(_ctx.CertInfos.AsEnumerable());
        } catch { throw; }
            
    }

}