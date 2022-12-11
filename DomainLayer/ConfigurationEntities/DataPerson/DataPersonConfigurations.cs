using DomainLayer.Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ConfigurationEntities
{
    public class DataPersonConfigurations : IEntityTypeConfiguration<DataPersons>
    {
        public void Configure(EntityTypeBuilder<DataPersons> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.BankTypesId).IsRequired();
            builder.Property(m => m.DamageDate).IsRequired();
            builder.Property(m => m.DamageTypeId).IsRequired();
            builder.Property(m => m.Iqama).IsRequired().HasMaxLength(10);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.PhoneNumber).IsRequired().HasMaxLength(12);
        }
    }
}
