using BloodDonation.Application.Models.InputModels.User;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BloodDonation.Application.Services.User;
public class UserValidation : AbstractValidator<UserInputModel>
{
    public UserValidation()
    {
        RuleFor(u => u.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage($"{nameof(Core.Entities.User.Name)} não pode estar vazio");

        RuleFor(u => u.Email)
            .EmailAddress()
            .WithMessage($"{nameof(Core.Entities.User.Email)} inválido");

        RuleFor(u => u.Password)
            .Must(ValidPassword)
            .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");
    }

    private static bool ValidPassword(string password)
    {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

        return regex.IsMatch(password);
    }
}
