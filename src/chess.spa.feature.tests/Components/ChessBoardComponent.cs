using System.Linq;
using OpenQA.Selenium;

namespace chess.spa.feature.tests.Components
{
    public class ChessBoardComponent : WebDriverComponent
    {

        private static readonly By RootElementSelector = By.CssSelector(".chessboard");

        public ChessBoardComponent(IWebDriver webDriver) : base(webDriver, webDriver.FindElement(RootElementSelector))
        {
            
        }

        public SquareComponent[] AllSquares => WebDriver
            .FindElements(By.ClassName(CssClassNames.BoardCell))
            .Select(e => new SquareComponent(WebDriver, e))
            .ToArray();

        public SquareComponent GetSquare(string location)
        {
            // get the TD represented by the chess location
            var x = location.ToLower()[0] - 96;
            var y = int.Parse(location[1].ToString());

            var rowIndex = 8 - y + 1;
            var colIndex = x - 1;

            var row = WebDriver
                .FindElement(RootElementSelector)
                .FindElements(By.TagName("TR"))[rowIndex];

            var col = row.FindElements(By.ClassName("board-cell"))[colIndex];

            return new SquareComponent(WebDriver, col);
        }

        public string ToPlay => RootElement.FindElement(By.TagName("TABLE"))
            .GetAttribute("class").Split(' ')
            .Single(c => c.EndsWith("-to-play"))
            .Replace("-to-play", "");

        public SquareComponent Click(string location)
        {
            var sqr = GetSquare(location);

            sqr.Click();

            return sqr;
        }
    }
}