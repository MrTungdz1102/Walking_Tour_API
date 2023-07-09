using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Walking_Tour_API.Core.Models.Domain;
using Walking_Tour_API.Infrastructure.Configuration;

namespace Walking_Tour_API.Infrastructure.Context
{
	public class TourAPIDbContext : IdentityDbContext<IdentityUser>
	{
		public TourAPIDbContext(DbContextOptions<TourAPIDbContext> options) : base(options)
		{

		}

		public DbSet<Region> Regions { get; set; }
		public DbSet<Travel> Travels { get; set; }
		public DbSet<Difficulty> Difficulties { get; set; }
		public DbSet<Image> Images { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new RegionConfiguration());
			modelBuilder.ApplyConfiguration(new DifficultyConfiguration());
			modelBuilder.ApplyConfiguration(new RoleConfiguration());
		}
	}
}
