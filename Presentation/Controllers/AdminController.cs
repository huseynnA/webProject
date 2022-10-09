using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Abstract;

namespace Presentation.Controllers
{
    public class AdminController : Controller
    {
        // [Authorize("Admin")]

        private readonly IAdminService _adminService;
        private readonly IProductService  _productService;

        public AdminController(IAdminService adminService,IProductService productService)
        {
            _adminService = adminService;
            _productService= productService;
        }



        [HttpGet]
        [Route("Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        [Route("Admin")]
        public IActionResult CreateProduct(ProductDTO product)
        {

            var res = _adminService.CreateProduct(product);
            return RedirectToAction("Admin");
        }

        [HttpGet]
        [Route("Products")]
        public IActionResult Products(SortOrder sortOrder, int page = 1, int pageSize = 15, string searchName = null)
        {

            #region initial data


            _productService.Create(new DTO.ProductDTO
            {
                Name = "Pulp Fiction",
                Price = 20,
                ImgPath = "~/img/pulp_fict.jpg"

            });
            #endregion
            return Ok();
        }
    }
}