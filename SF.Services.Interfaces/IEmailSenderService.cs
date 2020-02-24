
namespace SF.Services.Interfaces
{
    public interface IEmailSenderService
    {
        void SendEmailPlainTextAsync(string email, string subject, string bodyPlainText);

        void SendEmailHtmlTextAsync(string email, string subject, string bodyHtmlText);
    }
}
