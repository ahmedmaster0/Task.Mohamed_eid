using DomainLayer.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IData
{
    public class PersonDataRepository : Repository<DataPersons> , IPersonData
    {
        public PersonDataRepository(ApplicationContext context):base(context)
        {

        }
    }
}
