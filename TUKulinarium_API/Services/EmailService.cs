using System.Net;
using System.Net.Mail;
using FluentEmail.Core;
using Microsoft.AspNetCore.Identity;
using TUKulinarium_API.Data.Models;


public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;
    private readonly IConfiguration _configuration;

    public EmailService(ILogger<EmailService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public async Task SendEmailAsync(EmailMessage messageModel)
    {
        _logger.LogInformation("Sending email");
        var emailSettings = _configuration.GetSection("EmailSettings");

        using (var client = new SmtpClient(emailSettings["Host"]))
        {
            client.Port = int.Parse(emailSettings["Port"]);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(emailSettings["Username"], emailSettings["Password"]);
            client.EnableSsl = true;

            using (var mailMessage = new MailMessage(emailSettings["DefaultFromEmail"], messageModel.ToAddress))
            {
                mailMessage.Subject = messageModel.Subject;
                mailMessage.Body = $"<p> Please confirm your email address by clicking the following link:</p>" + messageModel.Body;
                mailMessage.IsBodyHtml = true;

                await client.SendMailAsync(mailMessage);
            }
        }
    }


}