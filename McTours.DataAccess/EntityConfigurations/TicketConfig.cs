using McTours.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McTours.DataAccess.EntityConfiguration
{
    internal class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable(nameof(Ticket));
            builder.HasKey(t => t.Id);
            builder.Property(t => t.BusTripId).IsRequired();
            builder.Property(t => t.PassengerId).IsRequired();
            builder.Property(t => t.SeatNumber).IsRequired();
            builder.Property(t => t.Price).IsRequired().HasColumnType("money");
            builder.HasOne(t => t.BusTrip)
                .WithMany(b => b.Tickets)
                .HasForeignKey(t => t.BusTripId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(t => t.Passenger)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.PassengerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(t => new
            {
                t.BusTripId,
                t.SeatNumber
            }).IsUnique();

            builder.HasData(
                new Ticket { Id = 1, PassengerId = 1, BusTripId = 1, SeatNumber = 1, Price = 180 },
                new Ticket { Id = 2, PassengerId = 2, BusTripId = 1, SeatNumber = 2, Price = 180 }
                );
        }
    }
}
