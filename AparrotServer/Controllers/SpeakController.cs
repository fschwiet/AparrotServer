using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AparrotServer.Controllers
{
    public class SpeakController : Controller
    {
        //
        // GET: /Speak/

        public ActionResult Index(string t = "Hello, world")
        {
            var text = t;

            var parameters = "-a 20 \"" + text + "\"";

            Response.Headers.Add("ESpeak-parameters", parameters);

            using(var driver = new ESpeakDriver())
            {
                var result = driver.Run(parameters);

                return new FileContentResult(result, "audio/wav");
            }
        }
    }
}
