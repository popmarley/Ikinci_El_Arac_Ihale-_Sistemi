using İkinciElAracİhale.UI.Models;
using İkinciElAracİhale.UI.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace İkinciElAracİhale.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string username, string pass, Kullanici kullanici)
        {
            UserDAL userDal = new UserDAL();
            var user = userDal.KullaniciGetir(username, pass);

            if (user != null)
            {
                if (user.RolID == 1 || user.RolID == 3) // Kullanıcının rolü 1 veya 3 ise giriş yapabilir
                {
                    FormsAuthentication.SetAuthCookie(username, true);

                    var menuName = userDal.RoleGoreMenuGetir(user.RolID);
                    Session["RolID"] = user.RolID; // Kullanıcının RolID'sini Session'a atama
                    Session["MenuNames"] = menuName;
                    Session["Ad"] = user.Ad; // Kullanıcının adını ve soyadını Session'a atama

                    if (user.RolID == 1)
                    {
                        Session["RoleName"] = "Admin";
                    }
                    else if (user.RolID == 3)
                    {
                        Session["RoleName"] = "PlusAdmin";
                    }

                    return RedirectToAction("_AracListeleme", "AdminPanel");
                }
                else
                {
                    ViewBag.Error = "Bu sayfaya sadece yönetici ve yetkili kullanıcılar giriş yapabilir!";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı!";
                return View();
            }
        }
        public ActionResult Logout()
        {
            // Oturum sonlandırma işlemi
            FormsAuthentication.SignOut();

            // Login sayfasına yönlendirme
            return RedirectToAction("Login");
        }
    }
}