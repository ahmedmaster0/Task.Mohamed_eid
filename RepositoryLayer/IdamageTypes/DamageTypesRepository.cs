using DomainLayer.DamageTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IdamageTypes
{
    public class DamageTypesRepository : Repository<DamageType> , RepositoryLayer.IDamageTypes.IDamageTypes
    {
        public DamageTypesRepository(ApplicationContext context):base(context)
        {

        }
    }
}
