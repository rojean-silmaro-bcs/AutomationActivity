Feature: FlightSearch
	
@FlightSearch
Scenario: User successfully search flight
	Given I go to the search page
	And I fill up the search details
	When I press search flights
	Then the result page should display
