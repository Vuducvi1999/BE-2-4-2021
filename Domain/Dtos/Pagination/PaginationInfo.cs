using Domain.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Pagination
{
    public class PaginationInfo
    {
        public int TotalItem { get; set; }
        public int Index { get; set; }
        public int Size { get; set; } = 8;
        public int Skip
        {
            get
            {
                if (Index != 0)
                    return (Index * Size);
                return 0;
            }
        }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((float)TotalItem / Size);
            }
        }
        public IEnumerable<ReadProductDto> Data { get; set; }
    }
}
