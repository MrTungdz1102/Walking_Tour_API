using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walking_Tour_API.Core.Models.Domain;
using Walking_Tour_API.Core.Models.DTO.Region;

namespace Walking_Tour_API.Core.Interface.Services
{
    public interface IRegionService : IGenericService<Region, GetRegionDTO, AddRegionDTO, UpdateRegionDTO>
    {
    }
}
