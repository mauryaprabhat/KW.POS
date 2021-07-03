using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;
using WK.POS.Interfaces;
using WK.POS.Services;

namespace WK.POS.WebAPI.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IPointOfSaleTerminal, PointOfSaleTerminalService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityDependencyResolver(container);
        }
        
    }
}