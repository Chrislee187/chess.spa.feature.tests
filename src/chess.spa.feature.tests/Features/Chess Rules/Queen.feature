Feature: Queen Rules
	Ensure the rules of chess for queens are correctly enforced and implemented


Scenario: Queens move diagonally
	Given a custom board is used with "white" to move
	|....k...|
	|........|
	|........|
	|........|
	|...Q....|
	|........|
	|........|
	|....K...|
	When I click the square at "d4"
	Then "c5,b6,a7" have destination highlighting
	And "e5,f6,g7,h8" have destination highlighting
	And "e3,f2,g1" have destination highlighting
	And "c3,b2,a1" have destination highlighting

Scenario: Queens move horizontally and vertically
	Given a custom board is used with "white" to move
	|....k...|
	|........|
	|........|
	|........|
	|...Q....|
	|........|
	|........|
	|....K...|
	When I click the square at "d4"
	Then "d5,d6,d7,d8" have destination highlighting
	And "d3,d2,d1" have destination highlighting
	And "a4,b4,c4" have destination highlighting
	And "e4,f4,g4,h4" have destination highlighting
