using System.Threading.Tasks;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CleanArchMvc.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        #region Attributes

        private readonly ICategoryService _categoryService;

        #endregion

        #region Ctor

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion

        #region HttpGet

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }
        #endregion
    }
}