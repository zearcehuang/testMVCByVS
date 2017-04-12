using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using testWebAPI.Models;

namespace testWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<DT311_ACode>("CodeData");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "CodeDataApi",
            //    routeTemplate: "api/{controller}/{action}/{CODE_TYPE}/{CODE}",
            //    defaults: new { CODE_TYPE = RouteParameter.Optional, CODE = RouteParameter.Optional }
            //);
        }
    }
}
