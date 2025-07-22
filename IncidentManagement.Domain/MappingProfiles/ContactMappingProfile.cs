using AutoMapper;
using IncidentManagement.Data.Entities;
using IncidentManagement.Domain.Dtos.Contact;

namespace IncidentManagement.Domain.MappingProfiles
{
    internal sealed class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<CreateContactDto, Contact>();
            CreateMap<UpdateContactDto, Contact>();
            CreateMap<Contact, ContactDto>();
        }
    }
}