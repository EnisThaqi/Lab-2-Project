using AutoMapper;
using Lab2.DTOs;
using Lab2.Models;

namespace Lab2
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RoletDTO, Rolet>();
            CreateMap<UserDTO, User>();
            CreateMap<SubjectTypeDTO, SubjectType>();
            CreateMap<OrdersDTO, Orders>();
            CreateMap<PackageSizesDTO, PackageSizes>();
            CreateMap<SubjectsDTO, Subjects>().ReverseMap();
            CreateMap<OrderStatusDTO, OrderStatus>();
            CreateMap<RoutesDTO, Routes>();
            CreateMap<VehiclesDTO, Vehicles>();
            CreateMap<UserSubjectsDTO, UserSubjects>();

            CreateMap<InvoiceDTO, Invoice>();
            CreateMap<InvoiceOrderDTO, InvoiceOrders>();
            CreateMap<PaymentsDTO, Payments>();
            CreateMap<PaymentMethodsDTO, PaymentMethods>();
        }
    }
}
