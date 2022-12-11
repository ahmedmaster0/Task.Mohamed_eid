using DomainLayer.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IData
{
    public class LocationDataRepository : Repository<LocationData> , ILocationData
    {
        public LocationDataRepository(ApplicationContext context):base(context)
        {

        }
    }
}
