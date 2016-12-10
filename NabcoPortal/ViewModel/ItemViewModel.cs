using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using Microsoft.Owin.Security.Provider;
using NabcoPortal.ItemMaster.Domain.Model;

namespace NabcoPortal.ViewModel
{


    public class ItemViewModel
    {

        public static IEnumerable<ItemViewModel> CreateRange(IEnumerable<Item> items)
        {
            var mv = new List<ItemViewModel>();

            foreach (var item in items)
            {
                mv.Add(new ItemViewModel
                {
                    Id = item.Id,
                    ModelNo = item.ModelNo,
                    FinishingCode = item.FinishingCode,
                    Name = item.Name,
                    Composition = item.Composition,
                    UOM = item.UOM,
                    IsActive = item.IsActive
                });
            }
            return mv;
        }


        public ItemViewModel()
        {
            ItemStatusInfo = new ItemStatusInfo(0,0,0,0,0,0,0);
            this.Id = 0;
        }

        public int Id { get; set; }

        [Required]
        public string ModelNo { get; set; }

        [Required]
        public string FinishingCode { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Composition { get; set; }

        public string Description { get { return Composition + " " + ModelNo + " " + FinishingCode; } }
        
        [Required]
        public string UOM { get; set; }

        public bool IsActive { get; private set; }

        public string ActionUrl { get; set; }

        public ItemStatusInfo ItemStatusInfo { get; set; }  



    }

    public class ItemStatusInfo
    {

        public ItemStatusInfo(int orderQty,int readyForShippingQty,
            int woodWorkingQty,int curvingQty,int assemblyQty,
            int finishingQty,int shippedQty)
        {
            this.OrderQty = orderQty;
            this.ReadyForShippingQty = readyForShippingQty;
            this.WoodWorkingQty = woodWorkingQty;
            this.CurvingQty = curvingQty;
            this.AssemblyQty = assemblyQty;
            this.FinishingQty = finishingQty;
            this.ShippedQty = shippedQty;
        }

        public int OrderQty { get; private set; }

        public int ReadyForShippingQty { get; private set; }

        public int WoodWorkingQty { get; private set; }

        public int CurvingQty { get; private set; }

        public int AssemblyQty { get; private set; }

        public int FinishingQty { get; private set; }

        public int ShippedQty { get; private set; }

    }
}