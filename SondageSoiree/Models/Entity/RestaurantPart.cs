using SondageSoiree.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SondageSoiree.Models.Entity
{
    [MetadataType(typeof(RestaurantMetadata))]
    public partial class Restaurant:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var valid = new List<ValidationResult>();
            if (string.IsNullOrWhiteSpace(Telephone) && string.IsNullOrWhiteSpace(Email))
            valid.Add( new ValidationResult("Vous devez saisir au moins un moyen de contacter le restaurant", new[] { "Telephone", "Email"}));
            return valid;
        }
    }
}