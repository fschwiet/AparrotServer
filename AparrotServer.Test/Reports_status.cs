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
            var serverUnderTest = beforeAll(() => new IISExpressDriver());

            var sitePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Settings.Default.AparratServerFilepath);

            sitePath = Path.GetFullPath(sitePath);

            arrange(() => serverUnderTest.Start(sitePath, 8084));

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
