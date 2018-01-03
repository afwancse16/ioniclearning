using AutoMapper;
using ContactApi.Models;

namespace ContactApi.Dto
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Contacts, ContactDto>()
                .ReverseMap();
        }
    }
}