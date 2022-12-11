using DomainLayer.BankTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ConfigurationEntities.BankTypes
{
    public class BankTypesConfigurations : IEntityTypeConfiguration<BankType>
    {
        public void Configure(EntityTypeBuilder<BankType> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.IBAN)
                .IsRequired()
                .HasMaxLength(24);

            builder.HasIndex(m => m.IBAN).IsUnique(true);


        }
    }
}
