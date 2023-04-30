namespace Mango.Services.OrderAPI.RabbmitMQSender
{
    public interface IRabbmitMQOrderMessageSender
    {
        void SendMessage(Object message, string exchangeName);
    }
}
