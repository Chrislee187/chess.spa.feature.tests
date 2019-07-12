using System;
using System.Threading;
using chess.spa.feature.tests.Components;
using OpenQA.Selenium;

namespace chess.spa.feature.tests.Pages
{
    public class ChessGamePage : WebDriverPage
    {
        private readonly string _host;


        public ChessGamePage(IWebDriver webDriver, string host = "http://localhost:52192") : base(webDriver)
        {
            _host = host;
        }

        public void Load()
        {
            if (WebDriver.Url == _host)
            {
                WebDriver.Navigate().Refresh();
            }
            else
            {
                WebDriver.Navigate().GoToUrl($"{_host}/blazorchess");
            }
            Thread.Sleep(1000); // TODO: How to wait for the api calls made in WebAssembly to finish?
        }

        public ChessBoardComponent ChessBoard => new ChessBoardComponent(WebDriver);

        public ChessBoardComponent CustomBoard(string boardString)
        {
            // TODO: Add to chess.blazor endpoint
            // https://...blazorchess/{boardString} to make work
            WebDriver.Navigate().GoToUrl($"{_host}/customboard/{boardString.Replace(".","_")}");

            // TODO: How to detect/capture WASM errors? eg. when internal API calls fail
            // custom attribute technique (captures client error and puts the text in an element attribute we can get via selenium

            Thread.Sleep(1000); // TODO: How to wait for the api calls made in WebAssembly to finish?
                                                // Hidden page-status field, that we set the loaded when render finishes
            return ChessBoard;
        }
    }
}