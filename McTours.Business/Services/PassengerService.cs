using System.Diagnostics;
using McTours.Business.Validators;
using McTours.BusTrips;
using McTours.DataAccess;
using McTours.Domain;
using McTours.Passengers;

namespace McTours.Business.Services
{
    public class PassengerService
    {
        private readonly McToursContext _context = new McToursContext();
        private readonly PassengerValidator _validator = new PassengerValidator();
        private static Passenger MapToPassenger(PassengerDto passengerDto)
        {
            Passenger entity = null;
            if (passengerDto != null)
            {
                entity = new Passenger()
                {
                    Id = passengerDto.Id,
                    FirstName = passengerDto.FirstName,
                    LastName = passengerDto.LastName,
                    IdentityNumber = passengerDto.IdentityNumber,
                    BirthDate = passengerDto.BirthDate,
                    Gender = passengerDto.Gender
                };
            }
            return entity;
        }
        private static PassengerDto MapToPassengerDto(Passenger passenger)
        {
            PassengerDto dto = null;
            if (passenger != null)
            {
                dto = new PassengerDto()
                {
                    Id = passenger.Id,
                    FirstName = passenger.FirstName,
                    LastName = passenger.LastName,
                    IdentityNumber = passenger.IdentityNumber,
                    BirthDate = passenger.BirthDate,
                    Gender = passenger.Gender
                };
            }
            return dto;
        }

        public IEnumerable<PassengerSummary> GetSummaries()
        {
            var passengers = _context.Passengers
                .Select(b => new PassengerSummary()
                {
                    Id = b.Id,
                    FirstName = b.FirstName,
                    LastName = b.LastName,
                    TicketCount = b.Tickets.Count(),
                    IdentityNumber = b.IdentityNumber,
                    BirthDate= b.BirthDate,
                    Gender = b.Gender
                }).ToList();
            return passengers;
        }
        public PassengerDto GetById(int id)
        {
            try
            {
                var passengerModel = _context.Passengers.Find(id);
                if (passengerModel != null)
                {
                    return MapToPassengerDto(passengerModel);
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
        public IEnumerable<PassengerDto> GetAll()
        {
            try
            {
                return _context.Passengers.Select(MapToPassengerDto).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return new List<PassengerDto>();
            }
        }
        public CommandResult Create(PassengerDto passengerDto)
        {
            if (passengerDto == null)
            {
                throw new ArgumentNullException(nameof(passengerDto));
            }
            try
            {
                var passengerModel = MapToPassenger(passengerDto);
                var validResult = _validator.Validate(passengerModel);
                if (validResult.HasErrors)
                {
                    return CommandResult.Failure(validResult.ErrorString);
                }
                _context.Passengers.Add(passengerModel);
                _context.SaveChanges();
                return CommandResult.Success("Success!");
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat(DateTime.Now, ex));
                return CommandResult.Error("Fail", ex);
            }
        }
        public CommandResult Update(PassengerDto passengerDto)
        {
            if (passengerDto is null)
            {
                throw new ArgumentNullException(nameof(passengerDto));
            }
            try
            {
                var passengerModel = MapToPassenger(passengerDto);
                var validationResult = _validator.Validate(passengerModel);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }
                _context.Passengers.Update(passengerModel);
                _context.SaveChanges();
                return CommandResult.Success("Success!");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error("Fail!", ex);
            }
        }
        public CommandResult Delete(PassengerDto passengerDto)
        {
            try
            {
                var passengerModel = MapToPassenger(passengerDto);
                _context.Passengers.Remove(passengerModel);
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
            return Delete(new PassengerDto() { Id = id });
        }

        public IEnumerable<SearchPassengerResult> SearchPassengers (SearchPassengerDto searchPassengerDto)
        {
            try
            {
                var query = _context.Passengers.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchPassengerDto.IdentityNumber))
                {
                    query = query.Where(pass => pass.IdentityNumber.Contains(searchPassengerDto.IdentityNumber));
                }
                if (!string.IsNullOrWhiteSpace(searchPassengerDto.FirstName))
                {
                    query = query.Where(pass => pass.FirstName.Contains(searchPassengerDto.FirstName));
                }
                if (!string.IsNullOrWhiteSpace(searchPassengerDto.LastName))
                {
                    query = query.Where(pass => pass.LastName.Contains(searchPassengerDto.LastName));
                }

                return query.Select(pass => new SearchPassengerResult()
                {
                    Id = pass.Id,
                    IdentityNumber = pass.IdentityNumber,
                    FirstName = pass.FirstName,
                    LastName = pass.LastName,
                    Gender = pass.Gender
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
