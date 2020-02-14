using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Infrastructure.Kafka
{
    public interface IKafkaFactory
    {
        public IKafkaConsumer CreateConsumer<TMessage> (KafkaConsumerOptions options) where TMessage : KafkaMessage
        {
            return new KafkaConsumer<TMessage>(options);
        }
    }
}
