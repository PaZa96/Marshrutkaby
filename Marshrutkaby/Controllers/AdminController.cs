using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Marshrutkaby.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Marshrutkaby.Controllers
{
    public class AdminController : Controller
    {
        Models.ApplicationDbContext db = new Models.ApplicationDbContext();
        public static int IDCompany;
        private ApplicationUserManager _userManager;
  
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.countTC = db.TransportCompanySet.Count();
            ViewBag.countRoute = db.RoutesSet.Count();
            ViewBag.countOrder = db.OrderSet.Count();
            ViewBag.countCar = db.CarSet.Count();
            ViewBag.countUser = db.Users.Count();

            return View();
        }

        public ActionResult Company()
        {
            var TC = db.TransportCompanySet.ToList();
            return View(TC);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Models.TransportCompanySet tc = db.TransportCompanySet.FirstOrDefault(x => x.IdTransportCompany == id);
            return View(tc);
        }

        [HttpPost]
        public ActionResult Edit(Models.TransportCompanySet tcs)
        {
            var edit = db.TransportCompanySet.FirstOrDefault(x => x.IdTransportCompany == tcs.IdTransportCompany);

            edit.Name = tcs.Name.ToString();
            edit.NumberPhone = tcs.NumberPhone.ToString();
            edit.Email = tcs.NumberPhone.ToString();

            db.SaveChanges();

            return RedirectToAction("Company");
        }

        public ActionResult Details(int id)
        {
            var tc = db.TransportCompanySet.Where(x => x.IdTransportCompany == id).ToList();
            ViewBag.IdTC = id;

            return View(tc);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.TransportCompanySet tcs)
        {
            this.db.TransportCompanySet.Add(tcs);
            this.db.SaveChanges();
            IDCompany = tcs.IdTransportCompany;
            return RedirectToAction("CreateAdminCompany", "Admin");
        }

        [HttpGet]
        public ActionResult CreateAdminCompany()
        {
            return View();
        }

        #region CreateAdminCompany

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public async System.Threading.Tasks.Task<ActionResult> CreateAdminCompany(Models.RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "Company");

                    var adminTC = new AdminTransportCompany
                    {
                        UserId = user.Id,
                        IdTransportCompany = IDCompany
                    };

                    this.db.AdminTransportCompany.Add(adminTC);
                    this.db.SaveChanges();

                    return RedirectToAction("Company", "Admin");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        #endregion

        public ActionResult Car(int id)
        {
            var cars = db.CarSet.Where(x => x.IdTransportCompany == id).ToList();
            return PartialView(cars);
        }

        public ActionResult Driver(int id)
        {
            var drivers = db.DriversSet.Where(x => x.IdTransportCompany == id).ToList();
            return PartialView(drivers);
        }

        public ActionResult Routes(int id)
        {
            var routes = db.DataRoutesSet.Where(x => x.IdTransportCompany == id).ToList();
            return PartialView(routes);
        }

        public ActionResult Delete(int id)
        {

            ViewBag.IdTc = id;
            Models.TransportCompanySet tc = db.TransportCompanySet.FirstOrDefault(x => x.IdTransportCompany == id);
            return PartialView(tc);
        }

        
        public ActionResult DeleteTC(int id)
        {

           

            Models.TransportCompanySet tcs = db.TransportCompanySet.FirstOrDefault(x => x.IdTransportCompany == id);
            this.db.TransportCompanySet.Remove(tcs);
            this.db.SaveChanges();

            var adminTC = db.AdminTransportCompany.Where(i => i.IdTransportCompany == id).ToList();

            foreach( var admin in adminTC)
            {
                var adm = db.Users.Find(admin.UserId);
                this.db.Users.Remove(adm);
                this.db.SaveChanges();
            }

            return RedirectToAction("Company");
        }
    }
}