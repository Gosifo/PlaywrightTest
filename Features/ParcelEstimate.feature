Feature: Test parcel delivery

@tag1
Scenario: Check parcel delivery estimate
	Given I navigate to evri site
	When I enter the from post code 'SW1A 1AA' to post code 'SW1A 2AA' and weight '1kg - 2kg' 
	And select send a parcel button
	Then I should see the 'Evri | Cheap Parcel Delivery & Courier Service UK' page