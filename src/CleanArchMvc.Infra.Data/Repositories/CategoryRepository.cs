using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Properties
        private readonly ApplicationDbContext _categoryRepository;
        #endregion

        #region Ctor
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryRepository = context;
        }
        #endregion

        #region Implements
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepository.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int? id)
        {
            return await _categoryRepository.Categories.FindAsync(id);
        }

        public async Task<Category> Create(Category category)
        {
            _categoryRepository.Categories.Add(category);
            await _categoryRepository.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _categoryRepository.Categories.Update(category);
            await _categoryRepository.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Remove(Category category)
        {
            _categoryRepository.Categories.Remove(category);
            await _categoryRepository.SaveChangesAsync();
            return category;
        }
        #endregion
    }
}