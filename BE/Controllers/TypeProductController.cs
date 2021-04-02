using AutoMapper;
using Domain.Dtos.TypeProduct;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeProductController : ControllerBase
    {
        private readonly IRepository<TypeProduct> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TypeProductController(IRepository<TypeProduct> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var allItem = repository.Queryable().ToList();
                var result = mapper.Map<List<TypeProduct>, List<ReadTypeProductDto>>(allItem);
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
                var result = mapper.Map<TypeProduct, ReadTypeProductDto>(Item);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] TypeProduct newTypeProduct)
        {
            try
            {
                repository.Insert(newTypeProduct);
                unitOfWork.SaveChanges();
                return Ok(true);
            }
            catch
            {
                throw;
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] TypeProduct updateProduct)
        {
            try
            {
                repository.Update(updateProduct);
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
