using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAssignmentPt2.Models.ViewModels
{
    public class SessionCart : Cart
    {
        // The SessionCart class is a subclass of the Cart class and overrides the AddItem, RemoveLine, and Clear
        // GetCart method is a factory for creating SessionCart objects and providing them with an ISession object so they can store themselves
        // Obtain an instance of the HttpContextAccessor service, which provides access to an HttpContext object that, in turn,
        // provides the ISession.
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new
            SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        // the methods below call the base implementations and then store the updated state in the session using the
        // extension methods on the ISession interface
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
