Feature: Create Warehouse

As a customer I want to manage products through the warehouse entity.
One warehouse resposnible for one specific product.

Scenario: I can create a warehouse
	Given product id is '8c2cecbc-143f-4fd2-ac87-737190b8369e'
	When I create a warehouse
	Then warehouse for given product id is created
	And new WarehouseCreatedEvent is created