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

            // Get the ActivityCategories + Events data and save it
            context.ActivityCategories.AddRange(GetActivityCategories().ToArray());
            context.Events.AddRange(GetEvents().ToArray());
            context.SaveChanges();


        }

        private List<ActivityCategory> GetActivityCategories()
        {
            // ActivityCategoryId
            // ActivityDescription
            // CreationDate
            List<ActivityCategory> categories = new List<ActivityCategory>()
            {
                new ActivityCategory()
                {
                    ActivityDescription = "Senior's Golf Tournament",
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Leadership General Assembly Meeting",
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Youth Bowling Tournament",
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Young Ladies Cooking Lessons",
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Youth Craft Lessons",
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Youth Choir Practice",
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Lunch",
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Pancake Breakfast",
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Swimming Lessons for Youth",
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Swimming Exercise for Parents",
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Bingo Tournament",
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                },
                new ActivityCategory()
                {
                    ActivityDescription = "BBQ Lunch",
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Garage Sale",
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                },

            };

            return categories;
        }

        private List<Event> GetEvents()
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
                // Below are the same events as on the outline, but 1 week earlier (for our testing)
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 10, 8, 30, 0),
                    ToDate =  new DateTime(2017, 10, 10, 10, 30, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 1,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 11, 8, 30, 0),
                    ToDate =  new DateTime(2017, 10, 11, 10, 30, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 2,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 13, 17, 30, 0),
                    ToDate =  new DateTime(2017, 10, 13, 19, 15, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 3,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 13, 19, 0, 0),
                    ToDate =  new DateTime(2017, 10, 13, 20, 0, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 4,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 14, 8, 30, 0),
                    ToDate =  new DateTime(2017, 10, 14, 10, 30, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 5,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 14, 10, 30, 0),
                    ToDate =  new DateTime(2017, 10, 14, 12, 0, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 6,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 14, 12, 0, 0),
                    ToDate =  new DateTime(2017, 10, 14, 13, 30, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 7,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 15, 7, 30, 0),
                    ToDate =  new DateTime(2017, 10, 15, 8, 30, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 8,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 15, 8, 30, 0),
                    ToDate =  new DateTime(2017, 10, 15, 10, 30, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 9,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 15, 8, 30, 0),
                    ToDate =  new DateTime(2017, 10, 15, 10, 30, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 10,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 15, 10, 30, 0),
                    ToDate =  new DateTime(2017, 10, 15, 12, 0, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 11,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 15, 12, 0, 0),
                    ToDate =  new DateTime(2017, 10, 15, 13, 0, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 12,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 15, 13, 0, 0),
                    ToDate =  new DateTime(2017, 10, 15, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 13,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },

                // Below are the events from the assignment outline (week of monday oct 16,2017 -> sunday oct 22, 2017)
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 17, 8, 30, 0),
                    ToDate =  new DateTime(2017, 10, 17, 10, 30, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 1,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 18, 8, 30, 0),
                    ToDate =  new DateTime(2017, 10, 18, 10, 30, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 2,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 20, 17, 30, 0),
                    ToDate =  new DateTime(2017, 10, 20, 19, 15, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 3,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 20, 19, 0, 0),
                    ToDate =  new DateTime(2017, 10, 20, 20, 0, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 4,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 21, 8, 30, 0),
                    ToDate =  new DateTime(2017, 10, 21, 10, 30, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 5,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 21, 10, 30, 0),
                    ToDate =  new DateTime(2017, 10, 21, 12, 0, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 6,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 21, 12, 0, 0),
                    ToDate =  new DateTime(2017, 10, 21, 13, 30, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 7,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 22, 7, 30, 0),
                    ToDate =  new DateTime(2017, 10, 22, 8, 30, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 8,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 22, 8, 30, 0),
                    ToDate =  new DateTime(2017, 10, 22, 10, 30, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 9,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 22, 8, 30, 0),
                    ToDate =  new DateTime(2017, 10, 22, 10, 30, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 10,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 22, 10, 30, 0),
                    ToDate =  new DateTime(2017, 10, 22, 12, 0, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 11,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 22, 12, 0, 0),
                    ToDate =  new DateTime(2017, 10, 22, 13, 0, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 12,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
                new Event()
                {
                    FromDate = new DateTime(2017, 10, 22, 13, 0, 0),
                    ToDate =  new DateTime(2017, 10, 22, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityCategoryId = 13,
                    CreationDate = new DateTime(2017, 9, 17, 10, 30, 0),
                    IsActive = true,
                },
            };
            return events;
        }

    }
}
