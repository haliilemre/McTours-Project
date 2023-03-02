namespace McTours.Domain
{
    public class VehicleDefinition
    {
        public int Id { get; set; }
        public int VehicleModelId { get; set; }
        public short Year { get; set; }
        public SeatingType SeatingType { get; set; }
        public short LineCount { get; set; }
        public FuelType FuelType { get; set; }
        public Utility Utilities { get; set; }

        // Navigation Property
        public VehicleModel VehicleModel { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
