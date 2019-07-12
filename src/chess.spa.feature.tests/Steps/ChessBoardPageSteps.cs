using System;
using System.Collections.Generic;
using System.Linq;
using chess.spa.feature.tests.Helpers;
using chess.spa.feature.tests.Pages;
using Shouldly;
using TechTalk.SpecFlow;

namespace chess.spa.feature.tests.Steps
{
    [Binding]
    public class ChessBoardPageSteps
    {
        private ChessGamePage _page;

        [Given(@"I am on the chess page")]
        public void GivenIAmOnTheChessPage()
        {
            _page = PagesContainer.ChessGamePage;
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
            // NOTE: Correct orientation has a black square at A1, we are measuring from top-right to bottom 
            // left so start with a white square at A8
            var isWhiteSquare = true;
            var count = 0;
            foreach (var sqr in _page.ChessBoard.AllSquares)
            {
                (isWhiteSquare ? sqr.IsWhiteSquare : sqr.IsBlackSquare).ShouldBeTrue();

                if (++count % 8 != 0)
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

        [Given(@"a custom board is used with ""(.*)"" to move")]
        public void GivenACustomBoardIsUsedWithToMove(string toMoveColour, Table table)
        {
            var ranks = new List<string> { table.Header.First() };

            ranks.AddRange(table.Rows.Select(r => r.Values.First()));

            var boardString = ranks.Aggregate("", (s, n) => s += n);

            if (!new[] { "k", "K" }.All(k => boardString.Contains(k)))
            {
                throw new ArgumentException("Board must include both kings");
            }

            _page = PagesContainer.ChessGamePage;
            _page.CustomBoard(boardString + $"{toMoveColour.ColourTextToSerialisedTurnIndicator()}0000");
        }

    }
}