using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Core.Enums;
public enum GenderEnum
{
    [Display(Name = "Não Informado")]
    Unknown,
    [Display(Name = "Masculino")]
    Male,
    [Display(Name = "Feminino")]
    Female,
    [Display(Name = "Outros")]
    Others
}
