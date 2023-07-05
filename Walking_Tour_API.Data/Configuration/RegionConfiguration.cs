using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walking_Tour_API.Core.Models.Domain;

namespace Walking_Tour_API.Infrastructure.Configuration
{
	public class RegionConfiguration : IEntityTypeConfiguration<Region>
	{
		public void Configure(EntityTypeBuilder<Region> builder)
		{
			builder.HasData(
				new Region { Id = Guid.NewGuid(), Code = "111", Name = "Region 1", RegionImageUrl = "Image Region 1"},
				new Region { Id = Guid.NewGuid(), Code = "222", Name = "Region 2", RegionImageUrl = "Image Region 2" },
				new Region { Id = Guid.NewGuid(), Code = "333", Name = "Region 3", RegionImageUrl = "Image Region 3" }
				);
		}
	}
}
