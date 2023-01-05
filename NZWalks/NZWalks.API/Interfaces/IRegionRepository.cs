using NZWalks.API.Models.Domain;

namespace NZWalks.API.Interfaces
{
    public interface IRegionRepository
    {
        public Task<IEnumerable<Region>> GetAllRegionsAsync();
    }
}
