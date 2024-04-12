public interface IEmailService
{
    Task SendEmailAsync(EmailMessage message);
    // Task SendPasswordRecoveryEmailAsync(string email);
}