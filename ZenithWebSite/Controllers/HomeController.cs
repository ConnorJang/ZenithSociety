using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ZenithDataLib.Models;
using Microsoft.AspNet.Identity;

namespace ZenithWebSite.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext dbContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            //DateTime oneWeek = DateTime.Now.AddDays(7);

            int dayOffest = (int)DateTime.Now.DayOfWeek;
            if (dayOffest == 0) dayOffest = 6;
            else dayOffest--;



            DateTime mondayDate = DateTime.Now.AddDays(-dayOffest);
            DateTime sundayDate = mondayDate.AddDays(6);

            var events = dbContext.Events
                .Where(x => x.ToDate.CompareTo(mondayDate) >= 0 
                    && x.FromDate.CompareTo(sundayDate) <= 0 
                    && x.IsActive)
                .OrderBy(x => x.FromDate)
                .Include(x => x.ActivityCategory).ToList();

            return View(events);
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
    }
}