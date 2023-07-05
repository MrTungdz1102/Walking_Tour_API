using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Walking_Tour_API.Core.Models.Domain;

namespace Walking_Tour_API.Infrastructure.Configuration
{
	public class RegionConfiguration : IEntityTypeConfiguration<Region>
	{
		public void Configure(EntityTypeBuilder<Region> builder)
		{
			builder.HasData(
				new Region { Id = Guid.NewGuid(), Code = "AKL", Name = "Auckland", RegionImageUrl = null },
				new Region { Id = Guid.NewGuid(), Code = "NTL", Name = "Northland", RegionImageUrl = null },
				new Region { Id = Guid.NewGuid(), Code = "BOP", Name = "Bay Of Plenty", RegionImageUrl = null },
				new Region { Id = Guid.NewGuid(), Code = "WGN", Name = "Wellington", RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
				new Region { Id = Guid.NewGuid(), Code = "NSN", Name = "Nelson", RegionImageUrl = null },
				new Region { Id = Guid.NewGuid(), Code = "STL", Name = "Southland", RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
				);
		}
	}
}
