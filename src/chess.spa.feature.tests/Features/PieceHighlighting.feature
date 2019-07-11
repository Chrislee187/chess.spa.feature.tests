Feature: PieceHighlighting
	To assist in playing chess
	I want to see the valid moves for the selected piece


Scenario: Selection/deselection works correctly
	Given I am on the chess page
	And a new game has been started
	When I click the square at "a2"
	Then "a2" has source highlighting
	And "a3,a4" has destination highlighting
	When I click the square at "a2"
	Then no squares are highlighted

Scenario: Selecting a different piece of same colour moves highlighting
	Given I am on the chess page
	And a new game has been started
	When I click the square at "a2"
	Then "a2" has source highlighting
	And "a3,a4" has destination highlighting
	When I click the square at "b2"
	Then "b2" has source highlighting
	And "a2, a3, a4" are not highlighted
	And "b3,b4" has destination highlighting

Scenario: Selecting an empty square is ignored as a source location
	Given I am on the chess page
	And a new game has been started
	When I click the square at "a3"
	Then no squares are highlighted

Scenario: Selecting an invalid squares is ignored as a destination location
	Given I am on the chess page
	And a new game has been started
	When I click the square at "a2"
	Then "a2" has source highlighting
	And "a3,a4" has destination highlighting
	When I click the square at "b4"
	Then "a2" has source highlighting
	And "a3,a4" has destination highlighting
	And "b4" has no highlighting
	When I click the square at "a7"
	Then "a2" has source highlighting
	And "a3,a4" has destination highlighting
	And "a7" has no highlighting

Scenario: Selecting a valid move removes highlighting
	Given I am on the chess page
	And a new game has been started
	When I click the square at "a2"
	And I click the square at "a3"
	Then no squares are highlighted
