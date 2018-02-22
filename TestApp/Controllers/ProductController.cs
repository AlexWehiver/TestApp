using System;
using System.Web.Mvc;
using TestApp.Models;
using TestApp.Repository;
using TestApp.ViewModels;

namespace TestApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IProductRepository productRepository;

        public ProductController()
        {
            db = new ApplicationDbContext();
            productRepository = new ProductRepository(db);
        }

        public ActionResult Create()
        {
            CreateProductViewModel viewModel = new CreateProductViewModel();

            return View("Create", viewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            Product product = new Product()
            {
                Name = viewModel.Name,
                Quantity = viewModel.Quantity,
                IsInStock = viewModel.IsInStock              
            };

            productRepository.Add(product);
            productRepository.Save();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            Product product = productRepository.GetById(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            productRepository.Delete(product);
            productRepository.Save();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            Product product = productRepository.GetById(Id);
            if (product == null)
            {
                return HttpNotFound();
            }

            EditProductViewModel viewModel = new EditProductViewModel()
            {
                Name = product.Name,
                Quantity = product.Quantity,
                IsInStock = product.IsInStock
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            Product product = productRepository.GetById(viewModel.Id);

            product.Name = viewModel.Name;
            product.Quantity = viewModel.Quantity;
            product.IsInStock = viewModel.IsInStock;

            productRepository.Update(product);
            productRepository.Save();

            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
