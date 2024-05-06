using EasyShopify.Data;
using EasyShopify.DataAccess.Repository.UnitOfWork;
using EasyShopify.Models;
using EasyShopify.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace EasyShopify.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork unitOfWork;

        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            this.unitOfWork = unitOfWork;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string Productpath = Path.Combine(wwwRootPath, @"Image/Product");

                    using (var fileStream = new FileStream(Path.Combine(Productpath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    product.ImgURL = @"\Image\Product\" + fileName;

                }

                unitOfWork.Product.Add(product);
                unitOfWork.Save();
            }
            return RedirectToAction("Retrive", "Product");
        }

        [HttpGet]
        public IActionResult Retrive()
        {
            var data = unitOfWork.Product.GetAll().ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var data = unitOfWork.Product.Get(u => u.Id == Id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Product product, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string Productpath = Path.Combine(wwwRootPath, @"Image/Product");

                    if (!string.IsNullOrEmpty(product.ImgURL))
                    {
                        //Deleteing Old Image from Folder
                        var oldImagePath = Path.Combine(wwwRootPath, product.ImgURL.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(Productpath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    product.ImgURL = @"\Image\Product\" + fileName;

                }
                unitOfWork.Product.Update(product);
                unitOfWork.Save();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var data = unitOfWork.Product.Get(u => u.Id == Id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            unitOfWork.Product.Remove(product);
            unitOfWork.Save();
            return RedirectToAction("Index", "Home");

        }
    }
}
