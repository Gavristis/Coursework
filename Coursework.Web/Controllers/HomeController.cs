using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coursework.DAL;
using Coursework.Entity.Entities;
using Coursework.Entity.Services;
using Coursework.Web.Models;
using Microsoft.AspNet.Identity;

namespace Coursework.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPictureService _pictureService;

        public HomeController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase uploadImage, PictureViewModel model)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                // установка массива байтов

                _pictureService.CreatePicture(model.FlowerId, imageData);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}