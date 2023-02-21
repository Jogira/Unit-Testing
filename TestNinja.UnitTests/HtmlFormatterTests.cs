using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TestNinja.Fundamentals;
using System.Threading.Tasks;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();
            var result = formatter.FormatAsBold("abc");
            //Specific assertion 
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);
            //More general assertion
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));

        }
    }
}
