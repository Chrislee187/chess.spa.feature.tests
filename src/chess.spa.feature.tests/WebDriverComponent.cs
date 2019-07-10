using OpenQA.Selenium;

namespace chess.spa.feature.tests
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

        public bool HasClass(string className) => RootElement.GetAttribute("class").Contains(className);
    }
}