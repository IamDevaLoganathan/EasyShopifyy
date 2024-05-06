using EasyShopify.DataAccess.Repository.UnitOfWork;
using EasyShopify.Migrations;
using EasyShopify.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyShopify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var data = unitOfWork.Product.GetAll().ToList();
           /* ViewBag.value = "Hello from ViewBag";
            ViewData["value"] = "Hello from ViewData";
            TempData["value"] = "Hello from TempData";*/
            return View(data);
      
        }

        public IActionResult Details(int Id)
        {
            ShppingCart cart = new ShppingCart()
            {
                Product = unitOfWork.Product.Get(u => u.Id == Id),
                Count = 1,
                ProductId = Id
            };
             return View(cart);

        }
        [HttpPost]
        public IActionResult Details(ShppingCart cart)
        {
            if(ModelState.IsValid)
            {

                //To get USerID from ASPNETUSER 
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userID = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                cart.ApplicationUserId = userID;

                //To Avoid Dyplicate Entries

                ShppingCart CartFronDB = unitOfWork.ShppingCart.Get(u => u.ApplicationUserId == userID && u.ProductId == cart.ProductId);

                if(CartFronDB != null)
                {
                    CartFronDB.Count += cart.Count;
                    unitOfWork.ShppingCart.Update(CartFronDB);
                }
                else
                {   
                    unitOfWork.ShppingCart.Add(cart);
                }

                unitOfWork.Save();
            }
            return RedirectToAction("Index","Cart");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
