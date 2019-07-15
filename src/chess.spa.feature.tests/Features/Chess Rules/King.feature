Feature: King Rules
	Ensure the rules of chess for kings are correctly enforced and implemented


Scenario: Kings can move one square diagonally
	Given a custom board is used with "white" to move
	|....k...|
	|........|
	|........|
	|........|
	|...K....|
	|........|
	|........|
	|........|
	When I click the square at "d4"
	Then "c5,e5,e3,c3" have destination highlighting
	And "b6,f6,f2,b2" have no highlighting 

Scenario: Kings move one square horizontally and vertically
	Given a custom board is used with "white" to move
	|....k...|
	|........|
	|........|
	|........|
	|...K....|
	|........|
	|........|
	|........|
	When I click the square at "d4"
	Then "d5,d3,c4,e4" have destination highlighting
	And "d6,d2,b4,f4" have no highlighting

Scenario: Kings cannot move in to check
	Given a custom board is used with "white" to move
	|....k...|
	|....r...|
	|........|
	|........|
	|...K....|
	|........|
	|........|
	|........|
	When I click the square at "d4"
	Then "c5,c3" have destination highlighting
	And "e3,e4,e5" have no highlighting 

Scenario: Kings cannot be left in check by other pieces move
	Given a custom board is used with "white" to move
	|....k...|
	|....r...|
	|........|
	|........|
	|....R...|
	|........|
	|........|
	|....K...|
	When I click the square at "e4"
	Then "e2,e3,e5,e6,e7" have destination highlighting
	And "a4,b4,c4,d4,f4,g4,h4" have no highlighting 

Scenario: Kings can castle king side
	Given a custom board is used with "white" to move
	|....k...|
	|....r...|
	|........|
	|........|
	|....R...|
	|........|
	|........|
	|....K..R|
	When I click the square at "e1"
	Then "g1" has destination highlighting
	When I click the square at "g1"
	Then "f1" contains "R"
	And "g1" contains "K"

Scenario: Kings can castle queen side
	Given a custom board is used with "white" to move
	|....k...|
	|....r...|
	|........|
	|........|
	|....R...|
	|........|
	|........|
	|R...K...|
	When I click the square at "e1"
	Then "c1" has destination highlighting
	When I click the square at "c1"
	Then "d1" contains "R"
	And "c1" contains "K"

Scenario: Kings cannot move next to each other white to move
	Given a custom board is used with "white" to move
	|..K.k...|
	|........|
	|........|
	|........|
	|........|
	|........|
	|........|
	|........|
	When I click the square at "c8"
	Then "d8" has no highlighting

	
Scenario: Kings cannot move next to each other black to move
	Given a custom board is used with "black" to move
	|..K.k...|
	|........|
	|........|
	|........|
	|........|
	|........|
	|........|
	|........|
	When I click the square at "e8"
	Then "d8" has no highlighting
