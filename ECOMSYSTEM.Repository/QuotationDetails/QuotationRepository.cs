using ECOMSYSTEM.DataAccess.EntityModel;
using ECOMSYSTEM.Shared.Interfaces;
using ECOMSYSTEM.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

public class QuotationRepository : IQuotationRepository
{
    private readonly ECOM_WebContext _context;
    
    public QuotationRepository(ECOM_WebContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateQuotation(long itemId, long userId, string status = "Pending")
    {
        try
        {
            var newQuotation = new TblQuotation
            {
                ItemId = itemId,
                UserId = userId,
                CreatedDate = DateTime.Now,
                QuotationStatus = status
            };
            await _context.TblQuotations.AddAsync(newQuotation);
            var affectedRows = await _context.SaveChangesAsync();  // Save changes and capture the number of affected rows
            return affectedRows > 0;  // Return true if at least one row was affected, false otherwise
        }
        catch (Exception)
        {
            return false;  // Return false if an error occurs
        }
    }


    public async Task<IEnumerable<Quotation>> GetAllQuotations()
    {
        var quotations = await _context.TblQuotations
            .Select(q => new Quotation
            {
                QuotationId = q.QuotationId,
                ItemId = q.ItemId,
                UserId = q.UserId,
                CreatedDate = q.CreatedDate,
                QuotationStatus = q.QuotationStatus
                // Map other properties as needed
            })
            .ToListAsync();

        return quotations;
    }

   

    public async Task<bool> UpdateQuotationStatus(long QuotationId, string status)
    {
        try
        {
            var quotation = await _context.TblQuotations.FindAsync(QuotationId);
            
            if (quotation == null)
                return false;

            quotation.QuotationStatus = status;
            await _context.SaveChangesAsync();
            
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}