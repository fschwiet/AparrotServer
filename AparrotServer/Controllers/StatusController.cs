using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AparrotServer.Controllers
{
    public class StatusController : Controller
    {
        //
        // GET: /Status/

        public ActionResult Index()
        {
            return new ContentResult()
            {
                Content = "OK",
                ContentType = "text/plain",
                ContentEncoding = Encoding.UTF8
            };
        }

    }
}
