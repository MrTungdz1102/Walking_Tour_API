using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking_Tour_API.Core.Interface
{
	public interface IGenericRepository<T> where T : class
	{
		//	Task<bool> CreateAsync<TMapper>(TMapper mapper);
		//	Task<TMapper> GetAsync<TMapper>(Guid id);
		//	Task<List<TMapper>> GetAllAsync<TMapper>();
		// delete khong can T do khong can tra ve du lieu khi xoa
		// nen update va delete theo id, khong nen theo entity
		//	Task<bool> DeleteAsync(Guid id);
		//	Task<T> UpdateAsync<TMapper>(Guid id, TMapper mapper) where TMapper : IBaseDTO;


		Task<T> FindAsync(Guid id);
		Task<T> CreateAsync(T entity);
		Task<T> Delete(Guid id);
		Task<List<T>> GetAllAsync();
		Task<T> UpdateAsync(Guid id);
	}
}
