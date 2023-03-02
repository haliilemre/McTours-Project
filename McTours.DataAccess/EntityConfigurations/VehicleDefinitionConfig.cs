using McTours.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McTours.DataAccess.EntityConfigurations
{
    internal class VehicleDefinitionConfig : IEntityTypeConfiguration<VehicleDefinition>
    {
        public void Configure(EntityTypeBuilder<VehicleDefinition> builder)
        {
            builder.ToTable(nameof(VehicleDefinition));
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Year).IsRequired().HasColumnType("smallint");
            builder.Property(v => v.SeatingType).IsRequired();
            builder.Property(v => v.LineCount).IsRequired().HasColumnType("smallint");
            builder.Property(v => v.FuelType).IsRequired();
            builder.Property(v => v.Utilities).IsRequired();

            builder.HasOne(model => model.VehicleModel)
                .WithMany(v => v.VehicleDefinitons)
                .HasForeignKey(v => v.VehicleModelId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new VehicleDefinition { Id = 1, VehicleModelId = 1, Year = 2009, SeatingType = SeatingType.Standard, LineCount = 10, FuelType = FuelType.Gasoline, Utilities = Utility.Wifi | Utility.FoodService | Utility.UsbCharge },
                new VehicleDefinition { Id = 2, VehicleModelId = 2, Year = 2019, SeatingType = SeatingType.Deluxe, LineCount = 10, FuelType = FuelType.Diesel, Utilities = Utility.Wifi | Utility.FoodService | Utility.UsbCharge | Utility.Headset | Utility.Toilet | Utility.Tv },
                new VehicleDefinition { Id = 3, VehicleModelId = 2, Year = 2012, SeatingType = SeatingType.Standard, LineCount = 10, FuelType = FuelType.Gasoline, Utilities = Utility.Wifi | Utility.FoodService | Utility.UsbCharge | Utility.Headset }
                );

            builder.Navigation(vd => vd.VehicleModel).AutoInclude();
        }
    }
}
