using McTours.Business.Validators;
using McTours.Cities;
using McTours.DataAccess;
using McTours.Domain;
using McTours.Vehicles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Business.Services
{
    public class CityService
    {
        private readonly McToursContext _context = new McToursContext();
        private static City MapToCityDomain(CityDto cityDto)
        {
            City entity = null;
            if (cityDto != null)
            {
                entity = new City()
                {
                    Id = cityDto.Id,
                    Name = cityDto.Name
                };
            }
            return entity;
        }
        private static CityDto MapToCityDto(City cityEntity)
        {
            CityDto dto = null;
            if (cityEntity != null)
            {
                dto = new CityDto()
                {
                    Id = cityEntity.Id,
                    Name = cityEntity.Name
                };
            }
            return dto;
        }

        public CityDto GetById(int id)
        {
            try
            {
                var cityModel = _context.Cities.Find(id);
                if (cityModel != null)
                {
                    return MapToCityDto(cityModel);
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
        public IEnumerable<CityDto> GetAll()
        {
            try
            {
                return _context.Cities.Select(MapToCityDto).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return new List<CityDto>();
            }
        }
    }
}
