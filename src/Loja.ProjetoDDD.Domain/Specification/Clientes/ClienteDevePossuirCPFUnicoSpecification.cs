using DomainValidation.Interfaces.Specification;
using Loja.ProjetoDDD.Domain.Entites;
using Loja.ProjetoDDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Domain.Specification.Clientes
{
    public class ClienteDevePossuirCPFUnicoSpecification : ISpecification<Cliente>
    {

        private readonly IFiliacaoRepository _filiacaoRepository;

        public ClienteDevePossuirCPFUnicoSpecification(IFiliacaoRepository filiacaoRepository)
        {
            _filiacaoRepository = filiacaoRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _filiacaoRepository.ObterPorCpf(cliente.CPF.Numero) == null;
        }
    }
}
