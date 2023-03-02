using McTours.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McTours.DataAccess.EntityConfiguration
{
    internal class PassengerConfig : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable(nameof(Passenger));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).IsRequired().IsUnicode().HasMaxLength(20);
            builder.Property(p => p.LastName).IsRequired().IsUnicode().HasMaxLength(20);
            builder.Property(p => p.IdentityNumber).IsUnicode(false).IsRequired().HasMaxLength(13);
            builder.Property(p => p.Gender).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired(false).HasColumnType("date");

            builder.HasIndex(p => p.IdentityNumber).IsUnique();


            builder.HasData(
                new Passenger { Id = 1, FirstName = "Tsubasa", LastName = "Ozora", IdentityNumber = "12345678910", Gender = Gender.Male, BirthDate = new DateTime(1982, 7, 26) },
                new Passenger { Id = 2, FirstName = "Sanae", LastName = "Ozora", IdentityNumber = "12345678550", Gender = Gender.Female, BirthDate = new DateTime(1982, 4, 11) },
                new Passenger { Id = 3, FirstName = "Kojiro", LastName = "Hyuga", IdentityNumber = "23456789101", Gender = Gender.Male, BirthDate = new DateTime(1982, 8, 17) },
                new Passenger { Id = 4, FirstName = "Genzo", LastName = "Wakabayashi", IdentityNumber = "34567891012", Gender = Gender.Male, BirthDate = new DateTime(1982, 11, 7) },
                new Passenger { Id = 5, FirstName = "Taro", LastName = "Misaki", IdentityNumber = "45678910123", Gender = Gender.Male, BirthDate = new DateTime(1982, 5, 5) },
                new Passenger { Id = 6, FirstName = "Ken", LastName = "Wakashimazu", IdentityNumber = "56789101234", Gender = Gender.Male, BirthDate = new DateTime(1982, 11, 29) }
                );
        }
    }
}
