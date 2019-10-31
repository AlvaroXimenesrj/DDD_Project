using DomainValidation.Validation;
using Loja.ProjetoDDD.Domain.Specification.Clientes;
using Loja.ProjetoDDD.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Domain.Entites
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
            Enderecos = new List<Endereco>();
            
        }

        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public CPF CPF { get; set; }
        public Email Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        /*ICollection e não IEnumerable? porque o IEnumerable apenas lista os
         objetos, não tem como manipula-los, tipo adicinando, removendo etc*/
        public virtual ICollection<Endereco> Enderecos { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool EhValido()
        {
            ValidationResult = new ClienteEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
