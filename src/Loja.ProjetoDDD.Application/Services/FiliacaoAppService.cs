using AutoMapper;
using Loja.ProjetoDDD.Application.Interfaces;
using Loja.ProjetoDDD.Application.ViewModels;
using Loja.ProjetoDDD.Domain.Entites;
using Loja.ProjetoDDD.Domain.Interfaces.Services;
using Loja.ProjetoDDD.Domain.Repository;
using Loja.ProjetoDDD.Infra.Data.Repository;
using Loja.ProjetoDDD.Infra.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Application.Services
{


    /*
    public class FiliacaoAppService : IFiliacaoAppService
     {

         private readonly IFiliacaoService _filiacaoService;


         public FiliacaoAppService(IFiliacaoService filiacaoService)
         {
             _filiacaoService = filiacaoService;
         }
         */
    // 2. Após o UnitOfWork:

    public class FiliacaoAppService : AppService, IFiliacaoAppService
    {

        private readonly IFiliacaoService _filiacaoService;


        public FiliacaoAppService(IFiliacaoService filiacaoService, IUnitOfWork uow)
            :base(uow)
        {
            _filiacaoService = filiacaoService;
        }



        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.ClienteViewModel);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel.EnderecoViewModel);

            cliente.Enderecos.Add(endereco);


            //Se o domínio não reclamar, OK!
            var clienteReturn = _filiacaoService.Adicionar(cliente);

            if (clienteReturn.ValidationResult.IsValid)
            {
                Commit();
            }

            clienteEnderecoViewModel.ClienteViewModel = Mapper.Map<ClienteViewModel>(clienteReturn);

            return clienteEnderecoViewModel;
        }


        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_filiacaoService.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_filiacaoService.ObterTodos());
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_filiacaoService.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_filiacaoService.ObterPorEmail(email));
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            var clienteReturn = _filiacaoService.Atualizar(cliente);
            return Mapper.Map<ClienteViewModel>(clienteReturn);

        }

        public void Remover(Guid id)
        {
            _filiacaoService.Remover(id);
        }

        public void Dispose()
        {
            _filiacaoService.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
