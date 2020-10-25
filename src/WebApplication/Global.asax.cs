using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (!Request.IsLocal && (
                Request.Url.AbsoluteUri == "http://www.ecoaprender.com.br/Escola-De-Educacao-Infantil-No-Jd-Analia-Franco" ||
                Request.Url.AbsoluteUri == "http://www.ecoaprender.com.br/Escola-De-Educacao-Infantil-No-Jd-Analia-Franco/" ||
                (!Request.Url.Host.StartsWith("www") && !Request.Url.IsLoopback)))
            {
                Response.StatusCode = 301;
                Response.RedirectPermanent("http://www.ecoaprender.com.br");
            }

            var uriBuilder = new UriBuilder(Request.Url)
            {
                Scheme = Uri.UriSchemeHttp,
                Port = -1 // default port for scheme
            };
        }
    }
}
