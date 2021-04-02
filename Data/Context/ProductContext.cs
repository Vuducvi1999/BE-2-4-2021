using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
	public class ProductContext : DataContext
	{
        public DbSet<Product> Products { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }
        public ProductContext(DbContextOptions<ProductContext> db) : base(db) { }
    }

}
