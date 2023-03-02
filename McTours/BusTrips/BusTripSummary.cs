using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.BusTrips
{
    public class BusTripSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int EstimatedDuration { get; set; }
        public decimal TicketPrice { get; set; }
        public string VehicleName { get; set; }
        public string DepartureCityName { get; set; }
        public string ArrivalCityName { get; set; }
        public SeatingType BusSeatingType { get; set; } 
        public int? BreakTimeDuration { get; set; }
        public short BusTripSeatingLineCount { get; set; }

    }
}
