using AutoMapper;
using NewsSystem.Models;
using NewsSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NewsSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Article, ArticleViewModel>().ForMember(vm => vm.Content, cfg => cfg.MapFrom(a => a.Content.Substring(0, 150) + "..."))
                .ForMember(vm => vm.Title, cfg => cfg.MapFrom(a => a.Title.Substring(0, 45) + "..."))
                .ForMember(vm => vm.CreationDate, cfg => cfg.MapFrom(d => d.CreationDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));

                expression.CreateMap<Category, CategoryViewModel>();

                expression.CreateMap<ArticleViewModel, Article>()
                        .ForMember(vm => vm.CreationDate, cfg => cfg.MapFrom(d => DateTime.ParseExact(d.CreationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                //expression.CreateMap<Car, CarVm>();
                //expression.CreateMap<Supplier, SupplierVm>()
                //    .ForMember(vm => vm.NumberOfPartsToSupply,
                //        configurationExpression =>
                //            configurationExpression.MapFrom(supplier => supplier.Parts.Count));
                //expression.CreateMap<Part, PartVm>();
                //expression.CreateMap<Sale, SaleVm>()
                //.ForMember(vm => vm.Price,
                //    configurationExpression =>
                //    configurationExpression.MapFrom(sale =>
                //            sale.Car.Parts.Sum(part => part.Price)));
            });
        }
    }
}
