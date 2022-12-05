using NetChallenge.Api.Models;
using NetChallenge.Api.Services.Interfaces;

namespace NetChallenge.Api.Services
{
    public class DroneService : IDroneService
    {
        public async Task<Output> CreateAsync(Input request)
        {
            //I will have to order by desc both lists first
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

                        //get the actual List<Trip> from the disctionary and add a tripnumber and location  
                        disctionaryDroneTrips[drone.Name].Add(new Trip()
                        {
                            TripNumber = disctionaryDroneTrips[drone.Name].Count() + 1,
                        });

                        remaningToDeliver = drone.MaxWeight > remaningToDeliver ? remaningToDeliver : remaningToDeliver - drone.MaxWeight;

                        if (remaningToDeliver == 0)
                            break;
                    }
                }            
            }

            //to determine the output.TotalCost I will have to get from the dictionary DroneTrips the drone that have the max number of trips, and than, subtract 1 and multiply by 100

            //to determine the output.Distribution I will have to transform disctionaryDroneTrips into a list of Distribution using linq

            //I will have to persist (database or cache) the response so I can access in the GetAsync method, and delete the previous values

            return output;
        }

        public async Task<Output> GetAsync()
        {
            // I will have to get the valeu from the persistence (database or cache) 
            return new Output();
        }
    }
}
