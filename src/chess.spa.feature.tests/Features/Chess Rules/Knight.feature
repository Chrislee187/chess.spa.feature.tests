Feature: Knight Rules
	Ensure the rules of chess for knight are correctly enforced and implemented


Scenario: Knights jump in eight directions
	Given a custom board is used with "white" to move
	|....k...|
	|........|
	|........|
	|........|
	|...N....|
	|........|
	|........|
	|....K...|
	When I click the square at "d4"
	Then "e6, f5, f3, e2, c2, b3, b5, c6" have destination highlighting

