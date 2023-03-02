using McTours.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McTours.DataAccess.EntityConfiguration
{
    internal class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(nameof(City));
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(20);

            builder.HasData(
                new City { Id = 1, Name = "İstanbul" },
                new City { Id = 2, Name = "Bursa" },
                new City { Id = 3, Name = "Ankara" },
                new City { Id = 4, Name = "İzmir" },
                new City { Id = 5, Name = "Antalya" },
                new City { Id = 6, Name = "Trabzon" }
                 );
        }
    }
}
