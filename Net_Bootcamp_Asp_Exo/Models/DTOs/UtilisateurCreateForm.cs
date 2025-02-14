using Net_Bootcamp_Asp_Exo.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Net_Bootcamp_Asp_Exo.Models.DTOs
{
    public class UtilisateurCreateForm
    {
        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email invalide.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=!]).{8,25}$", ErrorMessage = "Le mot de passe doit contenir au moins 1 Maj, 1 Min, 1 chiffre, 1 car spécial")]

        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }

        public Role Role { get; set; } = Role.Utilisateur;
    }
}
