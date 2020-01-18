using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Infrastructure.SendGrid
{
    public class SendGridAdapter : ISendGridAdapter
    {
        private readonly SendGridAdapterOptions _options;
        public SendGridAdapter(SendGridAdapterOptions options)
        {
            _options = options;
        }


        public async Task SendEmailAsync (string recipientEmail, string recipientName, string subject, string plainTextContent, string htmlContent)
        {
            if (_options == null) throw new ArgumentNullException("SendGridAdapterOptions is null");
            if (_options.IsEnabled)
            {
                await SendEmailAsync(_options.Apikey, _options.SenderEmail, _options.SenderName, recipientEmail, recipientName, subject, plainTextContent, htmlContent);
            }
        }

        public async Task SendEmailAsync (string apiKey, string senderEmail, string senderName, string recipientEmail, string recipientName, string subject, string plainTextContent, string htmlContent)
        {
            var client = new SendGridClient(apiKey);
            var xfrom = new EmailAddress(senderEmail, senderName);
            var xrecipient = new EmailAddress(recipientEmail, recipientName);
            var msg = MailHelper.CreateSingleEmail(xfrom, xrecipient, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
