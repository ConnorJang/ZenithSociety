namespace ZenithWebSite.Migrations.Event
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithDataLib.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Event";
        }

        protected override void Seed(ZenithDataLib.Models.ApplicationDbContext context)
        {
            // Create Roles for Admin and Member 
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("Member"))
                roleManager.Create(new IdentityRole("Member"));

            // Seed the emails + usernames for Admin/Member
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string[] emails = { "a@a.a", "m@m.m" };
            string[] userNames = { "a", "m" };

            if (userManager.FindByEmail(emails[0]) == null)
            {
                var user = new ApplicationUser
                {
                    Email = emails[0],
                    UserName = userNames[0],
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Admin");
            }
            if (userManager.FindByEmail(emails[1]) == null)
            {
                var user = new ApplicationUser
                {
                    Email = emails[1],
                    UserName = userNames[1],
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Member");
            }

        }

        private List<Event> GetEvent()
        {
            //EventId
            //Event from date and time
            //Event to date and time
            //Entered by username
            //ActivityCategory(FK)
            //CreationDate
            //IsActive
            // DateTime format: var theDate = new DateTime (DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, hours, minute, second);
            List<Event> events = new List<Event>()
            {
                new Event()
                {
                    EventId = 1,
                    FromDate = new DateTime(2017, 10, 17, 8, 30, 0),
                    ToDate =  new DateTime(2017, 10, 17, 10, 30, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 1,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
            };
            return events;
        }

    }
}
