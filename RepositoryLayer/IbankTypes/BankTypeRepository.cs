using DomainLayer.BankTypes;
using RepositoryLayer.IBankTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IbankTypes
{
    public class BankTypeRepository : Repository<BankType> , IBankType
    {
        public BankTypeRepository(ApplicationContext context):base(context)
        {
        }
    }
}
