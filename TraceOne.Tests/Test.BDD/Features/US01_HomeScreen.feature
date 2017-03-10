Feature: US01 - Home Screen
	In order to see a list of suppliers
	As a retailer user 
	I want see the home screen

Scenario: No Suppliers should be listed on the home screen
	When Retailer user launches the home screen
	Then the home screen should show no suppliers
