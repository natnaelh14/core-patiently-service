using AutoMapper;
using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Mappings;

public class AutoMapperProfiles: Profile
{
    public AutoMapperProfiles()
    {
        
    CreateMap<StaffUser, UserResponseDTO>().ReverseMap();

    CreateMap<PatientUser, UserResponseDTO>().ReverseMap();
    
    }
}