using Loja.ProjetoDDD.Application.Interfaces;
using Loja.ProjetoDDD.Application.Services;
using Loja.ProjetoDDD.Domain.Interfaces.Services;
using Loja.ProjetoDDD.Domain.Repository;
using Loja.ProjetoDDD.Domain.Services;
using Loja.ProjetoDDD.Infra.Data.Context;
using Loja.ProjetoDDD.Infra.Data.Repository;
using Loja.ProjetoDDD.Infra.Data.UnitOfWork;
using SimpleInjector;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Infra.CrossCutting.Ioc
{
    public class BootStrapper
    { //no registro ele receberá um container, que criaremos
        public static void Register(Container container)
        {
            /*abaixo significa que sempre que eu instanciar o IFiliacao... eu receberei 
            a classe Filiacao no lugar dela... */
            //Camada APP
            container.Register<IFiliacaoAppService, FiliacaoAppService>(Lifestyle.Scoped);

            //Camada Domain
            container.Register<IFiliacaoService, FiliacaoService>(Lifestyle.Scoped);

            //Data
            container.Register<IFiliacaoRepository, FiliacaoRepository>(Lifestyle.Scoped);

            //abaixo, antes, instalar nessa camada o EF
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<ProjetoDDDContext>(Lifestyle.Scoped);


        }
    }
}
