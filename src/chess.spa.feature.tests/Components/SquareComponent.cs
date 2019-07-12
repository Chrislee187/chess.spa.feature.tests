using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;

namespace chess.spa.feature.tests.Components
{
    public class SquareComponent : WebDriverComponent
    {
        public SquareComponent(IWebDriver webDriver, IWebElement rootElement) : base(webDriver, rootElement)
        {
        }

        public bool IsBlackSquare => HasClass(CssClassNames.BlackSquare);
        public bool IsWhiteSquare => HasClass(CssClassNames.WhiteSquare);
        public bool IsNotSourceLocation => !RootElement.GetAttribute("class").Contains(CssClassNames.SourceLocation);
        public bool IsSourceLocation => RootElement.Wait().ForClasses().ToContain(CssClassNames.SourceLocation);
        public bool IsNotDestinationLocation => !RootElement.GetAttribute("class").Contains(CssClassNames.DestinationLocation);
        public bool IsDestinationLocation => RootElement.Wait().ForClasses().ToContain(CssClassNames.DestinationLocation);
        public string Content => RootElement.Text;

        public bool HasNoHighlighting => IsNotSourceLocation && IsNotDestinationLocation;
        public void Click()
        {
            RootElement.Click();
        }
    }
}