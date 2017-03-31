using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Mvc;

namespace Marshrutkaby.Controllers
{
    public class CompanyController : Controller
    {
        Models.ApplicationDbContext db = new Models.ApplicationDbContext();
        // GET: Company
        public ActionResult Index()
        {
            var idTC = db.AdminTransportCompany.Find(User.Identity.GetUserId());
            var company = db.TransportCompanySet.Find(idTC.IdTransportCompany);
            return View(company);
        }

        public ActionResult Drivers()
        {
            var idTC = db.AdminTransportCompany.Find(User.Identity.GetUserId());
            var company = db.TransportCompanySet.Find(idTC.IdTransportCompany);
            var drivers = db.DriversSet.Find(company.IdTransportCompany);
            
            return View(drivers);
        }
    }
}