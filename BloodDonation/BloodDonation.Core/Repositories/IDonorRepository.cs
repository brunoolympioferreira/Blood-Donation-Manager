﻿using BloodDonation.Core.Entities;

namespace BloodDonation.Core.Repositories;
public interface IDonorRepository
{
    Task AddAsync(Donor donor);
}