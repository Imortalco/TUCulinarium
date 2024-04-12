using Microsoft.AspNetCore.Identity;
using TUKulinarium_API.Data.Models;
public class EmailSender : IEmailSender<User>
{
    private readonly IEmailService _emailService;

    public EmailSender(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
    {
        EmailMessage message = new EmailMessage(email, "Confirm your email", confirmationLink);

        await _emailService.SendEmailAsync(message);
    }

    public Task SendPasswordResetCodeAsync(User user, string email, string resetCode)
    {
        throw new NotImplementedException();
    }

    public Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
    {
        throw new NotImplementedException();
    }
}