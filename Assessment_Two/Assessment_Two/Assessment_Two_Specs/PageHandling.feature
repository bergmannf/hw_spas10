Feature: RequestSending
	In order to fetch a website
	As a user
	I want to be send a http request to an URL

Scenario: Navigate to google website
	Given I have entered http://www.google.co.uk/
	When I request the page 
	Then a 200-OK status code should be returned

Scenario: Navigate to invalid google website
	Given I have entered http://www.google.co.u/
	When I request the page
	Then a 404-header-message should be returned
	
Scenario: Navigate to forbidden website
	Given I have entered a forbidden website
	When I request the page
	Then a 403-header-message should be returned
	
Scenario: Send invalid html
	Given I have entered an invalid request
	When I request the page
	Then a 400-header-message should be returned