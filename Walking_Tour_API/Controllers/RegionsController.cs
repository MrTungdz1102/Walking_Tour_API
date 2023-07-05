using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using Walking_Tour_API.Core.Interface;
using Walking_Tour_API.Core.Models.Domain;
using Walking_Tour_API.Core.Models.DTO.Region;
using Walking_Tour_API.Infrastructure.Context;

namespace Walking_Tour_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegionsController : ControllerBase
	{
		private readonly IUnitOfWork _unit;
		private readonly IMapper _mapper;
		public RegionsController(IUnitOfWork unit, IMapper mapper)
		{
			_unit = unit;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllRegions()
		{
			// Get Data From Database - Domain models
			var regions = await _unit.Region.GetAllAsync();
			// map domain models to DTOs
			var result = _mapper.Map<List<GetRegionDTO>>(regions);
			return Ok(result);
		}

		[HttpGet("{id:Guid}")]
		public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
		{
			var region = await _unit.Region.FindAsync(id);
			var result = _mapper.Map<GetRegionDTO>(region);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> CreateRegion([FromBody] AddRegionDTO addRegionDTO)
		{
			var region = _mapper.Map<Region>(addRegionDTO);
			await _unit.Region.CreateAsync(region);
			await _unit.SaveAsync();
			// neu DTO giong voi domain model thi khong can map tro lai
			var result = _mapper.Map<GetRegionDTO>(region);
			return CreatedAtAction(nameof(GetRegionById), new { id = result.Id }, result);
		}
		
		[HttpPut("{id:Guid}")]
		public async Task<IActionResult> EditRegion([FromRoute] Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
		{
			var region = await _unit.Region.FindAsync(id);
			_mapper.Map(updateRegionDTO, region);
			await _unit.Region.UpdateAsync(region.Id);
			await _unit.SaveAsync();
			return Ok(_mapper.Map<GetRegionDTO>(region));
		}

		[HttpDelete("{id:Guid}")]
		public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
		{
			var region = await _unit.Region.Delete(id);
			await _unit.SaveAsync();
			return Ok(_mapper.Map<GetRegionDTO>(region));
		}
	}
}
