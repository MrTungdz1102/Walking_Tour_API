using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Walking_Tour_API.Core.Interface;
using Walking_Tour_API.Core.Interface.Repositories;
using Walking_Tour_API.Core.Interface.Services;

namespace Walking_Tour_API.Core.Services
{
    public class GenericService<TEntity, GetDTO, CreateDTO, UpdateDTO> : IGenericService<TEntity, GetDTO, CreateDTO, UpdateDTO> where TEntity : class 
	{
		private readonly IMapper _mapper;
		private readonly IGenericRepository<TEntity> _repository;
		private readonly IUnitOfWork _unit;
		public GenericService(IMapper mapper, IGenericRepository<TEntity> repository, IUnitOfWork unit)
		{
			_mapper = mapper;
			_repository = repository;
			_unit = unit;
		}

		public async Task<GetDTO> CreateAsync(CreateDTO dto)
		{
			var repo = _mapper.Map<TEntity>(dto);
			await _repository.CreateAsync(repo);
			await _unit.SaveAsync();
			return _mapper.Map<GetDTO>(repo);
		}

		public Task<GetDTO> Delete(Guid id)
		{
			// on progess
			throw new NotImplementedException();
		}

		public Task<GetDTO> FindAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<List<GetDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 10, Expression<Func<TEntity, object>> orderBy = null)
		{
			throw new NotImplementedException();
		}

		public Task<GetDTO> UpdateAsync(UpdateDTO updateDTO)
		{
			throw new NotImplementedException();
		}
	}
}
