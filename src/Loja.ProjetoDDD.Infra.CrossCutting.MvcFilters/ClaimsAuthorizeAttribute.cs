using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Loja.ProjetoDDD.Infra.CrossCutting.MvcFilters
{
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {/**/

        private readonly string _claimName;
        private readonly string _claimValue;

        public ClaimsAuthorizeAttribute(string claimName, string claimValue)
        {
            _claimName = claimName;
            _claimValue = claimValue;
        }

        protected override bool AuthorizeCore(HttpContextBase HttpContext)
        {
            var identity = (ClaimsIdentity)HttpContext.User.Identity;
            var claim = identity.Claims.FirstOrDefault(c => c.Type == _claimName);

            return claim != null && claim.Value.Contains(_claimValue);
            /*acima, ele pegará o usuário logado, vai converter para saber os claims, vai
             verificar se possui a claim que recebeu la em cima via paramtro, se possui, verá
             se o valor dela contem o que eu quero!*/
        }
        /*abaixo: manipular um request não autorizado
         se o usuário está autentica e fez login, o resultado desse filtro será um retorno
         do codigo de erro (forbidden), se nao estiver logado, mandar fazer o que já faz:
         ir para a página de login*/
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new HttpStatusCodeResult((int)HttpStatusCode.Forbidden);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}
