using System;

namespace Inventory.Application.Services.Navigation;

public interface IPageService
{
    Type GetPageType(string key);
}