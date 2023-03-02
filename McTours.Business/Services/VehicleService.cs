using McTours.Business.Validators;
using McTours.DataAccess;
using McTours.Domain;
using McTours.VehicleDefinitions;
using McTours.Vehicles;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace McTours.Business.Services
{
    public class VehicleService
    {

        private readonly McToursContext _context = new McToursContext();
        private readonly VehicleEntityValidator _validator = new VehicleEntityValidator();
        private static Vehicle MapToVehicleDomain(VehicleDto vehicleDto)
        {
            Vehicle entity = null;
            if (vehicleDto != null)
            {
                entity = new Vehicle()
                {
                    Id = vehicleDto.Id,
                    PlateNumber = vehicleDto.PlateNumber,
                    RegistrationNumber= vehicleDto.RegistrationNumber,
                    RegistrationDate= vehicleDto.RegistrationDate,
                    VehicleDefinitionId = vehicleDto.VehicleDefinitionId
                };
            }
            return entity;
        }
        private static VehicleDto MapToVehicleDto(Vehicle vehicleEntity)
        {
            VehicleDto dto = null;
            if (vehicleEntity != null)
            {
                dto = new()
                {
                    Id = vehicleEntity.Id,
                    PlateNumber = vehicleEntity.PlateNumber,
                    RegistrationNumber= vehicleEntity.RegistrationNumber,
                    RegistrationDate= vehicleEntity.RegistrationDate,
                    VehicleDefinitionId = vehicleEntity.VehicleDefinitionId
                };
            }
            return dto;
        }

        public IEnumerable<VehicleDefinitionsHeader> GetByNameDefinition()
        {
            try
            {
                // Buranın açıklaması lokalde _context Enumdan dolayı sqle çeviremiyor bu yüzden en başta contexti başlattım make ve modeli doldurdum
                //sonrasında Enum sorun çıkartmadı çünkü bağlantı önceden yapıldı dolduruldu!
                var allDefinitions = _context.VehicleDefinitions
                    .Include("VehicleModel.VehicleMake")
                    .ToList();

                return allDefinitions.Select(x => new VehicleDefinitionsHeader()
                {
                    Id = x.Id,
                    Definitions = string.Concat(x.VehicleModel.VehicleMake.Name, " - ", x.VehicleModel.Name, " - ", x.Year, " - ", EnumHelper.FuelNames[x.FuelType], " - ", x.LineCount)
                }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError($"{DateTime.Now} - {ex}");
                return Enumerable.Empty<VehicleDefinitionsHeader>();
            }
        }

        public IEnumerable<VehicleSummary> GetSummaries()
        {
            var vehicles = _context.Vehicles
                .Select(v => new VehicleSummary()
                {
                    Id = v.Id,
                    MakeName = v.VehicleDefinition.VehicleModel.VehicleMake.Name,
                    ModelName = v.VehicleDefinition.VehicleModel.Name,
                    PlateNumber = v.PlateNumber,
                    Year = v.VehicleDefinition.Year,
                    RegistrationNumber = v.RegistrationNumber,
                    RegistrationDate = v.RegistrationDate,

                }).ToList();
            return vehicles;
        }
        public VehicleDto GetById(int id)
        {
            try
            {
                var vehModel = _context.Vehicles.Find(id);
                if (vehModel != null)
                {
                    return MapToVehicleDto(vehModel);
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
        public IEnumerable<VehicleDto> GetAll()
        {
            try
            {
                return _context.Vehicles.Select(MapToVehicleDto).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return new List<VehicleDto>();
            }
        }
        public CommandResult Create(VehicleDto vehDto)
        {
            if (vehDto == null)
            {
                throw new ArgumentNullException(nameof(vehDto));
            }
            try
            {
                var vehModel = MapToVehicleDomain(vehDto);
                var validResult = _validator.Validate(vehModel);
                if (validResult.HasErrors)
                {
                    return CommandResult.Failure(validResult.ErrorString);
                }
                _context.Vehicles.Add(vehModel);
                _context.SaveChanges();
                return CommandResult.Success("Success!");
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat(DateTime.Now, ex));
                return CommandResult.Error("Fail", ex);
            }
        }
        public CommandResult Update(VehicleDto vehDto)
        {
            if (vehDto is null)
            {
                throw new ArgumentNullException(nameof(vehDto));
            }
            try
            {
                var vehModel = MapToVehicleDomain(vehDto);
                var validationResult = _validator.Validate(vehModel);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }
                _context.Vehicles.Update(vehModel);
                _context.SaveChanges();
                return CommandResult.Success("Success!");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error("Fail!", ex);
            }
        }
        public CommandResult Delete(VehicleDto vehDto)
        {
            try
            {
                var vehModel = MapToVehicleDomain(vehDto);
                _context.Vehicles.Remove(vehModel);
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
            return Delete(new VehicleDto() { Id = id });
        }
    }
}
