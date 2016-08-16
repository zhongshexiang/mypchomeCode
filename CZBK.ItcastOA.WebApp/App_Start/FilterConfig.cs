using CZBK.ItcastOA.WebApp.Models;
using System.Web;
using System.Web.Mvc;

namespace CZBK.ItcastOA.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MvcHandleErrorAttribute());
            filters.Add(new MvcActionFilterAttribute());
            //禁止匿名访问
            filters.Add(new System.Web.Mvc.AuthorizeAttribute());
        }
    }
}