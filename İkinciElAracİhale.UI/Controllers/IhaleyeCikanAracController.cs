using İkinciElAracİhale.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Controllers
{
    public class IhaleyeCikanAracController : Controller
    {
        // GET: IhaleyeCikanArac

        AracIhale db = new AracIhale();

        [Authorize]
        public ActionResult _IhaleyeCikanAraclar()
        {
            return View();
        }
    }
}