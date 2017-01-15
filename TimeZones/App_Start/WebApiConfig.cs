using System.Web.Http;

namespace TimeZones
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApiWithId",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);


			// TODO: check if a new version of TZDB is available, and if so, update NodaTime's embedded version
			// using NodaTime.TzdbCompiler (binary file format)
			// For instructions, see: http://nodatime.org/developer/tzdb-file-format.html
		}
	}
}
