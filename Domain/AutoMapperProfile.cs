using AutoMapper;
using Common.Paganation;
using Domain.Dtos.Pagination;
using Domain.Dtos.Product;
using Domain.Dtos.TypeProduct;
using Domain.Dtos.WareHouse;
using Domain.Entities;

namespace Domain
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ReadProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<TypeProduct, ReadTypeProductDto>().ReverseMap();
            CreateMap<WareHouse, ReadWareHouseDto>().ReverseMap();
            CreateMap<PaginationInfo, ReadPagination>().ReverseMap();
            CreateMap(typeof(Paganation<>), typeof(SerachPaganationDTO<>)).ReverseMap();

            CreateMap<Product, Product>();
        }
    }
}
