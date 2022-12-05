namespace NetChallenge.Api.Models
{
    public class ScheduledDestination
    {
        public int Id { get; set; }
        public string LocationCode { get; set; }
        public string Location { get; set; }
        public int TotalWeightToDeliver { get; set; }
    }
}
