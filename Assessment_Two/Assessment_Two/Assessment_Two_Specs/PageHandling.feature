Feature: RequestSending
	In order to fetch a website
	As a user
	I want to be send a http request to an URL

Scenario: Navigate to google website
	Given I have entered http://www.google.co.uk/
	When I press go
	Then a 200-header-message should be returned

Scenario: Navigate to invalid google website
	Given I have entered http://www.google.co.u/
	When I press go
	Then a 404-header-message should be returned