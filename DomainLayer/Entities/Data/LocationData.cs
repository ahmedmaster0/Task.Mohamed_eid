using DomainLayer.Region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Data
{
    public class LocationData : BaseEntity
    {
        public int DataPersonsId { get; set; }
        public virtual DataPersons DataPersons { get; set; }

        public int RegionsId { get; set; }
        public virtual RegionsEntity Regions { get; set; }

        public string City { get; set; }
        public string AreaQuarter { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string DamageImage { get; set; }
        public string VehicleImage { get; set; }

        public int InsurranceId { get; set; }

    }
}
