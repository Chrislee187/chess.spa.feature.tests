Feature: Pawn Rules
	Ensure the rules of chess for pawns are correct enforced


Scenario: Pawns can move two steps at start
	Given I am on the chess page
	And a new game has been started
	When I click the square at "a2"
	Then "a3,a4" have destination highlighting
	When I click the square at "a4"
	Then locations "a2" are empty
	And "a4" contains "P"

Scenario: Pawns can move one step at start
	Given I am on the chess page
	And a new game has been started
	When I click the square at "a2"
	Then "a3,a4" have destination highlighting
	When I click the square at "a3"
	Then locations "a2" are empty
	And "a3" contains "P"

Scenario: Pawns can only move one step after start
	Given I am on the chess page
	And a new game has been started
	When I click the square at "a2"
	Then "a3,a4" have destination highlighting
	When I click the square at "a3"
	Then locations "a2" are empty
	And "a3" contains "P"
	When I click the square at "h7"
	And I click the square at "h6"
	When I click the square at "a3"
	Then "a4" have destination highlighting

Scenario: Pawns can only move one step after start - type 2
	Given I am on the chess page
	And a custom board is used
	|.......|
	|.......|
	|.......|
	|.......|
	|.......|
	|...P...|
	|.......|
	|.......|
	When I click the square at "d4"
	Then "d5" have destination highlighting
	And "d6" has no highlighting



