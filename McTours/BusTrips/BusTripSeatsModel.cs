namespace McTours.BusTrips
{
    public class BusTripSeatsModel
    {
        public BusTripSeatsModel()
        {
            SoldSeatNumbers = new List<int>();
        }

        public int BusTripId { get; set; }
        public SeatingType BusSeatingType { get; set; }
        public int BusSeatingLineCount { get; set; }
        public ICollection<int> SoldSeatNumbers { get; }
    }
}
