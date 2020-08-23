Feature: Register
	In order to prevent submission of bad data
	As a user
	I want the website to warn me if I fail to corretley fill in the registration form

@BadData
Scenario: All fields empty
Given the register page is displayed
	And the data from test case 1 is entered
	When the Register button is clicked
	Then the correct fields should display an error