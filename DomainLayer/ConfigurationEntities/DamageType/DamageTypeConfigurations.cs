using DomainLayer.DamageTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ConfigurationEntities
{
    public class DamageTypeConfigurations : IEntityTypeConfiguration<DamageType>
    {
        public void Configure(EntityTypeBuilder<DamageType> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name)
                .IsRequired().HasMaxLength(50);
        }
    }
}
