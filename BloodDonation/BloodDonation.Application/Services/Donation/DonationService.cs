﻿using BloodDonation.Application.Models.InputModels.BloodStock;
using BloodDonation.Application.Models.InputModels.Donation;
using BloodDonation.Application.Services.BloodStock;
using BloodDonation.Core.Enums;
using BloodDonation.Core.Exceptions;
using BloodDonation.Infra.Persistence.UnityOfWork;

namespace BloodDonation.Application.Services.Donation;
public class DonationService(IUnityOfWork unityOfWork, IBloodStockService bloodStockService) : IDonationService
{
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    private readonly IBloodStockService _bloodStockService = bloodStockService;

    public async Task<Guid> Register(DonationInputModel model)
    {
        ValidateModel(model);

        var donor = await _unityOfWork.Donors.GetByIdAsync(model.DonorId);

        bool isMinorPerson = IsMinorPerson(donor.BirthdayDate);
        bool personCantDonate = PersonCanDonate(donor.Gender, donor.Donations);

        if (isMinorPerson)
        {
            throw new ValidationErrorsException("Menor de idade não pode doar");
        }
        
        if (personCantDonate == true)
        {
            throw new ValidationErrorsException("Tempo desde a última doação menor que o permitido");
        }

        var donation = model.ToEntity();

        await _unityOfWork.Donations.AddAsync(donation);

        BloodStockInputModel bloodStockInputModel = new()
        {
            BloodType = donor.BloodType,
            RhFactor = donor.RhFact,
            MLQuantity = donation.MLQuantity
        };

        await _bloodStockService.Update(bloodStockInputModel);

        await _unityOfWork.CompleteAsync();

        return donation.Id;
    }

    private static bool PersonCanDonate(GenderEnum gender, ICollection<Core.Entities.Donation> donations)
    {
        var lastPersonDonationDate = donations.OrderByDescending(d => d.DonationDate).FirstOrDefault()?.DonationDate ?? DateTime.MinValue;
        var countOfDays = (DateTime.Now - lastPersonDonationDate).Days;
        int manCountDateValue = 60;
        int womenCountDateValue = 90;

        bool personCanDonate = gender == GenderEnum.Male && countOfDays <= manCountDateValue || 
                              (gender == GenderEnum.Female && countOfDays <= womenCountDateValue);

        return personCanDonate;
    }

    private static bool IsMinorPerson(DateTime birthdayDate)
    {
        int personAge = DateTime.Now.Year - birthdayDate.Year;
        
        if (DateTime.Now < birthdayDate.AddYears(personAge))
        {
            personAge--;
        }

        bool isMinorPerson = personAge < 18;

        return isMinorPerson;
    }

    private static void ValidateModel(DonationInputModel model)
    {
        var validator = new DonationValidation();
        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }
}
