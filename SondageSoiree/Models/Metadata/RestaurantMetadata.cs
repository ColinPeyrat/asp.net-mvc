using System;
using System.ComponentModel.DataAnnotations;

namespace SondageSoiree.Models.Metadata
{
    public class RestaurantMetadata
    {
        [Required]
        [StringLength(100)]
        public string Nom;

        [EmailAddress]
        [StringLength(150)]
        public string Email;

        [Required]
        [StringLength(250)]
        public string Adresse;

		[Phone]
        [StringLength(20)]
        [Display(Name = "Téléphone")]
        public string Telephone;
    }
}