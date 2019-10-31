using Loja.ProjetoDDD.Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);
                

            Property(c => c.CPF.Numero)
                 .HasColumnName("CPF")
                 .IsRequired()
                 .HasMaxLength(11)
                 .IsFixedLength()
                 .HasColumnAnnotation("Index", new IndexAnnotation(
                     new IndexAttribute("IX_CPF") { IsUnique = true }));

            Property(c => c.Email.endereco)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(100);


            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            Ignore(c => c.ValidationResult);

            ToTable("Clientes", "Sistema");

        }
    }
}
