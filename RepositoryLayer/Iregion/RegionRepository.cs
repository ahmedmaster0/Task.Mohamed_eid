using DomainLayer.Region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Iregion
{
    public class RegionRepository : Repository<RegionsEntity> , IRegions
    {
        public RegionRepository(ApplicationContext context):base(context)
        {

        }
    }
}
