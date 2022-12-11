using DomainLayer.Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ConfigurationEntities.DataLocation
{
    public class DataLocationConfigurations : IEntityTypeConfiguration<LocationData>
    {
        public void Configure(EntityTypeBuilder<LocationData> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.AreaQuarter).HasMaxLength(50);
            builder.Property(m => m.City).HasMaxLength(50);
            builder.Property(m => m.DataPersonsId).IsRequired();
            builder.Property(m => m.PostalCode).HasMaxLength(5);
            builder.Property(m => m.RegionsId).IsRequired();
            builder.Property(m => m.Street).HasMaxLength(50);
        }
    }
}
