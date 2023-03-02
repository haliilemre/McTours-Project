using McTours.Business.Validators;
using McTours.BusTrips;
using McTours.DataAccess;
using McTours.Domain;
using System.Diagnostics;

namespace McTours.Business.Services
{
    public class BusTripService
    {
        private readonly McToursContext _context = new McToursContext();
        private readonly BusTripValidator _validator = new BusTripValidator();
        private static BusTrip MapToBusTrip(BusTripDto busTripDto)
        {
            BusTrip entity = null;
            if (busTripDto != null)
            {
                entity = new BusTrip()
                {
                    Id = busTripDto.Id,
                    VehicleId = busTripDto.VehicleId,
                    Date = busTripDto.Date,
                    DeppartureCityId = busTripDto.DeppartureCityId,
                    ArrivalCityId = busTripDto.ArrivalCityId,
                    EstimatedTravelTime = busTripDto.EstimatedTravelTime,
                    TicketPrice = busTripDto.TicketPrice,
                    BreakTimeDuration = busTripDto.BreakTimeDuration,
                };
            }
            return entity;
        }
        private static BusTripDto MapToBusTripDto(BusTrip busTrip)
        {
            BusTripDto dto = null;
            if (busTrip != null)
            {
                dto = new BusTripDto()
                {
                    Id = busTrip.Id,
                    VehicleId = busTrip.VehicleId,
                    Date = busTrip.Date,
                    DeppartureCityId = busTrip.DeppartureCityId,
                    ArrivalCityId = busTrip.ArrivalCityId,
                    EstimatedTravelTime = busTrip.EstimatedTravelTime,
                    TicketPrice = busTrip.TicketPrice,
                    BreakTimeDuration = busTrip.BreakTimeDuration
                };
            }
            return dto;
        }

        public IEnumerable<BusTripSummary> GetSummaries()
        {
            var busTrips = _context.BusTrips
                .Select(b => new BusTripSummary()
                {
                    Id = b.Id,
                    Name = string.Concat(b.DeppartureCity.Name, "-", b.ArrivalCity.Name, "-", b.Date),
                    VehicleName = string.Concat(b.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name, " ", b.Vehicle.VehicleDefinition.VehicleModel.Name, " - ", b.Vehicle.PlateNumber),
                    Date = b.Date,
                    DepartureCityName = b.DeppartureCity.Name,
                    ArrivalCityName = b.ArrivalCity.Name,
                    EstimatedDuration = b.EstimatedTravelTime,
                    TicketPrice = b.TicketPrice,
                    BreakTimeDuration = b.BreakTimeDuration,
                    BusSeatingType = b.Vehicle.VehicleDefinition.SeatingType

                }).ToList();
            return busTrips;
        }

        public BusTripSummary GetSummaryById(int id)
        {
            try
            {
                var busTrip = _context.BusTrips
                .Select(trip => new BusTripSummary()
                {
                    Id = trip.Id,
                    Name = string.Concat(trip.DeppartureCity.Name, "-", trip.ArrivalCity.Name),
                    VehicleName = string.Concat(trip.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name, " ", trip.Vehicle.VehicleDefinition.VehicleModel.Name, " - ", trip.Vehicle.PlateNumber),
                    Date = trip.Date,
                    DepartureCityName = trip.DeppartureCity.Name,
                    ArrivalCityName = trip.ArrivalCity.Name,
                    EstimatedDuration = trip.EstimatedTravelTime,
                    TicketPrice = trip.TicketPrice,
                    BreakTimeDuration = trip.BreakTimeDuration,
                    BusSeatingType = trip.Vehicle.VehicleDefinition.SeatingType,
                    BusTripSeatingLineCount = trip.Vehicle.VehicleDefinition.LineCount

                }).FirstOrDefault(trip => trip.Id == id);
                return busTrip;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }

        }

        public BusTripSeatsModel GetBusTripSeats(int id)
        {
            try
            {
                var busTripSeats = _context.BusTrips
                    .Select(busTrip => new BusTripSeatsModel()
                    {
                        BusTripId = busTrip.Id,
                        BusSeatingType = busTrip.Vehicle.VehicleDefinition.SeatingType,
                        BusSeatingLineCount = busTrip.Vehicle.VehicleDefinition.LineCount
                    })
                .FirstOrDefault(seats => seats.BusTripId == id);

                var soldTickets = _context.Tickets.Where(tic => tic.BusTripId == id).ToList();

                foreach (var soldTicket in soldTickets)
                {
                    busTripSeats.SoldSeatNumbers.Add(soldTicket.SeatNumber);
                }

                return busTripSeats;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }

        public BusTripDto GetById(int id)
        {
            try
            {
                var BusTripModel = _context.BusTrips.Find(id);
                if (BusTripModel != null)
                {
                    return MapToBusTripDto(BusTripModel);
                }
                else
                {
                    return default;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return default;
            }
        }
        public IEnumerable<BusTripDto> GetAll()
        {
            try
            {
                return _context.BusTrips.Select(MapToBusTripDto).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return new List<BusTripDto>();
            }
        }
        public CommandResult Create(BusTripDto busTripDto)
        {
            if (busTripDto == null)
            {
                throw new ArgumentNullException(nameof(busTripDto));
            }
            try
            {
                var busTripModel = MapToBusTrip(busTripDto);
                var validResult = _validator.Validate(busTripModel);
                if (validResult.HasErrors)
                {
                    return CommandResult.Failure(validResult.ErrorString);
                }
                _context.BusTrips.Add(busTripModel);
                _context.SaveChanges();
                return CommandResult.Success("Success!");
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat(DateTime.Now, ex));
                return CommandResult.Error("Fail", ex);
            }
        }
        public CommandResult Update(BusTripDto busTripDto)
        {
            if (busTripDto is null)
            {
                throw new ArgumentNullException(nameof(busTripDto));
            }
            try
            {
                var busTripModel = MapToBusTrip(busTripDto);
                var validationResult = _validator.Validate(busTripModel);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }
                _context.BusTrips.Update(busTripModel);
                _context.SaveChanges();
                return CommandResult.Success("Success!");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error("Fail!", ex);
            }
        }
        public CommandResult Delete(BusTripDto busTripDto)
        {
            try
            {
                var busTripModel = MapToBusTrip(busTripDto);
                _context.BusTrips.Remove(busTripModel);
                _context.SaveChanges();
                return CommandResult.Success("Success!");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error("Fail!", ex);
            }
        }
        public CommandResult Delete(int id)
        {
            return Delete(new BusTripDto() { Id = id });
        }
    }
}
