﻿using eShopOnWinUI.Domain.SeedWork.Events;

namespace eShopOnWinUI.Infrastructure.UnitOfWorks.DomainEventsDispatching;

public interface IDomainEventsProvider
{
    IReadOnlyCollection<IDomainEvent> GetAllDomainEvents();

    void ClearAllDomainEvents();
}