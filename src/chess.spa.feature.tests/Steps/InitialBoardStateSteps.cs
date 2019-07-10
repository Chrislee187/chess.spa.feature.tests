using System;
using System.Linq;
using chess.spa.feature.tests.Pages;
using chess.spa.feature.tests.Components;
using Shouldly;
using TechTalk.SpecFlow;

namespace chess.spa.feature.tests.Steps
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

            _page.ChessBoard.AllSquares
                .Count(s => s.HasClass($"{squareColour.ToLower()}-cell"))
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
                if (isWhiteSquare)
                {
                    sqr.IsWhiteSquare.ShouldBeTrue();
                }
                else
                {
                    sqr.IsBlackSquare.ShouldBeTrue();
                }


//                isWhiteSquare = !isWhiteSquare;
                count++;
                if (count % 8 != 0)
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

        [Then(@"it is ""(.*)"" to play")]
        public void ThenItIsToPlay(string colour)
        {
            _page.ChessBoard.ToPlay.ShouldBe(colour.ToLower());
        }

        private SquareComponent _lastSquareClicked;

        [When(@"I click the square at ""(.*)""")]
        public void WhenIClickTheSquareAt(string location)
        {
            _lastSquareClicked = _page.ChessBoard.GetSquare(location);

            _lastSquareClicked.Click();
        }

        [Then(@"the square is highlighted as a source location")]
        public void ThenTheSquareIsHighlightedAsASourceLocation()
        {
            _lastSquareClicked.IsSourceLocation.ShouldBeTrue();
        }

        [Then(@"""(.*)"" are highlighted as destination locations")]
        public void ThenAreHighlightedAsDestinations(string locations)
        {
            foreach (var s in locations.Split(","))
            {
                _page.ChessBoard.GetSquare(s.Trim()).IsDestinationLocation.ShouldBeTrue();
            }
        }

        [Then(@"all highlighting is removed")]
        public void ThenAllHighlightingIsRemoved()
        {
            _page.ChessBoard.AllSquares.All(s => s.IsNotDestinationLocation && s.IsNotSourceLocation).ShouldBeTrue();
        }

    }
}
