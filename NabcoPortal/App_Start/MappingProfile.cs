using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using NabcoPortal.ItemMaster.Domain.Model;
using NabcoPortal.ViewModel;

namespace NabcoPortal.App_Start
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Item, ItemViewModel>().ReverseMap();
        }
    }
}