using AutoMapper;
using IncidentManagement.Data.Entities;
using IncidentManagement.Domain.Dtos.Incident;

namespace IncidentManagement.Domain.MappingProfiles
{
    public class IncidentMappingProfile : Profile
    {
        public IncidentMappingProfile()
        {
            CreateMap<UpdateIncidentDto, Incident>();
            CreateMap<Incident, IncidentDto>();
        }
    }
}
