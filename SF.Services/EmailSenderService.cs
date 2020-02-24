using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using SF.Services.Interfaces;

namespace SF.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration _configuration;

        public EmailSenderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async void SendEmailPlainTextAsync(string recipientEmail, string subject, string bodyPlainText)
        {
            InitializeEmailSender(out var client, out var emailAddressFrom, out var emailAddressTo, recipientEmail);

            var msg = MailHelper.CreateSingleEmail(emailAddressFrom, emailAddressTo, subject, bodyPlainText, "");

            await client.SendEmailAsync(msg);
        }

        public async void SendEmailHtmlTextAsync(string recipientEmail, string subject, string bodyHtmlText)
        {
            InitializeEmailSender(out var client, out var emailAddressFrom, out var emailAddressTo, recipientEmail);

            var msg = MailHelper.CreateSingleEmail(emailAddressFrom, emailAddressTo, subject, "", bodyHtmlText);

            await client.SendEmailAsync(msg);
        }

        private void InitializeEmailSender(out SendGridClient client, out EmailAddress emailAddressFrom,
                                            out EmailAddress emailAddressTo, string email)
        {
            var apiKey = _configuration.GetSection(Constants.Email.sendgridApiKeyName).Value;
            client = new SendGridClient(apiKey);
            emailAddressFrom = new EmailAddress(Constants.Email.senderEmail);
            emailAddressTo = new EmailAddress(email);
        }
    }
}
