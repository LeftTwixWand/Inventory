using FluentAssertions;
using Inventory.Domain.Products;

namespace Inventory.Domain.UnitTest.StepDefinitions
{
    [Binding]
    public sealed class CreateProductStepDefinitions
    {
        private string name = string.Empty;
        private string category = string.Empty;
        private Product product = default!;

        [Given(@"product name is ""([^""]*)""")]
        public void GivenProductNameIs(string name)
        {
            this.name = name;
        }

        [Given(@"product category is ""([^""]*)""")]
        public void GivenProductCategoryIs(string category)
        {
            this.category = category;
        }

        [When(@"I create a new product")]
        public void WhenICreateANewProduct()
        {
            product = Product.Create(name, category);
        }

        [Then(@"the product is created")]
        public void ThenTheProductIsCreated()
        {
            product.Should().NotBeNull();
        }
    }
}