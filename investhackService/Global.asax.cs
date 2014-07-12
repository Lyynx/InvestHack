using System.Web.Http;
using System.Web.Routing;

namespace investhackService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register();
        }
    }
}