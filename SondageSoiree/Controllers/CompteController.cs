using SondageSoiree.Models.Entity;
using System;
using System.Collections.Generic;
using SondageSoiree.Models.DAL;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace SondageSoiree.Controllers
{
    public class CompteController : Controller
    {
        private readonly IDal dal;
        public CompteController(IDal dal)
        {
            this.dal = dal;
        }

        // GET: Compte
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        // GET: Compte
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Eleve poEleve)
        {
            using (var dal = new Dal())
            {
                if (dal.VerificationConnexionEleve(poEleve.Nom, poEleve.Password))
                    IdentitySignin(poEleve);
                else
                    ModelState.AddModelError(String.Empty, "L'éléve éxiste déjà");
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult CreerCompte(Eleve poEleve)
        {
            using (var dal = new Dal())
            {
                if (dal.EleveExist(poEleve.Nom))
                    ModelState.AddModelError(String.Empty, "L'éléve éxiste déjà");
                else
                    if (ModelState.IsValid)
                    {
                        dal.AjouterEtudiant(poEleve.Nom, poEleve.Prenom, poEleve.Password);
                        return RedirectToAction("login");
                    }
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreerCompte()
        {
            return View();
        }

        private void IdentitySignin(Eleve eleve)
        {

            var claims = new List<Claim>();

            // create required claims
            claims.Add(new Claim(ClaimTypes.NameIdentifier, eleve.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, eleve.Nom));
            var identity = new ClaimsIdentity(claims,
            DefaultAuthenticationTypes.ApplicationCookie);
            HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties()

            {

                AllowRefresh = true,
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)

            }, identity);

        }

        private void IdentitySignout()
        {

            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie,
             DefaultAuthenticationTypes.ExternalCookie);

        }
    }
}