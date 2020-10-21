Feature: Advertisement
	In order to gain money from sells
	As a user of gorod.dp.ua website
	I want to manage my advertisements on the gorod.dp.ua

	Background: 
	Given I on the ad page
	When I want to login to my account with my mcsymiv 123456789

@createAd
Scenario: Successful create car sell ad
	Given I want to add my ad
	When I fill in all necessary fields
	When I click on add ad
	Then I see thank you message on the page

@error_on_submit
Scenario: Error on skipping necessary fields
	Given Ad form is open
	When User leaves necessary field empty
	Then User see red error message
