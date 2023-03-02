using McTours.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McTours.DataAccess.EntityConfigurations
{
    internal class VehicleModelConfig : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.ToTable("VehicleModel");
            builder.HasKey(vmo => vmo.Id);
            builder.Property(vmo => vmo.Name).IsRequired().HasColumnType("nvarchar(50)");

            builder.HasOne(vmo => vmo.VehicleMake)
                .WithMany(vmo => vmo.VehicleModels)
                .HasForeignKey(vmo => vmo.VehicleMakeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new VehicleModel { Id = 1, Name = "Travego", VehicleMakeId = 1 },
                new VehicleModel { Id = 2, Name = "Tourismo", VehicleMakeId = 1 },
                new VehicleModel { Id = 3, Name = "Fortuna", VehicleMakeId = 2 },
                new VehicleModel { Id = 4, Name = "Lions", VehicleMakeId = 2 },
                new VehicleModel { Id = 5, Name = "Novociti", VehicleMakeId = 3 },
                new VehicleModel { Id = 6, Name = "Citibus", VehicleMakeId = 3 },
                new VehicleModel { Id = 7, Name = "Doruk", VehicleMakeId = 4 },
                new VehicleModel { Id = 8, Name = "Kent", VehicleMakeId = 4 },
                new VehicleModel { Id = 9, Name = "ProCity", VehicleMakeId = 5 },
                new VehicleModel { Id = 10, Name = "Belde", VehicleMakeId = 5 },
                new VehicleModel { Id = 11, Name = "M50", VehicleMakeId = 6 }
                );

            builder.Navigation(model => model.VehicleMake).AutoInclude();
        }
    }
}
