using MapsterMapper;
using Rentify.Model.RequestObjects;
using Rentify.Model.ResponseObjects;
using Rentify.Model.SearchObjects;
using Rentify.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentify.Services.Services
{
    public class PropertyService : BaseCRUDService<PropertyResponse, PropertySearchObject, Database.Property,PropertyInsertRequest, PropertyUpdateRequest>, IPropertyService
    {
        public PropertyService(RentifyDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
