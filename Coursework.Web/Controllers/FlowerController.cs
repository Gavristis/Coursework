using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Coursework.Entity.Services;
using Coursework.Web.Models;
using Microsoft.AspNet.Identity;

namespace Coursework.Web.Controllers
{
    public class FlowerController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFlowerService _flowerService;
        private readonly ICommentService _commentService;
        private readonly IPictureService _pictureService;

        public FlowerController(IUserService userService, IFlowerService flowerService, ICommentService commentService, IPictureService pictureService)
        {
            _userService = userService;
            _flowerService = flowerService;
            _commentService = commentService;
            _pictureService = pictureService;
        }
        // GET: Flower
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetFlowers()
        {
            var result = _flowerService.GetAllFlowers();
            var flowers = result.Select(Mapper.Map<FlowerViewModel>).ToList();
            return View(flowers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FlowerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _flowerService.CreateFlower(User.Identity.GetUserId(), model.FlowerName);
                return RedirectToAction("GetCurrentUser", "User");
            }
            return View(model);
        }

        public ActionResult Search(string s)
        {
            var result = _flowerService.GetAllFlowers();
            var flowers = result.Select(Mapper.Map<FlowerViewModel>).ToList();
            List<FlowerViewModel> res = new List<FlowerViewModel>();
            string tmp;

            foreach (var c in flowers)
            {
                tmp = c.FlowerName.ToLower();

                if (tmp.Contains(s.ToLower()))
                    res.Add(c);

            }
            return View(res);
        }

        public ActionResult GetFlower(long id)
        {
            var result = _flowerService.GetFlower(id);
            var _flower = Mapper.Map<FlowerViewModel>(result);

            if (result == null)
                return new HttpNotFoundResult();
            return View(_flower);
        }

        [HttpGet]
        public ActionResult Comment(long id)
        {
            CommentViewModel comment = new CommentViewModel();
            comment.FlowerId = id;
            return View(comment);
        }

        [HttpPost]
        public ActionResult Comment(CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                _commentService.CreateComment(User.Identity.GetUserId(), model.FlowerId, model.Text);
                return RedirectToAction("GetFlower", new { id = model.FlowerId });
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult AddPhoto(long id)
        {
            PictureViewModel picture = new PictureViewModel();
            picture.FlowerId = id;
            return View(picture);
        }

        public ActionResult AddPhoto(HttpPostedFileBase uploadImage, PictureViewModel model)
        {
            if (ModelState.IsValid && uploadImage!=null)
            {
                byte[] imageData = null;

                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                _pictureService.CreatePicture(model.FlowerId, imageData);
                return RedirectToAction("GetFlower", new { id = model.FlowerId });
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            var result = _flowerService.GetFlower(id);
            var _flower = Mapper.Map<FlowerViewModel>(result);
            return View(_flower);
        }

        [HttpPost]
        public ActionResult Delete(long id, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                _flowerService.DeleteFlower(id);
                return RedirectToAction("GetCurrentUser", "User");
            }
            return View();
        }
    }
}