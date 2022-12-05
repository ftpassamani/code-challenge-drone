using NetChallenge.Api.Models;
using NetChallenge.Api.Services.Interfaces;

namespace NetChallenge.Api.Services
{
    public class DroneService : IDroneService
    {
        public async Task<Output> CreateAsync(Input request)
        {
            var totalWeightCapacity = request.DronesAssigned.Select(x => x.MaxWeight).Sum();
            var totalWeightToDeliver = request.ScheduledDestinations.Select(x => x.TotalWeightToDeliver).Sum();
            var numberOfTrips = (double)totalWeightToDeliver / totalWeightCapacity;
            var output = new Output();
            var destinations = new List<Distribution>();
            output.TotalCost = 0;

            var disctionaryDroneTrips = new Dictionary<string, List<Trip>>();

            foreach (var destination in request.ScheduledDestinations)
            {
                var remaningToDeliver = destination.TotalWeightToDeliver;

                while (remaningToDeliver != 0)
                {
                    foreach (var drone in request.DronesAssigned)
                    {

                        if (!disctionaryDroneTrips.ContainsKey(drone.Name))
                        {
                            disctionaryDroneTrips.Add(drone.Name, new List<Trip>());
                        }
                        disctionaryDroneTrips[drone.Name].Add(new Trip()
                        {
                            TripNumber = disctionaryDroneTrips[drone.Name].Count() + 1,

                        });

                        remaningToDeliver = drone.MaxWeight > remaningToDeliver ? remaningToDeliver : remaningToDeliver - drone.MaxWeight;

                        if (remaningToDeliver != 0)
                            break;
                    }
                }            
            }

            return output;
        }

        public async Task<Output> GetAsync()
        {
            return new Output();
        }
    }
}
