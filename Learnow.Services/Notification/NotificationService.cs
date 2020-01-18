using Learnow.Common.Services;
using Learnow.Infrastructure.SendGrid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Services.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly ISendGridAdapter _sendGridAdapter;

        public NotificationService(ISendGridAdapter sendGridAdapter)
        {
            _sendGridAdapter = sendGridAdapter;
        }

        public async Task SendUserCreatedNotificationAsync (string recipient, string recipientName)
        {
            var to = recipient;
            var toName = recipientName;

            var subject = $"Your user {recipient} has been created";
            var plainText = $"You have created a new user call {recipientName}";
            var html = $"<h1>User Created</h1><h5>You have created a new user call {recipientName}</h5>";

            await _sendGridAdapter.SendEmailAsync(to, toName, subject, plainText, html);
        }
    }
}
