namespace McTours.Domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public int BusTripId { get; set; }
        public int PassengerId { get; set; }
        public short SeatNumber { get; set; }
        public decimal Price { get; set; }
        //Nav Props
        public BusTrip BusTrip { get; set; }
        public Passenger Passenger { get; set; }
    }
}
