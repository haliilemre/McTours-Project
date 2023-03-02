using System.Collections;

namespace McTours.Domain
{
    public class Passenger
    {
        public Passenger()
        {
            Tickets = new List<Ticket>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        //Nav Prop
        public ICollection<Ticket> Tickets { get; }
    }
}
