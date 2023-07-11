using System;
using BuildingBlocks.Application.CQRS.Commands;

namespace Inventory.Application.DomainOperations.Warehouse.ShipProduct;

internal sealed record ShipProductCommand(Guid ProductId) : CommandBase;