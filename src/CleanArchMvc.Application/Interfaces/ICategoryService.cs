using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Application.Dtos;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(int? id);
        Task Add(CategoryDTO category);
        Task Update(CategoryDTO category);
        Task Remove(int? id);
    }
}