using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await _repository.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _repository.GetEntityWithSpec(spec);

            return Ok(_mapper.Map<Product, ProductToReturnDto>(product));
        }

        // [HttpGet("brands")]
        // public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        // {
        //     return Ok(await _repository.ПУ());
        // }
        //
        // [HttpGet("types")]
        // public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        // {
        //     return Ok(await _repository.GetProductTypesAsync());
        // }
    }
}