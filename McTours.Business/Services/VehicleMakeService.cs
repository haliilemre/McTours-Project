using McTours.DataAccess;
using McTours.Domain;
using McTours.VehicleMakes;
using System.Diagnostics;

namespace McTours.Business.Services
{
    public class VehicleMakeService
    {
        private McToursContext _context;
        public VehicleMakeService()
        {
            _context = new McToursContext();
        }

        private static VehicleMake MapToVehicleMake(VehicleMakeDto vehicleMakeDto)
        {
            VehicleMake entity = null;

            if (vehicleMakeDto != null)
            {
                entity = new VehicleMake()
                {
                    Id = vehicleMakeDto.Id,
                    Name = vehicleMakeDto.Name,
                };
            }
            return entity;
        }

        private static VehicleMakeDto MapToVehicleMakeDto(VehicleMake vehicleMake)
        {
            VehicleMakeDto dto = null;

            if (vehicleMake != null)
            {
                dto = new VehicleMakeDto()
                {
                    Id = vehicleMake.Id,
                    Name = vehicleMake.Name,
                };
            }
            return dto;
        }

        public VehicleMakeDto GetById(int id)
        {
            try
            {
                var vehicleMake = _context.VehicleMakes.Find(id);
                if (vehicleMake != null)
                {
                    return MapToVehicleMakeDto(vehicleMake);
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

        public IEnumerable<VehicleMakeDto> GetAll()
        {
            try
            {
                var vehicleMakes = _context.VehicleMakes.Select(MapToVehicleMakeDto).ToList();
                return vehicleMakes;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return new List<VehicleMakeDto>();
            }
        }

        public CommandResult Create(VehicleMakeDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            try
            {
                var entity = MapToVehicleMake(model);

                if (string.IsNullOrWhiteSpace(entity.Name))
                {
                    return CommandResult.Failure("Marka adı boş geçilemez!!");
                }
                _context.VehicleMakes.Add(entity);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error("Fail!", ex);
            }
        }

        public CommandResult Update(VehicleMakeDto vehicleMakeDto)
        {
            if (vehicleMakeDto == null)
            {
                throw new ArgumentNullException(nameof(vehicleMakeDto));
            }
            var vehicleMake = MapToVehicleMake(vehicleMakeDto);
            try
            {
                if (string.IsNullOrWhiteSpace(vehicleMake.Name))
                {
                    return CommandResult.Failure("Marka adı boş geçilemez!!!!!!");
                }

                _context.VehicleMakes.Update(vehicleMake);
                _context.SaveChanges();
                return CommandResult.Success("Başarılı!");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error("Fail", ex);
            }
        }

        public CommandResult Delete(VehicleMakeDto vehicleMakeDto)
        {
            if (vehicleMakeDto == null)
            {
                throw new ArgumentNullException(nameof(vehicleMakeDto));
            }

            var vehicleMake = MapToVehicleMake(vehicleMakeDto);
            try
            {
                if (_context
                    .VehicleModels
                    .Any(v => v.VehicleMakeId == vehicleMake.Id))
                {
                    return CommandResult.Failure("Bu markaya kayıtlı araç modelleri olduğu için silinemez.");
                }

                _context.VehicleMakes.Remove(vehicleMake);
                _context.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error("Fail", ex);
            }
        }

        public CommandResult Delete(int id)
        {
            return Delete(new VehicleMakeDto() { Id = id });
        }
    }
}
