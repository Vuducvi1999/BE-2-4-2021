using AutoMapper;
using Domain.Dtos.Pagination;
using Domain.Dtos.Product;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Service.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IProductPagination service;

        public ProductController(IRepository<Product> repository,
                                IUnitOfWork unitOfWork,
                                IMapper mapper,
                                IProductPagination service)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet("page/{index}")]
        public IActionResult Get(int index)
        {
            try
            {
                var result = service.GetPage(index);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] SearchProductDto body)
        {
            try
            {
                var result = repository.Queryable().Where(item=> item.WareHouseId == body.WareHouseId || item.TypeId == body.TypeId || item.Title == body.Title).ToList();
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        // ignore get all
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var allItem = repository.Queryable().ToList();
                var result = mapper.Map<List<Product>, List<ReadProductDto>>(allItem);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }


        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var Item = repository.Find(id);
                var result = mapper.Map<Product, ReadProductDto>(Item);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] Product newProduct)
        {
            try
            {
                repository.Insert(newProduct);
                unitOfWork.SaveChanges();
                return Ok(true);
            }
            catch
            {
                throw;
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Product UpdateProduct)
        {
            try
            {
                //var FindProduct = repository.Find(id);
                //mapper.Map(UpdateProduct, FindProduct);

                repository.Update(UpdateProduct);
                unitOfWork.SaveChanges();
                return Ok(true);
            }
            catch
            {
                throw;
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                repository.Delete(id);
                unitOfWork.SaveChanges();
                return Ok(true);
            }
            catch
            {
                throw;
            }
        }
    }
}
