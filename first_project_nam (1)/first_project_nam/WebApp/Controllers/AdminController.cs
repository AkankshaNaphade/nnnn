using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL1;
namespace EComWFE.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Email, string Password, string returnUrl)
        {
            if (Admin.ValidateAdmin(Email, Password))
            {
                // return   this.RedirectToAction("index", "products");
                FormsAuthentication.SetAuthCookie(Email, false);
                return Redirect(returnUrl ?? Url.Action("Index", "Home"));
            }
            else
            {
                return View();
            }
        }
    }
  }
