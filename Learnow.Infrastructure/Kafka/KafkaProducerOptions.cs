using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Infrastructure.Kafka
{
    public class KafkaProducerOptions
    {
        //public string GroupId { get; set; }
        public string BootstrapServers { get; set; }
        public string Topic { get; set; }
        //public KafkaAutoOffsetReset AutoOffsetReset { get; set; }
    }
}
