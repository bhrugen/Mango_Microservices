using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Mango.Services.OrderAPI.RabbmitMQSender
{
    public class RabbmitMQOrderMessageSender : IRabbmitMQOrderMessageSender
    {

        private readonly string _hostName;
        private readonly string _username;
        private readonly string _password;
        private IConnection _connection;
        private const string OrderCreated_RewardsUpdateQueue = "RewardsUpdateQueue";
        private const string OrderCreated_EmailUpdateQueue = "EmailUpdateQueue";

        public RabbmitMQOrderMessageSender()
        {
            _hostName = "localhost";
            _password = "guest";
            _username = "guest";
        }

        public void SendMessage(object message, string exchangeName)
        {
            if (ConnectionExists())
            {

                using var channel = _connection.CreateModel();
                channel.ExchangeDeclare(exchangeName,ExchangeType.Direct,durable:false);
                channel.QueueDeclare(OrderCreated_EmailUpdateQueue, false, false, false, null);
                channel.QueueDeclare(OrderCreated_RewardsUpdateQueue, false, false, false, null);

                channel.QueueBind(OrderCreated_EmailUpdateQueue, exchangeName, "EmailUpdate");
                channel.QueueBind(OrderCreated_RewardsUpdateQueue, exchangeName, "RewardsUpdate");

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(exchange: exchangeName, "EmailUpdate", null, body: body);
                channel.BasicPublish(exchange: exchangeName, "RewardsUpdate", null, body: body);
            }

        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostName,
                    Password = _password,
                    UserName = _username
                };

                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {

            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }
            CreateConnection();
            return true;
        }
    }
}
