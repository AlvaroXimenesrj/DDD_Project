using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Loja.ProjetoDDD.UI.Sistema.Helpers
{
    public static class PermissionHelper
    { /*Extension metodo é metodo de extensao por exemplo a classe MvcHtmlString é
        uma classe do CSharp amas eu posso colocar alguns métodos, dentro dessa classe
        mesmo que essa classe não seja minha, e no caso são o claimName e a claimValue
        o WebViewPage é a view do Mvc. 
        método que valida ap ermissão segundo os métodos do usuário*/

        public static MvcHtmlString IfClaimHelper(this MvcHtmlString value, string claimName, string claimValue)
        {
            return ValidadePermission(claimName, claimValue) ? value : MvcHtmlString.Empty;
        }

        public static bool IfClaim(this WebViewPage page, string claimName, string claimValue)
        {
            return ValidadePermission(claimName, claimValue);
        }

        private static bool ValidadePermission(string claimName, string claimValue)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claim = identity.Claims.FirstOrDefault(c => c.Type == claimName);
            return claim != null && claim.Value.Contains(claimValue);
        }

    }
}
