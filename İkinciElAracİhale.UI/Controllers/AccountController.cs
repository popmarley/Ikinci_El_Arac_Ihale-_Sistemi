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

        public ActionResult Login(string username, string pass)
        {
            UserDAL userDal = new UserDAL();
            var user = userDal.KullaniciGetir(username, pass);

            if (user != null)
            {
                if (user.RolID == 1) // Sadece yönetici rolüne sahip kullanıcılar yönetici paneline erişebilir
                {
                    FormsAuthentication.SetAuthCookie(username, false);

                    Session["Ad"] = user.Ad; // Kullanıcının adını ve soyadını Session'a atama
                    return RedirectToAction("_AracListeleme", "AdminPanel");
                }
                else
                {
                    ViewBag.Error = "Bu sayfaya sadece yönetici girişi yapabilir!";
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