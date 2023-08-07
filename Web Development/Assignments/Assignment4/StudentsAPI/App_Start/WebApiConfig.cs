using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace StudentsAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Default API route
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Add CORS headers to handle CORS manually
            config.MessageHandlers.Add(new CustomCorsHandler());
        }
    }
}
