using AutoMapper;
using CorePatientlyService.Models.User;

namespace CorePatientlyService.Mappings;

public class AutoMapperProfiles: Profile
{
    public AutoMapperProfiles()
    {
        
    CreateMap<StaffUser, UserResponseDTO>().ReverseMap();

    CreateMap<PatientUser, UserResponseDTO>().ReverseMap();
    
    }
}