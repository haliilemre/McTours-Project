namespace McTours.Vehicles
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public int VehicleDefinitionId { get; set; }
        public string PlateNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
