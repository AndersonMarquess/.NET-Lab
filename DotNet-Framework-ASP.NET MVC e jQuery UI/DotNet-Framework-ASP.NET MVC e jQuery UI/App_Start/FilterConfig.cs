using System.Web;
using System.Web.Mvc;

namespace DotNet_Framework_ASP.NET_MVC_e_jQuery_UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
