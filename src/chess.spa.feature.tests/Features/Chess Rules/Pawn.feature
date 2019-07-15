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
	And "b3" has no highlighting
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
	Then "a4" has destination highlighting
	And "a5" has no highlighting

Scenario: Pawns take diagonally
	Given a custom board is used with "white" to move
	|....k...|
	|........|
	|........|
	|........|
	|..ppp...|
	|...P....|
	|........|
	|....K...|
	When I click the square at "d3"
	Then "c4,e4" has destination highlighting
	And "d4" has no highlighting

Scenario: Pawns can take with en-passant
	Given a custom board is used with "black" to move
	|....k...|
	|........|
	|........|
	|........|
	|...Ep...|
	|........|
	|........|
	|....K...|
	When I click the square at "e4"
	Then "d3,e3" has destination highlighting
	And "f3" has no highlighting

Scenario: Pawn promotions
	# TODO: Implement UI for promotion moves from the board in the clients

