using Net_Bootcamp_Asp_Exo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_Bootcamp_Asp_Exo.BLL.Interfaces
{
    public interface IUtilisateurService
    {
        public List<Utilisateur> GetAll();

        public Utilisateur GetById(int id);
        public Utilisateur Create(Utilisateur utilisateur);
        public Utilisateur Update(int id, Utilisateur utilisateur);
        public bool Delete(int id);
    }
}
