using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Product
{
    public class SearchProductDto
    {
        public Guid WareHouseId { get; set; }

        public Guid TypeId { get; set; }

        public string Title { get; set; }
    }
}
