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
        // dependency/controller injection - the controller class indicates that it needs a Cart and IStoreRepository implementation
        // object by declaring a constructor argument
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
        // model binding from the view - three primitive types that are used to create a complex type
        // the quantity comes from the dropdown quantity menu
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
        // the signatue will be changed to remove specific amount of products, not the whole line
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
