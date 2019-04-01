using ProjetoModeloDDD.Application;
using ProjetoModeloDDD.Application.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Domain.Services;
using ProjetoModeloDDD.Infra.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void RegisterComponents()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            // register all your components with the container here 
            // it is NOT necessary to register your controllers 

            container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            container.Register<IProdutoAppService, ProdutoAppService>(Lifestyle.Scoped);

            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>));
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);

            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }
    }
}