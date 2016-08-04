using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework.DAL.Identity;
using Owin;

namespace Coursework.DAL
{
    public class StartUp
    {
        public static void Configure(IAppBuilder app)
        {
            app.CreatePerOwinContext(MyDbContext.Create);
            app.CreatePerOwinContext<MyUserManager>(MyUserManager.Create);
            app.CreatePerOwinContext<MySignInManager>(MySignInManager.Create);
        }
    }
}
