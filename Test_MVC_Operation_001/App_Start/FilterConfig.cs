using System.Web;
using System.Web.Mvc;

namespace Test_MVC_Operation_001
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
