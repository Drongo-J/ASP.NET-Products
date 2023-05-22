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
            TempData["SuccessMessage"] = "Product was added successfully!";
            return RedirectToAction("Success");
        }

        [HttpGet]
        public IActionResult Delete(int productId)
        {
            var product = _productService.GetById(productId);
            if (product == null)
                return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var product = _productService.GetById(productId);
            if (product == null)
                return BadRequest();
            _productService.Delete(product.Id);
            TempData["SuccessMessage"] = "Product was deleted successfully!";
            return RedirectToAction("Success");
        }

        [HttpGet]
        public IActionResult Update(int productId)
        {
            var product = _productService.GetById(productId);
            if (product == null)
                return NotFound();
            return View(new UpdateProductViewModel() { Product = product });
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductViewModel productVM)
        {
            var product = productVM.Product ;
            if (product == null)
                return BadRequest();
            _productService.Update(product);
            TempData["SuccessMessage"] = "Product was updated successfully!";
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            var successMessage = TempData["SuccessMessage"]?.ToString();
            return View(new SuccessMessage(successMessage)); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}