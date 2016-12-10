using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using NabcoPortal.ItemMaster.Domain.Model;
using NabcoPortal.ViewModel;

namespace NabcoPortal.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper;

        public static void ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemViewModel>()
                    .ReverseMap();
            });
            
            Mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();
        }
    }
}