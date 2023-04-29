namespace Mango.Services.ShoppingCartAPI.RabbmitMQSender
{
    public interface IRabbmitMQCartMessageSender
    {
        void SendMessage(Object message, string queueName);
    }
}
