Feature: Pawn Rules
	Ensure the rules of chess for pawns are correctly enforced and implemented


Scenario: Pawns can move two steps at start
	Given a custom board is used with "white" to move
	|....k...|
	|........|
	|........|
	|........|
	|........|
	|........|
	|P.......|
	|....K...|
	When I click the square at "a2"
	Then "a3,a4" have destination highlighting
	When I click the square at "a4"
	Then locations "a2" are empty
	And "a4" contains "P"

Scenario: Pawns can move one step at start
	Given a custom board is used with "white" to move
	|....k...|
	|........|
	|........|
	|........|
	|........|
	|........|
	|P.......|
	|....K...|
	When I click the square at "a2"
	Then "a3,a4" have destination highlighting
	When I click the square at "a3"
	Then locations "a2" are empty
	And "a3" contains "P"

Scenario: Pawns can only move one step after start
	Given a custom board is used with "white" to move
	|....k...|
	|........|
	|........|
	|........|
	|........|
	|P.......|
	|........|
	|....K...|
	When I click the square at "a3"
	Then "a4" have destination highlighting
	And "a5" has no highlighting



