using AutoMapper;

namespace Balbet.BL.Configurations
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ModelsDTO.UserDTO, DAL.ModelsDTO.UserDTO>();
            CreateMap<DAL.ModelsDTO.UserDTO, ModelsDTO.UserDTO>();

            CreateMap<DAL.ModelsDTO.UserDTO, DAL.Models.User>();
            CreateMap<DAL.Models.User, DAL.ModelsDTO.UserDTO>();
        }
    }
}
