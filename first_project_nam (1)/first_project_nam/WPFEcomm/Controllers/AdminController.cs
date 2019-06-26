using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL1;
using BOL;
namespace EComWFE.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Product()
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
                return Redirect(returnUrl ?? Url.Action("Product", "Admin"));//(actionMethod,controller)
            }
            else
            {
                return View();
            }
        }
            public ActionResult Register()
            {
                return View();
            }
        [HttpPost]
            public ActionResult Register(int Id, string Email, string Password, string returnUrl)
            {
            if(Admin.RegisterAdmin(Id,Email,Password))
            {
                return Redirect(returnUrl ?? Url.Action("Login", "Admin"));
            }
            else
            {
                return View();
            }
            }
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(int Id,string Password,string returl)
        {
            if(Admin.Update(Id,Password))
            {
                return Redirect(returl ?? Url.Action("Login", "Admin"));
            }
            else { return View(); }
           
        }
        public ActionResult delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult delete(int Id,string returl)
        {
            if(Admin.Delete(Id))
            {
                return Redirect(returl ?? Url.Action("Login", "Admin"));
            }
            return View();
        }

    }


     
  }
