using Net_Bootcamp_Asp_Exo.Models.Domain;
using Net_Bootcamp_Asp_Exo.Models.DTOs;

namespace Net_Bootcamp_Asp_Exo.Mappers
{
    public static class UtilisateurMappers
    {
        public static Utilisateur ToUtilisateur(this UtilisateurCreateForm utilisateur)
        {
            return new Utilisateur
            {
                Nom = utilisateur.Nom,
                Prenom = utilisateur.Prenom,
                Email = utilisateur.Email,
                Password = utilisateur.Password,
                Role = utilisateur.Role,
            };

                
        }



        public static UtilisateurEditForm ToEditForm(this Utilisateur utilisateur)
        {
            return new UtilisateurEditForm
            {
                Id = utilisateur.Id,
                Nom = utilisateur.Nom,
                Prenom = utilisateur.Prenom,
                Email = utilisateur.Email,
                Password = utilisateur.Password,
                Role = utilisateur.Role,
            };


        }
    }
}
