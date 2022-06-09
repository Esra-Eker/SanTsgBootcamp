using Bootcamp.Application.Interfaces;
using Bootcamp.Application.Models;
using Bootcamp.Shared.SettingsModels;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;

namespace Bootcamp.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var builder = new BodyBuilder
            {
                HtmlBody = mailRequest.Body
            };

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_emailSettings.Mail);
            email.Subject = mailRequest.Subject;
            email.Body = builder.ToMessageBody();
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.From.Add(MailboxAddress.Parse("Bootcamp"));

            using var smtp = new SmtpClient();
            smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailSettings.Mail, _emailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
