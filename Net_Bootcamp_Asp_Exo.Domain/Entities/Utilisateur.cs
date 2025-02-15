﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Bootcamp_Asp_Exo.Domain.Entities
{
    public enum Role
    {
        Admin,
        Utilisateur
    }
    public class Utilisateur
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
