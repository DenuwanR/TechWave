//using ECOMSYSTEM.DataAccess.EntityModel;
//using ECOMSYSTEM.Repository.QuotationDetails;
//using ECOMSYSTEM.Shared.Interfaces;
//using ECOMSYSTEM.Shared.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;

//namespace ECOMSYSTEM.Repository.QuotationDetails
//{
//    public class QuotationDetailsRepository : IQuotationRepository
//    {
//        private readonly ECOM_WebContext _context;
//        private readonly ILogger<QuotationDetailsRepository> _logger;

//        public QuotationDetailsRepository(ECOM_WebContext context, ILogger<QuotationDetailsRepository> logger)
//        {
//            _context = context;
//            _logger = logger;
//        }

//        public async Task<bool> CreateQuotation(long itemId, long userId)
//        {
//            try
//            {
//                var newQuotation = new TblQuotation
//                {
//                    ItemId = itemId,
//                    UserId = userId,
//                    CreatedDate = DateTime.Now
//                };
//                await _context.TblQuotations.AddAsync(newQuotation);
//                return await _context.SaveChangesAsync() > 0;
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error creating quotation for ItemId: {ItemId}, UserId: {UserId}", itemId, userId);
//                return false;
//            }
//        }

//        public async Task<IEnumerable<ECOMSYSTEM.Shared.Models.QuotationDetails>> GetAllQuotations()
//        {
//            try
//            {
//                return await _context.TblQuotations
//                    .Include(q => q.ItemCart)
//                    .Include(q => q.User)
//                    .Select(q => new ECOMSYSTEM.Shared.Models.QuotationDetails(
//                        q.QuotationId,
//                        q.ItemId,
//                        q.UserId,
//                        q.CreatedDate,
//                        q.ItemCart != null ? q.ItemCart.ItemName : null,
//                        q.ItemCart != null ? q.ItemCart.ItemDescription : null,
//                        q.User != null ? q.User.MobileNo : null))
//                    .ToListAsync();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error retrieving all quotations");
//                return Enumerable.Empty<ECOMSYSTEM.Shared.Models.QuotationDetails>();
//            }
//        }

//        public async Task<bool> AddSupplierQuote(long quotationId, long? supplierId, double quotationAmount)
//        {
//            try
//            {
//                if (supplierId == null)
//                {
//                    _logger.LogWarning("Attempted to add supplier quote with null supplierId");
//                    throw new ArgumentException("SupplierId cannot be null.");
//                }

//                var newSupplierQuote = new TblSupplierQuote
//                {
//                    QuotationId = quotationId,
//                    SupplierId = supplierId.Value,
//                    QuotationAmount = quotationAmount,
//                    CreatedDate = DateTime.Now,
//                    QuotationStatus = "Pending"
//                };
//                await _context.TblSupplierQuotes.AddAsync(newSupplierQuote);
//                return await _context.SaveChangesAsync() > 0;
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error adding supplier quote for QuotationId: {QuotationId}, SupplierId: {SupplierId}",
//                    quotationId, supplierId);
//                return false;
//            }
//        }

//        public async Task<IEnumerable<ECOMSYSTEM.Shared.Models.QuotationDetails>> GetQuotationsForSuppliers()
//        {
//            try
//            {
//                return await _context.TblQuotations
//                    .Include(q => q.ItemCart)
//                    .Include(q => q.User)
//                    .Select(q => new ECOMSYSTEM.Shared.Models.QuotationDetails(
//                        q.QuotationId,
//                        q.ItemId,
//                        q.UserId,
//                        q.CreatedDate,
//                        q.ItemCart != null ? q.ItemCart.ItemName : null,
//                        q.ItemCart != null ? q.ItemCart.ItemDescription : null,
//                        q.User != null ? q.User.MobileNo : null))
//                    .ToListAsync();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error retrieving quotations for suppliers");
//                return Enumerable.Empty<ECOMSYSTEM.Shared.Models.QuotationDetails>();
//            }
//        }

//        public async Task<IEnumerable<ECOMSYSTEM.Shared.Models.QuotationDetails>> GetQuotationsForItem(long itemId)
//        {
//            try
//            {
//                return await _context.TblQuotations
//                    .Where(q => q.ItemId == itemId)
//                    .Include(q => q.ItemCart)
//                    .Include(q => q.User)
//                    .Select(q => new ECOMSYSTEM.Shared.Models.QuotationDetails(
//                        q.QuotationId,
//                        q.ItemId,
//                        q.UserId,
//                        q.CreatedDate,
//                        q.ItemCart != null ? q.ItemCart.ItemName : null,
//                        q.ItemCart != null ? q.ItemCart.ItemDescription : null,
//                        q.User != null ? q.User.MobileNo : null))
//                    .ToListAsync();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error retrieving quotations for ItemId: {ItemId}", itemId);
//                return Enumerable.Empty<ECOMSYSTEM.Shared.Models.QuotationDetails>();
//            }
//        }
//    }
//}




﻿using ECOMSYSTEM.DataAccess.EntityModel;
using ECOMSYSTEM.Shared.Interfaces;
using ECOMSYSTEM.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOMSYSTEM.Repository.QuotationDetails;


public class QuotationDetailsRepository : IQuotationRepository
{
    private readonly ECOM_WebContext _context;

    public QuotationDetailsRepository(ECOM_WebContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateQuotation(long itemId, long userId)
    {
        try
        {
            var newQuotation = new TblQuotation
            {
                ItemId = itemId,
                UserId = userId,
                CreatedDate = DateTime.Now
                // No QuotationStatus property here anymore
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

    public async Task<IEnumerable<QuotationDetails>> GetAllQuotations()
    {
        var quotations = await _context.TblQuotations
            .Include(q => q.ItemCart) // Include related ItemCart data
            .ThenInclude(ic => ic.User) // Include related User data through ItemCart
            .Select(q => new QuotationDetails
            {
                QuotationId = q.QuotationId,
                ItemId = q.ItemId,
                UserId = q.ItemCart.UserId, // Get UserId from TblItemCart
                CreatedDate = q.CreatedDate,
                ItemName = q.ItemCart.ItemName,
                ItemDescription = q.ItemCart.ItemDescription,
                MobileNo = q.ItemCart.User.MobileNo // Mobile number from TblUserRegistration via TblItemCart
            })
            .ToListAsync();

        return quotations;
    }

}