using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Infrastructure.Kafka
{
    public class KafkaFactory
    {
        public KafkaProducer CreateProducer(KafkaProducerOptions options)
        {
            return new KafkaProducer(options);
        }

        public KafkaConsumer<TMessage> CreateConsumer<TMessage>(KafkaConsumerOptions options) where TMessage : KafkaMessage
        {
            return new KafkaConsumer<TMessage>(options);
        }
    }
}
