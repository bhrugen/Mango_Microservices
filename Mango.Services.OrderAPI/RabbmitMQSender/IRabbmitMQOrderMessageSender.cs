namespace Mango.Services.OrderAPI.RabbmitMQSender
{
    public interface IRabbmitMQCartMessageSender
    {
        void SendMessage(Object message, string queueName);
    }
}
