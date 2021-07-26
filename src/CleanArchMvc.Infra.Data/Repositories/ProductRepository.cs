using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Properties
        private readonly ApplicationDbContext _productRepository;
        #endregion

        #region Ctor
        public ProductRepository(ApplicationDbContext context)
        {
            _productRepository = context;
        }
        #endregion

        #region Implements
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.Products.ToListAsync();
        }

        public async Task<Product> GetProductByCategory(int? id)
        {
            return await _productRepository.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetById(int? id)
        {
            return await _productRepository.Products.FindAsync(id);
        }

        public async Task<Product> Create(Product product)
        {
            _productRepository.Products.Add(product);
            await _productRepository.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _productRepository.Products.Update(product);
            await _productRepository.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Remove(Product product)
        {
            _productRepository.Products.Remove(product);
            await _productRepository.SaveChangesAsync();
            return product;
        }
        #endregion
    }
}