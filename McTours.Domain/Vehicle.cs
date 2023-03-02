namespace McTours.Domain
{
    public class Vehicle
    {
        public Vehicle()
        {
            BusTrips = new List<BusTrip>();
        }

        public int Id { get; set; }
        public string Name
        {
            get
            {
                return string.Concat(
                    VehicleDefinition.VehicleModel.VehicleMake.Name,
                    " ",
                    VehicleDefinition.VehicleModel.Name,
                    " - ",
                    PlateNumber);
            }
        }
        public int VehicleDefinitionId { get; set; }
        public string PlateNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime RegistrationDate { get; set; }

        // Navigation Property
        public VehicleDefinition VehicleDefinition { get; set; }
        public ICollection<BusTrip> BusTrips { get; }
    }
}
