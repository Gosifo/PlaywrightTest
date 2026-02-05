Feature: Test


@tag1
Scenario: Test environment setup
	Given I navigate to the Evri page
	When I click on the login button
	Then I should see the login form