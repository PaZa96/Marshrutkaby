using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Web.Mvc;
using Marshrutkaby.Models;

namespace Marshrutkaby.Controllers
{
    public class HomeController : Controller
    {
        public static int idDataRoute;
        public static int idOrder;
        Models.ApplicationDbContext db = new Models.ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }

            else if (User.IsInRole("TC"))
            {
                return View();
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(Models.DataRoutesSet datemodels)
        {
            if (ModelState.IsValid == false)
            {

                if (datemodels.Date >= DateTime.Now.Date)
                {
                    var drs = db.DataRoutesSet.Where(x => x.Date == datemodels.Date && x.RoutesSet.StartingPoint == datemodels.RoutesSet.StartingPoint && x.RoutesSet.EndPoint == datemodels.RoutesSet.EndPoint);

                    return View("SearchRoutes", drs.ToList());
                }
            }

            return View();
           
        }

        public ActionResult SearchRoutes()
        {
            return View();
        }

        public ActionResult Search()
        {
            Models.DataRoutesSet drs = db.DataRoutesSet.Find(idDataRoute);
            var dr = db.DataRoutesSet.Where(x => x.Date == drs.Date && x.RoutesSet.StartingPoint == drs.RoutesSet.StartingPoint && x.RoutesSet.EndPoint == drs.RoutesSet.EndPoint);

            return View("SearchRoutes", dr.ToList());
        }

        public ActionResult Confirmation(int id)
        {
            var ors = db.OrderSet.Where(x => x.IdRegistration == id).ToList();
            ViewBag.idreg = id;
            return View(ors);
        }

        [HttpPost]
        public ActionResult Confirmation(int idreg, int idroute)
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Order(int id)
        {
            var route = db.DataRoutesSet.Where(x => x.IdDataRoute == id).ToList();
            ViewBag.routes = route;
            ViewBag.idr = id;
            idDataRoute = id;
            return View();
        }

        [HttpPost]
        public ActionResult Order(Models.RegistrationAndRoutes rar)
        {
            
            if (ModelState.IsValid)
            {
                this.db.RegistrationSet.Add(rar.Registration);
                this.db.SaveChanges();

                ViewBag.reg = db.RegistrationSet.Where(x => x.IdRegistration == rar.Registration.IdRegistration).ToList();
                ViewBag.regroute = db.DataRoutesSet.Where(x => x.IdDataRoute == idDataRoute).ToList();

                
                int idreg = rar.Registration.IdRegistration;
                DateTime date1 = DateTime.Now;
                var order = new OrderSet
                {
                    IdDataRoute = idDataRoute,
                    IdRegistration = idreg,
                    OrderTime = date1,
                    IdUser = User.Identity.GetUserId()  
                };

                this.db.OrderSet.Add(order);
                this.db.SaveChanges();

                var ord = db.OrderSet.Where(x => x.IdRegistration == rar.Registration.IdRegistration).ToList();
                int id = rar.Registration.IdRegistration;
                idOrder = id;
                return RedirectToAction("Confirmation", new { id = id });
            }
            else return View();
        }
       
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Models.OrderSet ors = db.OrderSet.FirstOrDefault(x => x.IdRegistration == id);
            ViewBag.idregdel = id;
            return PartialView(ors);
        }
        
        public ActionResult Del(int id)
        {
            Models.OrderSet ors = db.OrderSet.FirstOrDefault(x => x.IdRegistration == id);
            this.db.OrderSet.Remove(ors);
            this.db.SaveChanges();

            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Models.OrderSet os = db.OrderSet.FirstOrDefault(x=>x.IdRegistration == id);

            ViewBag.order = db.OrderSet.Where(x => x.RegistrationSet.IdRegistration == id).ToList();

            return View("Edit", os);
        }

        [HttpPost]
        public ActionResult Edit( Models.OrderSet os)
        {
            var edit = db.RegistrationSet.FirstOrDefault(x => x.IdRegistration == os.IdRegistration);

            edit.LastName = os.RegistrationSet.LastName.ToString();
            edit.FirstName = os.RegistrationSet.FirstName.ToString();
            edit.MiddleName = os.RegistrationSet.MiddleName.ToString();
           
            db.SaveChanges();

            var ord = db.OrderSet.Where(x => x.IdRegistration == os.IdRegistration).ToList();
            return View("Confirmation", ord);
        }

       

        public ActionResult Home()
        {
            return View();
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