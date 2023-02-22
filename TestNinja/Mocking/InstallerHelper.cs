using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private IFileDownloader _fileDownLoader;
        public InstallerHelper(IFileDownloader fileDownLoader)
        {
            _fileDownLoader = fileDownLoader;
        }

        private string _setupDestinationFile;


        public bool DownloadInstaller(string customerName, string installerName)
        {
            // var client = new WebClient();
            try
            {
                //client.DownloadFile(
                //    string.Format("http://example.com/{0}/{1}",
                //        customerName,
                //        installerName),
                //    _setupDestinationFile);

                _fileDownLoader.DownloadFile(string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}