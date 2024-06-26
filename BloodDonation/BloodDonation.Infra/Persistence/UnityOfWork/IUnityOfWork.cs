﻿using BloodDonation.Core.Repositories;

namespace BloodDonation.Infra.Persistence.UnityOfWork;
public interface IUnityOfWork
{
    IUserRepository Users {  get; }
    IDonorRepository Donors { get; }
    IDonationRepository Donations { get; }
    IBloodStockRepository BloodStocks { get; }
    Task<int> CompleteAsync();
}
