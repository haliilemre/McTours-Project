using McTours.Business.Validators;
using McTours.DataAccess;
using McTours.Domain;
using McTours.VehicleDefinitions;
using System.Diagnostics;

namespace McTours.Business.Services
{
    public class VehicleDefinitionService
    {
        private McToursContext _context;

        private readonly VehicleDefinitionValidator _validator = new VehicleDefinitionValidator();

        public VehicleDefinitionService()
        {
            _context = new McToursContext();
        }

        private static VehicleDefinition MapToEntity(VehicleDefinitionDto dto)
        {
            VehicleDefinition entity = null;

            if (dto != null)
            {
                entity = new VehicleDefinition()
                {
                    Id = dto.Id,
                    VehicleModelId = dto.VehicleModelId,
                    Year = dto.Year,
                    FuelType = dto.FuelType,
                    LineCount = dto.LineCount,
                    SeatingType = dto.SeatingType
                };

                foreach (var utility in dto.Utilities)
                {
                    entity.Utilities = entity.Utilities | utility; //  "|" mantıksal toplama. "|=" ise mantık olarak birebir "+=".
                }
            }

            return entity;
        }

        private static VehicleDefinitionDto MapToDto(VehicleDefinition entity)
        {
            VehicleDefinitionDto dto = null;

            if (entity != null)
            {
                dto = new VehicleDefinitionDto()
                {
                    Id = entity.Id,
                    VehicleModelId = entity.VehicleModelId,
                    Year = entity.Year,
                    FuelType = entity.FuelType,
                    LineCount = entity.LineCount,
                    SeatingType = entity.SeatingType,
                };

                var allUtilities = Enum.GetValues<Utility>();

                foreach (var utility in allUtilities)
                {
                    if (utility != Utility.None && entity.Utilities.HasFlag(utility)) // utility none değilse ve utility flag'ini içeriyorsa
                    {
                        dto.Utilities.Add(utility);
                    }
                }
            }
            return dto;
        }

        public VehicleDefinitionDto GetById(int id)
        {
            try
            {
                var entity = _context.VehicleDefinitions.Find(id);
                if (entity != null)
                {
                    return MapToDto(entity);
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

        public IEnumerable<VehicleDefinitionDto> GetAll()
        {
            try
            {
                var vehDefinitions = _context.VehicleDefinitions.Select(MapToDto).ToList();
                return vehDefinitions;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return new List<VehicleDefinitionDto>();
            }
        }

        public IEnumerable<VehicleDefinitionSummary> GetSummaries()
        {
            try
            {
                var vehDefinitions = _context.VehicleDefinitions
                    .Select(v => new VehicleDefinitionSummary()
                    {
                        Id = v.Id,
                        VehicleMakeName = v.VehicleModel.VehicleMake.Name,
                        VehicleModelName = v.VehicleModel.Name,
                        Year = v.Year,
                        SeatingType = v.SeatingType,
                        LineCount = v.LineCount,
                        FuelType = v.FuelType,
                        Utilities = v.Utilities
                    }).ToList();

                return vehDefinitions;
            }
            catch (Exception ex)
            {
                Trace.TraceError($"{DateTime.Now} - {ex.Message}"); // Hatayı zamanı ile birlikte loglama

                return Enumerable.Empty<VehicleDefinitionSummary>();
            }
        }

        public CommandResult Create(VehicleDefinitionDto dto)
        {
            try
            {
                var vehDefinition = MapToEntity(dto);

                var result = _validator.Validate(vehDefinition);
                if (result.HasErrors)
                {
                    return CommandResult.Failure(result.ErrorString);
                }

                _context.VehicleDefinitions.Add(vehDefinition);
                _context.SaveChanges();
                return CommandResult.Success("Kayıt Başarılı!");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error("Fail!", ex);
            }
        }

        public CommandResult Update(VehicleDefinitionDto dto)
        {
            try
            {
                var vehicleDefinition = MapToEntity(dto);

                var result = _validator.Validate(vehicleDefinition);
                if (result.HasErrors)
                {
                    return CommandResult.Failure(result.ErrorString);
                }

                _context.VehicleDefinitions.Update(vehicleDefinition);
                _context.SaveChanges();
                return CommandResult.Success("Güncelleme Başarılı!");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error("Fail!", ex);
            }
        }

        public CommandResult Delete(VehicleDefinitionDto dto)
        {
            var vehDefinition = MapToEntity(dto);
            try
            {
                _context.VehicleDefinitions.Remove(vehDefinition);
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
            return Delete(new VehicleDefinitionDto() { Id = id });
        }
    }
}
