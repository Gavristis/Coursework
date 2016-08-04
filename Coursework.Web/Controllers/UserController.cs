using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Coursework.Entity.Services;
using Coursework.Web.Models;
using Microsoft.AspNet.Identity;

namespace Coursework.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCurrentUser()
        {
            var result = _userService.GetUser(User.Identity.GetUserId());
            var user = Mapper.Map<UserViewModel>(result);
            if (result == null)
                return new HttpNotFoundResult();
            return View(user);
        }

        public ActionResult GetUser(string id)
        {
            var result = _userService.GetUser(id);
            var user = Mapper.Map<UserViewModel>(result);
            if (result == null)
                return new HttpNotFoundResult();
            return View(user);
        }

        [HttpGet]
        public ActionResult Buy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buy(int count)
        {
            if (ModelState.IsValid)
            {
                _userService.Buy(count, User.Identity.GetUserId());               
            }
            return RedirectToAction("GetCurrentUser");
        }
    }
}