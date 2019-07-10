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
            WebDriver.Navigate().GoToUrl(_chessGamePage);

            Thread.Sleep(1000); // NOTE: How to wait for the api calls made in WebAssembly to finish?
        }

        public ChessBoardComponent ChessBoard => new ChessBoardComponent(WebDriver);
    }
}