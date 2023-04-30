using Mango.Services.RewardAPI.Message;
using Mango.Services.RewardAPI.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace Mango.Services.EmailAPI.Messaging
{
    public class RabbitMQOrderConsumer : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly RewardService _rewardService;
        private IConnection _connection;
        private IModel _channel;
        string queueName="";
        public RabbitMQOrderConsumer(IConfiguration configuration, RewardService rewardService)
        {
            _configuration = configuration;
            _rewardService = rewardService;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Password = "guest",
                UserName = "guest",
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(_configuration.GetValue<string>("TopicAndQueueNames:OrderCreatedTopic"),ExchangeType.Fanout);
            queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queueName, configuration.GetValue<string>("TopicAndQueueNames:OrderCreatedTopic"), "");
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                RewardsMessage rewardsMessage = JsonConvert.DeserializeObject<RewardsMessage>(content);
                HandleMessage(rewardsMessage).GetAwaiter().GetResult();

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(queueName, false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(RewardsMessage rewardsMessage)
        {
            _rewardService.UpdateRewards(rewardsMessage).GetAwaiter().GetResult();
        }
    }
}
