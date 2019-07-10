using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace chess.spa.feature.tests
{
    public class Browser
    {
        public static bool QuitBrowserOnExit = true;
        private static IWebDriver _instance;

        public static IWebDriver Instance => _instance ??= new ChromeDriver();

        ~Browser()
        {
            if (QuitBrowserOnExit)
            {
                _instance?.Quit();
            }
        }
    }
}