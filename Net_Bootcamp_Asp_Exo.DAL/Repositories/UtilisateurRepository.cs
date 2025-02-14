using Microsoft.EntityFrameworkCore;
using Net_Bootcamp_Asp_Exo.DAL.Data;
using Net_Bootcamp_Asp_Exo.DAL.Interfaces;
using Net_Bootcamp_Asp_Exo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_Bootcamp_Asp_Exo.DAL.Repositories
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly DataContext _dc;

        public UtilisateurRepository(DataContext dc)
        {
            _dc = dc;
        }


        public Utilisateur Create(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Utilisateur utilisateur)
        {
            _dc.Remove(utilisateur);
            _dc.SaveChanges();
            return _dc.Utilisateurs.Find(utilisateur.Id) is null ? true : false;
        }

        public List<Utilisateur> GetAll()
        {
            return _dc.Utilisateurs.OrderBy(u => u.Nom).ToList();
        }

        public Utilisateur GetById(int id)
        {
            return _dc.Utilisateurs.Find(id);
        }

        public Utilisateur Update(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }
    }
}
