﻿using İkinciElAracİhale.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Controllers
{
    public class RaporController : Controller
    {
        // GET: Rapor
        AracIhale db = new AracIhale();

        [Authorize]
        public ActionResult _BasitRapor()
        {
            return View();
        }

        [Authorize]
        public ActionResult _OrtaZorlukRapor()
        {
            return View();
        }

        [Authorize]
        public ActionResult _KompleksRapor()
        {
            return View();
        }
    }
}