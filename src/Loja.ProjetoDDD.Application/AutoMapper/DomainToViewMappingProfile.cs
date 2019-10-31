using AutoMapper;
using Loja.ProjetoDDD.Application.ViewModels;
using Loja.ProjetoDDD.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Application.AutoMapper
{
    public class DomainToViewMappingProfile : Profile
    {
        protected override void Configure()
        {   /*Abaixo o método CreateMap que vai pegar o que você quer (Cliente) e
            tranformar no que você quer (ClienteViewModel)
            OBS: de Domínio para View Model*/
            CreateMap<Cliente, ClienteViewModel>()
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF.Numero))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.endereco));

            CreateMap<Cliente, ClienteEnderecoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Endereco, ClienteEnderecoViewModel>();
        }
    }
}