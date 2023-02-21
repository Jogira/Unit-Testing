using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    internal class VideoServiceTests
    {
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            var service = new VideoService(new FakeFileReader());
            //Replace the REAL file reader with a FAKE one.
            //service.FileReader = new FakeFileReader();
            var result = service.ReadVideoTitle();
            Assert.That(result, Does.Contain("Error").IgnoreCase);
        }
    }
}
