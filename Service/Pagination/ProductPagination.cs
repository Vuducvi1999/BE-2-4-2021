using AutoMapper;
using Common.Paganation;
using Domain.Dtos.Pagination;
using Domain.Dtos.Product;
using Domain.Entities;
using Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Pagination
{
    public class ProductPagination: IProductPagination
    {
        private readonly IMapper mapper;
        private readonly IRepository<Product> repository;

        public ProductPagination(IMapper mapper, IRepository<Product> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public Paganation<ReadProductDto> GetPage(int index)
        {
            //var PageInfo = new PaginationInfo() { index = index };
            //PageInfo.totalItem = repository.Queryable().Count();

            //var Data = repository.Queryable().Skip(0).Take(8).ToList();
            //PageInfo.data = mapper.Map<List<Product>, List<ReadProductDto>>(Data);

            //var PageResult = mapper.Map<PaginationInfo, ReadPagination>(PageInfo);
            //return PageResult;
            var PageInfo = new SerachPaganationDTO<ReadProductDto>() { PageNumber = index};
            var DataProduct = repository.Queryable().Take(PageInfo.Take).Skip(PageInfo.Skip).ToList();
            var DataReadProductDto = mapper.Map<List<Product>, List<ReadProductDto>>(DataProduct);
            var TotalItem = repository.Queryable().Count();
            var Result = mapper.Map<SerachPaganationDTO<ReadProductDto>, Paganation<ReadProductDto>>(PageInfo);
            Result.InputData(TotalItem, DataReadProductDto);

            return Result;
        }
    }
}
