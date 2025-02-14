using Microsoft.EntityFrameworkCore;
using Net_Bootcamp_Asp_Exo.DAL.Data;
using Net_Bootcamp_Asp_Exo.DAL.Interfaces;
using Net_Bootcamp_Asp_Exo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
            _dc.Utilisateurs.Add(utilisateur);
            _dc.SaveChanges();
            return utilisateur;
        }

        public bool Delete(Utilisateur utilisateur)
        {
            _dc.Utilisateurs.Remove(utilisateur);
            _dc.SaveChanges();
            return _dc.Utilisateurs.Find(utilisateur.Id) == null;
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
            _dc.Utilisateurs.Update(utilisateur);
            _dc.SaveChanges();
            return utilisateur;
        }
    }
}
