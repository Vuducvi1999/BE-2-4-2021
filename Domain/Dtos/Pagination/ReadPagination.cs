using Domain.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Pagination
{
    public class ReadPagination
    {
        public int Index { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<ReadProductDto> Data { get; set; }
    }
}
