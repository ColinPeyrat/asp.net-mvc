using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SondageSoiree.Models.Metadata;
using System.ComponentModel.DataAnnotations;

namespace SondageSoiree.Models.Entity
{
     
    [MetadataType(typeof(EleveMetadata))]
    public partial class Eleve:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var valid = new List<ValidationResult>();
            if (Password.Length < 6)
                valid.Add(new ValidationResult("Le mot de passe doit être suppérieure à 6 caractères", new[] { "Password" }));
            return valid;
        }
    }
}