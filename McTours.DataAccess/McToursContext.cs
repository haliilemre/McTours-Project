using McTours.DataAccess.EntityConfiguration;
using McTours.DataAccess.EntityConfigurations;
using McTours.Domain;
using Microsoft.EntityFrameworkCore;

namespace McTours.DataAccess
{
    public class McToursContext : DbContext
    {
        private const string _connectionString = "Server=.; Database=McTours; Integrated Security= true;";

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleDefinition> VehicleDefinitions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<BusTrip> BusTrips { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new VehicleMakeConfig());
            modelBuilder.ApplyConfiguration(new VehicleModelConfig());
            modelBuilder.ApplyConfiguration(new VehicleDefinitionConfig());
            modelBuilder.ApplyConfiguration(new VehicleConfig());
            modelBuilder.ApplyConfiguration(new CityConfig());
            modelBuilder.ApplyConfiguration(new BusTripConfig());
            modelBuilder.ApplyConfiguration(new PassengerConfig());
            modelBuilder.ApplyConfiguration(new TicketConfig());
        }
    }
}
