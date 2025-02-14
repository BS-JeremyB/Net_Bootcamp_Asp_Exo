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



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DB_ENTITY_BOOTCAMP_NET_Exo;Integrated Security=True;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UtilisateurConfig());

            
        }
    }
}
