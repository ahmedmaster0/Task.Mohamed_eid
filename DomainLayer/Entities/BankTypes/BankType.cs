using DomainLayer.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.BankTypes
{
    public class BankType : BaseEntity
    {
        public BankType()
        {
            dataPersons = new List<DataPersons>();
        }

        public virtual ICollection<DataPersons>  dataPersons { get;}
        public string IBAN { get; set; }
    }
}
