using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net_Bootcamp_Asp_Exo.Domain.Entities;
using System.Reflection.Emit;

namespace Net_Bootcamp_Asp_Exo.DAL.Data.Config
{
    public class UtilisateurConfig : IEntityTypeConfiguration<Utilisateur>
    {
        public void Configure(EntityTypeBuilder<Utilisateur> builder)
        {
           
            builder.HasIndex(u => u.Email).IsUnique();

            builder.ToTable(u => u.HasCheckConstraint("CK_Utilisateur_Password", "[Password] LIKE '%[A-Z]%' " +
                                                                                 "AND [Password] LIKE '%[a-z]%' " +
                                                                                 "AND [Password] LIKE '%[0-9]%' " +
                                                                                 "AND [Password] LIKE '%[@#$%^&+=!]%' " +
                                                                                 "AND LEN([Password]) >= 8 " 
                                                      ));

            //builder.Property(u => u.Role).HasConversion<string>();
        }
    }
}
