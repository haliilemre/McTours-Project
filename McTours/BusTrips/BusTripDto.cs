using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.BusTrips
{
    public class BusTripDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
        public int DeppartureCityId { get; set; }
        public int ArrivalCityId { get; set; }
        public int EstimatedTravelTime { get; set; }
        public decimal TicketPrice { get; set; }
        public int? BreakTimeDuration { get; set; }
        public bool HasBreakTime => BreakTimeDuration != null;
    }
}
