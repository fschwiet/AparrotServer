using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using NJasmine;
using Raven.Tests.Util;

namespace AparrotServer.Test
{
    public class Can_synthesize_speech_with_espeak : GivenWhenThenFixture
    {
        public override void Specify()
        {
            IISExpressDriver serverUnderTest = this.ArrangeServer();

            var client = arrange(() => new WebClient());

            it("synethesizes 'Hello, World' by default", delegate
            {
                client.DownloadData(serverUnderTest.UrlFor("/Speak"));

                expect(() => client.ResponseHeaders["ESpeak-Parameters"] == "\"Hello, world\"");
                expect(() => client.ResponseHeaders["content-type"] == "audio/wav");
                expect(() => int.Parse(client.ResponseHeaders["content-length"]) > 0);
            });
        }
    }
}
