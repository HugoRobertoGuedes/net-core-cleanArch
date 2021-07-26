using System.Threading.Tasks;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductController : Controller
    {
        #region Attributes

        private readonly IProductService _productService;

        #endregion

        #region Ctor

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region HttpGet
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }
        #endregion
    }
}