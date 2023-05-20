using App.Business.Abstract;
using App.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using System.Diagnostics;

namespace Products.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAll();
            var productListViewModel = new ProductListViewModel();
            productListViewModel.Products = products;
            return View(productListViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Products(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            var productDetailsViewModel = new ProductDetailsViewModel()
            {
                 Product = product,
                 OtherProducts = _productService.GetRandomProducts(4)
            };
            return View("Product", productDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            _productService.Add(product);
            return RedirectToAction("success", "home");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View(); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}