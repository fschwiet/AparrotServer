using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NJasmine;
using OpenQA.Selenium.Firefox;
using Raven.Tests.Util;
using SizSelCsZzz;

namespace AparrotServer.Test
{
    public class There_is_a_talking_bird : GivenWhenThenFixture
    {
        public override void Specify()
        {
            IISExpressDriver serverUnderTest = this.ArrangeServer();

            var browser = arrange(() => new FirefoxDriver());
            
            it("shows a parrot", delegate()
            {
                browser.Navigate().GoToUrl(serverUnderTest.UrlFor("/parrot"));

                browser.FindElement(BySizzle.CssSelector("img[src*=parrot_text_mode]"));
            });

            it("speaks on input", delegate()
            {
                var phrase = "Polly wants a cracker";

                browser.Navigate().GoToUrl(serverUnderTest.UrlFor("/parrot"));

                browser.FindElement(BySizzle.CssSelector("input#t"))
                    .ClearThenSendKeys(phrase);

                browser.FindElement(BySizzle.CssSelector("input.parrot-submit"))
                    .ClearThenSendKeys(phrase);

                browser.WaitForElement(BySizzle.CssSelector("audio"));
                browser.WaitForElement(BySizzle.CssSelector("audio[src*=Polly]"));
                browser.WaitForElement(BySizzle.CssSelector("audio[src*='" + phrase.Replace(" ", "%20") + "']"));
            });
        }
    }
}
