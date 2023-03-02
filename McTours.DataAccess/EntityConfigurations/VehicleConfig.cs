using McTours.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McTours.DataAccess.EntityConfigurations
{
    internal class VehicleConfig : IEntityTypeConfiguration<Vehicle>
    {
        private static readonly DateTime vehRegisterDate = new DateTime(2023, 2, 18);


        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable(nameof(Vehicle));

            builder.HasKey(v => v.Id);
            builder.Property(v => v.PlateNumber).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(v => v.RegistrationNumber).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(v => v.RegistrationDate).IsRequired().HasColumnType("date");

            builder.HasOne(vehicle => vehicle.VehicleDefinition)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(v => v.VehicleDefinitionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);




            builder.HasData(
                new Vehicle { Id = 1, VehicleDefinitionId = 1, PlateNumber = "34AST001", RegistrationNumber = "ATS3030121AK", RegistrationDate = vehRegisterDate },
                new Vehicle { Id = 2, VehicleDefinitionId = 2, PlateNumber = "34UK080", RegistrationNumber = "ATS3546781AK", RegistrationDate = vehRegisterDate },
                new Vehicle { Id = 3, VehicleDefinitionId = 3, PlateNumber = "34CRF19", RegistrationNumber = "ATS0000459AK", RegistrationDate = vehRegisterDate }
                 );

            builder.Navigation(veh => veh.VehicleDefinition).AutoInclude();


        }
    }
}
