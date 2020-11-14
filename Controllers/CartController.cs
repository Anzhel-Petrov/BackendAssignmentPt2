using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackendAssignmentPt2.Models;
using BackendAssignmentPt2.Models.ViewModels;

namespace BackendAssignmentPt2.Controllers
{
    public class CartController : Controller
    {
        private IStoreRepository repository;
        private Cart cart;
        public CartController(IStoreRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }
        // Index method used to display the contents of the Cart
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult AddToCart(int productID, string returnUrl, int quantity)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductId == productID);
            if (product != null)
            {
                cart.AddItem(product, quantity);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int productID, string returnUrl)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductId == productID);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
