using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        #region ctor

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _productRepository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Attributes

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Implements

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.GetById(id));
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productEntity = await _productRepository.GetProductByCategory(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task Add(ProductDTO productDto)
        {
            await _productRepository.Create(_mapper.Map<Product>(productDto));
        }

        public async Task Update(ProductDTO productDto)
        {
            await _productRepository.Update(_mapper.Map<Product>(productDto));
        }

        public async Task Remove(int? id)
        {
            var productToBeRemoved = _productRepository.GetById(id).Result;
            await _productRepository.Remove(productToBeRemoved);
        }

        #endregion
    }
}