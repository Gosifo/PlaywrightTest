Feature: Login

@login
Scenario Outline: Invalid login details test
	Given I navigate to evri site
	When I select the login button
	And I enter invalid username and password credential for '<UserName>'
	Then I should see the 'Sign In' page
	And I should see the login form
Examples:
    | UserName             |
    | Sam.Phil12@yahoo.com |
    | 12Sam.Phil@yahoo.com |