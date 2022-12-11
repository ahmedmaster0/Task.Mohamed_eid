using RepositoryLayer.IBankTypes;
using RepositoryLayer.IData;
using RepositoryLayer.Iregion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IUnitOfWork
    {
        public IBankType bankType { get;}
        public IDamageTypes.IDamageTypes damageTypes { get;}
        public IRegions regions  { get;}
        public IPersonData personData  { get;}
        public ILocationData locationData  { get;}

        bool SaveData();

    }
}
