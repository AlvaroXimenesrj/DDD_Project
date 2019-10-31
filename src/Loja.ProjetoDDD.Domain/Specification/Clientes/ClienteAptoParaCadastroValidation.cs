using DomainValidation.Validation;
using Loja.ProjetoDDD.Domain.Entites;
using Loja.ProjetoDDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Domain.Specification.Clientes
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {

        public ClienteAptoParaCadastroValidation(IFiliacaoRepository filiacaoRepository)
        {
            var cpfDuplicado = new ClienteDevePossuirCPFUnicoSpecification(filiacaoRepository);
            var emailDuplicado = new ClienteDevePossuirEmailUnicoSpecification(filiacaoRepository);

            base.Add("cpfDuplicado", new Rule<Cliente>(cpfDuplicado, "CPF já cadastrado!"));
            base.Add("emailDuplicado", new Rule<Cliente>(emailDuplicado, "Email já cadastrado!"));
        }
    }
}
