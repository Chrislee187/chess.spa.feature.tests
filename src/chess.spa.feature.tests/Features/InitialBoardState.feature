Feature: Initial board state
	Ensure the board is in a correct state visually, assumes the actual pieces are in the correct place and
	checks class settings required for UX logic (highlighting)


Scenario: New board has correct logical styles
	Given I am on the chess page
	And a new game has been started
	Then there should be 64 board cells
	And 32 should be "white"
	And 32 should be "black"
	And has correct checkered pattern
	And there are 16 "white" pieces
	And there are 16 "black" pieces
	And it is "white" to play

