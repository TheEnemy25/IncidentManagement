using AutoMapper;
using IncidentManagement.Data.Entities;
using IncidentManagement.Domain.Dtos.Incident;

namespace IncidentManagement.Domain.MappingProfiles
{
    internal sealed class IncidentMappingProfile : Profile
    {
        public IncidentMappingProfile()
        {
            CreateMap<UpdateIncidentDto, Incident>();
            CreateMap<Incident, IncidentDto>();
            CreateMap<Incident, FullIncidentDto>();
        }
    }
}