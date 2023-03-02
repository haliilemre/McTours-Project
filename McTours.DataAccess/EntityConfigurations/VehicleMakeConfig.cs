using McTours.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.DataAccess.EntityConfigurations
{
    internal class VehicleMakeConfig : IEntityTypeConfiguration<VehicleMake>
    {
        public void Configure(EntityTypeBuilder<VehicleMake> builder)
        {
            builder.ToTable("VehicleMake");
            builder.HasKey(vm => vm.Id);
            builder.Property(vm => vm.Name).IsRequired().HasColumnType("varchar(50)");

            builder.HasData(
                new VehicleMake() { Id = 1, Name = "Mercedes-Benz" },
                new VehicleMake() { Id = 2, Name = "MAN" },
                new VehicleMake() { Id = 3, Name = "Isuzu" },
                new VehicleMake() { Id = 4, Name = "Otokar" },
                new VehicleMake() { Id = 5, Name = "BMC" },
                new VehicleMake() { Id = 6, Name = "Iveco" }
            );
        }
    }
}
