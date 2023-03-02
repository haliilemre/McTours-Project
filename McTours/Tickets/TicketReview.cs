namespace McTours.Tickets
{
    public class TicketReview
    {
        public int BusTripId { get; set; }
        public int PassengerId { get; set;}
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public string PassengerFirstName { get; set; }
        public string PassengerLastName { get; set; }
    }
}
