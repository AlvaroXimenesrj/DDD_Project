using AutoMapper;
using Loja.ProjetoDDD.Application.ViewModels;
using Loja.ProjetoDDD.Domain.Entites;
using Loja.ProjetoDDD.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {   /*Aqui já de ViewModel para dominio

            */
            CreateMap<ClienteViewModel, Cliente>()
                .ForMember(x => x.CPF, opt => opt.ResolveUsing(model => new CPF() { Numero = model.CPF }))
                .ForMember(x => x.Email, opt => opt.ResolveUsing(model => new Email() { endereco = model.Email }));
            CreateMap<ClienteEnderecoViewModel, Cliente>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<ClienteEnderecoViewModel, Endereco>();
        }

    }
}
