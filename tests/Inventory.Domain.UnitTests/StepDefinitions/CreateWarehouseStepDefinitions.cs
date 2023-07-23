using FluentAssertions;
using Inventory.Domain.Products;
using Inventory.Domain.Warehouses;
using Inventory.Domain.Warehouses.Events;

namespace Inventory.Domain.UnitTests.StepDefinitions;

[Binding]
public sealed class CreateWarehouseStepDefinitions
{
    private Guid productId;
    private Warehouse? warehouse;

    [Given(@"product id is '([^']*)'")]
    public void GivenProductIdIs(string guidProductId)
    {
        productId = Guid.Parse(guidProductId);
    }

    [When(@"I create a warehouse")]
    public void WhenICreateAWarehouse()
    {
        warehouse = Warehouse.Create(new ProductId(productId));
    }

    [Then(@"warehouse for given product id is created")]
    public void ThenWarehouseForGivenProductIdIsCreated()
    {
        warehouse.Should().NotBeNull();
        warehouse?.ProductId.Value.Should().Be(productId);
    }

    [Then(@"new WarehouseCreatedEvent is created")]
    public void ThenNewWarehouseCreatedEventIsCreated()
    {
        warehouse?.DomainEvents.Should().ContainSingle(e => e is WarehouseCreatedEvent);
    }
}