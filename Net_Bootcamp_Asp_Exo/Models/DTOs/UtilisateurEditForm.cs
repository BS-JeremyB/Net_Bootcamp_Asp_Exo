using Net_Bootcamp_Asp_Exo.Domain.Entities;
using Net_Bootcamp_Asp_Exo.Validations;
using System.ComponentModel.DataAnnotations;

namespace Net_Bootcamp_Asp_Exo.Models.DTOs
{
    public class UtilisateurEditForm
    {
        public int Id { get; set; }

    
        public string Nom { get; set; }


        public string Prenom { get; set; }

        [EmailAddress(ErrorMessage = "Email invalide.")]
        public string Email { get; set; }

        [OptionalPasswordRegex(ErrorMessage = "Le mot de passe doit contenir au moins 1 Maj, 1 Min, 1 chiffre, 1 char spécial (8-25).")]
        public string? Password { get; set; }

        [Compare("Password")]
        public string? PasswordConfirm { get; set; }

        public Role Role { get; set; }
    }
}
