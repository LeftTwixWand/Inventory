Feature: Create Product

As a customer I want to create a new product.
The domain specific requirements say, that the name and category are mandatory.

Scenario: I can create a product
	Given product name is 'Lamp'
	And product category is 'Desktop'
	When I create a new product
	Then product is created

Scenario: I can not create a product without name
	Given product name is ''
	And product category is 'Desktop'
	When I create a new product
	Then the BusinessRuleValidationException was thrown
	And the error message is 'Product name must not be empty.'

Scenario: I can not create a product without category
	Given product name is 'Lamp'
	And product category is ''
	When I create a new product
	Then the BusinessRuleValidationException was thrown
	And the error message is 'Product category must not be empty.'