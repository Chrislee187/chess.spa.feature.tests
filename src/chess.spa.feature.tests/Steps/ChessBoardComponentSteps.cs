using System.Collections.Generic;
using System.Linq;
using chess.spa.feature.tests.Components;
using Shouldly;
using TechTalk.SpecFlow;

namespace chess.spa.feature.tests.Steps
{
    [Binding]
    public class ChessBoardComponentSteps
    {
        private readonly ChessBoardComponent _board = PagesContainer.ChessGamePage.ChessBoard;

        [When(@"I click the square at ""(.*)""")]
        public void WhenIClickTheSquareAt(string location)
        {
            _board.Click(location);
        }

        [Then(@"no squares have highlighting")]
        public void ThenNoSquaresHaveHighlighting()
        {
            _board.AllSquares
                .All(s => s.HasNoHighlighting)
                .ShouldBeTrue();
        }

        [Then(@"""(.*)"" (?:has|have) no highlighting")]
        public void ThenHasNoHighlighting(string locations) =>
            SelectedLocations(locations)
                .All(sqr => sqr.HasNoHighlighting)
                .ShouldBeTrue();

        [Then(@"""(.*)"" (?:has|have) source highlighting")]
        public void ThenHasSourceHighlighting(string locations) =>
            SelectedLocations(locations)
                .All(sqr => sqr.IsSourceLocation)
                .ShouldBeTrue();

        [Then(@"""(.*)"" (?:has|have) destination highlighting")]
        public void ThenHaveDestinationHighlighting(string locations) =>
            SelectedLocations(locations)
                .All(sqr => sqr.IsDestinationLocation)
                .ShouldBeTrue();

        [Then(@"locations ""(.*)"" (?:is|are) empty")]
        public void ThenLocationsAreEmpty(string locations) =>
            SelectedLocations(locations)
                .All(sqr => new[] {".", " ", "_"}.Contains(sqr.Content))
                .ShouldBeTrue();

        [Then(@"""(.*)"" contains ""(.*)""")]
        public void ThenContains(string location, string content) =>
            _board.GetSquare(location).Content.Equals(content);

        private IEnumerable<string> SplitLocations(string locations) => 
            locations.Split(",")
                .Select(l => l.Trim());

        private IEnumerable<SquareComponent> SelectedLocations(string locations) =>
            SplitLocations(locations).Select(loc => _board.GetSquare(loc));
    }
}
