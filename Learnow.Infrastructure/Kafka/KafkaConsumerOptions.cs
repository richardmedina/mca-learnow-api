using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Infrastructure.Kafka
{
    public class KafkaConsumerOptions
    {
        public string GroupId { get; set; }
        public string BootstrapServers { get; set; }
        public string Topic { get; set; }
        public KafkaAutoOffsetReset AutoOffsetReset { get; set; }
    }

    public enum KafkaAutoOffsetReset
    {
        Latest = 0,
        Earliest = 1,
        Error = 2
    }
}
