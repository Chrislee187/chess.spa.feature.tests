using System;
using System.Collections.Generic;
using System.Linq;
using chess.spa.feature.tests.Components;
using OpenQA.Selenium;
using Shouldly;
using TechTalk.SpecFlow;

namespace chess.spa.feature.tests.Steps
{
    [Binding]
    public class ChessBoardComponentSteps
    {
        private readonly ChessBoardComponent _board = PagesContainer.ChessGamePage.ChessBoard;
        private SquareComponent _lastSquareClicked;

        [When(@"I click the square at ""(.*)""")]
        public void WhenIClickTheSquareAt(string location)
        {
            _lastSquareClicked = _board.GetSquare(location);

            _lastSquareClicked.Click();
        }

        [Then(@"no squares are highlighted")]
        public void ThenNoSquaresAreHighlighted()
        {
            _board.AllSquares.All(s => s.IsNotDestinationLocation && s.IsNotSourceLocation).ShouldBeTrue();
        }

        [Then(@"""(.*)"" are not highlighted")]
        public void ThenAreNotHighlighted(string locations)
        {
            foreach (var loc in SplitLocations(locations))
            {
                var sqr = _board.GetSquare(loc);
                (sqr.IsNotSourceLocation && sqr.IsNotDestinationLocation).ShouldBeTrue();
            }
        }

        [Then(@"""(.*)"" has source highlighting")]
        public void ThenHasSourceHighlighting(string locations)
        {
            foreach (var loc in SplitLocations(locations))
            {
                _board.GetSquare(loc).IsSourceLocation.ShouldBeTrue();
            }
        }

        [Then(@"""(.*)"" has destination highlighting")]
        public void ThenHasDestinationHighlighting(string locations)
        {
            foreach (var loc in SplitLocations(locations))
            {
                _board.GetSquare(loc).IsDestinationLocation.ShouldBeTrue();
            }
        }

        [Then(@"""(.*)"" has no highlighting")]
        public void ThenHasNoHighlighting(string location)
        {
            var sqr = _board.GetSquare(location);

            sqr.IsNotSourceLocation.ShouldBeTrue();
            sqr.IsNotDestinationLocation.ShouldBeTrue();
        }

        private IEnumerable<string> SplitLocations(string locations) => locations.Split(",").Select(l => l.Trim());
    }
}
