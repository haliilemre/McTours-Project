using McTours.Business.Validators;
using McTours.DataAccess;
using McTours.Domain;
using McTours.VehicleModels;
using System.Diagnostics;

namespace McTours.Business.Services
{
    public class VehicleModelService
    {
        private McToursContext _context;
        private readonly VehicleModelValidator _validator = new VehicleModelValidator();

        public VehicleModelService()
        {
            _context = new McToursContext();
        }

        private static VehicleModel MapToVehicleModel(VehicleModelDto vehicleModelDto)
        {
            VehicleModel entity = null;

            if (vehicleModelDto != null)
            {
                entity = new VehicleModel()
                {
                    Id = vehicleModelDto.Id,
                    Name = vehicleModelDto.Name,
                    VehicleMakeId = vehicleModelDto.VehicleMakeId,
                };
            }

            return entity;
        }

        private static VehicleModelDto MapToVehicleModelDto(VehicleModel vehicleModel)
        {
            VehicleModelDto dto = null;

            if (vehicleModel != null)
            {
                dto = new VehicleModelDto()
                {
                    Id = vehicleModel.Id,
                    Name = vehicleModel.Name,
                    VehicleMakeId = vehicleModel.VehicleMakeId,
                };
            }

            return dto;
        }

        public VehicleModelDto GetById(int id)
        {
            try
            {
                var vehicleModel = _context.VehicleModels.Find(id);
                if (vehicleModel != null)
                {
                    return MapToVehicleModelDto(vehicleModel);
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

        public IEnumerable<VehicleModelDto> GetAll()
        {
            try
            {
                var vehicleModels = _context.VehicleModels.Select(MapToVehicleModelDto).ToList();
                return vehicleModels;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return new List<VehicleModelDto>();
            }
        }

        public IEnumerable<VehicleModelSummary> GetSummaries()
        {
            try
            {
                return _context.VehicleModels
                    .Select(v => new VehicleModelSummary()
                    {
                        Id = v.Id,
                        Name = v.Name,
                        VehicleMakeId = v.VehicleMakeId,
                        VehicleMakeName = v.VehicleMake.Name
                    }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                return Enumerable.Empty<VehicleModelSummary>();

            }
        }

        public CommandResult Create(VehicleModelDto vehicleModelDto)
        {
            try
            {
                var vehicleModel = MapToVehicleModel(vehicleModelDto);

                var validationResult = _validator.Validate(vehicleModel);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }

                _context.VehicleModels.Add(vehicleModel);
                _context.SaveChanges();
                return CommandResult.Success("Kayıt Başarılı!");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error("Fail!", ex);
            }
        }

        public CommandResult Update(VehicleModelDto vehicleModelDto)
        {
            try
            {
                var vehicleModel = MapToVehicleModel(vehicleModelDto);

                var validationResult = _validator.Validate(vehicleModel);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }

                _context.VehicleModels.Update(vehicleModel);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error("Fail!", ex);
            }
        }

        public CommandResult Delete(VehicleModelDto vehicleModelDto)
        {
            var vehicleModel = MapToVehicleModel(vehicleModelDto);
            try
            {
                _context.VehicleModels.Remove(vehicleModel);
                _context.SaveChanges();
                return CommandResult.Success("Silme İşlemi Başarılı!!");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error("Fail!", ex);
            }
        }

        public CommandResult Delete(int id)
        {
            return Delete(new VehicleModelDto() { Id = id });
        }
    }
}
