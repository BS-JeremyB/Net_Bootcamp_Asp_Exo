using Net_Bootcamp_Asp_Exo.Models.Domain;

using Microsoft.EntityFrameworkCore;
using Net_Bootcamp_Asp_Exo.Data.Config;

namespace Net_Bootcamp_Asp_Exo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UtilisateurConfig());

            
        }
    }
}
