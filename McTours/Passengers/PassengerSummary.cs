namespace McTours.Passengers
{
    public class PassengerSummary
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TicketCount { get; set; }
        public string FullName
        {
            get
            {
                return string.Concat(FirstName, " ", LastName);
            }
        }
        public string IdentityNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}
