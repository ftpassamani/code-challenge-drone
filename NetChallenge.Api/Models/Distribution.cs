namespace NetChallenge.Api.Models
{
    public class Distribution
    {
        public string DroneAssigned { get; set; }
        public List<Trip> Trips { get; set; }
    }
}
