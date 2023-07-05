using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walking_Tour_API.Core.Models.Domain;

namespace Walking_Tour_API.Infrastructure.Configuration
{
	public class DifficultyConfiguration : IEntityTypeConfiguration<Difficulty>
	{
		public void Configure(EntityTypeBuilder<Difficulty> builder)
		{
			builder.HasData(
				 new Difficulty()
				 {
					 Id = Guid.NewGuid(),
					 Name = "Easy"
				 },
				new Difficulty()
				{
					Id = Guid.NewGuid(),
					Name = "Medium"
				},
				new Difficulty()
				{
					Id = Guid.NewGuid(),
					Name = "Hard"
				}
				);
		}
	}
}
