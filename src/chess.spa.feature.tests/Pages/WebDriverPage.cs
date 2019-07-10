using OpenQA.Selenium;

namespace chess.spa.feature.tests.Pages
{
    public class WebDriverPage
    {
        protected readonly IWebDriver WebDriver;

        public WebDriverPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }
}