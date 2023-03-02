namespace McTours.Domain
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VehicleMakeId { get; set; }

        // Navigation Property
        public VehicleMake VehicleMake { get; set; }
        public ICollection<VehicleDefinition> VehicleDefinitons { get; set; }
    }
}
