using DomainLayer.BankTypes;
using DomainLayer.ConfigurationEntities;
using DomainLayer.ConfigurationEntities.BankTypes;
using DomainLayer.ConfigurationEntities.DataLocation;
using DomainLayer.ConfigurationEntities.Regions;
using DomainLayer.DamageTypes;
using DomainLayer.Entities.Data;
using DomainLayer.Region;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new BankTypesConfigurations().Configure(modelBuilder.Entity<BankType>());
            new DamageTypeConfigurations().Configure(modelBuilder.Entity<DamageType>());
            new RegionsConfigurations().Configure(modelBuilder.Entity<RegionsEntity>());
            new DataLocationConfigurations().Configure(modelBuilder.Entity<LocationData>());
            new DataPersonConfigurations().Configure(modelBuilder.Entity<DataPersons>());

            modelBuilder.Entity<DamageType>().HasData(
                    new DamageType { Id = 1,Name = "مركبة"},
                    new DamageType { Id = 2,Name = "افراد"},
                    new DamageType { Id = 3,Name = "اخري"}
                );

            modelBuilder.Entity<BankType>().HasData(
                    new BankType { Id = 1, Name = "البنك الاهلي السعودي", IBAN = "SA3456789456123456789123"},
                    new BankType { Id = 2, Name = "بنك الرياض", IBAN = "SA3456789456123456789188"}
                );

            modelBuilder.Entity<RegionsEntity>().HasData(
                    new RegionsEntity { Id = 1,Name="مكه المكرمة"},
                    new RegionsEntity { Id = 2,Name="المدينة المنوره"}
                );
        }
    }
}
