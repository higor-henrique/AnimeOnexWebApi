using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AnimeOnexWebAPI
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Serviços e configuração da API da Web

			// Rotas da API da Web
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
			config.EnableCors();


			////aparentemente para serializar o json 
			var json = config.Formatters.JsonFormatter;
			json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
			config.Formatters.Remove(config.Formatters.XmlFormatter);
			//var jsonFormater = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
			//jsonFormater.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
		}
	}
}
