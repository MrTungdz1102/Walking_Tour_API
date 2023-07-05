using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walking_Tour_API.Core.Models.Domain;
using Walking_Tour_API.Infrastructure.Configuration;

namespace Walking_Tour_API.Infrastructure.Context
{
	public class TourAPIDbContext : DbContext
	{
		public TourAPIDbContext(DbContextOptions<TourAPIDbContext> options) : base(options)
		{
			
		}

		public DbSet<Region> Regions { get; set; }
		public DbSet<Travel> Travels { get; set; }
		public DbSet<Difficulty> Difficulties { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new RegionConfiguration());
			modelBuilder.ApplyConfiguration(new DifficultyConfiguration());
		}
	}
}
