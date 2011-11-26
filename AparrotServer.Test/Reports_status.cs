using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using NJasmine;
using Raven.Tests.Util;

namespace AparrotServer.Test
{
    public class Reports_status : GivenWhenThenFixture
    {
        public override void Specify()
        {
            IISExpressDriver serverUnderTest = this.ArrangeServer();

            it("responds OK to status requests", delegate()
            {
                using(var client = new WebClient())
                {
                    var statusUrl = serverUnderTest.UrlFor("/status");

                    var result = client.DownloadString(statusUrl);

                    expect(() => result == "OK");
                }
            });
        }
    }
}
