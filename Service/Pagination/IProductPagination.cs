using Common.Paganation;
using Domain.Dtos.Pagination;
using Domain.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Pagination
{
    public interface IProductPagination
    {
        public Paganation<ReadProductDto> GetPage(int index);
    }
}
