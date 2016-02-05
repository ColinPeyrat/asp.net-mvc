using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SondageSoiree;
using SondageSoiree.Models;
using SondageSoiree.Models.Entity;
using SondageSoiree.Models.DAL;

namespace SondageSoiree.Models.DAL
{
    public class Dal:IDal
    {
        private SoireeContext sctx;
        public Dal()
        {
            sctx = new SoireeContext();

      
        }
        public void Dispose()
        {
            sctx.Dispose();
        }

        public int AjouterEtudiant(string nom, string prenom, string password)
        {
            throw new NotImplementedException();
        }

        public int AjouterVote(int idSondage, int idResto, int idEtudiant)
        {
            throw new NotImplementedException();
        }

        public Eleve Authentifier(string nom, string password)
        {
            throw new NotImplementedException();
        }

        public int CreerRestaurant(string nom, string adresse, string telephone, string email)
        {
            
            Restaurant restaurant = new Restaurant() 
            { 
                Nom=nom,
                Adresse=adresse,
                Telephone=telephone,
                Email=email
            };

            sctx.Restaurants.Add(restaurant);
            sctx.SaveChanges();
          
            return restaurant.Id;
        }

        public int CreerSondage(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void ModifierRestaurant(int idResto, string nom, string adresse, string telephone, string email)
        {
            var result = sctx.Restaurants.SingleOrDefault(r => r.Id == idResto);
            if (result != null)
            {
                result.Nom = nom;
                result.Adresse = adresse;
                result.Telephone = telephone;
                result.Email = email;
                sctx.SaveChanges();
            }

        }

        public Eleve RenvoieEtudiant(int idEtudiant)
        {
            throw new NotImplementedException();
        }

        public IList<Resultat> RenvoieResultat(int idSondage)
        {
            throw new NotImplementedException();
        }

        public IList<Restaurant> RenvoieTousLesRestaurants()
        {
            return sctx.Restaurants.ToList();
        }

        public Restaurant RenvoieRestaurant(int idRestaurant)
        {
            return (Restaurant)sctx.Restaurants.Where(r => r.Id == idRestaurant).SingleOrDefault();
        }

        public bool RestaurantExist(string nom)
        {
            var restaurantCounts = sctx.Restaurants.Count(r => r.Nom == nom);
            if (restaurantCounts > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

          
        }

        public bool VoteExist(int idSondage, int idEtudiant)
        {
            throw new NotImplementedException();
        }
    }
}