using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    public class UtilisateurRepositoryAdo : IUtilisateurRepository
    {
        private readonly string _conn;

        public UtilisateurRepositoryAdo(IConfiguration configuration)
        {
            _conn = configuration.GetConnectionString("DefaultConnection");
        }


        public Utilisateur Create(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }

        public List<Utilisateur> GetAll()
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();

            using(SqlConnection conn = new SqlConnection(_conn))
            {
                using (SqlCommand cmd = conn.CreateCommand()) 
                {
                    cmd.CommandText = "SELECT * FROM UTILISATEURS";

                    conn.Open();

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            utilisateurs.Add(new Utilisateur
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nom = "ADO "+ Convert.ToString(reader["Nom"]),
                                Prenom = Convert.ToString(reader["Prenom"]),
                                Email = Convert.ToString(reader["Email"]),
                                Password = Convert.ToString(reader["Password"]),
                                Role = (Role)reader["Role"]

                            });
                        }

                    }
                }
                return utilisateurs;
            }
        }

        public Utilisateur Update(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }
    }
}
