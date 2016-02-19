using SondageSoiree.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SondageSoiree.Models.DAL;
using System.Net;

namespace SondageSoiree.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IDal dal;
        public RestaurantController(IDal dal)
        {
            this.dal = dal;
        }
        // GET: Restaurant
        public ActionResult Index()
        {
            return View(dal.RenvoieTousLesRestaurants());
        }

        [HttpGet]
        public ActionResult CreerRestaurant()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreerRestaurant(Restaurant poResto)
        {

            if (dal.RestaurantExist(poResto.Nom))
            {
                ModelState.AddModelError(string.Empty, "Ce restaurant existe déja");
            }
            if (ModelState.IsValid)
            {
                dal.CreerRestaurant(poResto.Nom, poResto.Adresse, poResto.Telephone, poResto.Email);
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
           
        }
        public ActionResult AfficherRestaurant(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = dal.RenvoieRestaurant((int)id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }
        public ActionResult ModifierRestaurant(int id)
        {
            Restaurant restaurant = dal.RenvoieRestaurant(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(restaurant);

            }
        }
        [HttpPost]
        public ActionResult ModifierRestaurant(int id, Restaurant poRestau)
        {
            if (ModelState.IsValid)
            {
                dal.ModifierRestaurant(poRestau.Id, poRestau.Nom, poRestau.Adresse, poRestau.Telephone, poRestau.Email);
                return RedirectToAction("AfficherRestaurant", new { id = poRestau.Id });
            }
            return View();
        }
    }
}