using BloodDonation.Application.Models.InputModels.Donation;
using FluentValidation;

namespace BloodDonation.Application.Services.Donation;
public class DonationValidation : AbstractValidator<DonationInputModel>
{
    public DonationValidation()
    {
        RuleFor(d => d.DonorId)
            .NotNull()
            .NotEmpty()
            .WithMessage("Id do doador obrigatório");

        RuleFor(d => d.DonationDate)
            .NotNull()
            .NotEmpty()
            .WithMessage("Data de doação requerido");

        RuleFor(d => d.MLQuantity)
            .NotNull()
            .NotEmpty()
            .WithMessage("Quantidade doada requerida")
            .GreaterThanOrEqualTo(420).WithMessage("A quantidade doada deve ser maior ou igual a 420 ml de sangue")
            .LessThanOrEqualTo(470).WithMessage("A quantidade doada deve ser menor ou igual a 470 ml de sangue");
    }
}
