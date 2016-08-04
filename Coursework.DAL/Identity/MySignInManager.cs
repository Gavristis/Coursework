using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Coursework.Entity.Entities;

namespace Coursework.DAL.Identity
{
    public class MySignInManager : SignInManager<User, string>
    {
        public MySignInManager(MyUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((MyUserManager)UserManager);
        }

        public static MySignInManager Create(IdentityFactoryOptions<MySignInManager> options, IOwinContext context)
        {
            return new MySignInManager(context.GetUserManager<MyUserManager>(), context.Authentication);
        }
    }
}
