using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp.Models;
using TestApp.Repository;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IProductRepository productRepository;
        public HomeController()
        {
            db = new ApplicationDbContext();
            productRepository = new ProductRepository(db);
        }

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            var viewModel = productRepository.GetAllProducts();

            return View(viewModel);
        }


    }
}
