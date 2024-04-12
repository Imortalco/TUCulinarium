using FluentEmail.Core;
using Microsoft.AspNetCore.Identity;
using TUKulinarium_API.Data.Models;


public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;
    private readonly UserManager<User> _userManager;
    private readonly IFluentEmailFactory _fluentEmailFactory;

    public EmailService(ILogger<EmailService> logger, IFluentEmailFactory fluentEmailFactory)
    {
        _logger = logger;
        _fluentEmailFactory = fluentEmailFactory;
    }

    public async Task SendEmailAsync(EmailMessage messageModel)
    {
        _logger.LogInformation("Sending email");
        await _fluentEmailFactory.Create().To(messageModel.ToAddress)
            .Subject(messageModel.Subject)
            .Body(messageModel.Body, true)
            .SendAsync();
    }


    // public async Task SendPasswordRecoveryEmailAsync(string email, string tokenUrl)
    // {
    //     string body = $"Please click on the following link to reset your password: {tokenUrl}";
    //     EmailMessage emailMsgModel = new EmailMessage(email, "Confirm your email", body);

    // }
}