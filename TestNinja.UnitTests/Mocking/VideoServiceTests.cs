using Moq;
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
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {

            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            //var service = new VideoService(new FakeFileReader());
            //Replace the REAL file reader with a FAKE one.
            //service.FileReader = new FakeFileReader();
            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("Error").IgnoreCase);
        }
    }
}
