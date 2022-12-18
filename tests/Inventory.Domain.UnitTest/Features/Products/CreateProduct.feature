Feature: CreateProduct

A short summary of the feature

@tag1
Scenario: I can create a new product
	Given product name is "Lamp"
	And product category is "Desktop"
	When I create a new product
	Then the product is created