namespace Portal.Migrations
{
    using Portal.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //the Admin role
            var roleManager = new RoleManager<IdentityRole>(new
                                          RoleStore<IdentityRole>(context));
            //Create Role Admin if it does not exist
            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Administrator"));
            }

            //Create Perm Remove Records if it does not exist
            if (!context.Roles.Any(r => r.Name == "Remove Records"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Remove Records"));
            }

            //Create Perm Create/Modify Meetings or Events if it does not exist
            if (!context.Roles.Any(r => r.Name == "Create/Modify Meetings or Events"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Create/Modify Meetings or Events"));
            }

            //Create Perm Create/Modify Meetings or Events if it does not exist
            if (!context.Roles.Any(r => r.Name == "Create/Modify Meetings or Events"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Create/Modify Meetings or Events"));
            }
            //Create Perm Manage Invitations if it does not exist
            if (!context.Roles.Any(r => r.Name == "Manage Invitations"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Manage Invitations"));
            }

            //Create Assign User Permissions if it does not exist
            if (!context.Roles.Any(r => r.Name == "Assign User Permissions"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Assign User Permissions"));
            }

            var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            //Add an administrator User when the system is created
            var administratoruser = new ApplicationUser
            {
                UserName = "administrator1@outlook.com",
                Email = "administrator1@outlook.com",
                UserDOB = DateTime.Today
            };

            if (!context.Users.Any(u => u.UserName == "administrator1@outlook.com"))
            {
                manager.Create(administratoruser, "Password1");
                manager.AddToRole(administratoruser.Id, "Administrator");
            }
            context.SaveChanges();
        }
    }
}
