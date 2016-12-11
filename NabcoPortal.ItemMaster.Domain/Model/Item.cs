using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NabcoPortal.ItemMaster.Domain.Model
{
    public class Item
    {


        public static Item Create(string name, string modelNo, string finishingCode,int categoryId, string composition, string uom)
        {
            return new Item(name, modelNo, finishingCode,categoryId, composition, uom);
        }

        public static Item ToUpdate(int id, string name, string modelNo, string finishingCode,int categoryId, string composition,
            string uom)
        {
            var item = Item.Create(name, modelNo, finishingCode,categoryId, composition, uom);
            item.Id = id;
            return item;
        }

        public Item(string name, string modelNo, string finishingCode,int categoryId, string composition, string uom)
            : this()
        {

            this.Name = name;
            this.ModelNo = modelNo;
            this.FinishingCode = finishingCode;
            this.Composition = composition;
            this.UOM = uom;
            this.CategoryId = categoryId;
            this.Description = this.Composition + " " + this.ModelNo + " " + this.FinishingCode;

        }

        public Item()
        {
            DateCreated = DateTime.Now;
            IsActive = true;
        }

        public int Id { get; set; }

        public DateTime DateCreated { get; private set; }

        public string ModelNo { get; set; }

        public string FinishingCode { get; set; }

        public string Name { get; set; }

        public string Composition { get; set; }

        public string Description { get; set; }

        public string UOM { get; set; }

        public bool IsActive { get; private set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public void Activate()
        {
            this.IsActive = true;
        }
    }
}
