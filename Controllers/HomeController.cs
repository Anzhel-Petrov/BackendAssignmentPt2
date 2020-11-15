using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackendAssignmentPt2.Models;
using BackendAssignmentPt2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BackendAssignmentPt2.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 5;
        // constructor injection - in order to create a new instance of the HomeController an object that implements
        // the IStoreRepository is required - the StoreRepository.
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }
        private List<SelectListItem> quantityDropdown = new List<SelectListItem>()
        {
              new SelectListItem { Text = "1", Value = "1"},
              new SelectListItem { Text = "2", Value = "2"},
              new SelectListItem { Text = "3", Value = "3"},
              new SelectListItem { Text = "4", Value = "4"},
              new SelectListItem { Text = "5", Value = "5"},
        };
        public ViewResult Index(string category, int productPage = 1)
        {
            ViewData["Quantity"] = quantityDropdown;
            ProductsListViewModel model = new ProductsListViewModel
            {
                // Get the Product objects, where category is not null, only those Product objects with a matching Category property are selected
                // order them by the primary key, skip over the products that occur before the start of the current page, and take the number of products
                // specified by the PageSize field
                Products = repository.Products
                .Where(p => category == null || p.Category.CategoryName == category)
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                // Pass information to the view about the number of pages available,
                // the current page,
                // and the total number of products in the repository
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(e =>
                    e.Category.CategoryName == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

    }
}
