using SondageSoiree.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SondageSoiree.Models.DAL
{
    public interface IDal : IDisposable
    {

        int AjouterEtudiant(string nom, string prenom, string password);

        int AjouterVote(int idSondage, int idResto, int idEtudiant);

        Eleve Authentifier(string nom, string password);

        int CreerRestaurant(string nom, string adresse, string telephone, string email);

        int CreerSondage(DateTime date);

        void ModifierRestaurant(int idResto, string nom, string adresse, string telephone, string email);
        
        Eleve RenvoieEtudiant(int idEtudiant);

        IList<Resultat> RenvoieResultat(int idSondage);

        IList<Restaurant> RenvoieTousLesRestaurants();
		
        Restaurant RenvoieRestaurant(int idRestaurant);

        bool RestaurantExist(string nom);

        bool VoteExist(int idSondage, int idEtudiant);



    }
}
