using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SondageSoiree.Models.Entity;

namespace SondageSoiree.Models
{
   
    public class Resultat
    {
        private String nom;

        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private int nbVote;

        public int NbVote
        {
            get { return nbVote; }
            set { nbVote = value; }
        }
        
        
    }
}