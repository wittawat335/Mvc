using System.Web;
using System.Web.Mvc;
using ShoppingComplex.Controllers;

namespace ShoppingComplex
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SecurityActionFilterAttribute());
        }
    }
}
