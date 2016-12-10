using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NabcoPortal.ItemMaster.Domain.Model
{
    public class ActiveItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ModelNo { get; set; }

        public string FinishingCode { get; set; }

        public string Composition { get; set; }

        public string UOM { get; set; }

       
    }
}
