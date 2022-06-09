using Bootcamp.Application.Models;
using System.Threading.Tasks;

namespace Bootcamp.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
