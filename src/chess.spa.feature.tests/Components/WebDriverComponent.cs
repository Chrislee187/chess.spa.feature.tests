using System.Linq;
using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;

namespace chess.spa.feature.tests.Components
{
    public class WebDriverComponent
    {
        protected IWebDriver WebDriver;
        protected IWebElement RootElement;

        public WebDriverComponent(IWebDriver webDriver, IWebElement rootElement)
        {
            WebDriver = webDriver;
            RootElement = rootElement;
        }

        public bool HasClass(string className)
        {
            return RootElement.GetAttribute("class").Split(' ').Contains(className);
        }
        public bool ShouldGainClass(string className)
        {
            return RootElement.Wait().ForClasses().ToContain(className);
        }
    }
}