using NetChallenge.Api.Models;
using NetChallenge.Api.Services.Interfaces;

namespace NetChallenge.Api.Services
{
    public class DroneService : IDroneService
    {
        public async Task<Output> CreateAsync(Input request)
        {
            return new Output();
        }

        public async Task<Output> GetAsync()
        {
            return new Output();
        }
    }
}
