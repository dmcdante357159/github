using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using github.Models;

namespace github.Controllers
{
    public class HomeController : Controller
    {
        DBUserLoginLogoutEntities db = new DBUserLoginLogoutEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.TBUserInfoes.ToList());
        }
        public ActionResult Sigup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Sigup(TBUserInfo tBUserInfo)
        {
            if (db.TBUserInfoes.Any(x => x.username == tBUserInfo.username))
            {
                ViewBag.Notification = "This account has already exist";
                return View();
            }
            else
            {
                db.TBUserInfoes.Add(tBUserInfo);
                db.SaveChanges();

                Session["IdSS"] = tBUserInfo.Id.ToString();
                Session["usernameSS"] = tBUserInfo.username.ToString();
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TBUserInfo tBUserInfo)
        {
            var checkLogin = db.TBUserInfoes.Where(x => x.username.Equals(tBUserInfo.username) && x.passwords.Equals(tBUserInfo.passwords)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["IdSS"] = tBUserInfo.Id.ToString();
                Session["usernameSS"] = tBUserInfo.username.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Ten dang nhap hoac mat khau sai";
            }
            return View();
        }
    }
}