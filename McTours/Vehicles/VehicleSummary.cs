namespace McTours.Vehicles
{
    public class VehicleSummary
    {
        public int Id { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string PlateNumber { get; set; }
        public short Year { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegistrationDateSummary
        {
            get
            {
                return $"{RegistrationDate.Day}/{RegistrationDate.Month}/{RegistrationDate.Year}";
            }
        }
        public string Name => string.Concat(PlateNumber, " ", MakeName, "/", ModelName);
    }
}
