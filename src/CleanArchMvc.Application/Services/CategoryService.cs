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
    public class CategoryService : ICategoryService
    {
        #region Ctor

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _categoryRepository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Attributes

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Implements

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var listCat = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(listCat);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var category = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task Add(CategoryDTO category)
        {
            await _categoryRepository.Create(_mapper.Map<Category>(typeof(CategoryDTO)));
        }

        public async Task Update(CategoryDTO category)
        {
            await _categoryRepository.Update(_mapper.Map<Category>(typeof(CategoryDTO)));
        }

        public async Task Remove(int? id)
        {
            var categoryToBeRemoved = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Remove(categoryToBeRemoved);
        }

        #endregion
    }
}