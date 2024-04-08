using AutoMapper;
using Lab2.DTOs;
using Lab2.Models;

namespace Lab2
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<RoletDTO, Rolet>();
            CreateMap<UserDTO, User>();
            CreateMap<SubjectTypeDTO, SubjectType>();
            CreateMap<OrdersDTO, Orders>();
            CreateMap<PackageSizesDTO, PackageSizes>();
        }
    }
}
