namespace BloodDonation.Application.Models.ViewModels;
public class ErrorViewModel
{
    public List<string> Messages { get; set; }

    public ErrorViewModel(List<string> messages)
    {
        Messages = messages;
    }

    public ErrorViewModel(string message)
    {
        Messages = [message];
    }
}
