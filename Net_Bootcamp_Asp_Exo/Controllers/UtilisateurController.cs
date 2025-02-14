using Microsoft.AspNetCore.Mvc;
using Net_Bootcamp_Asp_Exo.BLL.Interfaces;
using Net_Bootcamp_Asp_Exo.Domain.Entities;
using Net_Bootcamp_Asp_Exo.Mappers;
using Net_Bootcamp_Asp_Exo.Models.DTOs;
using System;

namespace Net_Bootcamp_Asp_Exo.Controllers
{
    public class UtilisateurController : Controller
    {
        private readonly IUtilisateurService _service;

        public UtilisateurController(IUtilisateurService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll());
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

            try
            {
                _service.Create(utilisateur.ToUtilisateur());
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Email", ex.Message);
                return View(utilisateur);
            }
        }

        public IActionResult Edit(int id)
        {
            Utilisateur utilisateur = _service.GetById(id);
            if (utilisateur == null) return NotFound();

            return View(utilisateur.ToEditForm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UtilisateurEditForm utilisateur)
        {
            if (!ModelState.IsValid) return View(utilisateur);

            if (id != utilisateur.Id)
            {
                return BadRequest("L'id de la route ne correspond pas à l'id du formulaire.");
            }

            try
            {
                _service.Update(id, utilisateur.ToUtilisateur());
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Email", ex.Message);
                return View(utilisateur);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        public IActionResult Delete(int id)
        {
            Utilisateur utilisateur = _service.GetById(id);
            if (utilisateur == null) return NotFound();

            return View(utilisateur);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
