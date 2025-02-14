using Net_Bootcamp_Asp_Exo.BLL.Interfaces;
using Net_Bootcamp_Asp_Exo.DAL.Interfaces;
using Net_Bootcamp_Asp_Exo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_Bootcamp_Asp_Exo.BLL.Services
{
    public class UtilisateurService : IUtilisateurService
    {

        private readonly IUtilisateurRepository _repository;

        public UtilisateurService(IUtilisateurRepository repository)
        {
            _repository = repository;
        }

        public IUtilisateurRepository GetRepository() => _repository;

        public Utilisateur Create(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
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

        public List<Utilisateur> GetAll()
        {
            return _repository.GetAll();
        }

        public Utilisateur Update(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }
    }
}
