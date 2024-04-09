using System.Web;
using System.Web.Mvc;

namespace NgoThanhTien_2001200542_WebKFC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
