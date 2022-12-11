using DomainLayer.BankTypes;
using DomainLayer.DamageTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Data
{
    public class DataPersons : BaseEntity
    {
        public string Iqama { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime? DamageDate { get; set; }


        public int BankTypesId { get; set; }
        public virtual BankType BankTypes { get; set; }

        public int DamageTypeId { get; set; }
        public virtual DamageType  DamageType { get; set; }


    }
}
