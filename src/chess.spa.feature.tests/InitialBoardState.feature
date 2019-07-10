Feature: Initial board state
	Ensure the board is in a correct state visually


Scenario: New board is correct
	Given I am on the chess page
	And a new game has been started
	Then there should be 64 board cells
	And 32 should be "white"
	And 32 should be "black"
	And has correct checkered pattern
	And there are 16 "white" pieces
	And there are 16 "black" pieces
	#And I have entered 70 into the calculator
	#When I press add
	#Then the result should be 120 on the screen
