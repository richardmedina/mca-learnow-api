using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Learnow.Infrastructure.Kafka
{
    public delegate void MessageReceivedHandler<TMessage> (object sender, TMessage message);

    public class KafkaConsumer<TMessage> : IKafkaConsumer where TMessage : KafkaMessage
    {
        private readonly KafkaConsumerOptions _options;
        private readonly IConsumer<Ignore, string> _consumer;

        private readonly CancellationTokenSource cancellationToken;
        private event MessageReceivedHandler<TMessage> MessageReceived;
        private void onMessageReceived(object sender, TMessage message)
        {
        }

        public KafkaConsumer(KafkaConsumerOptions options)
        {
            MessageReceived = new MessageReceivedHandler<TMessage>(onMessageReceived);

            _options = options;

            var conf = new ConsumerConfig
            {
                GroupId = _options.GroupId,
                BootstrapServers = _options.BootstrapServers,
                // Note: The AutoOffsetReset property determines the start offset in the event
                // there are not yet any committed offsets for the consumer group for the
                // topic/partitions of interest. By default, offsets are committed
                // automatically, so in this example, consumption will only start from the
                // earliest message in the topic 'my-topic' the first time you run the program.
                AutoOffsetReset = (AutoOffsetReset)_options.AutoOffsetReset
            };

            _consumer = new ConsumerBuilder<Ignore, string>(conf).Build();
            cancellationToken = new CancellationTokenSource();
            _consumer.Subscribe(_options.Topic);
        }

        public void Start()
        {
            try
            {
                while (true)
                {
                    try
                    {
                        var cr = _consumer.Consume(cancellationToken.Token);
                        var message = JsonConvert.DeserializeObject<TMessage>(cr.Value);
                        OnMessageReceived(message);
                        Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Error occured: {e.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Ensure the consumer leaves the group cleanly and final offsets are committed.
                _consumer.Close();
            }
        }

        public void Stop ()
        {
            cancellationToken.Cancel();
        }

        public void OnMessageReceived(TMessage message)
        {
            MessageReceived(this, message);
        }
    }
}
