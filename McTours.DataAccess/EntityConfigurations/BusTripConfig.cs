using McTours.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.DataAccess.EntityConfiguration
{
    internal class BusTripConfig : IEntityTypeConfiguration<BusTrip>
    {
        private static readonly DateTime tripDate01 = new DateTime(2023, 3, 15, 12, 00, 00);
        private static readonly DateTime tripDate02 = new DateTime(2023, 3, 16, 13, 00, 00);
        private static readonly DateTime tripDate03 = new DateTime(2023, 3, 17, 14, 00, 00);
        private static readonly DateTime tripDate04 = new DateTime(2023, 3, 18, 08, 00, 00);

        public void Configure(EntityTypeBuilder<BusTrip> builder)
        {
            builder.ToTable(nameof(BusTrip));
            builder.Property(b => b.Date).IsRequired().HasColumnType("datetime2(0)");
            builder.Property(b => b.TicketPrice).HasColumnType("money");
            builder.HasOne(b => b.Vehicle)
                .WithMany(b => b.BusTrips)
                .HasForeignKey(b => b.VehicleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(b => b.ArrivalCity)
                .WithMany()
                .HasForeignKey(b => b.ArrivalCityId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(b => b.DeppartureCity)
                .WithMany()
                .HasForeignKey(b => b.DeppartureCityId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new BusTrip { Id = 1, VehicleId = 1, Date = tripDate01, DeppartureCityId = 1, ArrivalCityId = 2, EstimatedTravelTime = 180, TicketPrice = 150, BreakTimeDuration = 30 },
                new BusTrip { Id = 2, VehicleId = 2, Date = tripDate02, DeppartureCityId = 3, ArrivalCityId = 1, EstimatedTravelTime = 360, TicketPrice = 200, BreakTimeDuration = 60 },
                new BusTrip { Id = 3, VehicleId = 3, Date = tripDate03, DeppartureCityId = 1, ArrivalCityId = 5, EstimatedTravelTime = 720, TicketPrice = 330, BreakTimeDuration = 90 },
                new BusTrip { Id = 4, VehicleId = 3, Date = tripDate04, DeppartureCityId = 5, ArrivalCityId = 1, EstimatedTravelTime = 720, TicketPrice = 330, BreakTimeDuration = 90 }
                );


        }
    }
}
