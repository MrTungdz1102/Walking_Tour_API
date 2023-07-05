using Microsoft.EntityFrameworkCore;
using Walking_Tour_API.Core.Interface;
using Walking_Tour_API.Infrastructure.Context;
using Walking_Tour_API.Infrastructure.Exception;

namespace Walking_Tour_API.Infrastructure.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly TourAPIDbContext _context;
		internal DbSet<T> _dbSet;
		//	private readonly IMapper _mapper;
		public GenericRepository(TourAPIDbContext context)
		{
			_context = context;
			//	_mapper = mapper;
			_dbSet = _context.Set<T>();
		}

		//public async Task<bool> CreateAsync<TMapper>(TMapper mapper)
		//{
		//	var entity = _mapper.Map<T>(mapper);
		//	await _dbSet.AddAsync(entity);
		//	return true;
		//}

		//public async Task<TMapper> GetAsync<TMapper>(Guid id)
		//{
		//	var result = await _dbSet.FindAsync(id);

		//	if (result is null)
		//	{
		//		throw new NotFoundException(typeof(T).Name, "Not Found With Key Provided");
		//	}
		//	return _mapper.Map<TMapper>(result);
		//}

		//public async Task<List<TMapper>> GetAllAsync<TMapper>()
		//{
		//	var result = await _dbSet.ToListAsync();
		//	return _mapper.Map<List<TMapper>>(result);
		//}

		//public async Task<bool> DeleteAsync(Guid id)
		//{
		//	var result = await FindAsync(id);
		//	if (result is null)
		//	{
		//		throw new NotFoundException(typeof(T).Name, "Not Found With Key Provided");
		//	}
		//	_dbSet.Remove(result);
		//	return true;
		//}

		//public async Task<T> UpdateAsync<TMapper>(Guid id, TMapper mapper) where TMapper : IBaseDTO
		//{
		//	if (id != mapper.Id)
		//	{
		//		throw new BadRequestException("Invalid Id used in request");
		//	}
		//	var entity = await FindAsync(id);
		//	if (entity is null)
		//	{
		//		throw new NotFoundException(typeof(T).Name, "Not Found With Key Provided");
		//	}
		//	_mapper.Map(mapper, entity);
		//	var result = _mapper.Map<T>(entity);
		//	_dbSet.Update(result);
		//	return result;
		//}

		public async Task<T> FindAsync(Guid id)
		{
			var result = await _dbSet.FindAsync(id);
			if (result is null)
			{
				throw new NotFoundException(typeof(T).Name, "Not Found With Key Provided");
			}
			return result;
		}


		public async Task<T> CreateAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
			return entity;
		}
		public async Task<T> Delete(Guid id)
		{
			var result = await _dbSet.FindAsync(id);

			if (result is null)
			{
				throw new NotFoundException(typeof(T).Name, "Not Found With Key Provided");
			}
			_dbSet.Remove(result);
			return result;
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<T> UpdateAsync(Guid id)
		{
			var result = await _dbSet.FindAsync(id);

			if (result is null)
			{
				throw new NotFoundException(typeof(T).Name, "Not Found With Key Provided");
			}
			_dbSet.Update(result);
			return result;
		}
	}
}
