Feature: US02 - Supplier Search
	In order to see a list of suppliers 
	As a retailer user 
	I want to click search

Background:
	Given the following suppliers
			| Supplier Name    | Supplier Id | Supplier Address |
			| Sausage Supplier | 1           | 1 Sausage Street |
			| Veg Supplier     | 2           | 2 Veg Street     |
			| Milk Supplier    | 3           | 3 Milk Street    |

Scenario: Return list of Suppliers
	When I press search
	Then the result should be a list of suppliers on the screen contain only: 'Sausage Supplier', 'Veg Supplier' ,'Milk Supplier'

Scenario: Search result should be ordered by supplier name
	When I search for suppliers
	Then the list of found suppliers should be:
		| Supplier Name    |
		| Milk Supplier    |
		| Sausage Supplier |
		| Veg Supplier     |
