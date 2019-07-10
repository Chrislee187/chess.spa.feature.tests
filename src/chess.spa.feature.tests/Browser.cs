using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace chess.spa.feature.tests
{
    public class Browser : IDisposable
    {
        public static bool QuitBrowserOnExit = true;
        private static IWebDriver _instance;

        public static IWebDriver Instance => _instance ??= new ChromeDriver();

        ~Browser()
        {
            ReleaseUnmanagedResources();
        }

        private void ReleaseUnmanagedResources()
        {
            _instance.Close();
            _instance.Quit();
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }
    }
}