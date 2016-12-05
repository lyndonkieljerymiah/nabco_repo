using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NabcoPortal.Models;

namespace NabcoPortal.Controllers
{
    public class PanelController : Controller
    {

        private ICollection<MenuHeader> _headers;

        public PanelController()
        {
            _headers = new List<MenuHeader>();
        }

        public ViewResult UnderConstruction()
        {
            return View("_UnderConstruction");
        }

        // GET: Panel
        public ViewResult GetMenu()
        {
            var user = new MenuHeader("User");
            user.AddItem("Profile","Account","Profile");
            _headers.Add(user);
            var order = new MenuHeader("Order");
            order.AddItem("Add Order","Order","Create");
            _headers.Add(order);


            

            return View("Menu",_headers);
        }
    }
}