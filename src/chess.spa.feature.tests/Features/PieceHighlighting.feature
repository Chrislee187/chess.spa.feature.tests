Feature: PieceHighlighting
	To ensure consistency the basic UX functionality around selecting a move is tested here


Scenario: Selecting and deselecting leaves no highlighting
	Given I am on the chess page
	And a new game has been started
	When I click the square at "a2"
	Then "a2" has source highlighting
	And "a3,a4" have destination highlighting
	When I click the square at "a2"
	Then no squares have highlighting

Scenario: Selecting a different piece of same colour moves highlighting
	Given I am on the chess page
	And a new game has been started
	When I click the square at "a2"
	Then "a2" has source highlighting
	And "a3,a4" have destination highlighting
	When I click the square at "b2"
	Then "b2" has source highlighting
	And "a2, a3, a4" has no highlighting
	And "b3,b4" have destination highlighting

Scenario: Selecting an empty square is ignored as a source location
	Given I am on the chess page
	And a new game has been started
	When I click the square at "a3"
	Then no squares have highlighting

Scenario: Selecting the wrong colour piece is ignored
	Given I am on the chess page
	And a new game has been started
	When I click the square at "a7"
	Then no squares have highlighting

Scenario: Selecting invalid square are ignored as a destination location
	Given I am on the chess page
	And a new game has been started
	When I click the square at "a2"
	Then "a2" has source highlighting
	And "a3,a4" have destination highlighting
	When I click the square at "b4"
	Then "a2" has source highlighting
	And "a3,a4" have destination highlighting
	And "b4" has no highlighting
	When I click the square at "a7"
	Then "a2" has source highlighting
	And "a3,a4" have destination highlighting
	And "a7" has no highlighting

Scenario: Selecting a valid moves removes highlighting
	Given I am on the chess page
	And a new game has been started
	When I click the square at "a2"
	And I click the square at "a3"
	Then no squares have highlighting
