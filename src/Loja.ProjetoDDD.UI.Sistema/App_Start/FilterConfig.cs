using Loja.ProjetoDDD.Infra.CrossCutting.MvcFilters;
using System.Web;
using System.Web.Mvc;

namespace Loja.ProjetoDDD.UI.Sistema
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorHandler());

        }
    }
}
