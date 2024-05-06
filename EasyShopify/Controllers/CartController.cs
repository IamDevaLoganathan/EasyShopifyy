using EasyShopify.Data;
using EasyShopify.DataAccess.Repository.UnitOfWork;
using EasyShopify.Migrations;
using EasyShopify.Models;
using EasyShopify.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Claims;

namespace EasyShopify.Controllers
{
    [Authorize]
    public class CartController : Controller
    {

        private readonly IUnitOfWork unitOfWork;

        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public ApplicationVM ApplicationVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userID = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            

            ShoppingCartVM = new()
            {
                ListCart = unitOfWork.ShppingCart.GetAll(u => u.ApplicationUserId == userID, includeProperties: "Product"),
                OrderHeader = new()
            };
            foreach (var cart in ShoppingCartVM.ListCart)
            {

                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }

            return View(ShoppingCartVM);
        }

        private int GetPriceBasedOnQuantity(ShppingCart shppingCart)
        {
            if (shppingCart.Count <= 50)
            {
                return shppingCart.Product.Price;

            }
            else
            {
                if (shppingCart.Count <= 100)
                {
                    return shppingCart.Product.Price50;
                }
                else
                {
                    return shppingCart.Product.Price100;
                }
            }
        }

        public IActionResult Plus(int cartId)
        {
            var CartFromDB = unitOfWork.ShppingCart.Get(u => u.ShppingCartId == cartId);
            CartFromDB.Count += 1;
            unitOfWork.ShppingCart.Update(CartFromDB);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }


        public IActionResult Minus(int cartId)
        {
            var CartFromDB = unitOfWork.ShppingCart.Get(u => u.ShppingCartId == cartId);
            if (CartFromDB.Count <= 1)
            {
                unitOfWork.ShppingCart.Remove(CartFromDB);
            }
            else
            {
                CartFromDB.Count -= 1;
                unitOfWork.ShppingCart.Update(CartFromDB);
            }
            unitOfWork.Save();
            return RedirectToAction("Index");

        }


        public IActionResult Remove(int cartId)
        {
            var CartFromDB = unitOfWork.ShppingCart.Get(u => u.ShppingCartId == cartId);
            unitOfWork.ShppingCart.Remove(CartFromDB);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }


        public IActionResult RemoveCheckout(int cartId)
        {
            var CartFromDB = unitOfWork.ShppingCart.Get(u => u.ShppingCartId == cartId);
            unitOfWork.ShppingCart.Remove(CartFromDB);
            unitOfWork.Save();
            return RedirectToAction("Checkout");
        }



        [HttpGet]
        public IActionResult Checkout()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userID = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                ListCart = unitOfWork.ShppingCart.GetAll(u => u.ApplicationUserId == userID, includeProperties:"Product"),
                OrderHeader = new(),
            };

            ShoppingCartVM.OrderHeader.ApplicationUser = unitOfWork.ApplicationUser.Get(u=>u.Id == userID);

            ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.ApplicationUser.Name;
            ShoppingCartVM.OrderHeader.City = ShoppingCartVM.OrderHeader.ApplicationUser.City;
            ShoppingCartVM.OrderHeader.State = ShoppingCartVM.OrderHeader.ApplicationUser.State;
            ShoppingCartVM.OrderHeader.PostalCode = ShoppingCartVM.OrderHeader.ApplicationUser.PostalCode;
            ShoppingCartVM.OrderHeader.Phone = ShoppingCartVM.OrderHeader.ApplicationUser.PhoneNumber;

       

            foreach (var cart in ShoppingCartVM.ListCart)
            {

                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }

            return View(ShoppingCartVM);
        }



        [HttpPost]
        [ActionName("Checkout")]
        public IActionResult CheckoutPOST()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userID = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            


            ShoppingCartVM.ListCart = unitOfWork.ShppingCart.GetAll(u => u.ApplicationUserId == userID, includeProperties: "Product");

            ShoppingCartVM.OrderHeader.OrderDate = DateTime.Now;
            ShoppingCartVM.OrderHeader.ApplicationUserId = userID;


            ApplicationUser applicationUser = unitOfWork.ApplicationUser.Get(u => u.Id == userID);


            foreach (var cart in ShoppingCartVM.ListCart)
            {

                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal = (cart.Price * cart.Count);

            }

            unitOfWork.OrderHeader.Add(ShoppingCartVM.OrderHeader);
            unitOfWork.Save();

            foreach (var cart in ShoppingCartVM.ListCart)
            {
                OrderDetail orderDetail = new()
                {
                    ProductId = cart.ProductId,
                    OrderHeaderId = ShoppingCartVM.OrderHeader.OrderHeaderId,
                    Count = cart.Count,
                    Price = cart.Price
                };
                unitOfWork.OrderDetail.Add(orderDetail);
                unitOfWork.Save();
            }
            return RedirectToAction("OrderConfirmation");

        }

        public IActionResult OrderConfirmation()
        {
              return View();
        }


    }
}
