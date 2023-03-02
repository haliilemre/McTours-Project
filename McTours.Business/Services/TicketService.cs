using System.Diagnostics;
using McTours.Business.Validators;
using McTours.DataAccess;
using McTours.Domain;
using McTours.Tickets;

namespace McTours.Business.Services
{
    public class TicketService
    {
        private readonly McToursContext _context = new McToursContext();
        private readonly TicketValidator _validator = new TicketValidator();
        private static Ticket MapToTicket(TicketDto Dto)
        {
            Ticket entity = null;
            if (Dto != null)
            {
                entity = new Ticket()
                {
                    Id = Dto.Id,
                    BusTripId = Dto.BusTripId,
                    PassengerId = Dto.PassengerId,
                    Price = Dto.Price,
                    SeatNumber = Dto.SeatNumber
                };
            }
            return entity;
        }
        private static TicketDto MapToTicketDto(Ticket ticket)
        {
            TicketDto dto = null;
            if (ticket != null)
            {
                dto = new TicketDto()
                {
                    Id = ticket.Id,
                    PassengerId = ticket.PassengerId,
                    Price = ticket.Price,
                    SeatNumber = ticket.SeatNumber,
                    BusTripId = ticket.BusTripId
                };
            }
            return dto;
        }

        public IEnumerable<TicketSummary> GetSummaries()
        {
            var tickets = _context.Tickets
                .Select(t => new TicketSummary()
                {
                    Id = t.Id,
                    VehicleName = string.Concat(t.BusTrip.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name, " ", t.BusTrip.Vehicle.VehicleDefinition.VehicleModel.Name, " - ", t.BusTrip.Vehicle.PlateNumber),
                    TicketDate = t.BusTrip.Date,
                    EstimatedTravelTime = t.BusTrip.EstimatedTravelTime,
                    DepartureCityName = t.BusTrip.DeppartureCity.Name,
                    ArrivalCityName = t.BusTrip.ArrivalCity.Name,
                    PassengerFullName = string.Concat(t.BusTrip.DeppartureCity.Name, "-", t.BusTrip.ArrivalCity.Name),
                    IdentityNumber = t.Passenger.IdentityNumber,
                    SeatingType = t.BusTrip.Vehicle.VehicleDefinition.SeatingType,
                    SeatNumber = t.SeatNumber,
                    BreakTimeDuration = t.BusTrip.BreakTimeDuration,
                    Price = t.Price,
                    PassengerGender = t.Passenger.Gender,
                }).ToList();
            return tickets;
        }
        public TicketDto GetById(int id)
        {
            try
            {
                var TicketModel = _context.Tickets.Find(id);
                if (TicketModel != null)
                {
                    return MapToTicketDto(TicketModel);
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
        public IEnumerable<TicketDto> GetAll()
        {
            try
            {
                return _context.Tickets.Select(MapToTicketDto).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return new List<TicketDto>();
            }
        }
        public CommandResult Create(TicketDto ticketDto)
        {
            if (ticketDto == null)
            {
                throw new ArgumentNullException(nameof(ticketDto));
            }
            try
            {
                var ticketModel = MapToTicket(ticketDto);
                var validResult = _validator.Validate(ticketModel);
                if (validResult.HasErrors)
                {
                    return CommandResult.Failure(validResult.ErrorString);
                }
                _context.Tickets.Add(ticketModel);
                _context.SaveChanges();
                return CommandResult.Success("Success!");
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat(DateTime.Now, ex));
                return CommandResult.Error("Fail", ex);
            }
        }
        public CommandResult Update(TicketDto ticketDto)
        {
            if (ticketDto is null)
            {
                throw new ArgumentNullException(nameof(ticketDto));
            }
            try
            {
                var ticketModel = MapToTicket(ticketDto);
                var validationResult = _validator.Validate(ticketModel);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }
                _context.Tickets.Update(ticketModel);
                _context.SaveChanges();
                return CommandResult.Success("Success!");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error("Fail!", ex);
            }
        }
        public CommandResult Delete(TicketDto ticketDto)
        {
            try
            {
                var ticketModel = MapToTicket(ticketDto);
                _context.Tickets.Remove(ticketModel);
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
            return Delete(new TicketDto() { Id = id });
        }
    }
}
