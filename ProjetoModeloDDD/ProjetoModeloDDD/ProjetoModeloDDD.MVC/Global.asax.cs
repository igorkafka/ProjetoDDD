using AutoMapper;
using ProjetoModeloDDD.MVC.App_Start;
using ProjetoModeloDDD.MVC.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProjetoModeloDDD.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            SimpleInjectorConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(x => {
                x.AddProfile<DomainToViewModelProfile>();
                x.AddProfile<ViewModelToDomainProfile>();
                });
        }
    }
}
