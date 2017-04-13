using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace testWebAPI.App_Start
{
    /// <summary>
    /// DI設定檔
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// 註冊DI注入物件資料
        /// </summary>
        public static void Register()
        {
            // 容器建立者
            var builder = new ContainerBuilder();
            // 註冊Web API Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // 註冊相依關係
            //builder.Register(c => new DT311_ACode_Repository()).As<IDT311_ACode_Repository>().InstancePerRequest();
            
            var dataAccess = Assembly.GetExecutingAssembly();
            //掃描所有Repository設定
            builder.RegisterAssemblyTypes(dataAccess)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces();
            // 建立容器
            var container = builder.Build();
            // 建立相依解析器
            var resolver = new AutofacWebApiDependencyResolver(container);
            // 組態Web API相依解析器
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}