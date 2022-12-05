using NetChallenge.Api.Models;

namespace NetChallenge.Api.Services.Interfaces
{
    public interface IDroneService
    {
        Task<Output> CreateAsync(Input request);
    }
}
