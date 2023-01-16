using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Interfaces;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public RegionRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var updateRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(updateRegion == null)
            {
                return null;
            }

            updateRegion.Code = region.Code;
            updateRegion.Name = region.Name;
            updateRegion.Area = region.Area;
            updateRegion.Lat = region.Lat;
            updateRegion.Long = region.Long;
            updateRegion.Population = region.Population;

            await _dbContext.SaveChangesAsync();
            return updateRegion;
        }
    }
}
