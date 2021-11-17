using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using BookShop.Data.Infastructure;
using BookShop.Data.Repositories;
using BookShop.Service;
using BookShop.Data;
using System.Web.Mvc;
using System.Web.Http;
using Autofac.Integration.WebApi;

[assembly: OwinStartup(typeof(BookShop.Web.App_Start.Startup))]

namespace BookShop.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigAutoFac(app);
        }
        private void ConfigAutoFac(IAppBuilder app)
        {
            //config nhu sau
            var builder = new ContainerBuilder();
            //Day moi Register cho controllerr
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //Can Register cho WEB API nua
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Khoi tao Repository va UnitOfWokr 
            // Moi khi class nao dc khoi tao thi no se RegisterType se tu type den
            //co che ko can khoi tao van co dung
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DBFactory>().As<IDBFactory>().InstancePerRequest();
            builder.RegisterType<BookShopDBConText>().AsSelf().InstancePerRequest();

            //Repositories
            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();


            //Service
            //Lay tat ca cac hau to co ten Service
            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();//no se lay cac Implement cua cac interface 
                                                                //sau do no khoi tao cac implement do.

            //Sau khi no implement tat cac nhu implement UnitOfWork , DBFactory, BookShopDBContext, Reposioty,Service
            //Thi ta can tao ra 1 cai thung chua

            //Dau tien gan vao thung cua Autofac
            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));//Thay the DependencyR mac dinh cua web bang AutofactDependency


            //Set cho WEB API Golbal COnfig
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver

        }
    }
}
