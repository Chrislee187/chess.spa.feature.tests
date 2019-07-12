using System;
using System.Diagnostics;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace chess.spa.feature.tests
{
    public class Browser
    {
        private static IWebDriver _instance;

        public static IWebDriver Instance
        {
            get
            {
                if (_instance == null)
                {
                    var opts = new ChromeOptions();
                    // NOTE: Doesn't seem to be any faster, leave off for dev purposes
                    // TODO: Sort out run headless when run from dotnet test 
                    //                    opts.AddArguments("headless"); 

                    _instance = new ChromeDriver(opts);
                }

                return _instance;
            }

        }

        public static void Quit()
        {
            // TODO: The chromedriver.exe process that gets spawns seems to be immortal!
            // none of the following kill it.
            _instance.Close();
            _instance.Quit();
            _instance.Dispose();

            Process.GetProcessesByName("chromedriver.exe").ToList().ForEach(i => i.Kill(true));

            // powershell command that does work: Get-Process | Where-Object {$_.Path -like \"*chromedriver*\"} | Stop-Process
            // see kill-chromedriver.ps1 is project root
            throw new Exception();
        }
    }
}