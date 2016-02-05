using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace SondageSoiree.Controllers
{
    public class PhotoController : Controller
    {
        // GET: Photo
        public ActionResult Index()
        {
            return View();
        }
        public string AfficherResultat(string date)
        {
            DateTime d = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            return "Il n'existe pas de photo à cet te date " + d.ToString();
        }
    }
}