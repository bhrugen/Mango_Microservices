namespace Mango.Services.RewardAPI.Message
{
    public class RewardsMessage
    {
        public string UserId { get; set; }
        public int RewardsActivity { get; set; }
        public int OrderId { get; set; }
    }
}
