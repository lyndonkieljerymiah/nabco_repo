using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NabcoPortal.Models;

namespace NabcoPortal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private VideoMeta _meta;

        public HomeController()
        {
            _meta = new VideoMeta();
            
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("_UnderConstruction");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("_UnderConstruction");
        }

        [AllowAnonymous]
        public ActionResult GetVideo()
        {   

            _meta.FileName = Request.MapPath("~/Content/imgs/samplevid.mp4");

            return  new FileStreamResult(_meta.GetVideo(),"video/mp4");
        }
    }
}