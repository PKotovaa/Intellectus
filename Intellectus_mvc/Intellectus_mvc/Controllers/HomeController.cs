using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intellectus_mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            CompanyAuthManager.Authenticate(name, password);

            if (CompanyAuthManager.LoggedCompany == null)
            {
                ModelState.AddModelError("authenticationFailed", "Wrong username or password!");
                ViewData["name"] = name;
            }
           
            else
            {
                return RedirectToAction("Details", "Companies", new { id = CompanyAuthManager.LoggedCompany.Id });
            }

            return RedirectToAction("Index", "Companies");
        }

        public ActionResult Logout()
        {
            if (CompanyAuthManager.LoggedCompany == null)
                return RedirectToAction("Login", "Home");

            CompanyAuthManager.Logout();

            return RedirectToAction("Login", "Home");
        }
    }
}