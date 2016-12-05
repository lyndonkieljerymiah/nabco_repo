using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NabcoPortal.Models
{
    public class MenuHeader
    {

        
        public MenuHeader(string title) : this()
        {
            this.Title = title;
        }

        public MenuHeader()
        {
            Items = new List<MenuItem>();
        }
        public string Title { get; set; }
        public ICollection<MenuItem> Items { get; set; }

        

        public void AddItem(string title, string controller,string action)
        {
            var item = new MenuItem
            {
                Title = title,
                Controller = controller,
                Action = action
            };

            Items.Add(item);
        }
    }

    public class MenuItem
    {
        public string Title { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}