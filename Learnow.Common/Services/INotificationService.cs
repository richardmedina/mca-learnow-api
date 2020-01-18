using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Common.Services
{
    public interface INotificationService
    {
        Task SendUserCreatedNotificationAsync(string recipient, string recipientName);
    }
}
