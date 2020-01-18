using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Infrastructure.SendGrid
{
    public interface ISendGridAdapter
    {
        Task SendEmailAsync(string recipientEmail, string recipientName, string subject, string plainTextContent, string htmlContent);
        Task SendEmailAsync(string apiKey, string from, string fromName, string recipient, string recipientName, string subject, string plainTextContent, string htmlContent);
    }
}
