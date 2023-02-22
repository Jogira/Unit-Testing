using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using NUnit.Framework;
using Moq;
using System.Net;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class InstallHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;
        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadCompletes_ReturnsTrue()
        {
            //Since it's not expecting a value to be returned, we don't need setup.
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.True);


        }
        [Test]
        public void DownloadInstaller_DownloadFails_ReturnsFalse()
        {

            _fileDownloader.Setup(fd => 
            fd.DownloadFile(It.IsAny<String>(), It.IsAny<String>()))
                .Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }
    }
}