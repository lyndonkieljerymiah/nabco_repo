using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NabcoPortal.ItemMaster.Domain.Model
{
    public class Item
    {


        public static Item Create(string code, string name, string description)
        {
            return new Item(code,name,description);
        }

        public Item(string code, string name, string description) : this()
        {
            this.Code = code;
            this.Name = name;
            this.Description = description;

        }

        public Item()
        {
            DateCreated = DateTime.Now;
            IsActive = false;
        }

        public int Id { get; set; }

        public DateTime DateCreated { get; private set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }






    }
}
