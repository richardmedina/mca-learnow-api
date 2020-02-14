using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Infrastructure.Kafka
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly KafkaProducerOptions _options;
        private readonly IProducer<Null, string> _producer;

        public KafkaProducer(KafkaProducerOptions options)
        {
            _options = options;
            var conf = new ProducerConfig { BootstrapServers = _options.BootstrapServers };

            Action<DeliveryReport<Null, string>> handler = r =>
                Console.WriteLine(!r.Error.IsError
                    ? $"Delivered message to {r.TopicPartitionOffset}"
                    : $"Delivery Error: {r.Error.Reason}");
            _producer = new ProducerBuilder<Null, string>(conf)
                .Build();

        }

        public async Task ProduceAsync<TObject>(string topic, TObject message)
        {
            await ProduceAsync(topic, JsonConvert.SerializeObject(message));
        }

        public async Task ProduceAsync(string topic, string message)
        {
            await _producer.ProduceAsync(topic, new Message<Null, String> { Value = message });

            //using (var p = new ProducerBuilder<Null, string>(conf).Build())
            //{
            //    for (int i = 0; i < 100; ++i)
            //    {
            //        p.Produce("test", new Message<Null, string> { Value = i.ToString() }, handler);
            //    }

            //    // wait for up to 10 seconds for any inflight messages to be delivered.
            //    p.Flush(TimeSpan.FromSeconds(10));
            //}
        }
    }
}
