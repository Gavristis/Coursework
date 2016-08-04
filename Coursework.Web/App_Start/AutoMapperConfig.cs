using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Coursework.Entity.Entities;
using Coursework.Entity.Services;
using Coursework.Web.Models;

namespace Coursework.Web.App_Start
{
    public class AutoMapperConfig
    {
        private static IUserService _userService;

        private static IFlowerService _flowerService;

        public static void RegisterMaps()
        {
            RegisterUserMap();
            _userService = DependencyResolver.Current.GetService<IUserService>();
            RegisterFlowerMap();
            _flowerService = DependencyResolver.Current.GetService<IFlowerService>();
        }

        private static void RegisterUserMap()
        {
            Mapper.CreateMap<User, UserViewModel>();
        }

        private static void RegisterFlowerMap()
        {
            Mapper.CreateMap<Flower, FlowerViewModel>();
        }

    }
}