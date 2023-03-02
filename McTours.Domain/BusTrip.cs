namespace McTours.Domain
{
    public class BusTrip
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
        public int DeppartureCityId { get; set; }
        public int ArrivalCityId { get; set; }
        public int EstimatedTravelTime { get; set; }
        public decimal TicketPrice { get; set; }
        public int? BreakTimeDuration { get; set; }
        public bool HasBreakTime => BreakTimeDuration != null; // BreakTimeDuration.HasValue;
        //NavProperties
        public City DeppartureCity { get; set; }
        public City ArrivalCity { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}
