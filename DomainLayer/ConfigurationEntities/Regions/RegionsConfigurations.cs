using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entities;
using DomainLayer.Region;

namespace DomainLayer.ConfigurationEntities.Regions
{
    public class RegionsConfigurations : IEntityTypeConfiguration<RegionsEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RegionsEntity> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
