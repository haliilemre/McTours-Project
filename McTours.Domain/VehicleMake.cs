namespace McTours.Domain
{
    public class VehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<VehicleModel> VehicleModels { get; set; }
    }
}
