using Net_Bootcamp_Asp_Exo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_Bootcamp_Asp_Exo.DAL.Interfaces
{
    public interface IUtilisateurRepository
    {

        public List<Utilisateur> GetAll();
        public Utilisateur GetById(int id);
        public Utilisateur Create(Utilisateur utilisateur);
        public Utilisateur Update(Utilisateur utilisateur);
        public bool Delete(Utilisateur utilisateur);
    }
}
