namespace McTours.VehicleDefinitions
{
    public class VehicleDefinitionDto
    {
        public VehicleDefinitionDto()
        {
            Utilities = new HashSet<Utility>(); // Interface'lerin instance'ı alınamaz. 
        }

        public int Id { get; set; }

        public int VehicleModelId { get; set; }
        public int VehicleMakeId { get; set; }
        public short Year { get; set; }
        public SeatingType SeatingType { get; set; }
        public short LineCount { get; set; }
        public FuelType FuelType { get; set; }
        public ICollection<Utility> Utilities { get; set; }
    }
}
