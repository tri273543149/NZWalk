using NZWalks.API.Models.Domain;

namespace NZWalks.API.Interfaces
{
    public interface IRegionRepository
    {
        public Task<IEnumerable<Region>> GetAllRegionsAsync();
        public Task<Region> GetAsync(Guid id);
        public Task<Region> AddAsync(Region region);
        public Task<Region> UpdateAsync(Guid id, Region region);
        public Task<Region> DeleteAsync(Guid id);
    }
}
