using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMPrakticniZadatak.Common.Models;
using WMPrakticniZadatak.Services.Interfaces;
using WMPrakticniZadatak.Web.Models;

namespace WMPrakticniZadatak.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(_service.GetProducts()?.Select(product => MapDtoToViewModel(product)));
        }

        // GET: Products/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _service.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(MapDtoToViewModel(product));
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _service.CreateProduct(MapViewModelToDto(product));
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _service.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(MapDtoToViewModel(product));
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                ProductDTO updatedProduct = null;
                try
                {
                    updatedProduct = _service.UpdateProduct(MapViewModelToDto(product));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (updatedProduct == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _service.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(MapDtoToViewModel(product));
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!_service.DeleteProduct(id))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        private ProductDTO MapViewModelToDto(ProductViewModel vm)
        {
            return new ProductDTO
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                Category = vm.Category,
                Manufacturer = vm.Manufacturer,
                Supplier = vm.Supplier,
                Price = vm.Price
            };
        }

        private ProductViewModel MapDtoToViewModel(ProductDTO dto)
        {
            return new ProductViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Category = dto.Category,
                Manufacturer = dto.Manufacturer,
                Supplier = dto.Supplier,
                Price = dto.Price
            };
        }
    }
}
