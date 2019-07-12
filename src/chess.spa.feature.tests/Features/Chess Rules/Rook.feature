Feature: Rook Rules
	Ensure the rules of chess for rooks are correctly enforced and implemented


Scenario: Rooks move vertically and horizontally
	Given a custom board is used with "white" to move
	|....k...|
	|........|
	|........|
	|........|
	|........|
	|........|
	|...R....|
	|....K...|
	When I click the square at "d2"
	Then "d1,d3,d4,d5,d6,d7,d8" have destination highlighting
	And "a2,b2,c2,e2,f2,g2,h2" have destination highlighting
