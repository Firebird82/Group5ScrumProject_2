using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Group5ScrumProject.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult index()
        {
            return View(); //David
        }
        public ActionResult Login(string tbxName, string tbxPassword)
        { // Tommy2
            if (Session["User"] != null)
                return View();
            tbUser loggedInUser = (from f in db.tbUsers
                     where f.sUserLoginName == tbxName && f.sUserPassword == tbxPassword
                     select f).FirstOrDefault();

            if (loggedInUser != null)
            {
                Session["User"] = loggedInUser;
                ViewBag.User = loggedInUser;
                return View();
            }
            Session.Clear();
            if(tbxName != null && tbxPassword != null)
                ViewBag.Message = "Felaktigt användarnamn eller lösenord";
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            ViewBag.User = null;
            return View("Login");

            //Björn
        }
    }
}
