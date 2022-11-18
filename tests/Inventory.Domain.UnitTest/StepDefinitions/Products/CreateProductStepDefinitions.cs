using System;
using TechTalk.SpecFlow;

namespace Inventory.Domain.UnitTest.StepDefinitions.Products
{
    [Binding]
    public class CreateProductStepDefinitions
    {
        [Given(@"product name is ""([^""]*)""")]
        public void GivenProductNameIs(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"I create the product")]
        public void WhenICreateTheProduct()
        {
            throw new PendingStepException();
        }

        [Then(@"the product is created")]
        public void ThenTheProductIsCreated()
        {
            throw new PendingStepException();
        }
    }
}
