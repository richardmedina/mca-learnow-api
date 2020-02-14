using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Infrastructure.Kafka
{
    public interface IKafkaProducer
    {
        public Task ProduceAsync(string topic, string message);
        Task ProduceAsync<TObject>(string topic, TObject message);
    }
}
