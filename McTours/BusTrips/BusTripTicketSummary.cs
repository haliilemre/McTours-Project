namespace McTours.BusTrips
{
    public class BusTripTicketSummary
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public DateTime Date { get; set; }
        public string VehicleName { get; set; }
        public SeatingType BusSeatingType { get; set; }
        public int BusSeatingLineCount { get; set; }
        public decimal TicketPrice { get; set; }
    }
}
