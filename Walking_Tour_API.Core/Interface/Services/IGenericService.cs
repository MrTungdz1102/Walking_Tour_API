using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Walking_Tour_API.Core.Interface.Services
{
    public interface IGenericService<TEntity, GetDTO, CreateDTO, UpdateDTO> where TEntity : class 
    {
        Task<GetDTO> FindAsync(Guid id);
        Task<GetDTO> CreateAsync(CreateDTO dto);
        Task<GetDTO> Delete(Guid id);
        Task<List<GetDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 10, Expression<Func<TEntity, object>> orderBy = null);
        Task<GetDTO> UpdateAsync(UpdateDTO updateDTO);
    }
}
