using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using NabcoPortal.App_Start;
using NabcoPortal.ItemMaster.Domain.Model;
using NabcoPortal.ViewModel;
using Utilities;
using Utilities.Extension;

namespace NabcoPortal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //mapper configuration
            Mapper.Initialize(cfg => cfg.CreateMap<Item, ItemViewModel>()
                .Ignore(c => c.IsActive)
                .ReverseMap());

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
}
