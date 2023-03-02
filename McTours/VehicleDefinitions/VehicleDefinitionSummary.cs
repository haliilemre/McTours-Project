namespace McTours.VehicleDefinitions
{
    public class VehicleDefinitionSummary
    {
        public int Id { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
        public short Year { get; set; }
        public FuelType FuelType { get; set; }
        public string FuelTypeName
        {
            get
            {
                return EnumHelper.FuelNames[FuelType];
            }
        }
        public SeatingType SeatingType { get; set; }
        public string SeatingTypeName
        {
            get
            {
                return EnumHelper.SeatingTypeNames[SeatingType];
            }
        }

        public Utility Utilities { get; set; }
        public string UtilityNames => Utilities.GetNames();

        public short LineCount { get; set; }
    }
}
