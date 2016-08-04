using Coursework.DAL.Identity;
using Coursework.Entity.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.DAL
{
    public class MyDbInitializer : DropCreateDatabaseAlways<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            var userManager = new MyUserManager(new UserStore<User>(context));

            var roles = new List<IdentityRole>
            {
                new IdentityRole("Admin"),
                new IdentityRole("User"),
                new IdentityRole("Manager")
            };
            foreach (var role in roles)
            {
                context.Roles.Add(role);
            }

            context.SaveChanges();

            // Create users.
            var users = new[]
            {
                new User
                {
                    Email = "admin@mail.com",
                    UserName = "Admin"
                },
                new User
                {
                    Email = "support1@mail.com",
                    UserName = "Support1",
                    PhoneNumber = "(095) 333-33-33",
                    FirstName = "Valera",
                    LastName = "Revolver",
                    Purchased = 3,
                    Flowers = new List<Flower>{},
                }
            };
            foreach (var user in users)
            {
                userManager.Create(user);
                userManager.AddPassword(user.Id, "Password_1");

            }
            context.SaveChanges();

            // Set roles to main users.
            userManager.AddToRole(users[0].Id, "Admin");
            userManager.AddToRole(users[1].Id, "Manager");
            context.SaveChanges();

            // Set roles to other users.
            for (int i = 2; i < users.Length; i++)
                userManager.AddToRole(users[i].Id, "User");
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
