using Microsoft.AspNetCore.Mvc;
using Net_Bootcamp_Asp_Exo.Data;
using Net_Bootcamp_Asp_Exo.Mappers;
using Net_Bootcamp_Asp_Exo.Models.Domain;
using Net_Bootcamp_Asp_Exo.Models.DTOs;
using System;

namespace Net_Bootcamp_Asp_Exo.Controllers
{
    public class UtilisateurController : Controller
    {
        private readonly DataContext _dc;
 

        public UtilisateurController(DataContext dc)
        {
            _dc = dc;
        }

        public IActionResult Index()
        {
            List<Utilisateur> utilisateurs = _dc.Utilisateurs.ToList();
            return View(utilisateurs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UtilisateurCreateForm utilisateur)
        {
            if (!ModelState.IsValid)
            {
                return View(utilisateur);
            }

            bool emailExists = _dc.Utilisateurs.Any(u => u.Email == utilisateur.Email);
            if (emailExists)
            {
                ModelState.AddModelError("Email", "Cette adresse email est déjà utilisée.");
                return View(utilisateur);
            }


            _dc.Utilisateurs.Add(utilisateur.ToUtilisateur());
            _dc.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Utilisateur utilisateur = _dc.Utilisateurs.Find(id);
            if (utilisateur == null) return NotFound();

            return View(utilisateur.ToEditForm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UtilisateurEditForm utilisateur)
        {
            if (!ModelState.IsValid) return View(utilisateur);


            bool emailExists = _dc.Utilisateurs.Any(u => u.Email == utilisateur.Email && u.Id != utilisateur.Id);
            if (emailExists)
            {
                ModelState.AddModelError("Email", "Cette adresse email est déjà utilisée.");
                return View(utilisateur);
            }

            Utilisateur utilisateurToEdit = _dc.Utilisateurs.Find(utilisateur.Id);
            if (utilisateurToEdit == null) return NotFound();


            utilisateurToEdit.Nom = utilisateur.Nom;
            utilisateurToEdit.Prenom = utilisateur.Prenom;
            utilisateurToEdit.Email = utilisateur.Email;
            utilisateurToEdit.Role = utilisateur.Role;


            if (!string.IsNullOrWhiteSpace(utilisateur.Password))
            {
                utilisateurToEdit.Password = utilisateur.Password;
            }

            _dc.Utilisateurs.Update(utilisateurToEdit);
            _dc.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            Utilisateur utilisateur = _dc.Utilisateurs.Find(id);
            if (utilisateur == null) return NotFound();

            return View(utilisateur);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Utilisateur utilisateur = _dc.Utilisateurs.Find(id);
            if (utilisateur == null) return NotFound();

            _dc.Utilisateurs.Remove(utilisateur);
            _dc.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
 