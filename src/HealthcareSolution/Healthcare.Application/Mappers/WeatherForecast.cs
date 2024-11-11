using AutoMapper;
using Healthcare.Domain.Entities;


namespace Healthcare.Application.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Map from Patient entity to PatientDto
            CreateMap<Patient, PatientDto>()
                .ReverseMap(); // Allows mapping both ways (from DTO to entity and vice versa)

            // Add other mappings as needed
            //CreateMap<Appointment, AppointmentDto>().ReverseMap();
        }
    }
}
