using bilerplate.Application.Models.Mail;
using System.Threading.Tasks;

namespace bilerplate.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
