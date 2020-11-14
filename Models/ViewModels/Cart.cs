using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAssignmentPt2.Models.ViewModels
{
    //The Cart class uses the CartLine class, defined in the same file, to represent a product and the quantity selected by
    //the customer
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        // AddItem, RemoveLine and Clear are virtual as the methods from SessionCart class will override them
        public virtual void AddItem(Product product, int quantity)
        {
            // check to see if the product is already in the cart
            CartLine item = lineCollection
            .Where(p => p.Product.ProductId == product.ProductId)
            .FirstOrDefault();
            // add product or update quantity
            if (item == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }
        // remove product - this will be changed to accept quantity as well
        public virtual void RemoveLine(Product product) =>
        lineCollection.RemoveAll(i => i.Product.ProductId == product.ProductId);
        // Linq syntax, return the total price for all products in the cart
        public decimal ComputeTotalValue() =>
        lineCollection.Sum(e => e.Product.Price * e.Quantity);
        // reset the cart by removing all items
        public virtual void Clear() => lineCollection.Clear();
        // a property Lines that gives access to the contents of the cart using a List<CartLine>
        public List<CartLine> Lines => lineCollection;
    }
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
