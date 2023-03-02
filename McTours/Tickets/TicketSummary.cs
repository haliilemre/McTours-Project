using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Tickets
{
    public class TicketSummary
    {
        public int Id { get; set; }
        public string VehicleName { get; set; }
        public DateTime TicketDate { get; set; }
        public int EstimatedTravelTime { get; set; }
        public string DepartureCityName { get; set; }
        public string ArrivalCityName { get; set; }
        public string PassengerFullName { get; set; }
        public Gender PassengerGender { get; set; }
        public string IdentityNumber { get; set; }
        public SeatingType SeatingType { get; set; }
        public short SeatNumber { get; set; }
        public int? BreakTimeDuration { get; set; }
        public decimal Price { get; set; }
    }
}
