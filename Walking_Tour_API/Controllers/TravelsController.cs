using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Walking_Tour_API.Core.Interface;
using Walking_Tour_API.Core.Models.Domain;
using Walking_Tour_API.Core.Models.DTO.Region;
using Walking_Tour_API.Core.Models.DTO.Travel;
using Walking_Tour_API.Infrastructure.CustomActionFilter;

namespace Walking_Tour_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TravelsController : ControllerBase
	{
		private readonly IUnitOfWork _unit;
		private readonly IMapper _mapper;
		public TravelsController(IUnitOfWork unit, IMapper mapper)
		{
			_unit = unit;
			_mapper = mapper;
		}
		[HttpGet("{id:Guid}")]
		public async Task<IActionResult> GetTravelById([FromRoute] Guid id)
		{
			//	var result = await _unit.Travel.FindAsync(id);
			var result = await _unit.Travel.GetDetail(id);
			var travel = _mapper.Map<DetailTravelDTO>(result);
			return Ok(travel);
		}

		[HttpGet]
		[EnableQuery]
		public async Task<IActionResult> GetAllTravel([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
		{
			var travels = await _unit.Travel.GetAllAsync(pageNumber, pageSize, orderBy: r => r.Name);
			var result = _mapper.Map<List<GetTravelDTO>>(travels);
			return Ok(result);
		}

		[HttpPost]
		[ValidateModel]
		public async Task<IActionResult> CreateTravel([FromBody] AddTravelDTO addTravelDTO)
		{
			var travel = _mapper.Map<Travel>(addTravelDTO);
			await _unit.Travel.CreateAsync(travel);
			await _unit.SaveAsync();
			var result = _mapper.Map<GetTravelDTO>(travel);
			return CreatedAtAction(nameof(GetTravelById), new { id = result.Id }, result);
		}

		[HttpPut("{id:Guid}")]
		[ValidateModel]
		public async Task<IActionResult> EditTravel([FromRoute] Guid id, [FromBody] UpdateTravelDTO updateTravelDTO)
		{
			var travel = await _unit.Travel.FindAsync(id);
			_mapper.Map(updateTravelDTO, travel);
			await _unit.Travel.UpdateAsync(travel.Id);
			await _unit.SaveAsync();
			var result = _mapper.Map<GetTravelDTO>(travel);
			return CreatedAtAction(nameof(GetTravelById), new { id = result.Id }, result);
		}

		[HttpDelete("{id:Guid}")]
		public async Task<IActionResult> DeleteTravel([FromRoute] Guid id)
		{
			var travel = await _unit.Travel.Delete(id);
			await _unit.SaveAsync();
			return Ok(_mapper.Map<GetTravelDTO>(travel));
		}
	}
}
