﻿using BloodDonation.Core.Entities;
using BloodDonation.Core.Enums;
using BloodDonation.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infra.Persistence.Repositories;
public class BloodStockRepository(BloodDonationDbContext context) : IBloodStockRepository
{
    private readonly BloodDonationDbContext _context = context;

    public async Task<BloodStock> GetByParams(BloodTypesEnum bloodType, RhFatorEnum rhFactor)
    {
        BloodStock? bloodStock = await _context.BloodStocks
            .AsNoTracking()
            .Where(x => x.BloodType == bloodType && x.RhFactor == rhFactor)
            .SingleOrDefaultAsync();

        return bloodStock;
    }

    public void Update(BloodStock bloodStock)
    {
        _context.BloodStocks.Update(bloodStock);
    }

    public async Task<List<BloodStock>> GetAllAsync()
    {
        List<BloodStock> stock = await _context.BloodStocks.AsNoTracking().ToListAsync();

        return stock;
    }
}
