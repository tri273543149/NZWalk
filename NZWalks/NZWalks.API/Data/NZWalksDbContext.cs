using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : base(options) { }

        DbSet<Region> Regions { get; set; }
        DbSet<Walk> Walks { get; set; }
        DbSet<WalkDifficulty> WalkDifficulty { get; set; }
    }
}
