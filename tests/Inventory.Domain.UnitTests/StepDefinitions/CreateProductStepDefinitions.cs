using BuildingBlocks.Domain.BusinessRules;
using FluentAssertions;
using Inventory.Domain.Products;

namespace Inventory.Domain.UnitTests.StepDefinitions;

[Binding]
public sealed class CreateProductStepDefinitions
{
    private string name = string.Empty;
    private string category = string.Empty;
    private Product? product;
    private Exception? exception;

    [Given(@"product name is '([^']*)'")]
    public void GivenProductNameIs(string name)
    {
        this.name = name;
    }

    [Given(@"product category is '([^']*)'")]
    public void GivenProductCategoryIs(string category)
    {
        this.category = category;
    }

    [When(@"I create a new product")]
    public void WhenICreateANewProduct()
    {
        try
        {
            product = Product.Create(name, category);
        }
        catch (Exception ex)
        {
            exception = ex;
        }
    }

    [Then(@"product is created")]
    public void ThenProductIsCreated()
    {
        product.Should().NotBeNull();
    }

    [Then(@"the BusinessRuleValidationException was thrown")]
    public void ThenTheBusinessRuleValidationExceptionBeingThrown()
    {
        exception.Should().BeOfType<BusinessRuleValidationException>();
    }

    [Then(@"the error message is '([^']*)'")]
    public void ThenTheErrorMessageIs(string message)
    {
        exception?.Message.Should().Be(message);
    }
}