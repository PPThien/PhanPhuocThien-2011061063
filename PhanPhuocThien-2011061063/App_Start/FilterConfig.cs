using System.Web;
using System.Web.Mvc;

namespace PhanPhuocThien_2011061063
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
