using DomainLayer.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Region
{
    public class RegionsEntity : BaseEntity
    {
        public RegionsEntity()
        {
            LocationDatas = new List<LocationData>();
        }

        public virtual ICollection<LocationData> LocationDatas { get; set; }
    }
}
