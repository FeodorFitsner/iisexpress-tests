using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IIsExpressTests
{
    public class MyTests
    {
        [Fact]
        public void Run_IIS_Express()
        {
            string applicationFolder = Path.Combine(Environment.GetEnvironmentVariable("appveyor_build_folder"), "website");
            string portNumber = "8088";

            // Start IIS Express
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            var iisProcess = new Process();
            iisProcess.StartInfo.FileName = programFiles + "\\IIS Express\\iisexpress.exe";
            iisProcess.StartInfo.Arguments = string.Format("/path:\"{0}\" /port:{1}", applicationFolder, portNumber);
            iisProcess.Start();

            // give it some time to start
            Task.Delay(TimeSpan.FromSeconds(2)).Wait();

            // verify results
            //using(var wc = new WebClient())
            //{
            //    var result = wc.DownloadString("http://localhost:8088");
            //    Assert.Equal("<h1>Hello, world!</h1>", result);
            //}
        }
    }
}
