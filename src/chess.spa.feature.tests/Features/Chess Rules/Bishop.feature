Feature: Bishop Rules
	Ensure the rules of chess for bishops are correctly enforced and implemented


Scenario: Bishops move diagonally
	Given a custom board is used with "white" to move
	|....k...|
	|........|
	|........|
	|........|
	|...B....|
	|........|
	|........|
	|....K...|
	When I click the square at "d4"
	Then "c5,b6,a7" have destination highlighting
	And "e5,f6,g7,h8" have destination highlighting
	And "e3,f2,g1" have destination highlighting
	And "c3,b2,a1" have destination highlighting
