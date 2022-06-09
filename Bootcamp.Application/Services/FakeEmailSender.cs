using Bootcamp.Application.Interfaces;
using Bootcamp.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Application.Services
{
    public class FakeEmailSender : IEmailService
    {
        public Task SendEmailAsync(MailRequest mailRequest)
        {
            Console.WriteLine("Email is ready to send");
            Console.WriteLine($"ToAddress is {mailRequest.ToEmail} and subject is {mailRequest.Subject}");
            return Task.CompletedTask;
        }
    }
}
