using DomainLayer.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DamageTypes
{
    public class DamageType : BaseEntity
    {
        public DamageType()
        {
            DataPersons = new List<DataPersons>();
        }

        public virtual ICollection<DataPersons>  DataPersons { get; set; }
    }
}
