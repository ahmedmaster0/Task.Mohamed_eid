using RepositoryLayer.IbankTypes;
using RepositoryLayer.IBankTypes;
using RepositoryLayer.IdamageTypes;
using RepositoryLayer.IData;
using RepositoryLayer.Iregion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.unitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext context;
        public UnitOfWork(ApplicationContext _context)
        {
            context = _context;
        }
        public IBankType bankType => new BankTypeRepository(context);

        public IDamageTypes.IDamageTypes damageTypes => new DamageTypesRepository(context);

        public IRegions regions => new RegionRepository(context);

        public IPersonData personData => new PersonDataRepository(context);

        public ILocationData locationData => new LocationDataRepository(context);

        public bool SaveData()
        {
            return context.SaveChanges() > 0 ? true : false;
        }
    }
}
