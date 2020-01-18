using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Infrastructure.SendGrid
{
    public class SendGridAdapterOptions
    {
        public string Apikey { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public bool IsEnabled { get; set; }
    }
}
