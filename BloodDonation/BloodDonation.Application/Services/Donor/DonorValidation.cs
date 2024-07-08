using BloodDonation.Application.Models.InputModels.Donor;
using FluentValidation;
using FluentValidationBR.Extensions;

namespace BloodDonation.Application.Services.Donor;
public class DonorValidation : AbstractValidator<DonorInputModel>
{
    public DonorValidation()
    {
        RuleFor(d => d.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage($"{nameof(DonorInputModel.Name)} não pode estar vazio");

        RuleFor(d => d.Email)
            .EmailAddress()
            .WithMessage($"{nameof(DonorInputModel.Email)} inválido");

        RuleFor(d => d.BirthdayDate)
            .NotEmpty()
            .NotNull()
            .WithMessage($"{nameof(DonorInputModel.BirthdayDate)} não pode ser nulo");

        RuleFor(d => d.Gender)
            .IsInEnum()
            .WithMessage($"{nameof(DonorInputModel.Gender)} inválido");

        RuleFor(d => d.Weight)
            .NotNull()
            .GreaterThanOrEqualTo(50)
            .WithMessage("Doador não pode pesar menos que 50kg");

        RuleFor(d => d.BloodType)
            .IsInEnum()
            .WithMessage($"{nameof(DonorInputModel.BloodType)} inválido");

        RuleFor(d => d.RhFact)
            .IsInEnum()
            .WithMessage($"{nameof(DonorInputModel.RhFact)} inválido");

        RuleFor(d => d.CEP)
            .Cep()
            .WithMessage($"{nameof(DonorInputModel.CEP)} inválido");
    }
}
