using System.Threading;
using chess.spa.feature.tests.Components;
using OpenQA.Selenium;

namespace chess.spa.feature.tests.Pages
{
    public class ChessGamePage : WebDriverPage
    {
        private readonly string _chessGamePage;


        public ChessGamePage(IWebDriver webDriver, string chessGamePage = "http://localhost:52192/blazorchess") : base(webDriver)
        {
            _chessGamePage = chessGamePage;
        }

        public void Load()
        {
            if (WebDriver.Url == _chessGamePage)
            {
                WebDriver.Navigate().Refresh();
            }
            else
            {
                WebDriver.Navigate().GoToUrl(_chessGamePage);
            }
            Thread.Sleep(1000); // NOTE: How to wait for the api calls made in WebAssembly to finish?
        }

        public ChessBoardComponent ChessBoard => new ChessBoardComponent(WebDriver);

        public ChessBoardComponent CustomBoard(string boardString)
        {
            // TODO: Add to chess.blazor endpoint
            // https://...blazorchess/{boardString} to make work
            throw new System.NotImplementedException("TODO: Custom board support not yet implemented");
        }
    }
}