using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Loja.ProjetoDDD.Infra.CrossCutting.MvcFilters
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            /*Aqui pode ser inserido um LOG de auditoria para
             saber se tal usuário add alguma informação
             posso colocar a manipulação do erro como abaixo :*/

            if (filterContext.Exception != null)
            {
                /* Manipular a EX
                 Injetar alguma LIB de tratamento de erro
                 -> gravar LOg de erro
                 -> Email para o admin
                 -> Retornar cod de erro amigavel*/

            }
            base.OnActionExecuted(filterContext);
        }
    }
}
