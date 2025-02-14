using Net_Bootcamp_Asp_Exo.BLL.Interfaces;
using Net_Bootcamp_Asp_Exo.DAL.Interfaces;
using Net_Bootcamp_Asp_Exo.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Net_Bootcamp_Asp_Exo.BLL.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IUtilisateurRepository _repository;

        public UtilisateurService(IUtilisateurRepository repository)
        {
            _repository = repository;
        }

        public List<Utilisateur> GetAll()
        {
            return _repository.GetAll();
        }

        public Utilisateur GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Utilisateur Create(Utilisateur utilisateur)
        {
            // Vérification si l'email est déjà utilisé
            bool emailExists = _repository.GetAll().Any(u => u.Email == utilisateur.Email);
            if (emailExists)
            {
                throw new InvalidOperationException("Cette adresse email est déjà utilisée.");
            }

            return _repository.Create(utilisateur);
        }

        public Utilisateur Update(int id, Utilisateur utilisateur)
        {
            Utilisateur utilisateurToUpdate = _repository.GetById(id);
            if (utilisateurToUpdate == null)
            {
                throw new KeyNotFoundException("Utilisateur non trouvé.");
            }

            // Vérifier si l'email est déjà utilisé par un autre utilisateur
            bool emailExists = _repository.GetAll().Any(u => u.Email == utilisateur.Email && u.Id != id);
            if (emailExists)
            {
                throw new InvalidOperationException("Cette adresse email est déjà utilisée.");
            }

            // Mise à jour des valeurs
            utilisateurToUpdate.Nom = utilisateur.Nom;
            utilisateurToUpdate.Prenom = utilisateur.Prenom;
            utilisateurToUpdate.Email = utilisateur.Email;
            utilisateurToUpdate.Role = utilisateur.Role;

            if (!string.IsNullOrWhiteSpace(utilisateur.Password))
            {
                utilisateurToUpdate.Password = utilisateur.Password;
            }

            return _repository.Update(utilisateurToUpdate);
        }

        public bool Delete(int id)
        {
            Utilisateur utilisateurToDelete = _repository.GetById(id);
            if (utilisateurToDelete != null)
            {
                return _repository.Delete(utilisateurToDelete);
            }
            return false;
        }
    }
}
