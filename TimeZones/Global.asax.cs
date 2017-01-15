using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System;

namespace TimeZones
{
	public class Global : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}

		protected void Application_Error(object sender, EventArgs e)
		{
			Exception ex = Server.GetLastError();

			if (ex.Message == "File does not exist.")
			{
				throw new Exception(string.Format("{0} {1}", ex.Message, HttpContext.Current.Request.Url.ToString()), ex);
			}
		}
	}
}
