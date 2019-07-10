using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.WebDriver.WaitExtensions;
using Shouldly;
using TechTalk.SpecFlow;

namespace chess.spa.feature.tests
{
    [Binding]
    public class InitialBoardStateSteps
    {
        private ChessGamePage _page;

        [Given(@"I am on the chess page")]
        public void GivenIAmOnTheChessPage()
        {
            _page = new ChessGamePage(Browser.Instance);
        }

        [Given(@"a new game has been started")]
        public void GivenANewGameHasBeenStarted()
        {
            _page.Load();
        }

        [Then(@"there should be 64 board cells")]
        public void ThenThereShouldBeBoardCells()
        {
            _page.ChessBoard.AllSquares.Length.ShouldBe(64);
        }

        [Then(@"(.*) should be ""(.*)""")]
        public void ThenShouldBe(int count, string squareColour)
        {

            _page.ChessBoard.AllSquares.Count(s => s.HasClass($"{squareColour.ToLower()}-cell"))
                .ShouldBe(count);
        }

        [Then(@"has correct checkered pattern")]
        public void ThenHasCorrectCheckeredPattern()
        {
            // NOTE: Correct pattern has a black square at A1, we are measuring from top-right to bottom 
            // left so start with a white square
            var isWhiteSquare = true;
            var count = 0;
            foreach (var sqr in _page.ChessBoard.AllSquares)
            {

                var colour = isWhiteSquare ? "white" : "black";

                sqr.HasClass($"{colour}-cell").ShouldBeTrue();

                isWhiteSquare = !isWhiteSquare;
                count++;
                if (count % 8 == 0)
                {
                    isWhiteSquare = !isWhiteSquare;
                }
            }
        }

        [Then(@"there are (.*) ""(.*)"" pieces")]
        public void ThenThereArePieces(int count, string colour)
        {
            var className = $"{colour}-piece-highlight";
            _page.ChessBoard.AllSquares.Count(s => s.HasClass(className))
                .ShouldBe(count);
        }

    }

    public class ChessGamePage : WebDriverPage
    {
        private readonly string _chessGamePage;


        public ChessGamePage(IWebDriver webDriver, string chessGamePage = "http://localhost:52192/blazorchess") : base(webDriver)
        {
            _chessGamePage = chessGamePage;
        }

        public void Load()
        {
            WebDriver.Navigate().GoToUrl(_chessGamePage);

            Thread.Sleep(1000); // NOTE: How to wait for the api calls made in WebAssembly to finish?
        }

        public ChessBoardComponent ChessBoard => new ChessBoardComponent(WebDriver);
    }
    public class CssClassNames
    {
        public const string BoardCell = "board-cell";
        public const string BlackSquare = "black-cell";
        public const string WhiteSquare = "white-cell";
    }
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

            var rowIndex = 8 - y;
            var colIndex = x - 1;

            var row = WebDriver
                .FindElement(RootElementSelector)
                .FindElements(By.TagName("TR"))[rowIndex];

            var col = row.FindElements(By.ClassName("board-cell"))[colIndex];

            return new SquareComponent(WebDriver, col);
        }


    }

    public class SquareComponent : WebDriverComponent
    {
        public SquareComponent(IWebDriver webDriver, IWebElement rootElement) : base(webDriver, rootElement)
        {
        }

        public bool IsBlackSquare => HasClass("black-cell");
        public bool IsWhiteSquare => HasClass("white-cell");
    }
}
