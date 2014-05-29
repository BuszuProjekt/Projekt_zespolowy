using System.Web;
using System.Web.Mvc;

namespace System_rezerwacji_biletów_w_Multikinie
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}