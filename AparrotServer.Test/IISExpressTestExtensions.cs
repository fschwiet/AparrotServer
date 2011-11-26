using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NJasmine;
using Raven.Tests.Util;

namespace AparrotServer.Test
{
    public static class IISExpressTestExtensions
    {
        public static IISExpressDriver ArrangeServer(this GivenWhenThenFixture fixture)
        {
            var serverUnderTest = fixture.beforeAll(() => new IISExpressDriver());

            var sitePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Settings.Default.AparratServerFilepath);

            sitePath = Path.GetFullPath(sitePath);

            fixture.arrange(() => serverUnderTest.Start(sitePath, 8084));

            return serverUnderTest;
        }
    }
}
